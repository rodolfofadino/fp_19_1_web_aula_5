using fpReceitas.Core.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Text;

namespace fpReceitas.Api
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });




            string connection = @"Server=(localdb)\mssqllocaldb;Database=EFGetStarted.AspNetCore.NewDb;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<ReceitaContext>(options => options.UseSqlServer(connection));

            services.AddCors(
                x =>
                {
                    x.AddPolicy("default", builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();

                    });
                });
            services.Configure<GzipCompressionProviderOptions>(
            o => o.Level = System.IO.Compression.CompressionLevel.Fastest);
                    services.AddResponseCompression(o =>
                    {
                        o.Providers.Add<GzipCompressionProvider>();
                    });

            services.AddMvc(
                a =>
                {
                    a.RespectBrowserAcceptHeader = true;
                    a.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                }
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);



            services.AddAuthentication(a => {
                a.DefaultAuthenticateScheme = "Jwt";
                a.DefaultChallengeScheme = "Jwt";
            }).AddJwtBearer("Jwt", o=>
            {
                o.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    //ValidAudience = "the audience you want to validate",
                    ValidateIssuer = false,
                    //ValidIssuer = "the isser you want to validate",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the secret that needs to be at least 16 characeters long for HmacSha256")),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                    
                };
                //o.RefreshOnIssuerKeyNotFound

            });

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(a => {
                a.SwaggerEndpoint("/swagger/v1/swagger.json", "Minha API");
            });

            app.UseCors("default");
            //app.UseHttpsRedirection();

            app.UseResponseCompression();
            app.UseMvc();
        }
    }
}
