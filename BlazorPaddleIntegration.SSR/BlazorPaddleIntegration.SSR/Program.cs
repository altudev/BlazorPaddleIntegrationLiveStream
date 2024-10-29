using BlazorPaddleIntegration.SSR.Client.Pages;
using BlazorPaddleIntegration.SSR.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
                      {
                          options.AddPolicy("AllowAll",
                              builder => builder
                                  .AllowAnyMethod()
                                  .AllowCredentials()
                                  .SetIsOriginAllowed((host) => true)
                                  .AllowAnyHeader());
                      });

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorPaddleIntegration.SSR.Client._Imports).Assembly);

app.MapControllers();

app.Run();
