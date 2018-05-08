using Log;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class TestWithoutMoq
    {
        /// <summary>
        /// 假设：日志当前行内容为“运行正常”
        /// 执行：ReadLine
        /// 期望：返回“运行正常”
        /// </summary>
        [TestMethod]
        public void ReadLine()
        {
            var logSystem = new LogSystem();

            logSystem.OpenRead(new Reader());

            var result = logSystem.ReadLine();

            Assert.AreEqual("运行正常", result);
        }

    }
}
