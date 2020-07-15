using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    public partial class Game : Form
    {
        int horVelocity = 0;
        int verVelocity = 0;
        int step = 20;

        Area area = new Area();
        Snake snake = new Snake();

        Timer mainTimer = new Timer();
       

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            mainTimer.Interval = 500;
            mainTimer.Tick += new EventHandler(MainTimer_Tick);
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            snake.Move();
        }

        private void InitializeGame()
        {

            this.Height = 600;
            this.Width = 600;

            this.Controls.Add(area);
            area.Top = 100;
            area.Left = 100;

            //adding snake body
            snake.Render(this);

            //add keyboard controller handler
            this.KeyDown += new KeyEventHandler(Game_KeyDown);


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
                    if (snake.VerticalVelocity != -1)
                    {
                        snake.VerticalVelocity = 1;
                    }
                    snake.HorizontalVelocity = 0;
                    break;
                case Keys.Up:
                    if (snake.VerticalVelocity !=1)
                    {
                        snake.VerticalVelocity = -1;
                    }
                    snake.HorizontalVelocity = 0;
                    break;
            }
        }
        
    }
}
