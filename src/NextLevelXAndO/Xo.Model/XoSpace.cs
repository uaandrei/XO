using System;

namespace Xo.Model
{
    public class XoSpace
    {
        private readonly XoPoint _position;
        private readonly XoTable _parent;
        private XoValue _value;

        public XoPoint Position
        {
            get
            {
                return _position;
            }
        }

        public XoValue Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public XoTable Parent
        {
            get
            {
                return _parent;
            }
        }

        public event EventHandler Marked;

        public XoSpace(XoPoint position, XoTable parent)
        {
            _position = position;
            _parent = parent;
        }

        public void Mark(Player player)
        {
            _value = player.Signature;
            RaiseOnMarkedEvent();
        }

        private void RaiseOnMarkedEvent()
        {
            if (Marked != null)
                Marked(this, EventArgs.Empty);
        }

        public override string ToString()
        {
            return string.Format("X:{0}, Y:{1}, Value: {2}", Position.X, Position.Y, Value);
        }
    }
}
