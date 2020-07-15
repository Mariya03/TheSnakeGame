using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    class Food : PictureBox
    {
        public Food()
        {
            InitializeFood();
        }

        private void InitializeFood()
        {
            this.Width = 20;
            this.Height = 20;
            this.BackColor = Color.Green;
        }
    }
}
