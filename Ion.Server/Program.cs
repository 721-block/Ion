using Ion.Server;
using Ion.Server.Hubs;

var builder = DiContainerBuilder.BuildContainer(args);
builder.Services.AddSignalR();

builder.Services.AddCors(c => c.AddDefaultPolicy(p => p.WithOrigins("*").WithHeaders("*")));

var app = builder.Build();

app.UseCors();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<AnnouncementChatHub>("/chat");
app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();