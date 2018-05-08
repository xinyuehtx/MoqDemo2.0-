using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Log
{
    public interface ILogSystem
    {
        ILogReader Reader { get; }
        ILogWriter Writer { get; }

        /// <summary>
        /// 若日志在程序生命周期内进行更新，则显示最新更新时间
        /// 否则，为null
        /// </summary>
        DateTime? UpdatedTime { get; set; }

        /// <summary>
        /// 以只读方式打开指定的日志源
        /// </summary>
        /// <param name="reader"></param>
        void OpenRead(ILogReader reader);

        /// <summary>
        /// 以添加内容的方式打开指定的日志源
        /// </summary>
        /// <param name="writer"></param>
        void OpenAppend(ILogWriter writer);

        /// <summary>
        /// 保存日志修改内容
        /// 成功，则返回"保存成功"
        /// 失败，则返回"保存失败"
        /// </summary>
        /// <exception cref="InvalidOperationException">不能在<see cref="OpenAppend"/>方法执行之前调用</exception>
        /// <returns></returns>
        string Save();

        /// <summary>
        /// 关闭日志，将<see cref="Reader"/>和<see cref="Writer"/>至为Null
        /// </summary>
        void Close();

        /// <summary>
        /// 调用<see cref="Reader"/>，从日志中读取一行信息，并移动至下一行
        /// </summary>
        /// <returns></returns>
        string ReadLine();

        /// <summary>
        /// 调用<see cref="Reader"/>，从日志的指定行中读取一行信息，并移动至下一行
        /// 若指定行号不存在则返回"查无此行"
        /// </summary>
        /// <returns></returns>
        string ReadLineAt(int line);

        /// <summary>
        /// 调用<see cref="Reader"/>，读取全部日志信息，
        /// 拼接成单个字符串，使用“;”分割
        /// </summary>
        /// <returns></returns>
        string ReadAll();

        /// <summary>
        /// 调用<see cref="Writer"/>，在日志中写一行信息，显示写入后光标所在行号
        /// </summary>
        /// <returns></returns>
        int AppendLine(string text);

        /// <summary>
        /// 调用<see cref="Writer"/>,在日志中写一行信息，若成功， 显示写入后光标所在行号
        /// 若失败，显示原有光标所在行号
        /// </summary>
        /// <param name="line">指定行号</param>
        /// <param name="text">指定内容</param>
        /// <param name="result">若成功，返回"写入成功"；否则,返回"指定行号有误"</param>
        /// <returns></returns>
        int InsertLineAt(int line, string text, out string result);

        /// <summary>
        /// 从日志查询指定文字。
        /// 若成功，返回第一个匹配项所在行。<example>Error的位置在line3</example>
        /// 若失败，则返回相应提示。
        /// </summary>
        /// <param name="word">需要查询文字</param>
        /// <returns></returns>
        string Find(string word);

        /// <summary>
        /// 显示地址
        /// </summary>
        /// <returns></returns>
        string ShowUri();
    }
}
