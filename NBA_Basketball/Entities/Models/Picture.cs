using System;
using System.Collections.Generic;

namespace NBA_Basketball.Models;

public partial class Picture
{
    public int PicturesId { get; set; }

    public byte[]? Img { get; set; }

    public string? Description { get; set; }

    public int NumberOfLike { get; set; }

    public DateTime CreateTime { get; set; }
}
