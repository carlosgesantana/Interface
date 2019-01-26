using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Null.Token;
using QuePerigo.Estoque.Models;
using QuePerigo.Repositorio;

namespace QuePerigo.Estoque
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            string connectionStringWithToken = Configuration.GetConnectionString("Default");
            string connectionString = Conexao.GetConnectionString(connectionStringWithToken);

            services.AddSingleton<System.Data.IDbConnection>(new System.Data.SqlClient.SqlConnection(connectionString));

            services.AddSingleton<Dados.IConexaoDados, Dados.ConexaoDados>();
            services.AddSingleton<IProdutoRepositorio, ProdutoRepositorio>();
            services.AddSingleton<IFornecedorRepositorio, FornecedorRepositorio>();
            services.AddSingleton<ILocalizacaoRepositorio, LocalizacaoRepositorio>();
            services.AddSingleton<IDominioFactory, DominioFactory>();
            services.AddSingleton<IModelInfo, ModelInfo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(Configuration.GetSection("ErrorPage").Value);
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
