using System;

namespace Log
{
    public interface ISource
    {
        /// <summary>
        /// 每当保存时触发，参数为最新更新时间
        /// </summary>
        event EventHandler<DateTime> Updated;
        /// <summary>
        /// 日志源所在的Uri
        /// </summary>
        Uri Uri { get; set; }
        DateTime CreateTime { get; set; }
        string Author { get; set; }

        /// <summary>
        /// 保存当前的修改，并且引发<see cref="Updated"/>事件
        /// </summary>
        /// <returns></returns>
        bool Save();
    }
}
