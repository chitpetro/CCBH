using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;

namespace GUI.Report.Gridcontrol
{
    public partial class r_vertical : DevExpress.XtraReports.UI.XtraReport
    {
        public r_vertical()
        {
            InitializeComponent();
        }

        private GridControl control;
        public GridControl GridControl
        {
            get
            {
                return control;
            }
            set
            {
                control = value;
                xuatbc.PrintableComponent = control;
            }
        }

    }
}
