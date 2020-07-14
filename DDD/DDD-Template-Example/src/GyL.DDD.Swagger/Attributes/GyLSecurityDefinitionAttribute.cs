using Microsoft.OpenApi.Models;
using System;

namespace GyL.DDD.DotNet.Swagger.Attributes
{
    public class GyLSecurityDefinitionAttribute : Attribute
    {
        public GyLSecurityDefinitionAttribute(SecuritySchemeType type)
        {
            Type = type.ToString();
        }
        public string Type { get; set; }
    }
}
