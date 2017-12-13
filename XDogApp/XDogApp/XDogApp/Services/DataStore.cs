using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Plugin.Connectivity;
using System.Diagnostics;
using XDogApp.Models;
using System.IO;
using ClientServerData.DataObjects;

namespace XDogApp.Services
{
    public class DataStore<T> : IDataStore<BaseId> where T : BaseId
    {
        IMobileServiceSyncTable<T> itemsTable;

        public static MobileServiceClient MobileService = null;

        public async Task InitializeAsync()
        {

            MobileService = new MobileServiceClient(PCL_AppConstants.sCurrentServiceURL);
            string path = "app.db";

            var store = new MobileServiceSQLiteStoreWithLogging(path, PCL_AppConstants.bLogSqlLite);
            store.DefineTable<TodoItem>();
            await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());
            itemsTable = MobileService.GetSyncTable<T>();
        }

        public async Task<IEnumerable<BaseId>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh)
                await PullLatestAsync();

            return await itemsTable.ToEnumerableAsync();
        }

        public async Task<BaseId> GetItemAsync(string id)
        {
            await PullLatestAsync();
            var items = await itemsTable.Where(s => ((BaseId)s).Id == id).ToListAsync();

            if (items == null || items.Count == 0)
                return null;

            return items[0];
        }

        public async Task<bool> AddItemAsync(BaseId item)
        {
            await PullLatestAsync();
            await itemsTable.InsertAsync((T)item);
            await SyncAsync();

            return true;
        }

        public async Task<bool> UpdateItemAsync(BaseId item)
        {
            await itemsTable.UpdateAsync((T)item);
            await SyncAsync();

            return true;
        }

        public async Task<bool> DeleteItemAsync(BaseId item)
        {
            await PullLatestAsync();
            await itemsTable.DeleteAsync((T)item);
            await SyncAsync();

            return true;
        }

        public async Task<bool> PullLatestAsync()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                Debug.WriteLine("Unable to pull items, we are offline");
                return false;
            }
            try
            {
                await itemsTable.PullAsync($"all{typeof(T).Name}", itemsTable.CreateQuery());
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to pull items, that is alright as we have offline capabilities: " + ex);
                return false;
            }
            return true;
        }

        public async Task<bool> SyncAsync()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                Debug.WriteLine("Unable to sync items, we are offline");
                return false;
            }

            
            try
            {
                await MobileService.SyncContext.PushAsync();
                if (!(await PullLatestAsync().ConfigureAwait(false)))
                    return false;
            }
            catch (MobileServicePushFailedException exc)
            {
                if (exc.PushResult == null)
                {
                    Debug.WriteLine("Unable to sync, that is alright as we have offline capabilities: " + exc);
                    return false;
                }

                foreach (var error in exc.PushResult.Errors)
                {
                    // SV added code to sync later, since asp.net service is down
                    if (error.Status == System.Net.HttpStatusCode.Forbidden)
                    {
                        Debug.WriteLine("Unable to sync, that is alright as we have offline capabilities: " + error.Status.ToString());
                        return false;
                    }

                    if (error.OperationKind == MobileServiceTableOperationKind.Update && error.Result != null)
                    {
                        //Update failed, reverting to server's copy.
                        await error.CancelAndUpdateItemAsync(error.Result);
                    }
                    else 
                    {
                        // Discard local change
                        await error.CancelAndDiscardItemAsync();
                    }

                    Debug.WriteLine(@"Error executing sync operation. Item: {0} ({1}). Operation discarded.", error.TableName, error.Item["id"]);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync items, that is alright as we have offline capabilities: " + ex);
                return false;
            }

            return true;
        }
    }

}
