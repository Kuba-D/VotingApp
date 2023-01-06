using Microsoft.EntityFrameworkCore;
using VotingApp.Context;
using VotingApp.Helpers;
using VotingApp.Repositories;
using VotingApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IVoterRepository,VoterRepository>();
builder.Services.AddScoped<ICandidateRepository,CandidateRepository>();
builder.Services.AddScoped<IVoterService, VoterService>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

RegisterDbContext(builder);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void RegisterDbContext(WebApplicationBuilder builder)
{
    builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection(ConnectionStringOptions.ConnectionStrings));
    var connectionStringOptions = new ConnectionStringOptions();
    builder.Configuration.GetSection(ConnectionStringOptions.ConnectionStrings).Bind(connectionStringOptions);

    var connectionString = connectionStringOptions.ServiceDatabase;
    builder.Services.AddDbContext<VotingAppContext>(options => options.UseSqlite(@"Data Source=.\VotingAppDb.db"));
}
