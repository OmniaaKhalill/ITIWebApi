
using ITIWebApi.BLL.Interfaces;
using ITIWebApi.BLL.Repositories;
using ITIWebApi.Models;
using ITIWebApi.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;


namespace ITIWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            string txt = "";
            builder.Services.AddControllers();

            builder.Services.AddScoped<ICourseRepo,CourseRepo>();
            builder.Services.AddScoped< IDepartmentRepo,DepartmentRepo> ();
            builder.Services.AddScoped<IStudentRepo, StudentRepo>();



            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAuthentication(op => op.DefaultAuthenticateScheme = "my schema").AddJwtBearer("my schema", op =>
            {
                string secretKey = "omniawishy_omniawishy_omniawishy";
                var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));
                op.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = key,
                    ValidateIssuer=false,
                    ValidateAudience=false
                };

            });


            //builder.Services.AddControllers().AddNewtonsoftJson(op=>op.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            //Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


            builder.Services.AddEndpointsApiExplorer();


            builder.Services.AddSwaggerGen(
                options =>{
                    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                    {
                        Version = "v1",
                        Title = "My ITI_PD Api",
                        Description = " Api to manage ITI_PD track Courses and Students",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                        {
                            Name = "Omnia Abd-Elmawgoud Khalil",
                            Email = "omniaaKhalill@gmail.com"

                        }

                    });
                    options.IncludeXmlComments("C:\\Users\\Omnia\\Downloads\\c#\\ITIWebApi\\ITIWebApi\\MyDoc.xml");
                    options.EnableAnnotations();
                   
                });
            builder.Services.AddDbContext<ITIContext>(op=>op.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("iticon")));
            
            
            //cors
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(txt,
                builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();

                });

            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                 app.UseSwagger();
              //  app.MapSwagger().RequireAuthorization();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(txt);
            app.MapControllers();


            app.Run();
        }
    }
}
