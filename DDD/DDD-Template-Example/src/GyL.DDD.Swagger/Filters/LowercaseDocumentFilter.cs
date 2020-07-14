using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;

namespace GyL.DDD.DotNet.Swagger.Filters
{
	public class LowercaseDocumentFilter : IDocumentFilter
	{
		public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
		{
			var items = swaggerDoc.Paths.Extensions;
			var dic = new Dictionary<string, IOpenApiExtension>();

			foreach (var item in items)
				dic.Add(LowercaseEverythingButParameters(item.Key), item.Value);

			swaggerDoc.Paths.Extensions = dic;
		}

		private static string LowercaseEverythingButParameters(string key)
		{
			return string.Join("/", key.Split('/').Select(x => x.Contains("{") ? x : x.ToLower()));
		}
	}
}
