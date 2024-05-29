using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace egitimPortali
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EducationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            // Add Identity services and configure options if necessary
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<EducationContext>()
                .AddDefaultTokenProviders();

            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddEntityFrameworkStores<EducationContext>();
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddFluentValidationAutoValidation();
            services.AddAutoMapper(typeof(Startup));

            // Register other services and configurations as needed
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.RoutePrefix = string.Empty;
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "egitim Portali");
                });
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
