using BookStoreApp.Models;
using BookStoreApp.Repositories.Abstract;
using BookStoreApp.Repositories.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connect=builder.Configuration.GetConnectionString("connect");
builder.Services.AddDbContext<BookContext>(op=>op.UseMySQL(connect));
builder.Services.AddScoped<IGenreService,GenreService>();
builder.Services.AddScoped<IAuthorService,AuthorService>();
builder.Services.AddScoped<IPublisherService,PublisherService>();
builder.Services.AddScoped<IBookService,BookService>();
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
    pattern: "{controller=Book}/{action=Add}/{id?}");

app.Run();
