using Application.Configrations;
using Data;
using Data.Blogs;
using Data.Courses;
using Data.Menus;
using Data.Users;
using Data.Users.Dervices;
using Data.Users.Logins;
using Domain.Models.Blogs;
using Domain.Models.Courses;
using Domain.Models.Menus;
using Domain.Models.Users;
using Domain.Models.Users.Devices;
using Domain.Models.Users.Logins;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;
using WebApi.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));



// Add services to the container.



builder.Services.AddCoreServices(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddHttpContextAccessor();

builder.Services.AddEndpointsApiExplorer();



builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        builder =>
        {
            builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:5001",
        ValidAudience = "https://localhost:5001",  
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345")) 
    };
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Api", Version = "v1" });

    // Customizing Swagger document
    c.CustomOperationIds(apiDesc =>
    {
        // Use custom operation IDs (optional)
        return apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null;
    });

    // Add a security definition for JWT Bearer token (optional)
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter 'Bearer {Token}'",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    // Add JWT Bearer authorization to all endpoints (optional)
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            Array.Empty<string>()
        }
    });
});

// Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionStrings");
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<ICourseRepository, CourseRepoitory>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserLoginRepository, UserLoginRepository>();
builder.Services.AddScoped<IUserDerviceRepository, UserDerviceRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<EmailService>();





//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowOrigin", builder =>
//    {
//        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.




app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Web Api v1");
    options.RoutePrefix = string.Empty;


});


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHsts();
app.UseCors("AllowOrigin");
app.UseStaticFiles();

/*app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();*/
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}


app.MapControllers();
app.Run();



