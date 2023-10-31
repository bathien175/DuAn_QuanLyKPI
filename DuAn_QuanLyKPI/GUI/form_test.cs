using DuAn_QuanLyKPI.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.GUI
{
    public partial class form_test : Form
    {
        public form_test()
        {
            InitializeComponent();
            this.Controls.Add(new customTabcontrol());
        }
        private void LoadData()
        {
            var db = DataProvider.Ins.DB;
            gridChonTaiChinh.DataSource = db.KPI.ToList();
        }
    }
}
