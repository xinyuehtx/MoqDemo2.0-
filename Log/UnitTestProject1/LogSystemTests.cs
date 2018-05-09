using System;
using System.Threading;
using Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTestProject1
{
    [TestClass]
    public class LogSystemTests
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
            // 新建一个ILogReader的Mock对象，其Object属性即为我们需要的伪对象
            var fakeReader = new Mock<ILogReader>();

            // 当调用ILogReader接口的ReadLine()方法时，将返回运行正常字符串
            fakeReader.Setup(fake => fake.ReadLine()).Returns("运行正常");

            //将伪对象注入到被测试类
            logSystem.OpenRead(fakeReader.Object);

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

            // 新建一个ILogReader的Mock对象，其Object属性即为我们需要的伪对象
            var fakeReader = new Mock<ILogReader>();

            // 当调用ILogReader接口的ReadLineAt(3)方法时，将返回运行正常字符串
            fakeReader.Setup(fake => fake.ReadLineAt(3)).Returns("运行正常");

            //将伪对象注入到被测试类
            logSystem.OpenRead(fakeReader.Object);

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

            // 新建一个ILogReader的Mock对象，其Object属性即为我们需要的伪对象
            var fakeReader = new Mock<ILogReader>();

            // 当调用ILogReader接口的ReadLineAt(3)方法时，将返回运行正常字符串
            fakeReader.Setup(fake => fake.ReadLineAt(3)).Returns("运行正常");
            // 当调用ILogReader接口的ReadLineAt(4)方法时，将返回运行正常字符串
            fakeReader.Setup(fake => fake.ReadLineAt(4)).Returns("运行正常");

            //将伪对象注入到被测试类
            logSystem.OpenRead(fakeReader.Object);

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

            // 新建一个ILogReader的Mock对象，其Object属性即为我们需要的伪对象
            var fakeReader = new Mock<ILogReader>();

            // 当调用ILogReader接口的ReadLineAt()方法，并传入任意int类型参数时，将返回运行正常字符串
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsAny<int>())).Returns("运行正常");

            //将伪对象注入到被测试类
            logSystem.OpenRead(fakeReader.Object);

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

            // 新建一个ILogReader的Mock对象，其Object属性即为我们需要的伪对象
            var fakeReader = new Mock<ILogReader>();

            // 当调用ILogReader接口的Find()方法，并传入任意string类型参数时，将返回$"{/*输入参数字符串*/}的位置在line1"字符串
            fakeReader.Setup(fake => fake.Find(It.IsAny<string>())).Returns((string value) => $"{value}的位置在line1");

            //将伪对象注入到被测试类
            logSystem.OpenRead(fakeReader.Object);

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

            // 新建一个ILogReader的Mock对象，其Object属性即为我们需要的伪对象
            var fakeReader = new Mock<ILogReader>();

            // 当调用ILogReader接口的ReadLineAt(-1)方法时，抛出ArgumentOutOfRangeException异常
            fakeReader.Setup(fake => fake.ReadLineAt(-1)).Throws<ArgumentOutOfRangeException>();

            //将伪对象注入到被测试类
            logSystem.OpenRead(fakeReader.Object);

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

            // 新建一个ILogReader的Mock对象，其Object属性即为我们需要的伪对象
            var fakeReader = new Mock<ILogReader>();

            // 伪造ILogReader接口的CurrentLine属性时，并且赋初值为3
            fakeReader.SetupProperty(fake => fake.CurrentLine, 3);

            // 当调用ILogReader接口的ReadLine()方法时，触发回调函数，将伪对象的CurrentLine属性值+1
            fakeReader.Setup(fake => fake.ReadLine()).Callback(() => fakeReader.Object.CurrentLine++);

            //将伪对象注入到被测试类
            logSystem.OpenRead(fakeReader.Object);

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

            // 新建一个ILogReader的Mock对象，其Object属性即为我们需要的伪对象
            var fakeReader = new Mock<ILogReader>();
            // 当连续调用ILogReader接口的ReadLine()方法时，依次返回"运行正常"，"运行异常"，"存储空间不足"
            // 并在最后抛出InvalidOperationException异常
            fakeReader.SetupSequence(fake => fake.ReadLine())
                      .Returns("运行正常")
                      .Returns("运行异常")
                      .Returns("存储空间不足")
                      .Throws<InvalidOperationException>();

            //将伪对象注入到被测试类
            logSystem.OpenRead(fakeReader.Object);

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

            // 新建一个ILogWriter的Mock对象，其Object属性即为我们需要的伪对象
            var fakeWriter = new Mock<ILogWriter>();
            // 新建一个ISource的Mock对象，其Object属性即为我们需要的ISource伪对象
            var fakeSource = new Mock<ISource>();
            //将ISource伪对象注入到ILogWriter伪对象的属性
            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            int count = 3;

            // 当连续调用ILogWriter接口的CurrentLine属性的Get方法时，返回count的值
            fakeWriter.SetupGet(fake => fake.CurrentLine).Returns(() => count);

            // 当连续调用ILogWriter接口的AppendLine方法，并输入任意string类型参数时，触发回调使count的值+1
            fakeWriter.Setup(fake => fake.AppendLine(It.IsAny<string>())).Callback(() => count++);

            //将伪对象注入到被测试类
            logSystem.OpenAppend(fakeWriter.Object);

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

            // 新建一个ILogWriter的Mock对象，其Object属性即为我们需要的伪对象
            var fakeWriter = new Mock<ILogWriter>();
            // 新建一个ISource的Mock对象，其Object属性即为我们需要的ISource伪对象
            var fakeSource = new Mock<ISource>();
            //将ISource伪对象注入到ILogWriter伪对象的属性
            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            // 伪造ILogWriter接口的CurrentLine属性
            fakeWriter.SetupProperty(fake => fake.CurrentLine);
            fakeWriter.Object.CurrentLine = 3;
            // 当连续调用ILogWriter接口的AppendLine方法，并输入任意string类型参数时，触发回调使伪对象CurrentLine属性的值+1
            fakeWriter.Setup(fake => fake.AppendLine(It.IsAny<string>()))
                      .Callback(() => fakeWriter.Object.CurrentLine++);

            //将伪对象注入到被测试类
            logSystem.OpenAppend(fakeWriter.Object);

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

            // 新建一个ILogWriter的Mock对象，其Object属性即为我们需要的伪对象
            var fakeWriter = new Mock<ILogWriter>();
            // 伪造ILogWriter接口的Source属性的Uri属性，并且赋初值new Uri("Log.txt", UriKind.Relative)
            fakeWriter.SetupProperty(fake => fake.Source.Uri, new Uri("Log.txt", UriKind.Relative));

            //将伪对象注入到被测试类
            logSystem.OpenAppend(fakeWriter.Object);

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

            // 新建一个ILogWriter的Mock对象，其Object属性即为我们需要的伪对象
            var fakeWriter = new Mock<ILogWriter>();
            // 新建一个ISource的Mock对象，其Object属性即为我们需要的ISource伪对象
            var fakeSource = new Mock<ISource>();
            //将ISource伪对象注入到ILogWriter伪对象的属性
            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            //将伪对象注入到被测试类
            logSystem.OpenAppend(fakeWriter.Object);

            // 触发ISource接口的Updated事件，并且设sender为ISource伪对象，参数为new DateTime(2018, 10, 10)
            fakeSource.Raise(fake => fake.Updated += null, fakeSource.Object, new DateTime(2018, 10, 10));

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

            // 新建一个ILogReader的Mock对象，其Object属性即为我们需要的伪对象
            var fakeReader = new Mock<ILogReader>();

            // 当调用ILogReader接口的ReadLineAt()方法，并传入[0,10]范围的int类型参数时，将返回运行正常字符串
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns("运行正常");
            // 当调用ILogReader接口的ReadLineAt()方法，并传入(int.MinValue,0)范围的int类型参数时，
            // 抛出ArgumentOutOfRangeException异常
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(int.MinValue, 0, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();
            // 当调用ILogReader接口的ReadLineAt()方法，并传入(10,int.MaxValue)范围的int类型参数时，
            // 抛出ArgumentOutOfRangeException异常
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(10, int.MaxValue, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();

            //将伪对象注入到被测试类
            logSystem.OpenRead(fakeReader.Object);

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

            // 新建一个ILogReader的Mock对象，其Object属性即为我们需要的伪对象
            var fakeReader = new Mock<ILogReader>();

            // 当调用ILogReader接口的ReadLineAt()方法，并传入[0,10]范围的int类型参数时，将返回运行正常字符串
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns("运行正常");
            // 当调用ILogReader接口的ReadLineAt()方法，并传入(int.MinValue,0)范围的int类型参数时，
            // 抛出ArgumentOutOfRangeException异常
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(int.MinValue, 0, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();
            // 当调用ILogReader接口的ReadLineAt()方法，并传入(10,int.MaxValue)范围的int类型参数时，
            // 抛出ArgumentOutOfRangeException异常
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(10, int.MaxValue, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();

            //将伪对象注入到被测试类
            logSystem.OpenRead(fakeReader.Object);

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

            // 新建一个ILogWriter的Mock对象，其Object属性即为我们需要的伪对象
            var fakeWriter = new Mock<ILogWriter>();
            // 新建一个ISource的Mock对象，其Object属性即为我们需要的ISource伪对象
            var fakeSource = new Mock<ISource>();
            //将ISource伪对象注入到ILogWriter伪对象的属性
            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            // 当调用ILogReader接口的Save()方法时，返回true
            fakeWriter.Setup(fake => fake.Save()).Returns(true);

            //将伪对象注入到被测试类
            logSystem.OpenAppend(fakeWriter.Object);

            var result = logSystem.Save();

            fakeWriter.Verify(fake => fake.Save(), Times.Once);
            //fakeWriter.Verify(fake => fake.Source, Times.Once);
            //fakeWriter.VerifyNoOtherCalls();
        }

        #endregion
    }
}
