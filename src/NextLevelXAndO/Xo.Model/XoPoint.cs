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

        public XoPoint(int x, int y)
            : this()
        {
            X = x;
            Y = y;
        }
    }
}
