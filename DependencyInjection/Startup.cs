using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //AddSingleton metodu ile uygulamada herhangi bir yerde cagirilan interface lerde bir sonraki parametre olarak verilen concrete sinif singleton olusturularak verilmektedir.
            //Yani ilerde EfProductRepository sinifini kullanmaktan vazgecip ayni arayuzu kullanan AdoProductRepository sinifini kullanmak istenirse yapilmasi gereken tek sey bu metodda ikinci parametreyi degistirmek olacaktir. Bu da kodda bagimliligi azalttigi icin buyuk olcude esneklik kazandirmaktadir.
            services.AddSingleton<IProductRepository, EfProductRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
