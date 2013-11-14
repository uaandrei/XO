namespace Xo.Model
{
    public class XoTable
    {
        private readonly int[,] _xoMatrix;
        private readonly XoValue _state;

        public readonly int Length = 3;

        public XoValue State
        {
            get
            {
                return _state;
            }
        }

        public XoValue this[int i, int j]
        {
            get
            {
                return (XoValue)_xoMatrix[i, j];
            }
            set
            {
                _xoMatrix[i, j] = (int)value;
            }
        }

        public XoTable()
        {
            _xoMatrix = new int[Length, Length];
            _state = XoValue.FreeSpace;
        }
    }
}
