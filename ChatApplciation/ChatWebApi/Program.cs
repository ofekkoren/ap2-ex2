using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ChatWebApi.Data;
using ChatWebApi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using ChatWebApi.Hubs;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ChatWebApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ChatWebApiContext") ?? throw new InvalidOperationException("Connection string 'ChatWebApiContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IContactService, ContactService>();
builder.Services.AddSingleton<IConversationService, ConversationService>();

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(7);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();


builder.Services.AddSignalR();


/*builder.Services.AddCors(options =>
{
    options.AddPolicy(name:"Allow react", policy =>
    {
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});*/

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "Allow react", policy =>
    {
        policy.SetIsOriginAllowed(param=>true).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

/*builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow All", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});*/

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Allow react");
//app.UseCors("Allow All");
app.UseHttpsRedirection();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
//app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}/{id?}");

/*app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<AppHub>("/chatHub");
});*/

app.MapHub<AppHub>("/hubs/chatHub");

app.Run();
