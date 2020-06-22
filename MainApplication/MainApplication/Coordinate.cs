using System.ComponentModel;

namespace MainApplication
{
    //this is where the magic starts
    [TypeConverter(typeof(CoordinateConverter))]
    public struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public override string ToString()
        {
            return X.ToString() + ", " + Y.ToString();
        }
    }
}
