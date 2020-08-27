using System;
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
        public int HorizontalVelocity { get; set; } = 0;
        public int VerticalVelocity { get; set; } = 0;
        public int Step { get; set; } = 20;
        public int first = 1;


       public List<PictureBox> snakePixels = new List<PictureBox>();
        public Snake()
        {
            InitializeSnake();
        }

        private void InitializeSnake()
        {
           this.AddPixel(300, 300);
           this.AddPixel(300, 320);
           this.AddPixel(300, 340);
        }


        public void AddPixel(int left, int top)
        {
            PictureBox snakePixel;
            snakePixel = new PictureBox();
            snakePixel.Height = 20;
            snakePixel.Width = 20;
            snakePixel.Left = left;
            snakePixel.Top = top;
            string imageName = "0-10-1";
            snakePixel.Image = (Image)Properties.Resources.ResourceManager.GetObject(imageName);
            snakePixel.SizeMode = PictureBoxSizeMode.StretchImage;
            snakePixel.BackColor = Color.Transparent;
            snakePixel.BringToFront();
            snakePixels.Add(snakePixel);
        }

        public void AddPixel2(int left, int top)
        {
            PictureBox snakePixel;
            snakePixel = new PictureBox();
            snakePixel.Height = 20;
            snakePixel.Width = 20;
            snakePixel.Left = left;
            snakePixel.Top = top;
            snakePixel.Image = snakePixels[snakePixels.Count - 1].Image;
            snakePixel.SizeMode = PictureBoxSizeMode.StretchImage;
            snakePixel.BackColor = Color.Transparent;
            snakePixel.BringToFront();
            snakePixels.Add(snakePixel);
        }

        public void Render(Form form)
       {
           foreach (var sp in snakePixels)
          {
                form.Controls.Add(sp);
                sp.Parent = form;
                sp.BringToFront();
          }
        }

        public void Delete(Form form)
        {
            foreach (var sp in snakePixels)
            {
                form.Controls.Remove(sp);
            }
            snakePixels.Clear();
            this.AddPixel(300, 300);
            this.AddPixel(300, 320);
            this.AddPixel(300, 340);
        }

        public void Move()
        {
            if(this.HorizontalVelocity == 0 && this.VerticalVelocity == 0)
            {
                return;
            }

            for(int i = snakePixels.Count - 1; i > 0; i --)
            {
                snakePixels[i].Location = snakePixels[i - 1].Location;
                snakePixels[i].Image = snakePixels[i - 1].Image;
            }

            snakePixels[0].Left += this.HorizontalVelocity * this.Step;
            snakePixels[0].Top += this.VerticalVelocity * this.Step;
            if (first == 1)
            {
                snakePixels[0].Image = (Image)Properties.Resources.ResourceManager.GetObject(HorizontalVelocity.ToString() + VerticalVelocity.ToString());
            }

        }
    }
}
