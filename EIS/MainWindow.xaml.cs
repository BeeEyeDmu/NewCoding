using System;
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
using System.Data;
using MySql.Data.MySqlClient;

namespace EIS
{
  /// <summary>
  /// MainWindow.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class MainWindow : Window
  {
    string pos = "";
    string dept = "";
    string gender = "";
    string dateEnter = "";
    string dateExit = "";

    string connStr = "server=localhost; user id=root; password=kang32837!; database=eis_db";
    MySqlConnection conn = null;
    public MainWindow()
    {
      InitializeComponent();

      
    }

    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
      if (rbMale.IsChecked == true)
        gender = "남성";
      else if (rbFeMale.IsChecked == true)
        gender = "여성";
       
      if(dpEnter.SelectedDate != null)
        dateEnter = dpEnter.SelectedDate.Value.Date.ToShortDateString();
      if (dpExit.SelectedDate != null)
        dateExit = dpExit.SelectedDate.Value.Date.ToShortDateString();
      else
        dateExit = DateTime.MaxValue.ToShortDateString();

      MessageBox.Show(gender + dept + pos + "\n" + dateEnter + "\n" + dateExit);

      conn = new MySqlConnection(connStr);
      conn.Open();

      //string connStr = "server=localhost; user id=root; password=; database=eis_db";
      string sql = string.Format("INSERT INTO eis_table (name, department, position, gender, date_enter, date_exit, contact, comment) "
        + "VALUES ('{0}', '{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
        txtName.Text, dept, pos, gender, dateEnter, dateExit, txtContact.Text, txtComment.Text);

      MySqlCommand cmd = new MySqlCommand(sql, conn);
      if (cmd.ExecuteNonQuery() == 1)
        MessageBox.Show("Inserted successfully!");

      conn.Close();
      InitControls();
    }

    private void InitControls()
    {
      txtEid.Text = "";
      txtName.Text = "";
      txtContact.Text = "";
      txtComment.Text = "";
      cbDept.SelectedIndex = -1;
      cbPos.SelectedIndex = -1;
      rbMale.IsChecked = false;
      rbMale.IsChecked = false;
      dpEnter.Text = "";
      dpExit.Text = "";
    }

    private void cbDept_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      ComboBox cb = sender as ComboBox;
      if(cb.SelectedIndex != -1)
        dept = ((ComboBoxItem)(cb.SelectedItem)).Content.ToString();
    }

    private void cbPos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      ComboBox cb = sender as ComboBox;
      if (cb.SelectedIndex != -1)
      {
        ComboBoxItem cbPos = cb.SelectedItem as ComboBoxItem;
        pos = cbPos.Content.ToString();
      }
    }

    private void btnUpdate_Click(object sender, RoutedEventArgs e)
    {
      cbDept.SelectedIndex = -1;
      cbPos.SelectedIndex = -1;
    }

    private void btnLoadData_Click(object sender, RoutedEventArgs e)
    {
      conn = new MySqlConnection(connStr);
      conn.Open();

      string sql = "SELECT * FROM eis_table";

      try
      {
        //MySqlCommand cmd = new MySqlCommand(sql, conn);
        //MySqlDataAdapter da = new MySqlDataAdapter();
        //da.SelectCommand = cmd;
        //DataTable dt = new DataTable();
        //da.Fill(dt);
        //dataGrid.DataContext = dt;
        MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
        DataSet ds = new DataSet();
        da.Fill(ds);
        dataGrid.ItemsSource = ds.Tables[0].DefaultView;
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.Message);
      }

      conn.Close();
    }
  }
}
