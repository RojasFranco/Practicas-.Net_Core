using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace GyL.DDD.DotNet.Swagger.ApplicationBuilder
{
	public static class ApplicationBuilderExtensions
    {
		public static void UseGyLSwagger(this IApplicationBuilder app, IApiVersionDescriptionProvider provider)
		{
			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.EnableFilter();

				foreach (var description in provider.ApiVersionDescriptions)
				{
					c.SwaggerEndpoint($"./{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());

					c.OAuthClientId(string.Empty);
					c.OAuthClientSecret(string.Empty);
				}
			});
		}
	}
}
