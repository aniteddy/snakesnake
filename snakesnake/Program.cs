using System;
using System.Collections.Generic;
using System.Threading;

namespace snakesnake
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.SetBufferSize(80, 25);

            Point p = new Point(4, 5, '*');
            p.draw();
            Walls walls = new Walls(80, 25);
            walls.Draw();

            

            //Отрисовка змеи
            Snake snake = new Snake( p, 4, Direction.RIGHT);
            snake.Drow();

            FoodCreator foodCreator = new FoodCreator(80, 25, '#');
            Point food = foodCreator.CreateFood();
            food.draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);
            
            
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
                Thread.Sleep(100);
                snake.Move();
            }

            
            
        }

    }
}
