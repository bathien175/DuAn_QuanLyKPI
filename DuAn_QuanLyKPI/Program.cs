using DuAn_QuanLyKPI.GUI;
using PhanMemQuanLyKPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuAn_QuanLyKPI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //Khai báo biến để hạn chế mở phần mềm 2 lần cùng lúc 
        public static Frm_Chinh_GUI MainForm;
        public const int ALLOW_INSTANCE = 1;
        static Semaphore semaphore = new Semaphore(ALLOW_INSTANCE, ALLOW_INSTANCE, "KPI");

        [STAThread]
        static void Main()
        {
            bool createdNew = false;
            try
            {
                createdNew = semaphore.WaitOne(0, false);
            }
            catch (AbandonedMutexException)
            {
                createdNew = true;
            }

            if (createdNew)
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Frm_Login());
                }
                finally
                {
                    semaphore.Release();
                }
            }
            else
            {
                MessageBox.Show($"Phần mềm này chỉ cho phép chạy {ALLOW_INSTANCE} phần mềm giống nhau cùng 1 lúc ", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}