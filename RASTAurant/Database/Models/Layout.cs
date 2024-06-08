using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RASTAurant.Database.Models
{

    public class Layout
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TablePosition> TablePositions { get; set; }

        public Layout()
        {
            TablePositions = new List<TablePosition>();
        }
    }

    public class TablePosition
    {
        public int Id { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public TablePosition(int id, int x, int y)
        {
            Id = id;
            X = x;
            Y = y;
        }

        public TablePosition(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
