using MaxPrimeNumber.Entities;
using MaxPrimeNumber.Repositories;
using MaxPrimeNumber.Repositories.UserRepository;
using MaxPrimeNumber.Services.Admin;
using MaxPrimeNumber.Services.EnteredNumber;
using MaxPrimeNumber.Services.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEnteredNumberRepository, EnteredNumberRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IEnteredNumberService, EnteredNumberService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("dbConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddRazorPages();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 0;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//hic bir sey kurmadim wwwroot dosyasi statik dosyalar icin kullaniliyor oraya atcaksin dosyalarini
// bu dosyalari aktiflestirmek icin de program.cs e app.useStaticFiles() methodunu kullandik bu kadar
// adam hic boyle yapmadı onunkı nasıl oldu pekı
// bilmiyorum dogrusu bu tamam css dosylarını buraya mı koycam 
//evet tamam yavrum Allah razı olsun senden ıyı mı bu template gayet iyi ugrasma daha fazla templatela falan yok ugrasmamak ıcın aldım ıste 
// sımdı zort denılen yerdeyım degısık bır sıstemı var 
// sayfaları tanımlamak lazım ındex de anladıgım kadarıyla allooo
// hangi sayfalari logın regıster zart zurt 
// normal link a href olarak tanimlicaksin bir sey yok ki onda 
// adam bır yere tanımladı gerek yok

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.MapControllers();


app.Run();


