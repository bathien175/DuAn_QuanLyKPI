using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI.Constants
{
    class customTabcontrol : TabControl
    {
        protected override void WndProc(ref Message m)
        {
            // 0x1300 là hằng số cho TCM_ADJUSTRECT, dùng để điều chỉnh phần đường viền của TabControl
            if (m.Msg == 0x1300)
            {
                m.Result = (IntPtr)1;
                return;
            }
            base.WndProc(ref m);
        }
    }
}
