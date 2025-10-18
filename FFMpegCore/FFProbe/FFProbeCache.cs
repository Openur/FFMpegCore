namespace FFMpegCore;

internal static class FFProbeCache
{
    private static readonly object _syncObject = new();
    private static readonly Dictionary<string, Dictionary<string, FFProbePixelFormat>> _pixelFormats = new();

    public static IReadOnlyDictionary<string, FFProbePixelFormat> PixelFormats(FFOptions ffOptions)
    {
        return Get(_pixelFormats, ffOptions, options => FFProbe.GetPixelFormats(options).PixelFormats.ToDictionary(format => format.Name));
    }

    private static IReadOnlyDictionary<string, TValue> Get<TValue>(Dictionary<string, Dictionary<string, TValue>> cache,
        FFOptions ffOptions, Func<FFOptions, Dictionary<string, TValue>> load)
    {
        var binaryPath = GlobalFFOptions.GetFFProbeBinaryPath(ffOptions);

        lock (_syncObject)
        {
            if (!cache.TryGetValue(binaryPath, out var entries))
            {
                entries = load(ffOptions);
                cache[binaryPath] = entries;
            }

            return entries;
        }
    }
}
