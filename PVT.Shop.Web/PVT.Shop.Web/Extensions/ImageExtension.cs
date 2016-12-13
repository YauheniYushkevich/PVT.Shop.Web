namespace PVT.Shop.Web.Extensions
{
    using System;
    using System.IO;

    public static class ImageExtension
    {
        public static string ToBase64(Stream stream)
        {
            var bytes = new byte[stream.Length];
            long data = stream.Read(bytes, 0, (int)stream.Length);
            stream.Close();
            return Convert.ToBase64String(bytes, 0, bytes.Length);
        }
    }
}