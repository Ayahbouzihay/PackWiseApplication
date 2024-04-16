
using Microsoft.EntityFrameworkCore;
using PackWiseAPI.Data;
using PackWiseAPI.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IExploreActivities, ExploreActivitiesService>();
builder.Services.AddScoped<ITripCategoryService, TripCategoryService >();
builder.Services.AddScoped<IPackingRecommendationService, PackingRecommendationService >();
builder.Services.AddDbContext<DbContextClass>(options =>
  {  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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
            builder.WithOrigins("https://localhost:7004")
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

app.UseCors("AllowMyRazorPagesApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
