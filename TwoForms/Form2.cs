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
  public partial class Form2 : Form
  {
    Form1 f = null;

    public Form2(string title, Form1 form)
    {
      InitializeComponent();
      f = form;
      this.Text = title;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      f.Text = "Form2에서 변경";
    }

    private void button2_Click(object sender, EventArgs e)
    {
      // Form1의 label1을 modifier에서 public으로 변경
      f.label1.Text = this.textBox1.Text;
    }

    private void button3_Click(object sender, EventArgs e)
    {
      Common.shared = this.textBox1.Text;
    }
  }
}
