using System;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace ImageUploader.security
{
    public class SecurityStrategy
    {
        private static SecurityStrategy _strategy = null;
        private volatile string _privateKey = String.Empty;
        private Timer timer = null;

        #region 负载均衡服务器的配置信息
        public static string[] serverLoadbalancingHost = { "172.31.21.183", "172.31.12.9" };
        public static string requsetURL = $"http://{GetAddressIPMAP(CD.Net.Core.Mvc.WebHelper.Http.LocalIP)}:{CD.Net.Core.Mvc.WebHelper.Http.Port}/fileupload/intancestrategy";
        /// <summary>
        /// 获取负载均衡服务器IP【key=内网IP, value=外网IP】
        /// <para>二台服务器交叉映射内外网IP</para>
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static string GetAddressIPMAP(string ip)
        {
            Dictionary<string, string> dicIP = new Dictionary<string, string>();
            dicIP.Add("172.31.21.183", "52.52.147.169");
            dicIP.Add("172.31.12.9", "52.9.111.120");
            return (dicIP.ContainsKey(ip)) ? dicIP[ip] : CD.Net.Core.Mvc.WebHelper.Http.LocalIP;
        }
        #endregion

        private SecurityStrategy() {
            initiaPrivatelKey();
        }
        /// <summary>
        /// 安全策略为单例模式
        /// </summary>
        public static SecurityStrategy getInstance(Boolean allowLoadBalance = true) {
            if (_strategy == null)
            {
                _strategy = new SecurityStrategy();
                #region 实例化负载均衡服务器上的SecurityStrategy的实例
                if (allowLoadBalance)
                {
                    //更新其他负载均衡服务器上的SecurityStrategy示例
                    if (serverLoadbalancingHost.Contains(CD.Net.Core.Mvc.WebHelper.Http.LocalIP))
                    {
                        LL.Kit.HTTP.Get(requsetURL);
                    }
                }
                #endregion
            }
            return _strategy;
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void dispose()
        {
            if (timer != null)
            {
                timer.Dispose();
            }
        }
        public String getCurrentKey() {
            while (String.IsNullOrEmpty(_privateKey)) { }
            return _privateKey;
        }
        /// <summary>
        /// 初始化_privateKey，这里
        /// </summary>
        private void initiaPrivatelKey() {
            timer = new Timer((e) =>
            {
                _privateKey = getNextPrivateKey();
            }, null, StrategyConfig.startTimeSpan, StrategyConfig.periodTimeSpan);
        }
        /// <summary>
        /// 将baseStrategyKey 和 时间字符串 拼接后，进行hash处理
        /// </summary>
        /// <returns></returns>
        private string getNextPrivateKey()
        {
            String text = StrategyConfig.baseStrategyKey + getTimeString();
            return MD5Ecrypt.GenerateMD5(text);
        }
        private String getTimeString() {
            //获取当前时间
            DateTime dt = DateTime.Now;
            int year = dt.Year;
            int month = dt.Month;
            int day = dt.Day;
            int hour = dt.Hour;
            int minute = dt.Minute;
            minute = minute - getYuShu(minute);
            return String.Format("{0}{1}{2}{3}{4}",year,month,day,hour,minute);
        }
        /// <summary>
        /// 这里的minutes保留了5分钟的间隔时间
        /// 主要是为了预留负载均衡服务器时间同步
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        private int getYuShu(int count) {
            return count % 5;
        }
    }
}
