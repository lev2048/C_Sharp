using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;//设置桌面

namespace bing壁纸
{
    class Program
    {
        public void Main(string[] args)
        {
           
                int day = 0;
                string mkt = "EN-IN";
                string content = GetBingData(day, mkt);
                Console.WriteLine("查询结果：" + content);
                string fileUrl = GetBingImageUrl(content);
                DownLoadImage(fileUrl);
                
            
        }
        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        /// <summary>
        /// 设置壁纸以壁纸在本地电脑中的路径为参数。
        /// </summary>
        /// <param name="path"></param>
        public static void SetWallpaper(string path)
        {
            SystemParametersInfo(20, 0, path, 0x01 | 0x02);
        }
        /// <summary>
        /// 下载壁纸
        /// </summary>
        /// <param name="url"></param>
        public static void DownLoadImage(string url)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, Path.GetFileName(url));
        }
        /// <summary>
        /// 得到图片地址
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetBingImageUrl(string str)
        {
            string[] strArray = str.Split(new string[] { "地址：" }, StringSplitOptions.RemoveEmptyEntries);
            return strArray[1];
        }
        public static string GetBingData(string day, string mkt)
        {
            string url = "http://test.dou.ms/bing/day/" + day + "/mkt/" + mkt;
            return GetHttpData(url);
        }
        public static string GetHttpData(string uri)
        {
            Uri url = new Uri(uri);//初始化uri
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);//初始化请求
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();//得到响应
            Stream stream = response.GetResponseStream();//获取响应的主体
            StreamReader reader = new StreamReader(stream);//初始化读取器
            string result = reader.ReadToEnd();//读取，存储结果
            reader.Close();//关闭读取器，释放资源
            stream.Close();//关闭流，释放资源
            return result;//返回读取结果
        }
        public static string GetInputString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
