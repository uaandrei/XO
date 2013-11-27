namespace Xo.Model
{
    public struct XoPoint
    {
        public int X
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public XoValue Value
        {
            get;
            set;
        }

        public XoPoint(int x, int y)
            : this()
        {
            X = x;
            Y = y;
            Value = XoValue.FreeSpace;
        }

        public static bool operator ==(XoPoint a, XoPoint b)
        {
            return a.X == b.X && a.Y == b.Y;
        }

        public static bool operator !=(XoPoint a, XoPoint b)
        {
            return !(a == b);
        }
    }
}
