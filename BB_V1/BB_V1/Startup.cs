using BB_V1.Data;
using BB_V1.Models;
using BB_V1.Services;
using BB_V1.Services.IRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB_V1
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

            services.AddControllers();
            services.AddDbContext<DbBloodBank>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("_ConnectionPath"));
            });

            services.AddScoped<ITaiKhoanRepository, TaiKhoanRepository>();
            services.AddScoped<ISuKienHienMauRepository, SuKienHienMauRepository>();
            services.AddScoped<INguoiHienMauRepository, NguoiHienMauRepository>();
            services.AddScoped<IChiTietSuKienRepository, ChiTietSuKienRepository>();
            services.AddScoped<ILoaiTheTichRepository, LoaiTheTichRepository>();
            services.AddScoped<IChiTietDiemHienMauCoDinhRepository, ChiTietDiemHienMauCoDinhRepository>();
            services.AddScoped<IDiemHienMauCoDinhRepository, DiemHienMauCoDinhRepository>();
            services.AddScoped<IBenhVienRepository, BenhVienRepository>();
            services.AddScoped<IQuaRepository, QuaRepository>();

            services.Configure<AppSetting>(Configuration.GetSection("AppSettings"));

            var secretKey = Configuration["AppSettings:SecretKey"];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);


            #region config json convert systemjson
            services.AddMvc(option => option.EnableEndpointRouting = false)
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
            #endregion
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["AppSettings:Issuser"],
                        ValidAudience = Configuration["AppSettings:Issuser"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["AppSettings:SecretKey"]))

                    };
                });


            /*

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
            {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    //Auto create token
                    ValidateIssuer = false,
                    ValidateAudience = false,

                    // sign in token
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes), //(AI doi xung)
                    ClockSkew = TimeSpan.Zero
                };
            });*/

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BB_V1", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BB_V1 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin().
                AllowAnyHeader()
                .AllowAnyMethod();

            });

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
