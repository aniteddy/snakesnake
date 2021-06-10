using System;
using System.Collections.Generic;
using System.Text;

namespace snakesnake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls (int mapwidth, int mapHeight)
        {
            wallList = new List<Figure>();

            //отрисовка рамочки
            HorizontalLine upline = new HorizontalLine(0, mapwidth-2, 0, '+');
            HorizontalLine downline = new HorizontalLine(0, mapwidth - 2, mapHeight - 1, '+');
            VerticalLine leftline = new VerticalLine(0, mapHeight-1, 0, '+');
            VerticalLine rightline = new VerticalLine(0, mapHeight - 1, mapwidth - 2, '+');

            wallList.Add(upline);
            wallList.Add(downline);
            wallList.Add(leftline);
            wallList.Add(rightline);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Drow();
            }
        }
    }
}
