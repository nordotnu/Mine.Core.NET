using System;
using System.Linq;

namespace Mine.Core
{
    public static class Creator
    {
        public static int UsedBombs;
        public static Field[,] CreateGame(int columns, int row, int bombs) // Returns a 2D vector of a game. (Based on the given parameters)
        {
            UsedBombs = 0;
            var chance = 100 * bombs / (columns * row);
            var fields = new Field[columns, row];
            var random = new Random(); // Bombs are chance based and not static, random based on the bombs / column * row.
            for (var i = 0; i < columns; i++)
            {
                for (var j = 0; j < row; j++)
                {
                    fields[i, j] = new Field();
                    fields[i, j].Col = i;
                    fields[i, j].Row = j;
                    var result = random.Next(0, 101);
                    if (result < chance && UsedBombs < bombs) // if the chance hits then it's a bomb.
                    {
                        fields[i, j].Bomb = true;
                        UsedBombs++;
                    }
                    else
                    {
                        fields[i, j].Bomb = false;
                    }
                }
            }
            for(var i = 0; i < columns; i++) // Set the number for the field with not bomb.
            {
                for(var j = 0; j < row; j++)
                {
                    if (fields[i, j].Bomb) continue;
                    var surroundedFields = new bool[8];
                    if(j !=0 && i != columns-1 && j != row-1)
                        surroundedFields[0] = fields[i, j-1].Bomb; 
                    if(j !=0&& i != columns-1)
                        surroundedFields[1] = fields[i+1, j-1].Bomb; 
                    if(i != columns-1)
                        surroundedFields[2] = fields[i+1, j].Bomb; 
                    if(i != columns-1 && j != row-1)
                        surroundedFields[3] = fields[i+1, j+1].Bomb; 
                    if(j != row-1)
                        surroundedFields[4] = fields[i, j+1].Bomb;
                    if(i != 0 && j != row-1)
                        surroundedFields[5] = fields[i-1, j+1].Bomb;
                    if(i != 0 )
                        surroundedFields[6] = fields[i-1, j].Bomb; 
                    if(i != 0 && j != 0)
                        surroundedFields[7] = fields[i-1, j-1].Bomb; 
                    var number = surroundedFields.Count(b => b);

                    fields[i, j].Number = number;
                }
            }
            return fields;
        }
    }
}