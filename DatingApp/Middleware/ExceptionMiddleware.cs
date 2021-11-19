namespace DatingApp.Middleware
{
    using System;
    using System.Net;
    using System.Text.Json;
    using System.Threading.Tasks;
    using DatingApp.Models.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    public class ExceptionMiddleware
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// 
        /// </summary>
        private readonly ILogger<ExceptionMiddleware> logger;

        /// <summary>
        /// 
        /// </summary>
        private readonly IHostEnvironment env;

        /// <summary>
        /// 
        /// </summary>
        private readonly JsonSerializerOptions jsonSerializerOptions;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        /// <param name="env"></param>
        public ExceptionMiddleware(
            RequestDelegate next, 
            ILogger<ExceptionMiddleware> logger, 
            IHostEnvironment env,
            IOptions<JsonOptions> jsonOptions)
        {
            this.next = next;
            this.logger = logger;
            this.env = env;
            this.jsonSerializerOptions = jsonOptions.Value.JsonSerializerOptions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.next(context);
            }
            catch (Exception e)
            {
                this.logger.LogError(e.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;

                var response = this.env.IsDevelopment()
                    ? new ApiException(context.Response.StatusCode, e.Message, e.StackTrace?.ToString())
                    : new ApiException(context.Response.StatusCode, "Internal Error");

                var json = JsonSerializer.Serialize(response, this.jsonSerializerOptions);

                await context.Response.WriteAsync(json);
            }
        }
    }
}