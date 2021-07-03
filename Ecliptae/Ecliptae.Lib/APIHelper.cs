using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace Ecliptae.Lib
{
    public static class APIHelper
    {
        public static string RestfulRequest(string url, string method, string jsonParam)
        {
            // 创建Restful的请求
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = method;
            request.ContentType = "application/json";

            // 创建参数
            string data = jsonParam;
            byte[] byteData = UTF8Encoding.UTF8.GetBytes(data.ToString());
            request.ContentLength = byteData.Length;

            // 以流的形式附加参数
            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(byteData, 0, byteData.Length);
            }

            // 接收来自Restful API的回复
            string json = string.Empty;  // 返回的类型是json格式字符串，声明并接收
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // 以流的形式读取，返回的就是字符串的json格式
                StreamReader reader = new StreamReader(response.GetResponseStream());
                json = reader.ReadToEnd();
            }
            return json;
        }
        // Get请求，返回json格式字符串
        public static string RestfulGet(string url)
        {
            // 创建Restful的请求
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "get";
            request.ContentType = "application/json";

            //接收来自Restful API的回复
            string json = string.Empty;  // 返回的类型是json格式字符串，声明并接收
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // 以流的形式读取，返回的就是字符串的json格式
                StreamReader reader = new StreamReader(response.GetResponseStream());
                json = reader.ReadToEnd();
            }
            return json;
        }

        /// <summary>
        /// 对字符串进行SHA1加密
        /// </summary>
        /// <param name="source">需要加密的字符串</param>
        /// <returns>密文</returns>
        public static string SHA1Encrypt(string source)
        {
            byte[] strRes = Encoding.Default.GetBytes(source);
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            strRes = iSHA.ComputeHash(strRes);
            StringBuilder enText = new StringBuilder();
            foreach (byte iByte in strRes)
            {
                enText.AppendFormat("{0:x2}", iByte);
            }
            return enText.ToString().ToUpper();
        }
    }
}
