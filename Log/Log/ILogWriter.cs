using System;

namespace Log
{
    public interface ILogWriter
    {
        /// <summary>
        /// 日志对象的源
        /// </summary>
        ISource Source { get; set; }

        /// <summary>
        /// 日志当前所在行号,从0开始
        /// </summary>
        int Line { get; set; }

        /// <summary>
        /// 从日志中写一行信息，并移动至下一行
        /// </summary>
        /// <returns></returns>
        void AppendLine(string text);

        /// <summary>
        /// 在日志的指定行写一行信息，并移动至所插入行的下一行
        /// </summary>
        /// <param name="line">指定行号</param>
        /// <param name="text"></param>
        /// 指定行号为越界，抛出<exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        string InsertLineAt(int line, string text);

        /// <summary>
        /// 调用<see cref="ISource"/>的<see cref="Save"/>方法
        /// </summary>
        /// <returns></returns>
        bool Save();
    }
}
