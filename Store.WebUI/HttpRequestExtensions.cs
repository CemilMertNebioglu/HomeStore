using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Store.WebUI
{
    public static class HttpRequestExtensions
    {
        public static ByteArrayContent ContentAsByteJson(object value, string mediaType = "application/json")
        {
            string message = JsonConvert.SerializeObject(value);
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            var content = new ByteArrayContent(messageBytes);
            content.Headers.ContentType = new MediaTypeHeaderValue(mediaType);
            return content;
        }
    }
}
