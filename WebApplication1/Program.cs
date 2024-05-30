var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();
//app.MapControllerRoute(
//    "default",
//    "{controller=home}/{action=index}/{id?}"
//    );
app.UseAuthorization();


app.Run();
