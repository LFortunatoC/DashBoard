using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace DashBoard
{
    class HistoryGen
    {
       
        static string Dir;
        static string FileName;

       public HistoryGen (string dir)
        {
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);
             Dir = dir;
        }
        
        public string dir {  set { Dir = dir; } get { return dir; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="strLog"></param>
        public void UpdateLog(string filename, string strLog)
        {
            using (StreamWriter sw = new StreamWriter(Dir + filename, true))
            {
                sw.WriteLine(strLog);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string ReadLog(string filename)
        {
            string strLog="";
            using (StreamReader sr = new StreamReader(Dir + filename))
            {
                strLog = sr.ReadToEnd();
            }
            return strLog;
        }
    }
}
