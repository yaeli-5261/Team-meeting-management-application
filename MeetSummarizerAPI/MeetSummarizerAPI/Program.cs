using MeetSummarizer.Core.Interfaces;
using MeetSummarizer.Core.IRepository;
using MeetSummarizer.Core.IServices;
using MeetSummarizer.Core.Mapping;
using MeetSummarizer.Core.Repository;
using MeetSummarizer.Core.Services;
using MeetSummarizer.Data.Repositories;
using MeetSummarizer.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Amazon.S3;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    // הגדרת ה-Security Definition עבור Bearer Token
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter your JWT token"
    });

    // הגדרת ה-Security Requirement כדי להחיל את הטוקן על כל הבקשות
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IMeetingService, MeetingService>();
builder.Services.AddScoped<IMeetingRepository, MeetingRepository>();

builder.Services.AddScoped<ITranscriptService, TranscriptService>();
builder.Services.AddScoped<ITranscriptRepository , TranscriptRepository>();

builder.Services.AddScoped<IRoleService ,RoleService> ();
builder.Services.AddScoped<IRoleRepository , RoleRepository>();

builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IUserRoleRepository , UserRoleRepository>();

builder.Services.AddScoped<IManagerRepository, ManagerRepository>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddAWSService<IAmazonS3>(); // הוספת שירות ה-AWS S3
builder.Services.AddScoped<IS3Service, S3Service>(); // הוספת ה-S3Service

//Mapper
builder.Services.AddAutoMapper(typeof(MappingProfile));


//// הוספת JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// הוספת הרשאות מבוססות-תפקידים
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("AdminAndWorker", policy => policy.RequireRole("Worker", "Admin"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
////הוספה של ריאקט 
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp",
//        builder => builder.WithOrigins("http://localhost:5173")  // כתובת ה-React שלך
//                          .AllowAnyMethod()
//                          .AllowAnyHeader());
//});


builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseDeveloperExceptionPage();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); // ✅ מציג שגיאות מפורטות
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ריאקט
app.UseCors("AllowAllOrigins");

// הפעלת אימות והרשאות
app.UseAuthentication();//JWT

app.UseAuthorization();

app.MapControllers();

app.Run();
