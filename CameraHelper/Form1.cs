using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CameraHelper
{
    public partial class CameraHelp : Form
    {
        public CameraHelp()
        {
            InitializeComponent();
        }

        private double arctan(double tanValue2)
        {
            double tanRadianValue2 = Math.Atan(tanValue2);//求弧度值
            return tanRadianValue2 / Math.PI * 180;//求角度
        }


        private void DistTracker_Scroll(object sender, EventArgs e)
        {
            this.DistValue.Text = DistTracker.Value.ToString();
        }

        private void Ftracker_Scroll(object sender, EventArgs e)
        {
            this.Fvalue.Text = Ftracker.Value.ToString();
        }


        private void FOVCal()
        {
            double imageH = double.Parse(ViewH.Text) * double.Parse(UnitSize.Text)/1000;
            double imageW = double.Parse(ViewV.Text) * double.Parse(UnitSize.Text) / 1000;
            float f = float.Parse(textBox2.Text);
            double temp = imageH / 2 / f;
            AngleH.Text = (2 * arctan(temp)).ToString();
            temp = imageW / 2 / f;
            AngleW.Text = (2 * arctan(temp)).ToString();
            FOVH.Text = ((double.Parse(DistValue.Text)* imageH)/f).ToString();
            FOVV.Text = ((double.Parse(DistValue.Text) * imageW) / f).ToString();
        }

        private void DOFCal()
        {
            double imageH = double.Parse(ViewH.Text) * double.Parse(UnitSize.Text) / 1000;
            double imageW = double.Parse(ViewV.Text) * double.Parse(UnitSize.Text) / 1000;
            float f = float.Parse(textBox2.Text);
            float L = float.Parse(DistValue.Text);
            float F = float.Parse(Fvalue.Text);
            float theta = float.Parse(Theta.Text);
            double front = (F * theta * L * L) / (f * f + F * theta * L);
            double back = (F * theta * L * L) / (f * f - F * theta * L);
            double total = front + back;

            DOFfront.Text = front.ToString();
            DOFback.Text = back.ToString();
            DOF.Text = total.ToString();
        }

        private void calcue_Click(object sender, EventArgs e)
        {
            FOVCal();
            DOFCal();
        }
    }
}
