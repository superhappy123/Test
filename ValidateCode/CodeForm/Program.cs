using Code;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Stream resStream = null;
                string fullpath = SaveImage(ref resStream);
                CheckCode cc = new CheckCode();
                fullpath = @"f:\_queryCph.jpg";
                Bitmap bmp = new Bitmap(fullpath);
                string s = cc.Read(bmp);
            }
            catch (Exception ex)
            {
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmCode());
        }

        public static string SaveImage(ref Stream resStream)
        {
            string url = "http://210.76.69.58/wfcx/captcha/_queryCph.jsp";
            string fullpath = string.Format("F:\\{0}.jpg", DateTime.Now.ToString("yyyyMMddHHmmssfff"));

            WebUrlRead wr = new WebUrlRead();
            string resultConent = "";

            wr.SelectRealTime(url, ref resultConent, ref resStream);

            FileOperator fo = new FileOperator();
            fo.SaveFile(fullpath, resultConent);

            return fullpath;
        }
    }
}
