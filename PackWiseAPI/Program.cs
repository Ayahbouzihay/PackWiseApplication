
using Microsoft.EntityFrameworkCore;
using PackWiseAPI.Data;
using PackWiseAPI.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITripCategoryService, TripCategoryService >();
builder.Services.AddDbContext<DbContextClass>(options =>
  {  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnections"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowMyRazorPagesApp",
        builder =>
        {
            builder.WithOrigins("https://localhost:7146")
            .AllowAnyHeader()
            .AllowAnyMethod();
        }

        );
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
