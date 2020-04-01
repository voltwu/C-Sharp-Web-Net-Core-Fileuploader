using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImageUploader.security
{
    public class StrategyConfig
    {
        /// <summary>
        /// 任务启动的延迟启动时间
        /// </summary>
        public static readonly TimeSpan startTimeSpan = TimeSpan.Zero;
        /// <summary>
        /// 任务执行的时间间隔
        /// </summary>
        public static readonly TimeSpan periodTimeSpan = TimeSpan.FromMinutes(10);

        public static String baseStrategyKey = "asfdszs123203ADBSDMKS";
    }
}
