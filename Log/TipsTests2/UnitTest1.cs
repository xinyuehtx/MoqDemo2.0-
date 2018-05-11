using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Tips;

namespace TipsTests2
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 假设：一个中国人叫黄腾霄，自我介绍为"大家好，我是黄腾霄"
        /// 执行：Introdution.SelfIntrodution
        /// 期望：返回"大家好，我是黄腾霄"
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var fakeChinese = new Mock<Man>();
            
            var result = Introdution.SelfIntrodution(fakeChinese.Object);
            Assert.AreEqual("大家好，我是黄腾霄", result);
        }
    }
}
