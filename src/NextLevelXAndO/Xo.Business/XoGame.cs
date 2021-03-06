﻿using System.Collections.Generic;
using System.Runtime.Serialization;
using Xo.Model;

namespace Xo.Business
{
    [DataContract]
    public class XoGame
    {
        public List<XoTable> Tables
        {
            get;
            private set;
        }

        public List<XoSpace> Spaces
        {
            get;
            private set;
        }

        public XoGame()
        {
            SetupXoTables();
        }

        public void MarkSpace(XoSpace space, Player player)
        {
            space.Mark(player);
        }

        private void SetupXoTables()
        {
            Tables = new List<XoTable>();
            Spaces = new List<XoSpace>();
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var table = new XoTable(new XoPoint(i, j));
                    Tables.Add(table);
                    SetupSpacesForTable(table);
                }
            }
        }

        private void SetupSpacesForTable(XoTable table)
        {
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    var space = new XoSpace(new XoPoint(i, j), table);
                    table.AddSpace(space);
                    Spaces.Add(space);
                }
            }
        }
    }
}
