using System;

namespace Log
{
    public interface ISource
    {
        event EventHandler<DateTime> Updated;
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
