using Microsoft.EntityFrameworkCore;
using student.Data;
using student.Services;

namespace student
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var connectionString = builder.Configuration.GetConnectionString("MyDB");
            builder.Services.AddDbContext<MyDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });
            builder.Services.AddScoped<INationRespository, NationRespository>();
            builder.Services.AddScoped<ICityRespository, CityRespository>();
            builder.Services.AddScoped<IDistrictRespository, DistrictRespository>();
            builder.Services.AddScoped<IWardRespository, WardRespository>();
            builder.Services.AddScoped<IStudentRespository, StudentRespository>();

            builder.Services.AddCors(p => p.AddPolicy("Cors", build =>
            {
                build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("Cors");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}