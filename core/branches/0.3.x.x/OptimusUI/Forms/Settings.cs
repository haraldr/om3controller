using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OptimusUI.Forms
{
  public partial class Settings : Form
  {
    public Settings()
    {
      InitializeComponent();
    }

    private void labelContrast_Click(object sender, EventArgs e)
    {

    }

    private void checkBox3_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void labelBackgroundColor_Click(object sender, EventArgs e)
    {
      ColorDialog lDialog = new ColorDialog();
      lDialog.ShowDialog(this);
      lDialog.Dispose();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {

    }
  }
}