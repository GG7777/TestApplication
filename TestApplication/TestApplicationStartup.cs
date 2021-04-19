using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TestApplication.Repositories;

namespace TestApplication
{
	public class TestApplicationStartup
	{
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();
			
			services.AddMediatR(typeof(TestApplicationStartup).Assembly);

			services.AddSingleton<BooksRepository>();
		}
		
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
		}
	}
}