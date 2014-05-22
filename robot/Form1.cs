using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotApp
{
    public partial class Form1 : Form
        
    {


        public Form1()
        {
            InitializeComponent();
            
            robotPresenter p = new robotPresenter(5);
            robotView v = new robotView(p);
            
            this.Controls.Add(v);
        }

    }
}


