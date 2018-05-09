using System;
using Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class LogSystemTests2
    {
        #region 伪造方法

        //伪造无参数方法
        /// <summary>
        /// 假设：日志当前行内容为“运行正常”
        /// 执行：ReadLine
        /// 期望：返回“运行正常”
        /// </summary>
        [TestMethod]
        public void ReadLine()
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.ReadLine();

            Assert.AreEqual("运行正常", result);
        }

        //伪造有参数方法
        /// <summary>
        /// 假设：日志第3行内容为“运行正常”
        /// 执行：ReadLineAt(3)
        /// 期望：返回“运行正常”
        /// </summary>
        [TestMethod]
        public void ReadLineAt()
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.ReadLineAt(3);

            Assert.AreEqual("运行正常", result);
        }

        //伪造多个有参数方法
        /// <summary>
        /// 假设：日志任意行内容都为“运行正常”
        /// 执行：ReadLineAt(3)
        /// 期望：返回“运行正常”
        /// 执行：ReadLineAt(4)
        /// 期望：返回“运行正常”
        /// </summary>
        [TestMethod]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadLineAt2(int i)
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.ReadLineAt(i);

            Assert.AreEqual("运行正常", result);
        }

        //伪造方法参数匹配
        /// <summary>
        /// 假设：日志任意行内容都为“运行正常”
        /// 执行：ReadLineAt(3)
        /// 期望：返回“运行正常”
        /// 执行：ReadLineAt(4)
        /// 期望：返回“运行正常”
        /// </summary>
        [TestMethod]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadLineAt3(int i)
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.ReadLineAt(i);

            Assert.AreEqual("运行正常", result);
        }

        //伪造方法返回值与参数相关
        /// <summary>
        /// 假设：日志第0行内容为“运行正常”
        ///       日志第1行内容为“超时异常”
        /// 执行：Find("异常")
        /// 期望：返回"异常的位置在line1"
        /// /// 执行：Find("超时")
        /// 期望：返回"异常的位置在line1"
        /// </summary>
        [TestMethod]
        [DataRow("异常")]
        [DataRow("超时")]
        public void Find(string s)
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.Find(s);

            Assert.AreEqual($"{s}的位置在line1", result);
        }

        //伪造方法抛出异常
        /// <summary>
        /// 执行：ReadLineAt(-1)
        /// 期望：返回“查无此行”
        /// </summary>
        [TestMethod]
        public void ReadLineAt4()
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.ReadLineAt(-1);

            Assert.AreEqual("查无此行", result);
        }

        //伪造方法回调
        /// <summary>
        /// 假设：日志当前行为3
        /// 执行：ReadLine()
        /// 期望：日志当前行变为4
        /// </summary>
        [TestMethod]
        public void ReadLine2()
        {
            var logSystem = new LogSystem();

            //todo

            logSystem.ReadLine();

            Assert.AreEqual(4, logSystem.Reader.CurrentLine);
        }


        //伪造方法返回值序列
        /// <summary>
        /// 假设：日志内容为：
        ///       运行正常
        ///       运行异常
        ///       存储空间不足
        /// 执行：ReadAll()
        /// 期望：返回“运行正常;运行异常;存储空间不足;”
        /// </summary>
        [TestMethod]
        public void ReadAll()
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.ReadAll();

            Assert.AreEqual("运行正常;运行异常;存储空间不足;", result);
        }

        #endregion

        #region 伪造属性

        //伪造属性返回值
        /// <summary>
        /// 假设：日志当前行为3
        /// 执行：AppendLine("运行异常")
        /// 期望：返回4
        /// </summary>
        [TestMethod]
        public void AppendLine()
        {
            var logSystem = new LogSystem();

            //todo

            logSystem.AppendLine("运行正常");

            Assert.AreEqual(4, logSystem.Writer.CurrentLine);
        }

        //伪造自动属性
        /// <summary>
        /// 假设：日志当前行为3
        /// 执行：AppendLine("运行异常")
        /// 期望：返回4
        /// </summary>
        [TestMethod]
        public void AppendLine2()
        {
            var logSystem = new LogSystem();

            //todo

            logSystem.AppendLine("运行正常");

            Assert.AreEqual(4, logSystem.Writer.CurrentLine);
        }

        //递归伪造属性
        /// <summary>
        /// 假设：当前日志的Uri是"Log.txt"
        /// 执行：ShowUri()
        /// 期望：返回"Log.txt"
        /// </summary>
        [TestMethod]
        public void ShowUri()
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.ShowUri();

            Assert.AreEqual("Log.txt", result);
        }

        #endregion

        #region 伪造事件

        /// <summary>
        /// 执行：ISource引发Updated事件
        /// 期望：UpdatedTime更新时间
        /// </summary>
        [TestMethod]
        public void UpdatedTime()
        {
            var logSystem = new LogSystem();

            //todo

            Assert.AreEqual(new DateTime(2018, 10, 10), logSystem.UpdatedTime);
        }

        #endregion

        #region 参数匹配

        //伪造方法参数匹配
        /// <summary>
        /// 假设：日志第0-10行内容都为“运行正常”
        /// 执行：ReadLineAt(0)
        /// 期望：返回“运行正常”
        /// 执行：ReadLineAt(10)
        /// 期望：返回“运行正常”
        /// </summary>
        [TestMethod]
        [DataRow(0)]
        [DataRow(10)]
        public void ReadLineAt5(int i)
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.ReadLineAt(i);

            Assert.AreEqual("运行正常", result);
        }

        //伪造方法参数匹配
        /// <summary>
        /// 假设：日志第0-10行内容都为“运行正常”
        /// 执行：ReadLineAt(-1)
        /// 期望：返回“查无此行”
        /// 执行：ReadLineAt(11)
        /// 期望：返回“查无此行”
        /// </summary>
        [TestMethod]
        [DataRow(-2)]
        [DataRow(11)]
        public void ReadLineAt6(int i)
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.ReadLineAt(i);

            Assert.AreEqual("查无此行", result);
        }

        #endregion

        #region 验证

        //伪造方法参数匹配
        /// <summary>
        /// 假设：日志第0-10行内容都为“运行正常”
        /// /// 执行：ReadLineAt(-1)
        /// 期望：返回“查无此行”
        /// 执行：ReadLineAt(11)
        /// 期望：返回“查无此行”
        /// </summary>
        [TestMethod]
        public void Save()
        {
            var logSystem = new LogSystem();

            //todo

            var result = logSystem.Save();
        }

        #endregion
    }
}
