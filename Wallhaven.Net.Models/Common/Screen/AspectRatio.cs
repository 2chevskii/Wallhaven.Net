namespace Wallhaven.Net.Models.Common.Screen;

public readonly struct AspectRatio/* : IComparable,
                                     IComparable<AspectRatio>,
                                     IComparable<float>,
                                     IComparable<Resolution>,
                                     IEquatable<AspectRatio>,
                                     IFormattable*/
{
    public float Value { get; }

    private bool IsSpecialRatio => Value < 0;

    public AspectRatio(float value)
    {
        if ( value <= 0 ) { throw new ArgumentOutOfRangeException( nameof( value ) ); }

        Value = value;
    }

    public AspectRatio(int width, int height) : this( (float) width / height ) { }

    public AspectRatio(Resolution resolution) : this( resolution.Width, resolution.Height ) { }

    private AspectRatio(int specialValue) { throw new NotImplementedException(); }

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => throw new NotImplementedException();

    public static class All
    {
        // Known name: Landscape
        public static readonly AspectRatio Wide = new AspectRatio( -1 );
        // Known name: Portrait
        public static readonly AspectRatio Portrait = new AspectRatio( -2 );
    }

    public static class Ultrawide
    {
        public static readonly AspectRatio                _21x9 = new AspectRatio( 21, 9 );
        public static readonly AspectRatio                _32x9 = new AspectRatio( 32, 9 );
        public static readonly AspectRatio                _48x9 = new AspectRatio( 48, 9 );
        public static readonly IReadOnlyList<AspectRatio> All   = new[] {_21x9, _32x9, _48x9};

        public static bool Is(AspectRatio ratio) => ratio.Value is -1f or >= 1.78f;
    }

    public static class Wide
    {
        public static readonly AspectRatio _16x9  = new AspectRatio( 16, 9 );
        public static readonly AspectRatio _16x10 = new AspectRatio( 16, 10 );

        public static readonly IReadOnlyList<AspectRatio> All = new[] {_16x9, _16x9};

        public static bool Is(AspectRatio ratio) => ratio.Value is -1f or > 1.5f and < 1.78f;
    }

    public static class Portrait
    {
        public static readonly AspectRatio _9x16  = new AspectRatio( 9, 16 );
        public static readonly AspectRatio _10x16 = new AspectRatio( 10, 16 );
        public static readonly AspectRatio _9x18  = new AspectRatio( 9, 18 );

        public static readonly IReadOnlyList<AspectRatio> All = new[] {_9x16, _10x16, _9x18};

        public static bool Is(AspectRatio ratio) => ratio.Value is -2f or < 1f;
    }

    public static class Square
    {
        public static readonly AspectRatio _1x1 = new AspectRatio( 1, 1 );
        public static readonly AspectRatio _3x2 = new AspectRatio( 3, 2 );
        public static readonly AspectRatio _4x3 = new AspectRatio( 4, 3 );
        public static readonly AspectRatio _5x4 = new AspectRatio( 5, 4 );

        public static readonly IReadOnlyList<AspectRatio> All = new[] {_1x1, _3x2, _4x3, _5x4};

        public static bool Is(AspectRatio ratio) => ratio.Value is >= 1f and <= 1.5f;
    }
}
