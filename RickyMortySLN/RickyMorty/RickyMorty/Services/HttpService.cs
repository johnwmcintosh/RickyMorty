using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RickyMorty.Services
{
    public static class HttpService
    {
        public enum RequestType
        {
            Get,
            Post,
            Put,
            Delete
        }

        public static async Task<HttpResponseMessage> RequestAsync(string url, RequestType requestType)
        {
            if (string.IsNullOrEmpty(url))
                throw new UriFormatException("The given url cannot be empty");
            else
                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                    throw new UriFormatException("The given url must be absolute");

            HttpResponseMessage message;
            using (var client = new HttpClient())
            {
                switch(requestType)
                {
                    case RequestType.Get:
                        message = await client.GetAsync(url);
                        break;
                    default:
                        message = null;
                        break;
                }
            }

            return message;
        }
    }
}
