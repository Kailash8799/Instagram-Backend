using Instagram.Services.PostAPI.Data;
using Instagram.Services.PostAPI.Extensions;
using Instagram.Services.PostAPI.Models;
using Instagram.Services.PostAPI.Service;
using Instagram.Services.PostAPI.Service.IService;
using Instagram.Services.PostAPI.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => {
    options.Filters.Add<CustomValidationFilter>();
}).AddNewtonsoftJson();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection")));
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IPostService, PostService>();

builder.Services.AddSwaggerGen(option => {
    option.AddSecurityDefinition(name: JwtBearerDefaults.AuthenticationScheme, securityScheme: new OpenApiSecurityScheme {
        Name = "Authorization",
        Description = "Enter the Bearer Authorization string as following: `Bearer Generated-JWT-Token`",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference= new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id=JwtBearerDefaults.AuthenticationScheme
                }
            }, new string[]{}
        }
    });
});


builder.AddAppAuthetication();
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<CustomExceptionMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
ApplyMigration();
app.Run();

void ApplyMigration() {
    using (var scope = app.Services.CreateScope()) {
        var _db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if(_db.Database.GetPendingMigrations().Any()) {
            _db.Database.Migrate();
        }
    }
}