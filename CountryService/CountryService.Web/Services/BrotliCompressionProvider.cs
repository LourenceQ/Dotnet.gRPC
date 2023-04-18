using Grpc.Net.Compression;
using System.IO.Compression;

namespace CountryService.Web.Services;

public class BrotliCompressionProvider : ICompressionProvider
{
    private readonly CompressionLevel? _compressionLevel;
    public string EncodingName => "br";

    public BrotliCompressionProvider(CompressionLevel? compressionLevel)
    {
        _compressionLevel = compressionLevel;
    }
    public BrotliCompressionProvider()
    {

    }

    public Stream CreateCompressionStream(Stream stream, CompressionLevel? compressionLevel)
    {
        if (_compressionLevel.HasValue)
            return new BrotliStream(stream, compressionLevel ?? _compressionLevel.Value, true);

        else if (!_compressionLevel.HasValue && compressionLevel.HasValue)
            return new BrotliStream(stream, compressionLevel.Value, true);

        return new BrotliStream(stream, CompressionLevel.Fastest, true);

    }

    public Stream CreateDecompressionStream(Stream stream)
    {
        return new BrotliStream(stream, CompressionMode.Decompress);
    }
}
