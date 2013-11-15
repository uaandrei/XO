namespace Xo.Model
{
    public class Player
    {
        private readonly XoValue _signature;

        public XoValue Signature
        {
            get
            {
                return _signature;
            }
        }

        public Player(XoValue signature)
        {
            _signature = signature;
        }
    }
}
