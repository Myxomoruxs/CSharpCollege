using System;
using System.Drawing;
using System.Windows.Forms;

namespace HouseDrawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.Text = "Рисуем домик";
            this.ClientSize = new Size(600, 500);
            this.BackColor = Color.LightBlue;
            this.Paint += Form1_Paint;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Рисуем фон
            DrawBackground(g);

            // Рисуем дом
            DrawHouse(g);

            // Рисуем солнце и облака
            DrawSunAndClouds(g);
        }

        private void DrawBackground(Graphics g)
        {
            // Небо
            g.FillRectangle(Brushes.SkyBlue, 0, 0, this.Width, this.Height * 2 / 3);

            // Трава
            g.FillRectangle(Brushes.LawnGreen, 0, this.Height * 2 / 3, this.Width, this.Height / 3);
        }

        private void DrawHouse(Graphics g)
        {
            // Основной дом
            Rectangle houseRect = new Rectangle(200, 200, 200, 150);
            g.FillRectangle(Brushes.Beige, houseRect);
            g.DrawRectangle(Pens.Brown, houseRect);

            // Крыша
            Point[] roofPoints = {
                new Point(200, 200),
                new Point(300, 120),
                new Point(400, 200)
            };
            g.FillPolygon(Brushes.DarkRed, roofPoints);
            g.DrawPolygon(Pens.Black, roofPoints);

            // Дверь
            Rectangle doorRect = new Rectangle(280, 280, 40, 70);
            g.FillRectangle(Brushes.SaddleBrown, doorRect);
            g.DrawRectangle(Pens.Black, doorRect);

            // Ручка двери
            g.FillEllipse(Brushes.Gold, 310, 315, 6, 6);

            // Окна
            DrawWindow(g, 220, 220);
            DrawWindow(g, 340, 220);
        }

        private void DrawWindow(Graphics g, int x, int y)
        {
            Rectangle windowRect = new Rectangle(x, y, 40, 40);
            g.FillRectangle(Brushes.LightYellow, windowRect);
            g.DrawRectangle(Pens.Black, windowRect);

            // Переплет окна
            g.DrawLine(Pens.Black, x, y + 20, x + 40, y + 20); // Горизонтальная линия
            g.DrawLine(Pens.Black, x + 20, y, x + 20, y + 40); // Вертикальная линия
        }

        private void DrawSunAndClouds(Graphics g)
        {
            // Солнце
            g.FillEllipse(Brushes.Yellow, 450, 50, 60, 60);

            // Облака
            DrawCloud(g, 100, 80);
            DrawCloud(g, 300, 60);
            DrawCloud(g, 200, 100);
        }

        private void DrawCloud(Graphics g, int x, int y)
        {
            g.FillEllipse(Brushes.White, x, y, 50, 30);
            g.FillEllipse(Brushes.White, x + 20, y - 10, 50, 30);
            g.FillEllipse(Brushes.White, x + 40, y, 50, 30);
            g.FillEllipse(Brushes.White, x + 20, y + 10, 50, 30);
        }
    }
}