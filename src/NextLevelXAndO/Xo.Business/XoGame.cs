using Xo.Model;

namespace Xo.Business
{
    public class XoGame
    {
        private readonly XoTable[,] _xoTables;
        private XoPoint _currentTable;
        private int _currentPlayer;

        public XoTable[,] Tables
        {
            get
            {
                return _xoTables;
            }
        }

        public XoGame(int currentPlayer)
        {
            _xoTables = new XoTable[3, 3];
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    _xoTables[i, j] = new XoTable();
                }
            }
            _currentTable = new XoPoint(0, 0);
            _currentPlayer = currentPlayer;
        }

        public void MarkCurrentTableOn(XoPoint pointToMark)
        {
            _xoTables[_currentTable.X, _currentTable.Y][pointToMark.X, pointToMark.Y] = (XoValue)_currentPlayer + 1;
            _currentPlayer = (_currentPlayer + 1) % 2;
            _currentTable = pointToMark;
        }
    }
}
