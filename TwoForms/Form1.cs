using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoForms
{
  public partial class Form1 : Form
  {
    Form2 f;
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      f = new Form2("제목", this);  // form2에 form1 전달
      f.Show();     
    }

    private void button2_Click(object sender, EventArgs e)
    {
      label1.Text = f.textBox1.Text; // Modifier 속성을 public으로 변경
      MessageBox.Show(f.textBox1.Text); 
    }

    private void button3_Click(object sender, EventArgs e)
    {
      MessageBox.Show(Common.shared);
    }
  }

  public static class Common
  {
    public static string shared = "";
  }
}
