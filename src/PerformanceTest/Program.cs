using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace PerformanceTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Stopwatch sw = Stopwatch.StartNew();
            TestLoggerHierarchy();
            sw.Stop();
            Console.WriteLine("Time taken: {0:N}ms", sw.Elapsed.TotalMilliseconds);
            Console.ReadKey();
        }



        private static void TestLoggerHierarchy()
        {
            for (var i = 0; i < 1; i++)
            {
                //{

                //    string folderName = @"c:\temp\Log";
                //    string jobId = System.Guid.NewGuid().ToString();
                //    jobId = jobId + "\\MIPS";
                //    string pathString = System.IO.Path.Combine(folderName, jobId);
                //    System.IO.Directory.CreateDirectory(pathString);

                //    string fileName = "Mipslogger.log";
                //    pathString = System.IO.Path.Combine(pathString, fileName);
                //    using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                //    {

                //    }
                //    using (System.IO.StreamWriter file =
                //   new System.IO.StreamWriter(pathString))
                //    {
                //        for (var line = 0; line < (1000000 + (i * 100)); line++)
                //          for (var line = 0; line < (1000000 + (1 * 100)); line++)
                //        {
                //            file.WriteLine("MIP : " + line);
                //        }
                //    }
                //}



                {
                    string jobId = System.Guid.NewGuid().ToString();
                    NLog.GlobalDiagnosticsContext.Set("jobId", jobId);

                    var mipLogger = LogManager.GetLogger("mipLogger");

                    mipLogger.Info("MIP Started");

                    for (var line = 0; line < (10000000 + (i * 100)); line++)
                    {
                          mipLogger.Info("MIP : {0}" + line);
                         // mipLogger.Info(new LogEventInfo(LogLevel.Info, "mipLogger", "MIP : " + line));
                    }
                    LogManager.Flush();
                    mipLogger.Info("MIP Finished");
                }

            }
        }

    }
}
