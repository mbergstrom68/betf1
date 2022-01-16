using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp.Client;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using ErgastApi.Client;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
      .AddBlazorise( options =>
      {
          options.ChangeTextOnKeyPress = true;
      } )
      .AddBootstrapProviders()
      .AddFontAwesomeIcons();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["API_Prefix"] ?? builder.HostEnvironment.BaseAddress) });


builder.Services.AddSingleton<IErgastClient, ErgastClient>();
builder.Services.AddScoped<ICircuitService, CircuitsService>();
builder.Services.AddScoped<IRaceService, RaceService>();
builder.Services.AddScoped<IDriverService, DriverService>();

await builder.Build().RunAsync();
