using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Xo.Model
{
    [DataContract]
    public class XoTable : XoSpace
    {
        private readonly List<XoSpace> _xoSpaces;

        public List<XoSpace> XoSpaces
        {
            get
            {
                return _xoSpaces;
            }
        }

        public XoTable(XoPoint position)
            : base(position, null)
        {
            _xoSpaces = new List<XoSpace>();
        }

        public void AddSpace(XoSpace xoSpace)
        {
            XoSpaces.Add(xoSpace);
        }
    }
}
