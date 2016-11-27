using PAO.Event;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormTest
{
    public partial class EventTestForm : Form
    {
        public EventTestForm() {
            InitializeComponent();
        }

        public void Initialize(EventInfo eventInfo) {
            EventControl.Initialize(eventInfo);
        }
    }
}
