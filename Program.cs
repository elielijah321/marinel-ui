using Marinel_ui.Data;
using Marinel_ui.Services;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<SchoolContext>();
builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();
builder.Services.AddSingleton<IMSGraphService, MSGraphService>();

var instance = Environment.GetEnvironmentVariable("Instance") ?? builder.Configuration["Instance"];
var domain = Environment.GetEnvironmentVariable("Domain") ?? builder.Configuration["Domain"];
var clientId = Environment.GetEnvironmentVariable("ClientId") ?? builder.Configuration["ClientId"];
var tenantId = Environment.GetEnvironmentVariable("TenantId") ?? builder.Configuration["TenantId"];
var signedOutCallbackPath = Environment.GetEnvironmentVariable("SignedOutCallbackPath") ?? builder.Configuration["SignedOutCallbackPath"];
var signUpSignInPolicyId = Environment.GetEnvironmentVariable("SignUpSignInPolicyId") ?? builder.Configuration["SignUpSignInPolicyId"];

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(options =>
            {
                options.Instance = instance;
                options.Domain = domain;
                options.ClientId = clientId;
                options.TenantId = tenantId;
                options.SignedOutCallbackPath = signedOutCallbackPath;
                options.SignUpSignInPolicyId = signUpSignInPolicyId;
            });


builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
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

