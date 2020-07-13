using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using GyL.DDD.DotNet.Swagger.Attributes;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GyL.DDD.DotNet.Swagger.Filters
{
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if ((!context.MethodInfo.GetCustomAttributes(true).Any(x => x is AllowAnonymousAttribute))
                && (context.MethodInfo.GetCustomAttributes(true).Any(x => x is AuthorizeAttribute)
                    || context.MethodInfo.DeclaringType.GetCustomAttributes(true).Any(x => x is AuthorizeAttribute))
                && (((GyLSecurityDefinitionAttribute)context.MethodInfo.GetCustomAttributes(true).FirstOrDefault(x => x is GyLSecurityDefinitionAttribute))?.Type != null
                    || ((GyLSecurityDefinitionAttribute)context.MethodInfo.DeclaringType.GetCustomAttributes(true).FirstOrDefault(x => x is GyLSecurityDefinitionAttribute))?.Type != null))
            {
                var secType = ((GyLSecurityDefinitionAttribute)context.MethodInfo.GetCustomAttributes(true).FirstOrDefault(x => x is GyLSecurityDefinitionAttribute))?.Type ??
                    ((GyLSecurityDefinitionAttribute)context.MethodInfo.DeclaringType.GetCustomAttributes(true).FirstOrDefault(x => x is GyLSecurityDefinitionAttribute))?.Type;

                var security = new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme() { Type = (SecuritySchemeType)Enum.Parse(typeof(SecuritySchemeType), secType, true) }, Array.Empty<string>() }
                };

                operation.Security = new List<OpenApiSecurityRequirement>() { security };
            }
        }
    }
}
