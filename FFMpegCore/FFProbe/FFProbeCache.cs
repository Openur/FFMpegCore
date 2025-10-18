namespace FFMpegCore;

internal static class FFProbeCache
{
    private static readonly object _syncObject = new();
    private static Dictionary<string, FFProbePixelFormat>? _pixelFormats;

    public static IReadOnlyDictionary<string, FFProbePixelFormat> PixelFormats
    {
        get
        {
            if (_pixelFormats == null)
            {
                lock (_syncObject)
                {
                    _pixelFormats ??= FFProbe.GetPixelFormats().PixelFormats.ToDictionary(x => x.Name);
                }
            }

            return _pixelFormats;
        }
    }
}
