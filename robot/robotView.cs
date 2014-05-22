using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RobotApp
{
    public partial class robotView : UserControl
    {
        const int _xOffset = 20;
        const int _yOffset = 100;
        const int _gridSize = 20;
        const int _eyeSize = 4;
        
        private robotPresenter _p;

        public robotView(robotPresenter p)
        {
            InitializeComponent();
            txtCmd.KeyDown += new KeyEventHandler(txtCmd_KeyDown);
            _p = p;    
        }
               
        private void DrawRobot(int x, int y, robotPresenter.direction f)
        {
            using (Graphics g = this.CreateGraphics())
            {
                //Setup Drawing
                System.Drawing.SolidBrush robotBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
                Pen facePen = new Pen(Color.White, 2);
                Pen borderPen = new Pen(Color.Black, 2);
                Brush brush = new SolidBrush(this.BackColor);
                System.Drawing.Graphics formGraphics = this.CreateGraphics();

                //Redraw Rectangle clearing previous drawing
                formGraphics.FillRectangle(brush, 20, 20, _gridSize * _p.GridNumber, _gridSize * _p.GridNumber);
                formGraphics.DrawRectangle(borderPen, 20, 20, _gridSize * _p.GridNumber, _gridSize * _p.GridNumber);

                //Calculate Cordinates
                x = x * _gridSize;
                y = y * _gridSize;

                if (_p.PosX >= 0 && _p.PosY >= 0) {
                    //Draw the Robot
                    formGraphics.FillEllipse(robotBrush, _xOffset + x, _yOffset - y, _gridSize, _gridSize);
                
                
                    //Draw the Eyes
                    if (f == robotPresenter.direction.North)
                    {
                            formGraphics.DrawEllipse(facePen, _xOffset + x + (_gridSize/4), _yOffset - y + (_gridSize/4), _eyeSize, _eyeSize);
                            formGraphics.DrawEllipse(facePen, _xOffset + x + ((_gridSize / 4) * 2), _yOffset - y + (_gridSize / 4), _eyeSize, _eyeSize);
                    }
                    else if (f == robotPresenter.direction.East)
                    { 
                            formGraphics.DrawEllipse(facePen, _xOffset + x + ((_gridSize / 4) * 2), _yOffset - y + (_gridSize / 4), _eyeSize, _eyeSize);
                            formGraphics.DrawEllipse(facePen, _xOffset + x + ((_gridSize / 4) * 2), _yOffset - y + ((_gridSize / 4) * 2), _eyeSize, _eyeSize);
                    }
                    else if (f == robotPresenter.direction.South)
                    {
                            formGraphics.DrawEllipse(facePen, _xOffset + x + (_gridSize / 4), _yOffset - y + ((_gridSize / 4) * 2), _eyeSize, _eyeSize);
                            formGraphics.DrawEllipse(facePen, _xOffset + x + ((_gridSize / 4) * 2), _yOffset - y + ((_gridSize / 4) * 2), _eyeSize, _eyeSize);
                    }
                    else if (f == robotPresenter.direction.West)
                    {
                            formGraphics.DrawEllipse(facePen, _xOffset + x + (_gridSize / 4), _yOffset - y + (_gridSize / 4), _eyeSize, _eyeSize);
                            formGraphics.DrawEllipse(facePen, _xOffset + x + (_gridSize / 4), _yOffset - y + ((_gridSize / 4) * 2), _eyeSize, _eyeSize);
                    }
                }

                //Clean up
                formGraphics.Dispose();
                facePen.Dispose();
                robotBrush.Dispose();
            }

        }

        private void txtCmd_KeyDown(object sender, KeyEventArgs e)
        {
            //Make hitting Enter, send command, redraw graphics and clear the text box.
            if (e.KeyCode == Keys.Enter) {
                lblOutput.Text = _p.Command(txtCmd.Text);
                DrawRobot(_p.PosX, _p.PosY, _p.PosFace);
                RaisePaintEvent(new object(), new PaintEventArgs(this.CreateGraphics(), new Rectangle()));
                txtCmd.Text = string.Empty;
            }
        }

    }
}
