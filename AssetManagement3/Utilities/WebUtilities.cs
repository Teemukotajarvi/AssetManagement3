using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace AssetManagement3.Utilities
{
    public static class WebUtilities
    {
        public static string ReadToEnd(this Stream stream)
        {
            int lenght = (int)stream.Length;
            byte[] buffer = new byte[lenght];
            int bytesRead = stream.Read(buffer,0 , lenght);
            string data = Encoding.UTF8.GetString(buffer, 0 , bytesRead);
            return data;

        }
    }
}