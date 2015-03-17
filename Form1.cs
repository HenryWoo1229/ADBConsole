using System;
//using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;    //to run commands concurrently
using System.Text.RegularExpressions;

using System.IO;

namespace ADBConsole
{
    public partial class Form1 : Form
    {
        const int MAX_LINES = 5000;
        const bool AUTO_SAVE_LOG_FILE = false;
        
        bool bTest;

        string m_strCoding;

        Thread m_adbListenThread;
        Queue adbOutputQueue;
        ADBAccess m_ADBAccess;
        bool m_bSuspendLogout;
        System.IO.StreamWriter m_logFile;
        
        String m_tagFilter;
        Boolean m_tagFilterEnabled;

        bool m_bCMDQueuing;

        int selectedLevel = 0;


        //This queue contains ADB commands.
        //Reader is for dequeue the request CMD by ADBAccess
        //Writer is for enqueue new CMD by this Form1 class.
        Queue m_ADBCommandQueue;
        Queue m_ADBCommandQueueReader;
        Queue m_ADBCommandQueueWriter;

        private void StartADBThread()
        {
            m_adbListenThread = new Thread(new ThreadStart(StartListen));
            m_adbListenThread.Start();
        }

        public Form1()
        {
            InitializeComponent();

            m_bCMDQueuing = false;
            m_adbListenThread = null;
            bTest = true;
            m_tagFilter = "";
            m_tagFilterEnabled = false;


           

            String FILE_NAME = "AdbMessage";
            int suffix = 1;

            String fileName = @".\" + FILE_NAME + ".log";

            cmbLevel.SelectedIndex = 0;
            cmbCode.SelectedIndex = 0;

            //fileLocationMsg.Text = @"The log file is saved at : " + fileName;
            if (AUTO_SAVE_LOG_FILE == true)
            {
                while (System.IO.File.Exists(fileName))
                {
                    fileName = @".\" + FILE_NAME + suffix.ToString() + ".log";
                    ++suffix;
                }

                m_logFile = new System.IO.StreamWriter(fileName);
            }
            

            m_ADBCommandQueue = new Queue();
            m_ADBCommandQueueReader = Queue.Synchronized(m_ADBCommandQueue);
            m_ADBCommandQueueWriter = Queue.Synchronized(m_ADBCommandQueue);

            m_ADBAccess = new ADBAccess();
            m_ADBAccess.WinOutputQueueReader = m_ADBCommandQueueReader;
        }

        private void StartListen()
        {
            adbOutputQueue = new Queue(1000,2);
            
            while (true)
            {
                try
                {
                    if (!m_ADBAccess.isCMDOutputQueueEmpty())
                    {
                        adbOutputQueue.Enqueue(m_ADBAccess.CMDOutputDequeue() + "\r\n");
                    }

                    Application.DoEvents();

                    if (0 == adbOutputQueue.Count)
                    {
                        //only flush at idle time
                        if (AUTO_SAVE_LOG_FILE == true)
                        {
                            m_logFile.Flush();
                        }
                        
                        //only sleep when there is no string in the queue.
                        System.Threading.Thread.Sleep(2);
                    }
                    else
                    {                      
                         if ( !m_bSuspendLogout )
                         {
                             DisplayMessage(adbOutputQueue.Dequeue().ToString());
                         }
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine("WinListen Thread Exception: " + err.Message);
                    //Cleanup();
                    break;
                }                
            }
        }

        private delegate void DisplayDelegate(string message);
        private void DisplayMessage(string message)
        {

            if (consoleBox.InvokeRequired)
            {
                Invoke(new DisplayDelegate(DisplayMessage), new object[] { message });
            }
            else
            {
                if (m_tagFilterEnabled)
                {
                    string msg = message.Trim().ToUpper();
                    if (0 < m_tagFilter.Length)
                    {
                        if (msg.Contains(m_tagFilter) == false)
                        {
                            return;
                        }
                    }
                }

                try
                {
                    string pattern = @" [VIDWEFS][/]*";
                    Match match = Regex.Match(message, pattern);
                    if (match.Success)
                    {

                        char tagLevel = match.Value[1];

                        if (getIntLevel(tagLevel) < selectedLevel)
                        {
                            return;
                        }

                        switch (tagLevel)
                        {
                            case 'I':
                            case 'V':
                                {
                                    consoleBox.SelectionColor = Color.LightGreen;
                                    //consoleBox.SelectionBackColor = Color.SlateGray;
                                    break;
                                }
                            case 'D':
                                {
                                    consoleBox.SelectionColor = Color.DeepSkyBlue;
                                    //consoleBox.SelectionBackColor = Color.SlateGray;
                                    break;
                                }
                            case 'W':
                                {
                                    consoleBox.SelectionColor = Color.LightSalmon;
                                    //consoleBox.SelectionBackColor = Color.SlateGray;
                                    break;
                                }
                            case 'E':
                            case 'F':
                                {
                                    consoleBox.SelectionColor = Color.Tomato;
                                    //consoleBox.SelectionBackColor = Color.SlateGray;
                                    break;
                                }
                            default:
                                {
                                    consoleBox.SelectionColor = Color.White; //should not go here
                                    break;
                                }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception from Regex");
                }

                if (bTest)
                {
                    Encoding GBK,UTF8;
                    GBK = Encoding.GetEncoding("GBK");
                    UTF8 = Encoding.GetEncoding("UTF-8");

                    if (m_strCoding == "GBK")
                    {
                        message = UTF8.GetString(GBK.GetBytes(message));
                    }
                    //consoleBox.AppendText(message);
                    consoleBox.AppendText(message);

                    if (AUTO_SAVE_LOG_FILE == true)
                    {
                        m_logFile.Write(message);
                    }
                    
                }
      


               // int maxLines = MAX_LINES;
                int delta = 100; //to improve performance, delete 100 lines each time
                if (consoleBox.Lines.Length > MAX_LINES + delta)
                {
                    //Console.WriteLine(" >>>>>>>>>>>>>>> delete ");
                    consoleBox.SelectionStart = 0;

                    int pos = consoleBox.GetFirstCharIndexFromLine(consoleBox.Lines.Length - MAX_LINES);

                    consoleBox.Select(0, pos);
                    consoleBox.SelectedText = "";
                    
                }

                consoleBox.SelectionStart = consoleBox.Text.Length;
                consoleBox.ScrollToCaret();
            }
        }

        private void ADBStartBtn_Click(object sender, EventArgs e)
        {
            if (null == m_adbListenThread)
            {
                StartADBThread();
                System.Threading.Thread.Sleep(100);
                m_ADBAccess.StartCMD();
                System.Threading.Thread.Sleep(200);

                //send demo command
                {
                    string ADBCMD;
                    //ADBCMD = "dir";
                    ADBCMD = "adb logcat -c";
                    m_bCMDQueuing = true;
                    m_ADBCommandQueueWriter.Enqueue(ADBCMD);
                    ADBCMD = "adb logcat -v time";
                    m_ADBCommandQueueWriter.Enqueue(ADBCMD);
                    m_bCMDQueuing = false;
                }
                SetLogcatSuspend(false);
            }
            else
            {
                SetLogcatSuspend(!m_bSuspendLogout);
            }
        }

        private void Cleanup()
        {
            if (AUTO_SAVE_LOG_FILE == true)
            {
                m_logFile.Close();
            }

            m_ADBCommandQueue.Clear();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            OnExit();
        }

        private void TagEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckState.Checked == this.TagEnable.CheckState)
            {
                m_tagFilter = TagNameBox.Text.ToUpper();
                m_tagFilterEnabled = true;
                TagNameBox.Enabled = false;
            }
            else
            {
                m_tagFilterEnabled = false;
                m_tagFilter = "";
                TagNameBox.Enabled = true;
            }
        }

        private void OnExit()
        {
            m_ADBAccess.Exit();
            Cleanup();
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void ADBClearBtn_Click(object sender, EventArgs e)
        {
            consoleBox.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnExit();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            //string consoleBoxText = consoleBox.Text;
            saveFileDialog1.Filter = "log文件(*.log)|*.log|文本文件(*.txt)|*.txt";
            if (saveFileDialog1.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            string fileName = saveFileDialog1.FileName;

            StreamWriter fs = new StreamWriter(fileName);
            fs.Write(consoleBox.Text);
            fs.Close();
            

        }

        private int getIntLevel(char level)
        {
            int r = 0;

            try
            {
                r = "VDIWEFS".IndexOf(level);
            }
            catch (System.Exception ex)
            {

            }
            return r;
        }

        private void cmbLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedLevel = cmbLevel.SelectedIndex;
        }

        private bool SetLogcatSuspend(bool status)
        {
            m_bSuspendLogout = status;
            if (status)
            {
                pictureBox1.BackColor = System.Drawing.Color.Red;
            }
            else
            {
                pictureBox1.BackColor = System.Drawing.Color.Green;
            }
           
            return m_bSuspendLogout;
        }


        private static bool isUtf8(byte[] buff)
        {
            for (int i = 0; i < buff.Length; i++)
            {
                if ((buff[i] & 0xE0) == 0xC0)    // 110x xxxx 10xx xxxx  
                {
                    if ((buff[i + 1] & 0x80) != 0x80)
                    {
                        return false;
                    }
                }
                else if ((buff[i] & 0xF0) == 0xE0)  // 1110 xxxx 10xx xxxx 10xx xxxx  
                {
                    if ((buff[i + 1] & 0x80) != 0x80 || (buff[i + 2] & 0x80) != 0x80)
                    {
                        return false;
                    }
                }
                else if ((buff[i] & 0xF8) == 0xF0)  // 1111 0xxx 10xx xxxx 10xx xxxx 10xx xxxx  
                {
                    if ((buff[i + 1] & 0x80) != 0x80 || (buff[i + 2] & 0x80) != 0x80 || (buff[i + 3] & 0x80) != 0x80)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_strCoding = cmbCode.Items[cmbCode.SelectedIndex].ToString();
        }

        private void TopEnable_CheckedChanged(object sender, EventArgs e)
        {
            if (TopEnable.Checked)
            {
                this.TopMost = true;
            }
            else
            {
                this.TopMost = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

    }
}