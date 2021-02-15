﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Models
{
    public struct GameboardPosition
    {

        public int Row { get; set; }

        public int Column { get; set; }

        public GameboardPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
