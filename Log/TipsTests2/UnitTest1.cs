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
        /// ���裺һ���й��˽л����������ҽ���Ϊ"��Һã����ǻ�����"
        /// ִ�У�Introdution.SelfIntrodution
        /// ����������"��Һã����ǻ�����"
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var fakeChinese = new Mock<Man>();
            
            var result = Introdution.SelfIntrodution(fakeChinese.Object);
            Assert.AreEqual("��Һã����ǻ�����", result);
        }
    }
}
