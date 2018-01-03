using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace XDogApp.Utils
{
    public static class CameraUtils
    {
        public static async Task<Tuple<int, Stream, string>> PickPhotoAsync()
        {
            string resp = String.Empty;
            Stream retStream = null;
            int iRet = 1;

            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            {
                iRet = 2;
                resp = "Camera Not Available/Supported";
            }
            else
            {
                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file != null)
                {
                    retStream = file.GetStream();
                    file.Dispose();
                }
            }

            Tuple<int, Stream, string> ret = new Tuple<int, Stream, string>(iRet, retStream, resp);
            return ret;
        }
        public static async Task<Tuple<int, Stream, string>> PickVideoAsync()
        {
            string resp = String.Empty;
            Stream retStream = null;
            int iRet = 1;

            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickVideoSupported)
            {
                iRet = 2;
                resp = "Camera Not Available/Supported";
            }
            else
            {
                var file = await CrossMedia.Current.PickVideoAsync();
                if (file != null)
                {
                    retStream = file.GetStream();
                    file.Dispose();
                }
            }

            Tuple<int, Stream, string> ret = new Tuple<int, Stream, string>(iRet, retStream, resp);
            return ret;
        }

        public static async Task<Tuple<int, Stream, string>> TakePhotoAsync()
        {
            string resp = String.Empty;
            Stream retStream = null;
            int iRet = 1;

            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                iRet = 2;
                resp = "Camera Not Available/Supported";
            }
            else
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions() { SaveToAlbum = true });
                if (file != null)
                {
                    retStream = file.GetStream();
                    file.Dispose();
                }
            }

            Tuple<int, Stream, string> ret = new Tuple<int, Stream, string>(iRet, retStream, resp);
            return ret;
        }

        public static async Task<Tuple<int, Stream, string>> TakeVideoAsync()
        {
            string resp = String.Empty;
            Stream retStream = null;
            int iRet = 1;

            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
            {
                iRet = 2;
                resp = "Camera Not Available/Supported";
            }
            else
            {
                var file = await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions() { SaveToAlbum = true });
                if (file != null)
                {
                    retStream = file.GetStream();
                    file.Dispose();
                }
            }

            Tuple<int, Stream, string> ret = new Tuple<int, Stream, string>(iRet, retStream, resp);
            return ret;
        }


        public static byte[] StreamToByteArray(Stream stream)
        {
            using (var memoryStream = new MemoryStream())
            {
                stream.Position = 0;
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
