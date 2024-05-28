using Ion.RazorPages;
using Microsoft.Extensions.FileProviders;

var builder = DiContainerBuilder.BuildContainer(args);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "images")),
    RequestPath = new PathString("/images")
});

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AnnouncementMVC}/{action=Index}/{id?}");

app.Run();
