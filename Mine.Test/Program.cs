using System;
using Mine.Core;

namespace Mine.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(10,10,50);
            for(var i = 0; i < game.Columns; i++)
            {
                for(var j = 0; j < game.Row; j++)
                {
                    Console.Write(game.Fields[i, j].Bomb ? $"| * |" : $"| {game.Fields[i, j].Number} {game.Fields[i, j].IsOpened}  |");
                }
                Console.Write("\n__________________________________________________\n");
            }
            Console.WriteLine("Column");
            var col = Console.ReadLine();
            Console.WriteLine("Row");
            var row = Console.ReadLine();
            Console.WriteLine(game.Open(Int32.Parse(col), Int32.Parse(row)));
            
            
            Console.ReadLine();
            
            for(var i = 0; i < game.Columns; i++)
            {
                for(var j = 0; j < game.Row; j++)
                {
                    if(game.Fields[i, j].Bomb)
                        Console.Write($"| * |");
                    else
                        Console.Write($"| {game.Fields[i, j].Number} {game.Fields[i, j].IsOpened}  |");
                }
                Console.Write("\n__________________________________________________\n");
            }
        }
    }
}