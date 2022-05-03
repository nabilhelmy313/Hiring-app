using Application;
using Application.Interfaces.Repositories.General;
using Application.Interfaces.Repositories.General.Auth;
using Application.Interfaces.Services.General;
using Application.Services.Auth;
using Application.Services.General;
using Domain.Entities.General;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Persistence.Repositories.Auth;
using Persistence.Repositories.General;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add mulit Languages support
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<System.Globalization.CultureInfo>
                {
                    new System.Globalization.CultureInfo("ar-EG"),
                    new System.Globalization.CultureInfo("en-US")
                };

    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.CustomRequestCultureProvider(context =>
    {
        var defaultLang = "en-US";
        var lang = context.Request.Headers["Accept-Language"].ToString();
        if (!string.IsNullOrWhiteSpace(lang) && lang.ToString().Length > 4 && lang.ToString().Substring(2, 1) == "-")
            defaultLang = lang.ToString().Substring(0, 5);

        return Task.FromResult(new Microsoft.AspNetCore.Localization.ProviderCultureResult(defaultLang, defaultLang));
    }));
});

#region IdentityCoreAuth
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<HiringDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDbContext<HiringDbContext>(options =>
{

    options.UseSqlServer(builder.Configuration.GetConnectionString("HiringDBConnStr"));
    options.EnableSensitiveDataLogging();

});
builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 1;
});
#endregion


#region JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Bearer", options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = "Hiring.com",
        ValidAudience = "Hiring.com",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("HiringSuperSecretPassword"))
    };
 });
#endregion

builder.Services.AddAutoMapper(typeof(MappingProfileBase));
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
});
#region Repositories
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IAttachmentRepository, AttachmentRepository>();

#endregion

#region Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFileService, FileService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
