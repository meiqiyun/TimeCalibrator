using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



namespace 时间校准器
{
    public partial class FrmMian : Form
    {
        //服务器时间
        private static DateTime serverTime;
        //北京标准时间
        private static DateTime beiJingTime;
        //要更新的时间
        private static DateTime updateTime;
        //时间线程
        private Thread threadTime;
        //校验速度
        private static int speed = 5;
        //代理
        private delegate void SetPos(int ipos, string vinfo);
       

        public FrmMian()
        {
            //加载嵌入资源（添加程序集解析事件）
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            InitializeComponent();          
        }
        /// <summary>
        /// 加载嵌入资源中的全部dll文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            string dllName = args.Name.Contains(",") ? args.Name.Substring(0, args.Name.IndexOf(',')) : args.Name.Replace(".dll", "");
            dllName = dllName.Replace(".", "_");
            if (dllName.EndsWith("_resources")) return null;
            System.Resources.ResourceManager rm = new System.Resources.ResourceManager(GetType().Namespace + ".Properties.Resources", System.Reflection.Assembly.GetExecutingAssembly());
            byte[] bytes = (byte[])rm.GetObject(dllName);
            return System.Reflection.Assembly.Load(bytes);
        }     

        // 针对于旧Windows系统，如Windows XP,win2003,win2008
        [DllImport("Kernel32.dll")]
        public static extern bool SetSystemTime(ref SystemTime sysTime);

        [DllImport("Kernel32.dll")]
        public static extern void GetSystemTime(ref SystemTime sysTime);

        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SystemTime sysTime);

        [DllImport("Kernel32.dll")]
        public static extern void GetLocalTime(ref SystemTime sysTime);

        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            [MarshalAs(UnmanagedType.U2)]
            internal ushort year; // 年
            [MarshalAs(UnmanagedType.U2)]
            internal ushort month; // 月
            [MarshalAs(UnmanagedType.U2)]
            internal ushort dayOfWeek; // 星期
            [MarshalAs(UnmanagedType.U2)]
            internal ushort day; // 日
            [MarshalAs(UnmanagedType.U2)]
            internal ushort hour; // 时
            [MarshalAs(UnmanagedType.U2)]
            internal ushort minute; // 分
            [MarshalAs(UnmanagedType.U2)]
            internal ushort second; // 秒
            [MarshalAs(UnmanagedType.U2)]
            internal ushort milliseconds; // 毫秒
        }

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                //FrmMian为我窗体的类名
                FrmMian.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            //每秒+1
            serverTime = serverTime.AddSeconds(+1);
            beiJingTime = beiJingTime.AddSeconds(+1);
            this.lbIDCTime.Text = serverTime.ToString("yyyy-MM-dd HH:mm:ss");
            if (beiJingTime.ToString("yyyy-MM-dd").Equals("2017-01-01"))
            {
                this.lbBeiJingTime.ForeColor = Color.Red;
                this.lbBeiJingTime.Font = new Font("宋体", 12, FontStyle.Regular);//一个是字体，第二个大小，第三个是样式
                this.lbBeiJingTime.Text = "网络异常，获取失败!";
                beiJingTime = GetTimeBySuNing();
            }
            else
            {
                this.lbBeiJingTime.ForeColor = Color.Blue;
                this.lbBeiJingTime.Font = new Font("宋体", 14, FontStyle.Bold);
                this.lbBeiJingTime.Text = beiJingTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            //释放内存
            ClearMemory();
        }
        /// <summary>
        /// 校正时间
        /// </summary>
        private void correctionTime()
        {
            //检测一下时间是否正确  
            serverTime = DateTime.Now;//服务器时间
            updateTime = getUpdateTime();
            if (updateTime.ToString("yyyy-MM-dd").Equals("2017-01-01"))
            {
                return;
            }
            //计算时间差
            TimeSpan ts=ExecDateDiff(serverTime, updateTime);
            int days = ts.Days;
            int hours = ts.Hours;
            int minutes = ts.Minutes;
            int seconds = ts.Seconds;       
            if (days > 0 || hours > 0 || minutes > 0 || seconds > 0)
            {
                StringBuilder sb = new StringBuilder(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.Append(" 成功校正了");
                if (days > 0)
                {
                    sb.Append(days);
                    sb.Append("天");
                }
                if (hours > 0)
                {
                    sb.Append(hours);
                    sb.Append("小时");
                }
                if (minutes > 0)
                {
                    sb.Append(minutes);
                    sb.Append("分");
                }
                if (seconds > 0)
                {
                    sb.Append(seconds);
                    sb.Append("秒");
                }
                //显示日志信息
                SetLogText(0, sb.ToString()); 
                //MessageBox.Show("相差" + days + "天" + hours + "小时" + minutes + "分" + seconds + "秒");
                //设置系统时间
                setSystemDate(updateTime);
            }
            
        }
        /// <summary>
        /// 显示日志信息
        /// </summary>
        /// <param name="ipos"></param>
        /// <param name="vinfo"></param>
        private void SetLogText(int ipos, string vinfo)
        {
            if (this.InvokeRequired)
            {
                SetPos setpos = new SetPos(SetLogText);
                this.Invoke(setpos, new object[] { ipos, vinfo });
            }
            else
            {
                this.labLog.ForeColor = Color.Green;
                this.labLog.Text = vinfo;
            }
        }
        #region 使用TimeSpan计算两个时间的差值  ExecDateDiff(DateTime DateTime1, DateTime DateTime2)
        /// <summary>
        /// 使用TimeSpan计算两个时间的差值
        /// </summary>
        /// <param name="DateTime1">第一个时间</param>
        /// <param name="DateTime2">第二个时间</param>
        public static TimeSpan ExecDateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan dateDiff = ts1.Subtract(ts2).Duration();
            return dateDiff;
        }
        #endregion
        /// <summary>
        /// 线程1执行逻辑
        /// </summary>
        private void Thread1()
        {
            do
            {
                correctionTime();
                //线程延迟
                System.Threading.Thread.Sleep(speed * 1000);
                
            } while (true);
           
        }
        /// <summary>
        /// 获取淘宝网API的北京时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetTimeByTaobao()
        {
            string url = "http://api.m.taobao.com/rest/api3.do?api=mtop.common.getTimestamp?t=" + DateTime.Now;
            DateTime dt;
            WebRequest wrt = null;
            WebResponse wrp = null;
            try
            {
                wrt = WebRequest.Create(url);
                wrt.Credentials = CredentialCache.DefaultCredentials;

                wrp = wrt.GetResponse();
                StreamReader sr = new StreamReader(wrp.GetResponseStream(), Encoding.UTF8);
                //获取到的是Json数据
                string html = sr.ReadToEnd();
                //Newtonsoft.Json读取数据
                JObject obj = JsonConvert.DeserializeObject<JObject>(html);
                string result = obj["data"]["t"].ToString();//嵌套的数组，拼2个[]即可
                //MessageBox.Show(result);
                dt = DateTime.Parse(result);

            }           
            catch (Exception)
            {
                return GetTimeBySuNing();
            }
            finally
            {
                if (wrp != null)
                    wrp.Close();
                if (wrt != null)
                    wrt.Abort();
            }
            return dt;
        }

        /// <summary>
        /// 获取苏宁API的北京时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetTimeBySuNing()
        {
            string url = "http://quan.suning.com/getSysTime.do?t=" + DateTime.Now;
            DateTime dt;
            WebRequest wrt = null;
            WebResponse wrp = null;
            try
            {
                wrt = WebRequest.Create(url);
                wrt.Credentials = CredentialCache.DefaultCredentials;

                wrp = wrt.GetResponse();
                StreamReader sr = new StreamReader(wrp.GetResponseStream(), Encoding.UTF8);
                //获取到的是Json数据
                string html = sr.ReadToEnd();
                //Newtonsoft.Json读取数据
                JObject obj = JsonConvert.DeserializeObject<JObject>(html);
                string result = obj["sysTime2"].ToString();
                //MessageBox.Show(result);
                dt = DateTime.Parse(result);

            }
            catch (Exception)
            {
                //return DateTime.Parse("2017-01-01");
                return GetTimeByTaobao();
            }
            finally
            {
                if (wrp != null)
                    wrp.Close();
                if (wrt != null)
                    wrt.Abort();
            }
            return dt;
        }

        /// <summary>          
        /// 获取标准北京时间       
        /// /// </summary>         
        /// /// <returns></returns>       
        /// 
        public DateTime GetBeijingTime()
        {
            DateTime dt;
            WebRequest wrt = null;
            WebResponse wrp = null;
            try
            {
                wrt = WebRequest.Create("http://www.time.ac.cn/timeflash.asp?user=flash");
                wrt.Credentials = CredentialCache.DefaultCredentials;

                wrp = wrt.GetResponse();
                StreamReader sr = new StreamReader(wrp.GetResponseStream(), Encoding.UTF8);
                string html = sr.ReadToEnd();

                sr.Close();
                wrp.Close();
                int yearIndex = html.IndexOf("<year>") + 6;
                int monthIndex = html.IndexOf("<month>") + 7;
                int dayIndex = html.IndexOf("<day>") + 5;
                int hourIndex = html.IndexOf("<hour>") + 6;
                int miniteIndex = html.IndexOf("<minite>") + 8;
                int secondIndex = html.IndexOf("<second>") + 8;

                string year = html.Substring(yearIndex, html.IndexOf("</year>") - yearIndex);
                string month = html.Substring(monthIndex, html.IndexOf("</month>") - monthIndex); ;
                string day = html.Substring(dayIndex, html.IndexOf("</day>") - dayIndex);
                string hour = html.Substring(hourIndex, html.IndexOf("</hour>") - hourIndex);
                string minite = html.Substring(miniteIndex, html.IndexOf("</minite>") - miniteIndex);
                string second = html.Substring(secondIndex, html.IndexOf("</second>") - secondIndex);
                string time = year + "-" + addZero(month) + "-" + addZero(day) + " " + addZero(hour) + ":" + addZero(minite) + ":" + addZero(second);
                dt = DateTime.Parse(time);
            }          
            catch (Exception)
            {
                return DateTime.Parse("2017-01-01");
            }
            finally
            {
                if (wrp != null)
                    wrp.Close();
                if (wrt != null)
                    wrt.Abort();
            }
            return dt;

        }
        //时间补0函数
        private static string addZero(string num)
        {
            if (Int32.Parse(num) < 10)
            {
                return "0" + num;
            }
            else
            {
                return num;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            //获取校正的时 分 秒
            string hour = this.txtHour.Text.Trim();
            string minute = this.txtMinute.Text.Trim();
            string second = this.txtSecond.Text.Trim();
            if (checkNumber(hour) == false || checkNumber(minute) == false || checkNumber(second) == false)
            {
                MessageBox.Show("设置参数有错！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (this.btnStart.Text == "开始校正")
            {
                //创建线程
                if (threadTime == null)
                {
                    threadTime = new Thread(new ThreadStart(Thread1));
                }
                this.btnStart.Text = "停止校正";
                this.btnStart.BackColor = Color.GreenYellow;
                this.btnStart.ForeColor = Color.Red;
                //先手动设置一次系统时间，然后再调用定时器检测更新
                correctionTime();
                //启动线程
                threadTime.Start();
            }
            else
            {
                //销毁线程           
                if (threadTime != null)
                {
                    threadTime.Abort();
                    threadTime = null;
                }
                this.btnStart.Text = "开始校正";
                this.btnStart.BackColor = Color.WhiteSmoke;
                this.btnStart.ForeColor = Color.Black;
            }

        }

       /// <summary>
        /// 获取要更新的时间
       /// </summary>
       /// <returns></returns>
        private DateTime getUpdateTime()
        {
            if (beiJingTime.ToString("yyyy-MM-dd").Equals("2017-01-01"))
            {
                updateTime = Convert.ToDateTime("2017-01-01 00:00:00");
                return updateTime;
            }

            updateTime = beiJingTime;

            //获取校正的时 分 秒
            string hour = this.txtHour.Text.Trim();
            string minute = this.txtMinute.Text.Trim();
            string second = this.txtSecond.Text.Trim();
            if (!checkNumber(hour) || !checkNumber(minute) || !checkNumber(second))
            {
                updateTime = Convert.ToDateTime("2017-01-01 00:00:00");
                return updateTime;
            }
            if (hour == string.Empty || hour == "00")
            {
                hour = "0";//默认值
            }
            if (minute == string.Empty || minute == "00")
            {
                minute = "0";//默认值
            }
            if (second == string.Empty || second == "00")
            {
                second = "0";//默认值
            }

            //慢
            if (rbSlow.Checked == true)
            {
                if (hour != "0")
                {
                    int h = Convert.ToInt32(hour);
                    updateTime = updateTime.AddHours(-h);
                }

                if (minute != "0")
                {
                    int m = Convert.ToInt32(minute);
                    updateTime = updateTime.AddMinutes(-m);
                }

                if (second != "0")
                {
                    int s = Convert.ToInt32(second);
                    updateTime = updateTime.AddSeconds(-s);
                }
            }
            //快
            else
            {
                if (hour != "0")
                {
                    int h = Convert.ToInt32(hour);
                    updateTime = updateTime.AddHours(+h);
                }

                if (minute != "0")
                {
                    int m = Convert.ToInt32(minute);
                    updateTime = updateTime.AddMinutes(+m);
                }

                if (second != "0")
                {
                    int s = Convert.ToInt32(second);
                    updateTime = updateTime.AddSeconds(+s);
                }
            }
            return updateTime;
        }

        /// <summary>
        /// 设置系统时间
        /// </summary>
        private void setSystemDate(DateTime currentTime)
        {
              //判断是32位系统还是64位
              bool type = Environment.Is64BitOperatingSystem;              
              SystemTime sysTime = new SystemTime();
              sysTime.year = Convert.ToUInt16(currentTime.Year);
              sysTime.month = Convert.ToUInt16(currentTime.Month);
              sysTime.day = Convert.ToUInt16(currentTime.Day);
              sysTime.dayOfWeek = Convert.ToUInt16(currentTime.DayOfWeek);
              sysTime.minute = Convert.ToUInt16(currentTime.Minute);
              sysTime.second = Convert.ToUInt16(currentTime.Second);
              sysTime.milliseconds = Convert.ToUInt16(currentTime.Millisecond);

              //SetSystemTime()默认设置的为UTC时间，设定时比北京时间多了8个小时。  
              //int nBeijingHour = currentTime.Hour - 8
                int nBeijingHour = currentTime.Hour;
               if (nBeijingHour < 0)
                  {
                    nBeijingHour = 24;
                    sysTime.day = Convert.ToUInt16(currentTime.Day - 1);
                    sysTime.dayOfWeek = Convert.ToUInt16(currentTime.DayOfWeek - 1);
                  }
               else
               {
                   sysTime.day = Convert.ToUInt16(currentTime.Day);
                   sysTime.dayOfWeek = Convert.ToUInt16(currentTime.DayOfWeek);
               }
                sysTime.hour = Convert.ToUInt16(nBeijingHour);
                //设置系统时间
                //SetSystemTime(ref sysTime);
                SetLocalTime(ref sysTime);
               
        }

        private void txtHour_TextChanged(object sender, EventArgs e)
        {
            string hour = this.txtHour.Text.Trim();
            checkNumber(hour);

        }
        //检查输入的是否为数字
        private Boolean checkNumber(string num)
        {
            if (num == string.Empty)
            {
                return true;
            }

            Regex sz = new Regex("^[0-9]{1,}$");//定义正则表达式
            if (sz.IsMatch(num) == false)//判断，如果不满足正则表达式(结果为flase)，给出提示
            {
                this.labLog.Text = "请输入数字！";
                this.labLog.ForeColor = Color.Red;
                return false;
            }
            else
            {
                this.labLog.Text = "";
                return true;
            }
        }

        private void txtMinute_TextChanged(object sender, EventArgs e)
        {
            string minute = this.txtMinute.Text.Trim();
            checkNumber(minute);
        }

        private void txtSecond_TextChanged(object sender, EventArgs e)
        {
            string second = this.txtSecond.Text.Trim();
            checkNumber(second);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //点击窗体关闭按钮时，最小化到系统托盘里
            e.Cancel = true;
            this.Hide();               //隐藏窗体 
            this.ShowInTaskbar = false;//图标不显示在任务栏上
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;//图标显示在任务栏上    
            this.Show();//显示窗体
            this.WindowState = FormWindowState.Normal;//正常显示
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            //当窗体为最小化状态时
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.notifyIcon1.Visible = true; //显示托盘图标
                //this.Hide();//隐藏窗体
                //this.ShowInTaskbar = false;//图标不显示在任务栏
            }
        }

        private void tsmiClose_Click(object sender, EventArgs e)
        {
            //销毁线程1            
            if (threadTime != null)
            {
                threadTime.Abort();
                threadTime = null;
            }
            //关闭定时器
            this.timer1.Stop();
            //强制退出程序
            Environment.Exit(0);
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;//图标显示在任务栏上           
            this.Show();//显示窗体
            this.WindowState = FormWindowState.Normal;//正常显示
        }

        private void FrmMian_Load(object sender, EventArgs e)
        {
            //1.启动软件时，获取服务器当前时间
            serverTime = DateTime.Now;
            //2.启动软件时，获取北京标准时间
            beiJingTime = GetTimeByTaobao();    
            //显示校正速度
            this.trackBar1.Value = speed;
            showTrackBar();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            speed = this.trackBar1.Value;
            showTrackBar();
        }

        private void showTrackBar()
        {
            if (speed >= 60)
            {
                int h = speed / 60;
                int m = speed % 60;
                this.lbTigs.Text = h + "分" + (m > 0 ? m + "秒" : "钟");
            }
            else
            {
                this.lbTigs.Text = speed + "秒";
            }
        }

        private void labelUrl_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.zy13.net");
        }

    }
}
