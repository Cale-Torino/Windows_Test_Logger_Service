using System;
using System.IO;
using System.ServiceProcess;
using System.Timers;

namespace Windows_Test_Logger_Service
{
    public partial class Service1 : ServiceBase
    {
        //https://www.c-sharpcorner.com/article/create-windows-services-in-c-sharp/
        Timer timer = new Timer();
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            CreateFolder();
            LogClass.WriteLine($"Service has started at {DateTime.Now}");
            timer.Elapsed += new ElapsedEventHandler(OnElapsedTime);
            timer.Interval = 5000; //number in milisecinds
            timer.Enabled = true;
        }

        private void CreateFolder()
        {
            try
            {
                //Create the folders used by the app
                string path = AppDomain.CurrentDomain.BaseDirectory;
                Directory.CreateDirectory(@$"{path}\Logs");
                //Directory.CreateDirectory(path + @"\Updates");
                LogClass.WriteLine(" *** Application Start [ServiceApp] ***");
                //richTextBox.AppendText($"[{DateTime.Now}] : Application Start\n");
                LogClass.WriteLine(" *** CreateDirectory Success [ServiceApp] ***");
                //richTextBox.AppendText($"[{DateTime.Now}] : Logs Create Directory Success\n");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Create Folder Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogClass.WriteLine($" *** Error:{ex.Message} [ServiceApp] ***");
                return;
            }
        }

        protected override void OnStop()
        {
            LogClass.WriteLine($"Service is stopped at {DateTime.Now}");
        }
        private void OnElapsedTime(object source, ElapsedEventArgs e)
        {
            LogClass.WriteLine($"Service is recall at {DateTime.Now}");
        }
    }
}
