using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
	public class Barrier
	{
        private Point _position;
        public Point Position
        {
            get => _position;
            set => _position = value;
        }
        public Barrier(int row, int col)
        {
            _position = new Point(row, col);
        }

        public Barrier(Point position)
        {
            _position = position;
        }
    }
}
