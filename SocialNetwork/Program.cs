using SocialNetwork.BusinessLogic.Factoies.JwtFactory;
using SocialNetwork.BusinessLogic.PasswordHasher;
using SocialNetwork.BusinessLogic.Services.Authentication;
using SocialNetwork.Data.Repositories.Users;
using SocialNetwork.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguredAuthentication(builder.Configuration);
builder.Services.AddOptions(builder.Configuration);

builder.Services.AddTransient<IAuthenticationService, AuthenticationService>();
builder.Services.AddTransient<IJwtFactory, JwtFactory>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IPasswordHasher, PasswordHasher>();

builder.Services.AddControllers();


var app = builder.Build();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();


app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");


app.Run();


// authorization
// profile
// friends
// posts with image and text
// emotions on posts
// infinity post feed