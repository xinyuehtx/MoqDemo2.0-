using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Moq.Protected;
using Tips;

namespace TipsTests
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
        public void SelfIntrodution()
        {
            var fakeChinese = new Mock<Man>() { CallBase = true };
            fakeChinese.SetupAllProperties();
            fakeChinese.Object.Name = "腾霄";
            fakeChinese.Protected().SetupGet<string>("FamilyName").Returns("黄");
            fakeChinese.Setup(fake => fake.SelfIntrodution())
                       .Returns(() => "大家好，我是" + fakeChinese.Object.GetFullName());
            var result = Introdution.SelfIntrodution(fakeChinese.Object);
            Assert.AreEqual("大家好，我是黄腾霄", result);
        }
    }
}
