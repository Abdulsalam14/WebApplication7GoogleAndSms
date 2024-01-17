using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme=CookieAuthenticationDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme=GoogleDefaults.AuthenticationScheme;
})
    .AddCookie()
    .AddGoogle(GoogleDefaults.AuthenticationScheme, opt =>
{
    opt.ClientId=builder.Configuration.GetSection("GoogleKeys:ClientId").Value;
    opt.ClientSecret=builder.Configuration.GetSection("GoogleKeys:ClientSecret").Value;
});
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
