using System.Reflection;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using PhotoGallery.Server.Data;
using PhotoGallery.Server.Data.Entities;
using PhotoGallery.Server.Services;
using PhotoGallery.Server.Services.Interfaces;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
//Scoped services
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
builder.Services.AddSingleton<IFileService, FileService>();

builder.Services.AddDbContext<PhotoGalleryDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("AppDbContext"));
});

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<PhotoGalleryDbContext>();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<PhotoGalleryDbContext>();

//auth configuration
builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorizationBuilder();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddCors(options => options.AddPolicy("AllowAll", corsPolicyBuilder =>
{
    corsPolicyBuilder
        .WithOrigins("https://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
}));

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//For migration purposes
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<PhotoGalleryDbContext>();
    context.Database.Migrate();
}

app.MapIdentityApi<User>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.UseCors("AllowAll"); // Use the CORS policy

app.MapFallbackToFile("/index.html");

app.Run();
