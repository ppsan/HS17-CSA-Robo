using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using RobotCtrl;

namespace RobotView
{
    public partial class LedView : UserControl
    {

        private bool state;
        private Led ledCtrl;

        public LedView()
        {
            InitializeComponent();
            state = false;
        }


        public bool State
        {
            get { return state; }
            set
            {
                state = value;
                ledPictureBox.Image = value ? Resource.LedOn : Resource.LedOff;
            }
        }

        public Led LedCtrl
        {
            set
            {

                ledCtrl = value;
                ledCtrl.LedStateChanged += LedCtrl_LedStateChanged;                
            }
        }

        private void LedCtrl_LedStateChanged(object sender, LedEventArgs e)
        {
            this.state = e.LedEnabled;
        }

        private void updateView()
        {
            this.ledPictureBox.Image = this.state ? Resource.LedOn : Resource.LedOff;
        }

        private void ledPictureBox_Click(object sender, EventArgs e)
        {
            //ledPictureBox.Image = ledPictureBox.Image == Resource.LedOn ? Resource.LedOff : Resource.LedOn;
        }
    }
}