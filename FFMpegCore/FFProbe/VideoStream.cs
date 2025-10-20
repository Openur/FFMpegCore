using System.Text.Json.Nodes;
using FFMpegCore.Enums;

namespace FFMpegCore;

public class VideoStream : MediaStream
{
    public decimal AvgFrameRate { get; set; }
    public int BitsPerRawSample { get; set; }
    public (int Width, int Height) DisplayAspectRatio { get; set; }
    public (int Width, int Height) SampleAspectRatio { get; set; }
    public string Profile { get; set; } = null!;
    public int Width { get; set; }
    public int Height { get; set; }
    public decimal FrameRate { get; set; }
    public string PixelFormat { get; set; } = null!;
    public int Level { get; set; }
    public int Rotation { get; set; }
    public decimal AverageFrameRate { get; set; }
    public string ColorRange { get; set; } = null!;
    public string ColorSpace { get; set; } = null!;
    public string ColorTransfer { get; set; } = null!;
    public string ColorPrimaries { get; set; } = null!;
    public List<Dictionary<string, JsonNode>> SideData { get; set; } = null!;

    public PixelFormat GetPixelFormatInfo()
    {
        return FFMpeg.GetPixelFormat(PixelFormat);
    }
}
