using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Constants
{
    public static class LinkConstant
    {
        private static string baseUri = $"https://localhost:5000//api";

        public static UriBuilder UriBuilder(string userId, string token,string path)
        {
            var builder = new UriBuilder(baseUri);
            builder.Path = $"api/{path}";
            builder.Query = $"userId={userId}&token={Uri.EscapeDataString(token)}";
            return builder;
        }
    }
}
