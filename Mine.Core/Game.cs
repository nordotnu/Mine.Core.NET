using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace Mine.Core
{
    public class Game
    {
        public int Columns { get; set; }
        public int Row { get; set; }
        public int NumberOfMines { get; set; }
        public Field[,] Fields { get; set; }

        public Game(int columns, int row, int mines)
        {
            Columns = columns;
            Row = row;
            Fields = Creator.CreateGame(columns, row, mines);
            NumberOfMines = Creator.UsedBombs;
        }

        public Status Open(int col, int row)
        {
            if (col > Columns || row > Row || Fields[col, row].IsOpened)
                return Status.Error;
            if (Fields[col, row].Bomb)
                return Status.Lost;
            Fields = Fields[col, row].Open(Fields, Columns-1,Row-1);
            return DidIWin() ? Status.Won : Status.Ok;
        }

        private bool DidIWin()
        {
            var opened = 0;
            for (var i = 0; i < Columns -1; i++)
            {
                for (var j = 0; j < Row -1; j++)
                {
                    if (Fields[i, j].IsOpened == true)
                        opened++;
                }
            }
            return Columns * Row - NumberOfMines == opened;
        }
    }
}