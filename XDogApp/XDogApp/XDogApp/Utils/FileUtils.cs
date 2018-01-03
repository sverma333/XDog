using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XDogApp.Utils
{
    public static class FileUtils
    {
        public async static Task<string> SaveToFile(string folder, string fileName, byte[] data)
        {
            string ret = String.Empty;
            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder fld = await rootFolder.CreateFolderAsync(folder, CreationCollisionOption.OpenIfExists);
                IFile file = await fld.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                ret = file.Path;
                using (var memoryStreamHandler = new MemoryStream())
                {
                    await memoryStreamHandler.WriteAsync(data, 0, data.Length);

                    using (var fileStreamHandler = await file.OpenAsync(FileAccess.ReadAndWrite))
                    {
                        memoryStreamHandler.Position = 0;
                        await memoryStreamHandler.CopyToAsync(fileStreamHandler);
                    }
                }
            }
            catch(Exception)
            {
                
            }

            return ret;
        }

        public async static Task<Stream> ReadFromFile(string folder, string fileName)
        {
            Stream ret = null;
            try
            {
                IFolder rootFolder = FileSystem.Current.LocalStorage;
                IFolder fld = await rootFolder.CreateFolderAsync(folder, CreationCollisionOption.OpenIfExists);
                IFile file = await fld.GetFileAsync(fileName);
                ret = await file.OpenAsync(FileAccess.Read);
            }
            catch(Exception)
            {
                
            }

            return ret;
        }

        public async static Task<bool> FileExist(string folder, string fileName)
        {
            Stream str = await ReadFromFile(folder, fileName);

            return str != null;
        }
    }
}
