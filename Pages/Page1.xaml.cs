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

namespace Pages
{
  /// <summary>
  /// Page1.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class Page1 : Page
  {
    public Page1()
    {
      InitializeComponent();
    }

    private void btnInfo_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Uri("/Email.xaml", UriKind.Relative));
    }

    private void btnLogin_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new Uri("/Login.xaml", UriKind.Relative));
    }

    private void btnSignUp_Click(object sender, RoutedEventArgs e)
    {
      NavigationService.Navigate(new Uri("/SignUp.xaml", UriKind.Relative));
    }
  }
}