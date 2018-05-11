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
        /// ���裺һ���й��˽л����������ҽ���Ϊ"��Һã����ǻ�����"
        /// ִ�У�Introdution.SelfIntrodution
        /// ����������"��Һã����ǻ�����"
        /// </summary>
        [TestMethod]
        public void SelfIntrodution()
        {
            var fakeChinese = new Mock<Man>() { CallBase = true };
            fakeChinese.SetupAllProperties();
            fakeChinese.Object.Name = "����";
            fakeChinese.Protected().SetupGet<string>("FamilyName").Returns("��");
            fakeChinese.Setup(fake => fake.SelfIntrodution())
                       .Returns(() => "��Һã�����" + fakeChinese.Object.GetFullName());
            var result = Introdution.SelfIntrodution(fakeChinese.Object);
            Assert.AreEqual("��Һã����ǻ�����", result);
        }
    }
}
