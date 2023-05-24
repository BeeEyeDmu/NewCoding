using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SnakeBiteWPF
{
  /// <summary>
  /// Game.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class Game : Window
  {
    Ellipse[] snakes = new Ellipse[30];
    Ellipse egg;
    Random r = new Random();
    private int visibleCount = 5;

    private string move = "";
    private int eaten = 0;
    DispatcherTimer timer = new DispatcherTimer();
    Stopwatch sw = new Stopwatch();
    private bool startFlag = false;
    private int size = 10;  // egg와 snakes의 크기

    public Game()
    {
      InitializeComponent();
      InitEgg();
      InitSnakes();

      timer.Interval = new TimeSpan(0, 0, 0, 0, 100); // 0.1초 마다
      timer.Tick += Timer_Tick; ;

    }

    private void Timer_Tick(object sender, EventArgs e)
    {
      if (startFlag == false)
      {
        startFlag = true;
      }
      else
      {
        for (int i = visibleCount; i >= 1; i--)     // 꼬리 하나를 더 계산해 둔다
        {
          Point p = (Point)snakes[i - 1].Tag;
          snakes[i].Tag = new Point(p.X, p.Y);
        }

        Point pnt = (Point)snakes[0].Tag;
        if (move == "R")
          snakes[0].Tag = new Point(pnt.X + size, pnt.Y);
        else if (move == "L")
          snakes[0].Tag = new Point(pnt.X - size, pnt.Y);
        else if (move == "U")
          snakes[0].Tag = new Point(pnt.X, pnt.Y - size);
        else if (move == "D")
          snakes[0].Tag = new Point(pnt.X, pnt.Y + size);

        EatEgg();   // 알을 먹었는지 체크
      }

    }

    private void EatEgg()
    {
      Point pS = (Point)snakes[0].Tag;
      Point pE = (Point)egg.Tag;

      if (pS.X == pE.X && pS.Y == pE.Y)
      {
        egg.Visibility = Visibility.Hidden;
        visibleCount++;
        snakes[visibleCount - 1].Visibility = Visibility.Visible;   // 꼬리를 하나 늘림
        txtScore.Text = "Eggs = " + (++eaten).ToString();

        if (visibleCount == 30)
        {
          timer.Stop();
          sw.Stop();
          Bites();
          TimeSpan ts = sw.Elapsed;
          string TimeElapsed = String.Format("Time = {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
          MessageBox.Show("Success!!!  " + TimeElapsed + " sec");
          this.Close();
        }

        Point p = new Point(r.Next(1, 480 / size) * size, r.Next(1, 380 / size) * size);
        egg.Tag = p;
        egg.Visibility = Visibility.Visible;
        Canvas.SetLeft(egg, p.X);
        Canvas.SetTop(egg, p.Y);
      }
    }

    private void Bites()
    {
      for (int i = 0; i < visibleCount; i++)
      {
        Point p = (Point)snakes[i].Tag;
        Canvas.SetLeft(snakes[i], p.X);
        Canvas.SetTop(snakes[i], p.Y);
      }
    }

    private void InitSnakes()
    {
      //int x = r.Next(0, 42);
      //int y = r.Next(0, 32);
      int x = r.Next(0, (int)(field.Width / size));
      int y = r.Next(0, (int)(field.Height / size));

      for (int i = 0; i < 30; i++)
      {
        snakes[i] = new Ellipse();
        snakes[i].Width = size;
        snakes[i].Height = size;
        if (i % 5 == 0)
          snakes[i].Fill = Brushes.Green;
        else
          snakes[i].Fill = Brushes.Gold;
        snakes[i].Stroke = Brushes.Black;
        field.Children.Add(snakes[i]);
        snakes[i].Tag = new Point(x * size, (y + i) * size);
        Canvas.SetLeft(snakes[i], x * size);
        Canvas.SetTop(snakes[i], (y + i) * size);
      }
      snakes[0].Fill = Brushes.Chocolate;
      for (int i = visibleCount; i < 30; i++)
        snakes[i].Visibility = Visibility.Hidden;
    }

    private void InitEgg()
    {
      egg = new Ellipse();
      egg.Width = size;
      egg.Height = size;
      egg.Stroke = Brushes.Black;
      egg.Fill = Brushes.Red;

      // Canvas의 크기: Width="420" Height="320"
      int x = r.Next(0, (int)(field.Width / size));
      int y = r.Next(0, (int)(field.Height / size));
      //int x = r.Next(0, 42);
      //int y = r.Next(0, 32);

      Point p = new Point(x * size, y * size); // Point 구조체로 저장
      egg.Tag = p;

      field.Children.Add(egg);
      Canvas.SetLeft(egg, x * size);
      Canvas.SetTop(egg, y * size);
    }

    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
      timer.Start();
      sw.Start();
      if (e.Key == Key.Left)
        move = "L";
      else if (e.Key == Key.Right)
        move = "R";
      else if (e.Key == Key.Up)
        move = "U";
      else if (e.Key == Key.Down)
        move = "D";
      else if (e.Key == Key.Escape)
      {
        move = "";
        timer.Stop();
      }

    }
  }

}

