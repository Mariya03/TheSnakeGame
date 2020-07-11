﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheSnakeGame
{
    class Snake
    {
        List<PictureBox> snakePixels = new List<PictureBox>();
        public Snake()
        {
            InitializeSnake();
        }

        private void InitializeSnake()
        {
            PictureBox snakePixel = new PictureBox();
            snakePixel.Height = 20;
            snakePixel.Width = 20;
            snakePixel.BackColor = Color.OrangeRed;
            snakePixels.Add(snakePixel);
        }

       public void Render(Form form)
       {
           foreach (var sp in snakePixels)
          {
               form.Controls.Add(sp);
          }
        }
    }
}