using System.Globalization;

namespace DotNet7StudLTE.Helpers
{
    public class ErrHandler
    {
        //Read json file.
        static IConfiguration MyConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        public static void WriteLog(string Message, string emailtype)
        {



            string directoryName = MyConfig.GetValue<string>("ConnectionStrings:Logs");
            //string directoryName = ConfigurationManager.AppSettings["SendRateNotificationLogs"].ToString();
            try
            {
                DateTime today = DateTime.Today;
                string str = string.Concat(directoryName, "/INVENTORY/", today.ToString("dd-MM-yy"));
                if (!Directory.Exists(str))
                {
                    Directory.CreateDirectory(str);
                }
                string str1 = string.Concat(str, "/", emailtype, ".txt");
                if (!File.Exists(str1))
                {
                    File.Create(str1).Dispose();
                }
                if (File.Exists(str1))
                {
                    using (StreamWriter streamWriter = File.AppendText(str1))
                    {
                        streamWriter.Write("\r\nLog Entry :");
                        today = DateTime.Now;
                        streamWriter.Write("{0}", today.ToString(CultureInfo.InvariantCulture));
                        streamWriter.WriteLine(string.Concat("-:-", Message));
                        streamWriter.Flush();
                        streamWriter.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                ErrHandler.WriteLog(exception.Message, emailtype);
            }

        }
    }
}
