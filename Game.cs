using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    public partial class Game : Form
    {
        // int horVelocity = 0;
        // int verVelocity = 0;
        // int step = 20;
        private int score = 0;
        Area area = new Area();
        Snake snake = new Snake();

        Timer mainTimer = new Timer();
        Food food = new Food();
        Random rand = new Random();
    
        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            mainTimer.Interval = 300;
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            snake.Move();
            SnakeFoodCollision();
            SnakeBorderCollision();
            SnakeSelfCollision();
        }

        //private void RandomizeFoodLocation()
      // {
            //food.Top = 100 + rand.Next(0, 20) * 20;
           // food.Left = 100 + rand.Next(0, 20) * 20;
        //}

       // private void MainTimer_Tick(object sender, EventArgs e)
       // {
          //  snake.Move();
           // SnakeFoodCollision();
           // SnakeBorderCollision();
           // SnakeSelfCollision();
        //}

        private void InitializeGame()
        {

            this.Height = 600;
            this.Width = 600;

            this.Controls.Add(area);
            area.Top = 100;
            area.Left = 100;

            //set score to 0
            score = 0;

            //adding snake body
            snake.Render(this);

            //adding food to the game
            this.Controls.Add(food);
            food.BringToFront();
           // RandomizeFoodLocation();
            SetFoodLocation();

            //add keyboard controller handler
            this.KeyDown += new KeyEventHandler(Game_KeyDown);

        }

        private void RandomizeFoodLocation()
        {
            food.Top = 100 + rand.Next(0, 20) * 20;
            food.Left = 100 + rand.Next(0, 20) * 20;
        }

        private void SetFoodLocation()
        {
            bool touch;
            do
            {
                RandomizeFoodLocation();
                touch = false;
                foreach (var sp in snake.snakePixels)
                {
                    if (sp.Location == food.Location)
                    {
                        touch = true;
                        break;
                    }
                }
            }
            while (touch);
        }
        private void SnakeBorderCollision()
        {
            if(!snake.snakePixels[0].Bounds.IntersectsWith(area.Bounds))
            {
                GameOver();
            }
        }

        private void SnakeSelfCollision()
        {
           for (int i = 1; i < snake.snakePixels.Count; i++)
            {
               if (snake.snakePixels[0].Bounds.IntersectsWith(snake.snakePixels[i].Bounds))
                {
                    GameOver();
                }
            }
        }

        private void GameOver()
        {
            mainTimer.Stop();
            snake.snakePixels[0].BackColor = Color.Red;
            snake.snakePixels[0].BringToFront();
            MessageBox.Show("Game over! Your score: " + score);
        }

        private void Game_KeyDown(object snder, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (snake.HorizontalVelocity != -1)
                    {
                        snake.HorizontalVelocity = 1;
                    }
                    snake.VerticalVelocity = 0;
                    break;
                case Keys.Left:
                    if (snake.HorizontalVelocity != 1)
                    {
                        snake.HorizontalVelocity = -1;
                    }
                    snake.VerticalVelocity = 0;
                    break;
                case Keys.Down:
                    snake.HorizontalVelocity = 0;
                    if (snake.VerticalVelocity != -1)
                    {
                        snake.VerticalVelocity = 1;
                    }
                    break;
                case Keys.Up:
                    snake.HorizontalVelocity = 0;
                    if (snake.VerticalVelocity !=1)
                    {
                        snake.VerticalVelocity = -1;
                    }
                    break;
                    
            }
        }

       // private void SetFoodLocation()
        //{
           // bool touch;
           // do
           // {
               // RandomizeFoodLocation();
               // touch = false;
              //  foreach (var sp in snake.snakePixels)
              //  {
                    //if (sp.Location == food.Location)
                    //{
                      //  touch = true;
                       // break;
                   // }
               // }
           // }
          //  while (touch);
       // }
        
        private void SnakeFoodCollision()
        {
            if(snake.snakePixels[0].Bounds.IntersectsWith(food.Bounds))
            {
                //increase score
                score += 10;
                //regenerate food
               
                SetFoodLocation();
               
                //add pixels 
                int left = snake.snakePixels[snake.snakePixels.Count - 1].Left;
                int top = snake.snakePixels[snake.snakePixels.Count - 1].Top;
                snake.AddPixel(left, top);
                snake.Render(this);
                //increase movement speed
                if (mainTimer.Interval >= 20)
                {
                    mainTimer.Interval -= 20;
                }
              }
           
        }

    }
}
