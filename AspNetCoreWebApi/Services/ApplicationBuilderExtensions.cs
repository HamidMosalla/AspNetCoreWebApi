﻿using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreWebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreWebApi.Services
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseWebApiExceptionHandler(this IApplicationBuilder app)
        {
           return app.UseExceptionHandler(WebApiExceptionHandler().Result);
        }

        private static async Task<Action<IApplicationBuilder>> WebApiExceptionHandler()
        {
            return errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500; // or another Status accordingly to Exception Type
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;

                        await context.Response.WriteAsync(new ErrorDto()
                        {
                            Code = (int)HttpStatusCode.BadRequest,
                            Message = ex.Message
                        }.ToString(), Encoding.UTF8);
                    }
                });
            };
        }
    }
}