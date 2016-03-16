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
    class SetBiZhi
    {
        public int day = 0;
        public string mkt = "JA-JP";


        public string setbz(int day,string mkt)
        {
            string content = GetBingData(day, mkt);
            string fileUrl = GetBingImageUrl(content);
            DownLoadImage(fileUrl);
            string path1 = Directory.GetCurrentDirectory() + "\\" + Path.GetFileName(fileUrl);
            return path1;

        }
        public void setbz2(int day, string mkt)
        {
            string content = GetBingData(day, mkt);
            string fileUrl = GetBingImageUrl(content);
            DownLoadImage(fileUrl);
            SetWallpaper(Directory.GetCurrentDirectory() + "\\" + Path.GetFileName(fileUrl));//path地址 
        }



        [DllImport("user32.dll")]
        private static extern bool SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
        public static void SetWallpaper(string path)
        {
            SystemParametersInfo(20, 0, path, 0x01 | 0x02);
        }
        public static void DownLoadImage(string url)
        {
            WebClient webClient = new WebClient();
            webClient.DownloadFile(url, Path.GetFileName(url));
        }
        public static string GetBingImageUrl(string str)
        {
            string[] strArray = str.Split(new string[] { "地址：" }, StringSplitOptions.RemoveEmptyEntries);
            return strArray[1];
        }
        public static string GetBingData(int day, string mkt)
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
      
    }
}
