using ToDos.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<ThemeFilter>();
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
app.UseSession();

app.Use(async (context, next) =>
{
    // Lire le cookie Theme
    var theme = context.Request.Cookies["Theme"] ?? "light";

    // Stocker la valeur pour l'action et les vues
    context.Items["Theme"] = theme;

    // Continuer le pipeline
    await next();
});

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Todos}/{action=Add}/{id?}")
    .WithStaticAssets();


app.Run();
