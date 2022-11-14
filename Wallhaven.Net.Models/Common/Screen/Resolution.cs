namespace Wallhaven.Net.Models.Common.Screen;

public readonly struct Resolution
{
    public int Width { get; }
    public int Height { get; }

    public Resolution(int width, int height)
    {
        if ( width <= 0 )
            throw new ArgumentOutOfRangeException( nameof( width ) );

        if ( height <= 0 )
            throw new ArgumentOutOfRangeException( nameof( height ) );

        Width  = width;
        Height = height;
    }

    public override string ToString() => throw new NotImplementedException();

    public static class Ultrawide
    {
        public static readonly Resolution _2560x1080 = new Resolution( 2560, 1080 );
        public static readonly Resolution _3440x1440 = new Resolution( 3440, 1440 );
        public static readonly Resolution _3840x1600 = new Resolution( 3840, 1600 );

        public static readonly IReadOnlyCollection<Resolution> All = new[] {
            _2560x1080, _3440x1440, _3840x1600
        };
    }

    public static class Wide
    {
        public static readonly Resolution _1280x720  = new Resolution( 1280, 720 );
        public static readonly Resolution HD         = _1280x720;
        public static readonly Resolution _1600x900  = new Resolution( 1600, 900 );
        public static readonly Resolution HDPlus     = _1600x900;
        public static readonly Resolution _1920x1080 = new Resolution( 1920, 1080 );
        public static readonly Resolution FullHD     = _1920x1080;
        public static readonly Resolution _2560x1440 = new Resolution( 2560, 1440 );
        public static readonly Resolution QuadHD     = _2560x1440;
        public static readonly Resolution _3840x2160 = new Resolution( 3840, 2160 );
        public static readonly Resolution UltraHD    = _3840x2160;

        public static readonly IReadOnlyCollection<Resolution> All = new[] {
            _1280x720, _1600x900, _1920x1080, _2560x1440, _3840x2160
        };
    }

    public static class _16x10
    {
        public static readonly Resolution _1280x800  = new Resolution( 1280, 800 );
        public static readonly Resolution _1600x1000 = new Resolution( 1600, 1000 );
        public static readonly Resolution _1920x1200 = new Resolution( 1920, 1200 );
        public static readonly Resolution _2560x1600 = new Resolution( 2560, 1600 );
        public static readonly Resolution _3840x2400 = new Resolution( 3840, 2400 );

        public static readonly IReadOnlyCollection<Resolution> All = new[] {
            _1280x800, _1600x1000, _1920x1200, _2560x1600, _3840x2400
        };
    }

    public static class _4x3
    {
        public static readonly Resolution _1280x800  = new Resolution( 1280, 800 );
        public static readonly Resolution _1600x1200 = new Resolution( 1600, 1200 );
        public static readonly Resolution _1920x1440 = new Resolution( 1920, 1440 );
        public static readonly Resolution _2560x1920 = new Resolution( 2560, 1920 );
        public static readonly Resolution _3840x2880 = new Resolution( 3840, 2880 );

        public static readonly IReadOnlyCollection<Resolution> All = new[] {
            _1280x800, _1600x1200, _1920x1440, _2560x1920, _3840x2880
        };
    }

    public static class _5x4
    {
        public static readonly Resolution _1280x1024 = new Resolution( 1280, 1024 );
        public static readonly Resolution _1600x1280 = new Resolution( 1600, 1280 );
        public static readonly Resolution _1920x1536 = new Resolution( 1920, 1536 );
        public static readonly Resolution _2560x2048 = new Resolution( 2560, 2048 );
        public static readonly Resolution _3840x3072 = new Resolution( 3840, 3072 );

        public static readonly IReadOnlyCollection<Resolution> All = new[] {
            _1280x1024, _1600x1280, _1920x1536, _2560x2048, _3840x3072
        };
    }
}
