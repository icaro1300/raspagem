﻿using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Raspagem.Services
{
    public static class HttpRequestService
    {
        private static readonly HtmlParser _parser = new();
        public static HttpClient ConfiguringHttp(string url)
        {
            HttpClient client = new();
            client.BaseAddress = new Uri(url);
            return client;
        }
        public static async Task<string> Pegar_Html(this HttpClient client)
        {
            try
            {
                string response = await client.GetStringAsync(client.BaseAddress);
                var content = await _parser.ParseDocumentAsync(response);
                return content.DocumentElement.OuterHtml;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
