using System.Net;
using BlazorClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var client = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

builder.Services.AddScoped(sp => client);

await builder.Build().RunAsync();
