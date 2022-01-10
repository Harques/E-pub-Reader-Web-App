using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using SoftwareEngineering.IService;
using SoftwareEngineering.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareEngineering
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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddScoped<IUserService, UserService>();

            var key = "8Zz5tw0Ionm3XPZZfN0NOml3z9FMfmpgXwovR9fp6ryDIoGRM8EPHAB6iHsc0fb";
            services.AddCors(options =>
                options.AddPolicy("AllowAll", builder =>
                builder.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials())
            );
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero

                };
                x.Events = new JwtBearerEvents();
                x.Events.OnMessageReceived = context =>
                {
                    if (context.Request.Cookies.ContainsKey("X-Access-Token"))
                    {
                        context.Token = context.Request.Cookies["X-Access-Token"];
                    }

                    return Task.CompletedTask;
                };
            }).AddCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;
            });

            services.AddSingleton<IJWTAuthenticationManager>(new JWTAuthenticationManager(key));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("AllowAll");
            app.UseMiddleware<MaintainCorsHeadersMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                //endpoints.MapControllerRoute(
                //    name: "Api",
                //    pattern: "api/{controller}/{action}/{id?}"
                //    );
            });
        }
    }
    public class MaintainCorsHeadersMiddleware
    {
        public MaintainCorsHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        private readonly RequestDelegate _next;

        public async Task Invoke(HttpContext httpContext)
        {
            // Find and hold onto any CORS related headers ...
            var corsHeaders = new HeaderDictionary();
            foreach (var pair in httpContext.Response.Headers)
            {
                if (!pair.Key.ToLower().StartsWith("access-control-")) { continue; } // Not CORS related
                corsHeaders[pair.Key] = pair.Value;
            }

            // Bind to the OnStarting event so that we can make sure these CORS headers are still included going to the client
            httpContext.Response.OnStarting(o => {
                var ctx = (HttpContext)o;
                var headers = ctx.Response.Headers;
                // Ensure all CORS headers remain or else add them back in ...
                foreach (var pair in corsHeaders)
                {
                    if (headers.ContainsKey(pair.Key)) { continue; } // Still there!
                    headers.Add(pair.Key, pair.Value);
                }
                return Task.CompletedTask;
            }, httpContext);

            // Call the pipeline ...
            await _next(httpContext);
        }
    }
}
