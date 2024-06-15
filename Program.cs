using SmartBreadcrumbs.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddBreadcrumbs(Assembly.GetExecutingAssembly(), options =>
//{
//    options.TagName = "nav";
//    options.TagClasses = "";
//    options.OlClasses = "breadcrumb";
//    options.LiClasses = "breadcrumb-item";
//    options.ActiveLiClasses = "breadcrumb-item active";
//    options.SeparatorElement = "<li class=\" separator \">&nbsp;>&nbsp;</li>";
//});
try
{
    builder.Services.AddBreadcrumbs(Assembly.GetExecutingAssembly(), options =>
    {
        options.TagName = "";
        options.TagClasses = "";
        options.OlClasses = "breadcrumb";
        options.LiClasses = "";
        options.ActiveLiClasses = "breadcrumb-item active";
        options.LiTemplate = "<li><a href=\"{1}\">{2}{0}</a></li>";
        options.ActiveLiTemplate = "<li class=\"breadcrumb-item active\">{2}{0}</li>";
        options.SeparatorElement = "<li class=\" separator \">&nbsp;>&nbsp;</li>";
        options.DontLookForDefaultNode = true;
    });
}
catch(Exception ex)
{
    Console.WriteLine(ex);
}

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


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
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
