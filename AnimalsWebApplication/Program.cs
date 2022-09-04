using AnimalsWebApplication.Data;
using AnimalsWebApplication.Repository;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AnimalContext>(options => options.UseSqlite("Data Source=c:\\temp\\animalsProject.db"));
builder.Services.AddTransient<IRepository, MyRepository>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
//    ctx.Database.EnsureDeleted();
//    ctx.Database.EnsureCreated();
//}
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("Default", "{controller=Home}/{action=Index}");
});

app.Run();