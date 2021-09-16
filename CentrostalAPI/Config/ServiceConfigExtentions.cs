using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DTOs;
using CentrostalAPI.Helpers;
using CentrostalAPI.HttpErrors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CentrostalAPI.Config {
    public static class AuthorizationPolicies {
        public const string AdminOnly = "AdminOnly";
    }
    public static class ServiceConfigExtentions {
        public static void configureAuthentication(this IServiceCollection services) {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JwtHelper.issuer,
                        ValidAudience = JwtHelper.audience,
                        ClockSkew = TimeSpan.Zero,
                        IssuerSigningKey = new SymmetricSecurityKey(
                             Encoding.UTF8.GetBytes(JwtHelper.secret))
                    };

                });

            services.AddAuthorization(options => {
                options.AddPolicy(AuthorizationPolicies.AdminOnly, policy => {
                    policy.RequireClaim("isAdmin", true.ToString());
                });
            });
        }

        public static void configureCors(this IServiceCollection services) {
            services.AddCors(options => {
                options.AddPolicy(name: "AllowAll",
                    builder => {
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                        builder.AllowAnyOrigin();
                    });
            });
        }
        public static void configureExceptionHandler(this IApplicationBuilder app, ILogger logger) {
            app.UseExceptionHandler(appError => {
                appError.Run(async context => {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null) {
                        var error = contextFeature.Error;
                        if(error is not HttpError) {
                            error = new HttpError(500);
                        }

                        var httpError = (HttpError)error;
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = httpError.errorCode;
                        await context.Response.WriteAsync(new ErrorDTO() {
                            statusCode = httpError.errorCode,
                            message = httpError.Message
                        }.ToString());

                        if(httpError.errorCode == 500)
                            logger.LogError($"Something went wrong: {contextFeature.Error}");
                    }
                });
            });
        }
    }
}
