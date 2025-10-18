using System.Text.Json.Serialization;

namespace FFMpegCore;

public class FFProbePixelFormat
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("nb_components")]
    public int NbComponents { get; set; }

    [JsonPropertyName("log2_chroma_w")]
    public int Log2ChromaW { get; set; }

    [JsonPropertyName("log2_chroma_h")]
    public int Log2ChromaH { get; set; }

    [JsonPropertyName("bits_per_pixel")]
    public int BitsPerPixel { get; set; }

    [JsonPropertyName("flags")]
    public FFProbePixelFormatFlags Flags { get; set; } = null!;

    [JsonPropertyName("components")]
    public IReadOnlyList<FFProbePixelFormatComponent> Components { get; set; } = null!;
}

public class FFProbePixelFormatComponent
{
    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("bit_depth")]
    public int BitDepth { get; set; }
}

public class FFProbePixelFormatFlags
{
    [JsonPropertyName("big_endian")]
    public int BigEndian { get; set; }

    [JsonPropertyName("palette")]
    public int Palette { get; set; }

    [JsonPropertyName("bitstream")]
    public int Bitstream { get; set; }

    [JsonPropertyName("hwaccel")]
    public int Hwaccel { get; set; }

    [JsonPropertyName("planar")]
    public int Planar { get; set; }

    [JsonPropertyName("rgb")]
    public int Rgb { get; set; }

    [JsonPropertyName("alpha")]
    public int Alpha { get; set; }
}

public class FFProbePixelFormats
{
    [JsonPropertyName("pixel_formats")]
    public IReadOnlyList<FFProbePixelFormat> PixelFormats { get; set; } = null!;
}
