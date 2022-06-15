using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Snake
{
    public class Field
    {
        private Random _rand;
        private int _rows;
        private int _cols;
        private Snake _snake;
        private Food _food;

        private List<Barrier> _barriers;
        private int _barriersCount;
        private Difficulty _difficulty;

        public List<Point> BarriersPostions => _barriers.Select(bar => bar.Position).ToList(); // выборка
        public List<Point> SnakePosition => _snake.Coords;
        public Point FoodPosition => _food.Position;

        public Direction SnakeDirection
        {
            get => _snake.CurrentDirection;
            set
            {
                _snake.Turn(value);
            }
        }
        public int Rows
        {
            get => _rows;
            set
            {
                if (value < 10) value = 10;
                if (value > 100) value = 100;
                _rows = value;
            }
        }

        public int Columns
        {
            get => _cols;
            set
            {
                if (value < 10) value = 10;
                if (value > 100) value = 100;
                _cols = value;
            }
        }

        public Field(Difficulty difficulty) : this(difficulty, 30, 30)
        {
        }

        public Field(Difficulty difficulty, int rows, int cols)
        {
            _difficulty = difficulty;
            Rows = rows;
            Columns = cols;
            _barriers = new List<Barrier>();
            _rand = new Random((int)DateTime.Now.Ticks);
            _snake = new Snake(new Point(_rand.Next(3, Rows - 3), _rand.Next(3, Columns - 3)));
            NewFood();
			switch (_difficulty)
			{
				case Difficulty.Easy:
                    _barriersCount = 0;
					break;
				case Difficulty.Medium:
                    _barriersCount = 10;
					break;
				case Difficulty.Hard:
                    _barriersCount = 25;
                    break;
				default:
					break;
			}
			CreateBarriers();
        }

        private void NewFood()
        {
            do
            {
                _food = new Food(_rand.Next(3, Rows - 3), _rand.Next(3, Columns - 3));
            } while (_snake.Contains(_food.Position));
        }
        public void NextStep()
        {
            _snake.Crawl();
            if (_snake.Ate(_food))
            {
                _snake.Grow();
                NewFood();
            }
            if (_snake.Die(_barriers))
			{
				System.Windows.Forms.MessageBox.Show("Вы проиграли");
			}
        }
        private void CreateBarriers()
		{
            for (int i = 0; i < _barriersCount; i++)
            {
                Barrier newBarrier = new Barrier(_rand.Next(3, Rows - 3), _rand.Next(3, Columns - 3));
                while (_snake.Contains(newBarrier.Position) || newBarrier.Position == _food.Position) 
				{
                    newBarrier.Position = new Point(_rand.Next(3, Rows - 3), _rand.Next(3, Columns - 3));
                }
                _barriers.Add(newBarrier);
            } 
		}
    }
}