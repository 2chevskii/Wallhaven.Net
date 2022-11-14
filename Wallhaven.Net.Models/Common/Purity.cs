namespace Wallhaven.Net.Models.Common;

// Default is Sfw (100)
[Flags] public enum Purity { Nsfw = 1, Sketchy = 1 << 1, Sfw = 1 << 2 }
