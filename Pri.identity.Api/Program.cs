using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Pri.identity.Api.Data;
using Pri.identity.Api.Entities;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); 

// Identity configuration
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => // AddIdentity because UI package is not needed, if UI is needed then AddDefaultIdentity<ApplicationUser>
	{ 
		options.SignIn.RequireConfirmedEmail = false; 
	})
	.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(option => 
{ 
	option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
	option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
})
.AddJwtBearer(jwtOptions => 
{ 
	jwtOptions.TokenValidationParameters = new TokenValidationParameters() 
	{ 
		ValidateActor = true, 
		ValidateAudience = true, 
		ValidateLifetime = true, 
		ValidIssuer = builder.Configuration["JWTConfiguration:Issuer"], 
		ValidAudience = builder.Configuration["JWTConfiguration:Audience"], 
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTConfiguration:SigningKey"])) 
	}; 
});

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

app.MapRazorPages();

app.Run();
