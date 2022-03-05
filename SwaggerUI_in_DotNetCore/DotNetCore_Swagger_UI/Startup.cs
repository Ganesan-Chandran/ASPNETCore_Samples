using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DotNetCore_Swagger_UI
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services
				.AddSwaggerGen(options =>
				{
					options.SwaggerDoc("v1", new OpenApiInfo
					{
						Version = "v1",
						Title = "Sample API",
						Description = "Sample API for Swagger integration",
						TermsOfService = new Uri("https://test.com/terms"), // Add url of term of service details
						Contact = new OpenApiContact
						{
							Name = "Test Contact",
							Url = new Uri("https://test.com/contact") // Add url of contact details
						},
						License = new OpenApiLicense
						{
							Name = "Test License",
							Url = new Uri("https://test.com/license") // Add url of license details
						}
					});

					var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
					var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
					options.IncludeXmlComments(xmlPath);
				})
				.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API");
			});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
