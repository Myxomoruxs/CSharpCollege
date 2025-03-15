﻿using FifteenGame.Common.Definitions;
using FifteenGame.Common.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenGame.Common.Dtos
{
    public class GameDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public CellsModel[,] Cells { get; set; } = new CellsModel[Constants.RowCount, Constants.ColumnCount];

        public int MoveCount { get; set; }

        public DateTime GameBegin { get; set; }
    }
}
