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
        Label scorelabel = new Label();
        int pause = 0;
        int lastfoodx = 0;
        int lastfoody = 0;


        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            mainTimer.Interval = 100;
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
            this.Width = 615;
            this.BackColor = Color.OliveDrab;

            PictureBox lp = new PictureBox();
            lp.Height = 412;
            lp.Width = 3;
            lp.Top = 94;
            lp.Left = 94;
            lp.BackColor = Color.Black;
            this.Controls.Add(lp);
            lp.BringToFront();
            PictureBox rp = new PictureBox();
            rp.Height = 412;
            rp.Width = 3;
            rp.Top = 94;
            rp.Left = 503;
            rp.BackColor = Color.Black;
            this.Controls.Add(rp);
            rp.BringToFront();
            PictureBox up = new PictureBox();
            up.Height = 3;
            up.Width = 406;
            up.Top = 94;
            up.Left = 97;
            up.BackColor = Color.Black;
            this.Controls.Add(up);
            up.BringToFront();
            PictureBox dp = new PictureBox();
            dp.Height = 3;
            dp.Width = 406;
            dp.Top = 503;
            dp.Left = 97;
            dp.BackColor = Color.Black;
            this.Controls.Add(dp);
            dp.BringToFront();

            this.Controls.Add(area);
            area.Top = 100;
            area.Left = 100;
            area.Parent = this;

            //set score to 0
            score = 0;
            scorelabel.Font = new Font("Digital-7", 36);
            scorelabel.Width = 150;
            scorelabel.Height = 50;
            scorelabel.Text = score.ToString();
            scorelabel.Top = 45;
            scorelabel.Left = 85;
            this.Controls.Add(scorelabel);

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
            snake.first = 0;
            switch (e.KeyCode)
            {
                case Keys.Right:
                    string imageName1 = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                    if (snake.HorizontalVelocity != -1)
                    {
                        snake.HorizontalVelocity = 1;
                    }
                    snake.VerticalVelocity = 0;
                    imageName1 += snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                    if (snake.snakePixels[0].Location.X == lastfoodx && snake.snakePixels[0].Location.Y == lastfoody)
                    {
                        imageName1 += "f";
                        lastfoodx = -1;
                        lastfoody = -1;
                    }
                    snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName1);
                    snake.snakePixels[0].SizeMode = PictureBoxSizeMode.StretchImage;
                    snake.snakePixels[0].BackColor = Color.Transparent;
                    snake.first = 1;
                    break;
                case Keys.Left:
                    string imageName2 = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                    if (snake.HorizontalVelocity != 1)
                    {
                        snake.HorizontalVelocity = -1;
                    }
                    snake.VerticalVelocity = 0;
                    imageName2 += snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                    if (snake.snakePixels[0].Location.X == lastfoodx && snake.snakePixels[0].Location.Y == lastfoody)
                    {
                        imageName2 += "f";
                        lastfoodx = -1;
                        lastfoody = -1;
                    }
                    snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName2);
                    snake.snakePixels[0].SizeMode = PictureBoxSizeMode.StretchImage;
                    snake.snakePixels[0].BackColor = Color.Transparent;
                    snake.first = 1;
                    break;
                case Keys.Down:
                    string imageName3 = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                    snake.HorizontalVelocity = 0;
                    if (snake.VerticalVelocity != -1)
                    {
                        snake.VerticalVelocity = 1;
                    }
                    imageName3 += snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                    if (snake.snakePixels[0].Location.X == lastfoodx && snake.snakePixels[0].Location.Y == lastfoody)
                    {
                        imageName3 += "f";
                        lastfoodx = -1;
                        lastfoody = -1;
                    }
                    snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName3);
                    snake.snakePixels[0].SizeMode = PictureBoxSizeMode.StretchImage;
                    snake.snakePixels[0].BackColor = Color.Transparent;
                    snake.first = 1;
                    break;
                case Keys.Up:
                    string imageName4 = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                    snake.HorizontalVelocity = 0;
                    if (snake.VerticalVelocity !=1)
                    {
                        snake.VerticalVelocity = -1;
                    }
                    imageName4 += snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                    if (snake.snakePixels[0].Location.X == lastfoodx && snake.snakePixels[0].Location.Y == lastfoody)
                    {
                        imageName4 += "f";
                        lastfoodx = -1;
                        lastfoody = -1;
                    }
                    snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName4);
                    snake.snakePixels[0].SizeMode = PictureBoxSizeMode.StretchImage;
                    snake.snakePixels[0].BackColor = Color.Transparent;
                    snake.first = 1;
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
                scorelabel.Text = score.ToString();
                //regenerate food
                lastfoodx = food.Location.X;
                lastfoody = food.Location.Y;
                SetFoodLocation();
               
                //add pixels 
                int left = snake.snakePixels[snake.snakePixels.Count - 1].Left;
                int top = snake.snakePixels[snake.snakePixels.Count - 1].Top;
                snake.AddPixel2(left, top);
                snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString() + "f");
                snake.snakePixels[0].SizeMode = PictureBoxSizeMode.StretchImage;
                snake.snakePixels[0].BackColor = Color.Transparent;
                snake.Render(this);
                //increase movement speed
                /*if (mainTimer.Interval >= 20)
                {
                    mainTimer.Interval -= 20;
                }*/
              }
           
        }

        private void NewGameClick(object sender, EventArgs e)
        {
            snake.Delete(this);
            snake.Render(this);
            snake.HorizontalVelocity = 0;
            snake.VerticalVelocity = 0;
            mainTimer.Start();
        }

        private void Pause(object sender, EventArgs e)
        {
            if (pause == 0)
            {
                mainTimer.Stop();
                pause = 1;
            } else
            {
                mainTimer.Start();
                pause = 0;
            }
        }
    }
}
