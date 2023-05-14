using BlazorConf.StateManagement.Demo;
using BlazorConf.StateManagement.Demo.StateStores;
using Fluxor;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// State Container Service Cart
builder.Services.AddScoped<StateContainerServiceCartStore>();

// Reactive Cart
builder.Services.AddScoped<ReactiveStateCartStore>();

// Fluxor Cart
builder.Services.AddFluxor(opts =>
{
    opts.ScanAssemblies(typeof(Program).Assembly);
    opts.UseReduxDevTools();
});

await builder.Build().RunAsync();
