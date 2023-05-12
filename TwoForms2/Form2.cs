using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoForms2
{
  public partial class Form2 : Form
  {
    Form1 f = null;
    public Form2(Form1 form)
    {
      InitializeComponent();
      f = form;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      f.Show();
    }

    // Form2에서 Form1의 Text 변경
    private void button2_Click(object sender, EventArgs e)
    {
      f.Text = textBox1.Text;
    }

    private void button3_Click(object sender, EventArgs e)
    {
      // Form1의 label1의 Modifiers 속성을 public으로 바꾼 다음
      f.label1.Text = "label1.Text = " + textBox1.Text;
    }

    private void button4_Click(object sender, EventArgs e)
    {
      Common.str = textBox1.Text;
    }
  }
}
