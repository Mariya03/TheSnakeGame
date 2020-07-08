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
        Area area = new Area();
       

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeSnake();
        }

        private void InitializeGame()
        {

            this.Height = 600;
            this.Width = 600;

            this.Controls.Add(area);
            area.Top = 100;
            area.Left = 100;
            //area.Location = new Point(100, 100);
            
        }
         private void InitializeSnake()
        {
            PictureBox snake = new PictureBox();
            Controls.Add(snake);
        }
    }
}
