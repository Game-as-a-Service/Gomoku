using Domain.Enum;

namespace Domain.Model
{
    public class Position
    {
        public Position()
        {
            
        }
        public Position(int row, int columns)
        {
            this.row = row;
            this.columns = columns;
        }
        public int row { get; set; }
        public int columns { get; set; }
    }
}
