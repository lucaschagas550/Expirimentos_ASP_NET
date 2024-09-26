using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Rotativa.AspNetCore;
using SmartBreadcrumbs.Extensions;
using System.Globalization;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//A principio definir a culture para toda aplicao nao influencia no valor de exibicao e envio
//builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    var supportedCultures = new List<CultureInfo>
//        {
//            new CultureInfo("pt-BR")
//        };

//    options.DefaultRequestCulture = new RequestCulture("pt-BR");
//    options.SupportedCultures = supportedCultures;
//    options.SupportedUICultures = supportedCultures;
//});

// Add services to the container.
//builder.Services.AddControllersWithViews()
//    .AddDataAnnotationsLocalization();

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

//A principio definir a culture para toda aplicao nao influencia no valor de exibicao e envio
//var supportedCultures = new[] { new CultureInfo("pt-BR") };
//var localizationOptions = new RequestLocalizationOptions
//{
//    DefaultRequestCulture = new RequestCulture("pt-BR"),
//    SupportedCultures = supportedCultures,
//    SupportedUICultures = supportedCultures
//};

//app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRotativa();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
