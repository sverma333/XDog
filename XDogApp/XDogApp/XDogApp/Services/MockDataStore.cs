using ClientServerData.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDogApp.Models;

namespace XDogApp.Services
{
    public class MockDataStore<T> : IDataStore<BaseId> where T : BaseId
    {
        bool isInitialized;
        List<BaseId> items;

        public async Task<bool> AddItemAsync(BaseId item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(BaseId item)
        {
            await InitializeAsync();

            var _item = items.Where((BaseId arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(BaseId item)
        {
            await InitializeAsync();

            var _item = items.Where((BaseId arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<BaseId> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult((BaseId)items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<BaseId>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();
            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task InitializeAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            if (isInitialized)
                return;

            items = new List<BaseId>();
            var _items = new List<TodoItem>
            {
                //new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                //new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                //new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                //new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                //new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                //new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },

                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "First item"},
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Second item"},
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Third item"},
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Fourth item"},
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Fifth item"},
                new TodoItem { Id = Guid.NewGuid().ToString(), Text = "Sixth item"},
            };

            foreach (TodoItem item in _items)
            {
                items.Add((BaseId)item);
            }

            isInitialized = true;
        }
    }

}
