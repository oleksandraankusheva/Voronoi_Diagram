using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2
{
    public partial class Form1 : Form
    {
        private List<Point> points = new List<Point>();
        private bool isMultiThreaded = false;
        private readonly object bmpLock = new object();
        public Form1()
        {
            InitializeComponent();

            this.panel1.MouseClick += new MouseEventHandler(this.panel1_MouseClick);
            this.clearButton.Click += new EventHandler(this.clearButton_Click);
            this.generateButton.Click += new EventHandler(this.generateButton_Click);
            this.randomButton.Click += new EventHandler(this.randomButton_Click);
            this.multiThreadCheckBox.CheckedChanged += new EventHandler(this.multiThreadCheckBox_CheckedChanged);
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                points.Add(e.Location);
                DrawPoint(e.Location);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Point? pointToRemove = points.FirstOrDefault(p => Distance(p, e.Location) < 5);
                if (pointToRemove != null)
                {
                    points.Remove(pointToRemove.Value);
                    panel1.Invalidate();
                    DrawPoints();
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            points.Clear();
            panel1.BackgroundImage = null; // Очистити фонове зображення панелі
            panel1.Invalidate(); // Перемалювати панель
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (points.Count > 1)
            {
                Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
                Graphics g = Graphics.FromImage(bmp);

                if (isMultiThreaded)
                {
                    int threads = 4;
                    int regionHeight = panel1.Height / threads;
                    List<Task> tasks = new List<Task>();

                    for (int i = 0; i < threads; i++)
                    {
                        int startY = i * regionHeight;
                        int endY = (i + 1) * regionHeight;
                        tasks.Add(Task.Run(() => GenerateVoronoiRegion(bmp, startY, endY)));
                    }

                    Task.WaitAll(tasks.ToArray());
                }
                else
                {
                    GenerateVoronoiRegion(bmp, 0, panel1.Height);
                }

                g.Dispose();
                panel1.BackgroundImage = bmp;
                DrawPoints();
            }
        }

        private void GenerateVoronoiRegion(Bitmap bmp, int startY, int endY)
        {
            for (int x = 0; x < panel1.Width; x++)
            {
                for (int y = startY; y < endY; y++)
                {
                    Point closest = GetClosestPoint(new Point(x, y));
                    lock (bmpLock)
                    {
                        bmp.SetPixel(x, y, GetColorForPoint(closest));
                    }
                }
            }
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int count = 40; // Кількість випадкових точок
            for (int i = 0; i < count; i++)
            {
                Point p = new Point(rand.Next(panel1.Width), rand.Next(panel1.Height));
                points.Add(p);
                DrawPoint(p);
            }
        }

        private void multiThreadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            isMultiThreaded = multiThreadCheckBox.Checked;
        }

        private void DrawPoints()
        {
            using (Graphics g = panel1.CreateGraphics())
            {
                foreach (var point in points)
                {
                    g.FillEllipse(Brushes.Red, point.X - 2, point.Y - 2, 4, 4);
                }
            }
        }

        private void DrawPoint(Point p)
        {
            using (Graphics g = panel1.CreateGraphics())
            {
                g.FillEllipse(Brushes.Red, p.X - 2, p.Y - 2, 4, 4);
            }
        }

        private Point GetClosestPoint(Point p)
        {
            Point closest = points[0];
            double minDist = Distance(p, closest);

            foreach (Point pt in points)
            {
                double dist = Distance(p, pt);
                if (dist < minDist)
                {
                    minDist = dist;
                    closest = pt;
                }
            }

            return closest;
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));
        }

        private Color GetColorForPoint(Point p)
        {
            Random rand = new Random(p.GetHashCode());
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }
    }
}
