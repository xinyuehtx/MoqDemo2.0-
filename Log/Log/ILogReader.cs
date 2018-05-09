using System;
using System.Threading.Tasks.Dataflow;

namespace Log
{
    public interface ILogReader
    {
        /// <summary>
        /// 日志对象的源
        /// </summary>
        ISource Source { get; set; }

        /// <summary>
        /// 日志当前所在行号,从0开始
        /// </summary>
        int CurrentLine { get; set; }

        /// <summary>
        /// 从日志中读取一行信息，并移动至下一行
        /// 若当前位置为文件末尾,，则抛出<exception cref="InvalidOperationException"></exception>
        /// </summary>
        /// <returns></returns>
        string ReadLine();

        /// <summary>
        /// 从日志的指定行中读取一行信息，并移动至下一行
        /// </summary>
        /// <param name="line">指定行号</param>
        /// 指定行号为越界，抛出<exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns></returns>
        string ReadLineAt(int line);

        /// <summary>
        /// 从日志查询指定文字。
        /// 若成功，返回第一个匹配项所在行。<example>Error的位置在line3</example>
        /// 若失败，则返回相应提示。
        /// </summary>
        /// <param name="word">需要查询文字</param>
        /// <returns></returns>
        string Find(string word);
    }
}
