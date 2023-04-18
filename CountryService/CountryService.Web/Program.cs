using CountryService.Web.Services;
using Grpc.Net.Compression;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc(options =>
{
    options.MaxReceiveMessageSize = 6291456; // 6 MB
    options.MaxSendMessageSize = 6291456; // 6 MB
    /*options.CompressionProviders = new List<Microsoft.AspNetCore.ResponseCompression.ICompressionProvider>
     {
        BrotliCompressionProvider(CompressionLevel.Optimal) // br
     };*/
    options.ResponseCompressionAlgorithm = "br"; // grpcaccept-encoding, and must match the compression provider declared in CompressionProviders collection
    options.ResponseCompressionLevel = CompressionLevel.Optimal; // compression level used if not set on the provider
});

builder.Services.AddSingleton<CountryManagementService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<CountryGrpcService>();
app.MapGet("/"
    , () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
