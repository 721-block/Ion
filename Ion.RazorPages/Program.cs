using Ion.RazorPages;
using Swashbuckle.AspNetCore.SwaggerUI;

var builder = DiContainerBuilder.BuildContainer(args);

builder.Services.AddSwaggerGen();

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

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    c.DocumentTitle = "IonAPI";
    c.DocExpansion(DocExpansion.None);
    c.RoutePrefix = "api";                   
});    

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AnnouncementMVC}/{action=Index}/{id?}");

app.Run();
