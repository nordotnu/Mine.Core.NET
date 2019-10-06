using System.Threading;
using System.Threading.Tasks;

namespace Mine.Core
{
    public class Field
    {
        public int Col { get; set; }
        public int Row { get; set; }
        public bool Bomb { get; set; }
        public int Number { get; set; }
        public bool IsOpened { get; set; } = false;

        public Field[,] Open(Field[,] fields, int maxCol, int maxRow)
        {
            
            if (Bomb != false || IsOpened != false) return fields;
            IsOpened = true;
            if (Number != 0) return fields;
            if (Row != 0 && Col != maxCol && Row != maxRow) 
                fields[Col, Row - 1].Open(fields, maxCol, maxRow);
            if (Row != 0 && Col != maxCol)
                fields[Col + 1, Row - 1].Open(fields, maxCol, maxRow);
                            
            if (Col != maxCol)
                fields[    Col + 1, Row].Open(fields, maxCol, maxRow);
                        
            if (Col != maxCol && Row != maxRow)
                fields[Col + 1, Row + 1].Open(fields, maxCol, maxRow);
                            
            if (Row != maxRow)
                fields[    Col, Row + 1].Open(fields, maxCol, maxRow);
                        
            if (Col != 0 && Row != maxRow)
                fields[Col - 1, Row + 1].Open(fields, maxCol, maxRow);
                            
            if (Col != 0)
                fields[    Col - 1, Row].Open(fields, maxCol, maxRow);
                        
            if (Col != 0 && Row != 0)
                fields[Col - 1, Row - 1].Open(fields, maxCol, maxRow);
            return fields;
        }
    }
}