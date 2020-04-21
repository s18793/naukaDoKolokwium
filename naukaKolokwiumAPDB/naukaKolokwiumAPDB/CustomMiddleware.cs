using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace naukaKolokwiumAPDB
{
    public class CustomMiddleware
    {

        private RequestDelegate _next;
        public CustomMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("nag", "18793");

            await _next.Invoke(context);   //uruchamia sie kolejny middlerwearew


        }
    }
}
