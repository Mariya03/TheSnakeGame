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

        Food food2 = new Food();
        int ate = 0;
        int timing = 0;
        int food2check = 0;
        PictureBox food2level = new PictureBox();

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
            mainTimer.Interval = 200;
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            snake.Move();
            Check_Food();
            food2Check();
            SnakeFoodCollision();
            SnakeFood2Collision();
            SnakeBorderCollision();
            SnakeSelfCollision();
        }

        private void Check_Food()
        {
            if (snake.snakePixels[0].Location.X + 20 == food.Location.X && snake.snakePixels[0].Location.Y == food.Location.Y && snake.HorizontalVelocity == 1)
            {
                snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString() + "e");
                snake.second = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
            }
            if (snake.snakePixels[0].Location.X - 20 == food.Location.X && snake.snakePixels[0].Location.Y == food.Location.Y && snake.HorizontalVelocity == -1)
            {
                snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString() + "e");
                snake.second = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
            }
            if (snake.snakePixels[0].Location.X == food.Location.X && snake.snakePixels[0].Location.Y + 20 == food.Location.Y && snake.VerticalVelocity == 1)
            {
                snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString() + "e");
                snake.second = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
            }
            if (snake.snakePixels[0].Location.X == food.Location.X && snake.snakePixels[0].Location.Y - 20 == food.Location.Y && snake.VerticalVelocity == -1)
            {
                snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString() + "e");
                snake.second = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
            }
            if (food2.Visible == true)
            {
                if (snake.snakePixels[0].Location.X + 20 == food2.Location.X && snake.snakePixels[0].Location.Y == food2.Location.Y && snake.HorizontalVelocity == 1)
                {
                    snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString() + "e");
                    snake.second = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                }
                if (snake.snakePixels[0].Location.X - 20 == food2.Location.X && snake.snakePixels[0].Location.Y == food2.Location.Y && snake.HorizontalVelocity == -1)
                {
                    snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString() + "e");
                    snake.second = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                }
                if (snake.snakePixels[0].Location.X == food2.Location.X && snake.snakePixels[0].Location.Y + 20 == food2.Location.Y && snake.VerticalVelocity == 1)
                {
                    snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString() + "e");
                    snake.second = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                }
                if (snake.snakePixels[0].Location.X == food2.Location.X && snake.snakePixels[0].Location.Y - 20 == food2.Location.Y && snake.VerticalVelocity == -1)
                {
                    snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString() + "e");
                    snake.second = snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString();
                }
            }

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
            scorelabel.Width = 120;
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

            this.Controls.Add(food2);
            food2.BringToFront();
            food2.Image = (Image)Properties.Resources.ResourceManager.GetObject("food3");
            food2.Visible = false;

            food2level.Top = 50;
            food2level.Left = 250;
            food2level.Width = 250;
            food2level.Height = 35;
            food2level.BackColor = Color.Black;
            this.Controls.Add(food2level);
            food2level.Visible = false;
            SetFood2Location();
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
        private void RandomizeFood2Location()
        {
            food2.Top = 100 + rand.Next(0, 20) * 20;
            food2.Left = 100 + rand.Next(0, 20) * 20;
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

        private void food2Check()
        {
            if (ate == 5 && food2check == 0)
            {
                food2.Visible = true;
                food2level.Visible = true;
                food2check = 1;
                ate = 0;
            }
            if (food2check == 1 && timing < 25)
            {
                timing += 1;
                food2level.Width -= 10;
            }
            if (timing == 25)
            {
                timing = 0;
                food2.Visible = false;
                food2level.Visible = false;
                food2level.Width = 250;
                SetFood2Location();
                food2check = 0;
            }
        }

        private void SetFood2Location()
        {
            bool touch;
            do
            {
                RandomizeFood2Location();
                touch = false;
                foreach (var sp in snake.snakePixels)
                {
                    if (sp.Location == food2.Location)
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
                    snake.second = imageName1;
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
                    snake.second = imageName2;
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
                    snake.second = imageName3;
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
                    snake.second = imageName4;
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
                ate += 1;
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
              }
        }

        private void SnakeFood2Collision()
        {
            if (snake.snakePixels[0].Bounds.IntersectsWith(food2.Bounds) && food2.Visible == true)
            {
                //increase score
                score += 50;
                scorelabel.Text = score.ToString();
                //regenerate food
                lastfoodx = food2.Location.X;
                lastfoody = food2.Location.Y;
                ate = 0;
                SetFood2Location();
                timing = 0;
                food2.Visible = false;
                food2level.Visible = false;
                food2level.Width = 250;
                food2check = 0;

                //add pixels 
                int left = snake.snakePixels[snake.snakePixels.Count - 1].Left;
                int top = snake.snakePixels[snake.snakePixels.Count - 1].Top;
                snake.AddPixel2(left, top);
                snake.snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(snake.HorizontalVelocity.ToString() + snake.VerticalVelocity.ToString() + "f");
                snake.snakePixels[0].SizeMode = PictureBoxSizeMode.StretchImage;
                snake.snakePixels[0].BackColor = Color.Transparent;
                snake.Render(this);
            }
        }

        private void NewGameClick(object sender, EventArgs e)
        {
            snake.Delete(this);
            snake.Render(this);
            snake.HorizontalVelocity = 0;
            snake.VerticalVelocity = 0;
            ate = 0;
            food2check = 0;
            SetFood2Location();
            timing = 0;
            food2.Visible = false;
            food2level.Visible = false;
            food2level.Width = 250;
            score = 0;
            scorelabel.Text = score.ToString();
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
