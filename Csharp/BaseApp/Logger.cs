using System;
using System.Collections.Generic;
using System.IO;

namespace BaseApp
{
    static class Logger
    {
        /// <summary>
        /// Writes a line of text composed of current time ("@HH:mm:ss # ") string to which the supplied <paramref name="text"/> is concatenated.
        /// Composed string is written to the file given by the <paramref name="path"/> parameter.
        /// </summary>
        /// <param name="path">A path (including a file name) where to write text string. If file of directory do not exist they are created.</param>
        /// <param name="text">A text to be written to the specified path.</param>
        public static void Log(string path, string text)
        {
            try
            {
                /// Create directory if it does not exist, do nothing otherwise
                Directory.CreateDirectory(Path.GetDirectoryName(path));

                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine(DateTime.Now.ToString("@HH:mm:ss # ") + text);
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Exception.txt", true))
                {
                    sw.WriteLine(DateTime.Now.ToString("@HH:mm:ss # ") + e.Message);
                }
            }
        }
        /// <summary>
        /// Writes a single record of data bytes appended by a newline 
        /// </summary>
        /// <param name="path">A path (including a file name) where to write data bytes. If file or directory do not exist they are created.</param>
        /// <param name="data">A byte array holding data to be written to the specified path.</param>
        public static void Log(string path, byte[] data)
        {
            try
            {
                /// Create directory if it does not exist, do nothing otherwise
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                // Create or append to given file, open it for writing, 
                using (FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                {
                    fs.Write(data, 0, data.Length);
                    fs.Write(new byte[] { Convert.ToByte('\n') }, 0, 1);
                }
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Exception.txt", true))
                {
                    sw.WriteLineAsync(DateTime.Now.ToString("@HH:mm:ss # ") + e.Message);
                }
            }
        }

        public static LinkedList<byte[]> Parse(string path)
        {
            LinkedList<byte[]> dataList = new LinkedList<byte[]>();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    while (fs.Position < fs.Length)
                    {
                        byte[] data = new byte[6];
                        //byte[] newLine = new byte[1];

                        fs.Read(data, 0, 6);
                        fs.Read(new byte[1], 0, 1);
                        //fs.ReadAsync(data, 0, 6);
                        //fs.ReadAsync(newLine, 0, 1);

                        if (!CheckData(data))
                        {
                            dataList.AddLast(new byte[] { 254, 254, 254, 254 });
                            break;
                        }

                        dataList.AddLast(new byte[] { data[1], data[2], data[3], data[4] });
                    }
                }
                return dataList;
            }
            catch (Exception e)
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Exception.txt", true))
                {
                    sw.WriteLineAsync(DateTime.Now.ToString("@HH:mm:ss # ") + e.Message + e.StackTrace);
                }
                return dataList;
            }
        }
        private static bool CheckData(byte[] data)
        {
            return ((data[0] == 204 && data[5] == 185) ? true : false);
        }
    }
}