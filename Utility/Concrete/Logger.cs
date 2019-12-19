namespace CatTravels.Utility.Concrete
{
    using CatTravels.Utility.Abstract;
    using System;
    using System.IO;
    public class Logger : ILogger
    {
        /// <summary>
        /// log the error message in log files
        /// </summary>
        /// <param name="LogInput">logInput variable gets the error message that needs to be logged</param>
        public void WriteErrorLog(string logInput)
        {
            try
            {
                var path = System.IO.Directory.GetCurrentDirectory();
                var filepath = path + "\\wwwroot\\Log\\";
                var filename = "APIRequestJson_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
                using (StreamWriter sw = new StreamWriter(filepath + filename))
                {
                    sw.WriteLine(logInput);
                    sw.Close();
                }
            }
            finally { }
        }
    }
}
