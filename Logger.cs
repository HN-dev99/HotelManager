using System;
using System.IO;

namespace HotelManagement
{
    public static class Logger
    {
        private static readonly string filePath = "HotelLog.txt";

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine($"{DateTime.Now}: {message}");

                    sw.WriteLine(); // Thêm dòng trống sau mỗi log entry
                }


            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Could not log data: {ex.Message}");
                Console.ResetColor();
            }
        }
    }

}







