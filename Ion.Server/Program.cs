using Ion.Server;
using Ion.Server.Hubs;

var builder = DiContainerBuilder.BuildContainer(args);
builder.Services.AddSignalR();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<AnnouncementChatHub>("/chat");
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();