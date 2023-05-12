﻿using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TwoWindows
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void btnShow_Click(object sender, RoutedEventArgs e)
    {
      Window1 w = new Window1();
      w.Show();
    }

    private void btnShowDialog_Click(object sender, RoutedEventArgs e)
    {
      Window1 w = new Window1();
      w.ShowDialog();
    }
  }
}