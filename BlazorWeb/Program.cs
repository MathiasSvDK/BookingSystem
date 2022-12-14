using Blazored.Toast;
using Datalayer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Servicelayer.Interfaces;
using Servicelayer.Repositories;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Identity;
using BlazorWeb.Data;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorWeb.Areas.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Datalayer.Entities;
using BlazorWeb.Services;
using System.Security.Claims;
using Web.Service;
using Web.Service.IdentityService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var Configuration = builder.Configuration;

builder.Services.AddControllers().AddJsonOptions(x =>
				x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


builder.Services.AddDbContext<BookingContext>(options =>
			options.UseMySql(Configuration.GetConnectionString("BookingConnectionString").ToString(), MariaDbServerVersion.LatestSupportedServerVersion));

builder.Services.AddDbContext<hospitalContext>(options =>
			options.UseMySql(Configuration.GetConnectionString("HospitalConnectionString").ToString(), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.34-mariadb")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
			options.UseMySql(Configuration.GetConnectionString("IdentityConnection").ToString(), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.34-mariadb")));

builder.Services.AddDefaultIdentity<ApplicationUser>()
	.AddSignInManager<CustomSignInManager>()
	.AddEntityFrameworkStores<ApplicationDbContext>()
	.AddDefaultTokenProviders();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddScoped<ITreatmentRepository, TreatmentRepository>();
builder.Services.AddScoped<IAvailableRepository, AvailableRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IHospitalizationRepository, HospitalizationRepository>();

builder.Services.AddScoped<IApiService, ApiService>();
builder.Services.Configure<IdentityServerSettings>(builder.Configuration.GetSection("IdentityServerSettings"));
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAuthentication(options =>
{
	options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddOpenIdConnect(
 OpenIdConnectDefaults.AuthenticationScheme,
	 options =>
	 {
		 options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
		 options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
		 options.Authority = builder.Configuration["InteractiveServiceSettings:AuthorityUrl"];
		 options.ClientId = builder.Configuration["InteractiveServiceSettings:ClientId"];
		 options.ClientSecret = builder.Configuration["InteractiveServiceSettings:ClientSecret"];
		 options.Scope.Add("api custom.name");
		 options.ResponseType = "code";
		 options.SaveTokens = true;
		 options.GetClaimsFromUserInfoEndpoint = true;
		 options.Prompt = "consent";
	 }
	);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();
