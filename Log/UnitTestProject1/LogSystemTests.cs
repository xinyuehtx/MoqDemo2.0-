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
        #region α�췽��

        //α���޲�������
        /// <summary>
        /// ���裺��־��ǰ������Ϊ������������
        /// ִ�У�ReadLine
        /// ���������ء�����������
        /// </summary>
        [TestMethod]
        public void ReadLine()
        {
            var logSystem = new LogSystem();

            var fakeReader = new Mock<ILogReader>();

            fakeReader.Setup(fake => fake.ReadLine()).Returns("��������");

            logSystem.OpenRead(fakeReader.Object);

            var result = logSystem.ReadLine();

            Assert.AreEqual("��������", result);
        }

        //α���в�������
        /// <summary>
        /// ���裺��־��3������Ϊ������������
        /// ִ�У�ReadLineAt(3)
        /// ���������ء�����������
        /// </summary>
        [TestMethod]
        public void ReadLineAt()
        {
            var logSystem = new LogSystem();

            var fakeReader = new Mock<ILogReader>();

            fakeReader.Setup(fake => fake.ReadLineAt(3)).Returns("��������");

            logSystem.OpenRead(fakeReader.Object);

            var result = logSystem.ReadLineAt(3);

            Assert.AreEqual("��������", result);
        }

        //α�����в�������
        /// <summary>
        /// ���裺��־���������ݶ�Ϊ������������
        /// ִ�У�ReadLineAt(3)
        /// ���������ء�����������
        /// ִ�У�ReadLineAt(4)
        /// ���������ء�����������
        /// </summary>
        [TestMethod]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadLineAt2(int i)
        {
            var logSystem = new LogSystem();

            var fakeReader = new Mock<ILogReader>();

            fakeReader.Setup(fake => fake.ReadLineAt(3)).Returns("��������");
            fakeReader.Setup(fake => fake.ReadLineAt(4)).Returns("��������");

            logSystem.OpenRead(fakeReader.Object);

            var result = logSystem.ReadLineAt(i);

            Assert.AreEqual("��������", result);
        }

        //α�췽������ƥ��
        /// <summary>
        /// ���裺��־���������ݶ�Ϊ������������
        /// ִ�У�ReadLineAt(3)
        /// ���������ء�����������
        /// ִ�У�ReadLineAt(4)
        /// ���������ء�����������
        /// </summary>
        [TestMethod]
        [DataRow(3)]
        [DataRow(4)]
        public void ReadLineAt3(int i)
        {
            var logSystem = new LogSystem();

            var fakeReader = new Mock<ILogReader>();

            fakeReader.Setup(fake => fake.ReadLineAt(It.IsAny<int>())).Returns("��������");

            logSystem.OpenRead(fakeReader.Object);

            var result = logSystem.ReadLineAt(i);

            Assert.AreEqual("��������", result);
        }

        //α�췽������ֵ��������
        /// <summary>
        /// ���裺��־��0������Ϊ������������
        ///       ��־��1������Ϊ����ʱ�쳣��
        /// ִ�У�Find("�쳣")
        /// ����������"�쳣��λ����line1"
        /// /// ִ�У�Find("��ʱ")
        /// ����������"�쳣��λ����line1"
        /// </summary>
        [TestMethod]
        [DataRow("�쳣")]
        [DataRow("��ʱ")]
        public void Find(string s)
        {
            var logSystem = new LogSystem();

            var fakeReader = new Mock<ILogReader>();

            fakeReader.Setup(fake => fake.Find(It.IsAny<string>())).Returns((string value) => $"{value}��λ����line1");

            logSystem.OpenRead(fakeReader.Object);

            var result = logSystem.Find(s);

            Assert.AreEqual($"{s}��λ����line1", result);
        }

        //α�췽���׳��쳣
        /// <summary>
        /// ִ�У�ReadLineAt(-1)
        /// ���������ء����޴��С�
        /// </summary>
        [TestMethod]
        public void ReadLineAt4()
        {
            var logSystem = new LogSystem();

            var fakeReader = new Mock<ILogReader>();

            fakeReader.Setup(fake => fake.ReadLineAt(-1)).Throws<ArgumentOutOfRangeException>();

            logSystem.OpenRead(fakeReader.Object);

            var result = logSystem.ReadLineAt(-1);

            Assert.AreEqual("���޴���", result);
        }

        //α�췽���ص�
        /// <summary>
        /// ���裺��־��ǰ��Ϊ3
        /// ִ�У�ReadLine()
        /// ��������־��ǰ�б�Ϊ4
        /// </summary>
        [TestMethod]
        public void ReadLine2()
        {
            var logSystem = new LogSystem();

            var fakeReader = new Mock<ILogReader>();

            fakeReader.SetupProperty(fake => fake.CurrentLine, 3);

            fakeReader.Setup(fake => fake.ReadLine()).Callback(() => fakeReader.Object.CurrentLine++);

            logSystem.OpenRead(fakeReader.Object);

            logSystem.ReadLine();

            Assert.AreEqual(4, logSystem.Reader.CurrentLine);
        }


        //α�췽������ֵ����
        /// <summary>
        /// ���裺��־����Ϊ��
        ///       ��������
        ///       �����쳣
        ///       �洢�ռ䲻��
        /// ִ�У�ReadAll()
        /// ���������ء���������;�����쳣;�洢�ռ䲻��;��
        /// </summary>
        [TestMethod]
        public void ReadAll()
        {
            var logSystem = new LogSystem();

            var fakeReader = new Mock<ILogReader>();

            fakeReader.SetupSequence(fake => fake.ReadLine())
                      .Returns("��������")
                      .Returns("�����쳣")
                      .Returns("�洢�ռ䲻��")
                      .Throws<InvalidOperationException>();

            logSystem.OpenRead(fakeReader.Object);

            var result = logSystem.ReadAll();

            Assert.AreEqual("��������;�����쳣;�洢�ռ䲻��;", result);
        }

        #endregion

        #region α������

        //α�����Է���ֵ
        /// <summary>
        /// ���裺��־��ǰ��Ϊ3
        /// ִ�У�AppendLine("�����쳣")
        /// ����������4
        /// </summary>
        [TestMethod]
        public void AppendLine()
        {
            var logSystem = new LogSystem();

            var fakeWriter = new Mock<ILogWriter>();
            var fakeSource = new Mock<ISource>();
            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            int count = 3;

            fakeWriter.SetupGet(fake => fake.CurrentLine).Returns(() => count);

            fakeWriter.Setup(fake => fake.AppendLine(It.IsAny<string>())).Callback(() => count++);

            logSystem.OpenAppend(fakeWriter.Object);

            logSystem.AppendLine("��������");

            Assert.AreEqual(4, logSystem.Writer.CurrentLine);
        }

        //α���Զ�����
        /// <summary>
        /// ���裺��־��ǰ��Ϊ3
        /// ִ�У�AppendLine("�����쳣")
        /// ����������4
        /// </summary>
        [TestMethod]
        public void AppendLine2()
        {
            var logSystem = new LogSystem();

            var fakeWriter = new Mock<ILogWriter>();
            var fakeSource = new Mock<ISource>();
            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            fakeWriter.SetupProperty(fake => fake.CurrentLine);
            fakeWriter.Object.CurrentLine = 3;
            fakeWriter.Setup(fake => fake.AppendLine(It.IsAny<string>())).Callback(() => fakeWriter.Object.CurrentLine++);

            logSystem.OpenAppend(fakeWriter.Object);

            logSystem.AppendLine("��������");

            Assert.AreEqual(4, logSystem.Writer.CurrentLine);
        }

        //�ݹ�α������
        /// <summary>
        /// ���裺��ǰ��־��Uri��"Log.txt"
        /// ִ�У�ShowUri()
        /// ����������"Log.txt"
        /// </summary>
        [TestMethod]
        public void ShowUri()
        {
            var logSystem = new LogSystem();

            var fakeWriter = new Mock<ILogWriter>();
            fakeWriter.SetupProperty(fake => fake.Source.Uri, new Uri("Log.txt",UriKind.Relative));

            logSystem.OpenAppend(fakeWriter.Object);

            var result = logSystem.ShowUri();

            Assert.AreEqual("Log.txt", result);
        }

        #endregion

        #region α���¼�

        /// <summary>
        /// ִ�У�ISource����Updated�¼�
        /// ������UpdatedTime����ʱ��
        /// </summary>
        [TestMethod]
        public void UpdatedTime()
        {
            var logSystem = new LogSystem();

            var fakeWriter = new Mock<ILogWriter>();
            var fakeSource = new Mock<ISource>();

            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            logSystem.OpenAppend(fakeWriter.Object);

            fakeSource.Raise(fake => fake.Updated += null, fakeSource.Object, new DateTime(2018, 10, 10));

            Assert.AreEqual(new DateTime(2018, 10, 10), logSystem.UpdatedTime);
        }

        #endregion

        #region ����ƥ��

        //α�췽������ƥ��
        /// <summary>
        /// ���裺��־��0-10�����ݶ�Ϊ������������
        /// ִ�У�ReadLineAt(0)
        /// ���������ء�����������
        /// ִ�У�ReadLineAt(10)
        /// ���������ء�����������
        /// </summary>
        [TestMethod]
        [DataRow(0)]
        [DataRow(10)]
        public void ReadLineAt5(int i)
        {
            var logSystem = new LogSystem();

            var fakeReader = new Mock<ILogReader>();

            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns("��������");
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(int.MinValue, 0, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(10, int.MaxValue, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();

            logSystem.OpenRead(fakeReader.Object);

            var result = logSystem.ReadLineAt(i);

            Assert.AreEqual("��������", result);
        }

        //α�췽������ƥ��
        /// <summary>
        /// ���裺��־��0-10�����ݶ�Ϊ������������
        /// ִ�У�ReadLineAt(-1)
        /// ���������ء����޴��С�
        /// ִ�У�ReadLineAt(11)
        /// ���������ء����޴��С�
        /// </summary>
        [TestMethod]
        [DataRow(-2)]
        [DataRow(11)]
        public void ReadLineAt6(int i)
        {
            var logSystem = new LogSystem();

            var fakeReader = new Mock<ILogReader>();

            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns("��������");
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(int.MinValue, 0, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(10, int.MaxValue, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();

            logSystem.OpenRead(fakeReader.Object);

            var result = logSystem.ReadLineAt(i);

            Assert.AreEqual("���޴���", result);
        }

        #endregion

        #region ��֤

        //α�췽������ƥ��
        /// <summary>
        /// ���裺��־��0-10�����ݶ�Ϊ������������
        /// /// ִ�У�ReadLineAt(-1)
        /// ���������ء����޴��С�
        /// ִ�У�ReadLineAt(11)
        /// ���������ء����޴��С�
        /// </summary>
        [TestMethod]
        public void Save()
        {
            var logSystem = new LogSystem();

            var fakeWriter = new Mock<ILogWriter>();
            var fakeSource = new Mock<ISource>();

            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);
            fakeWriter.Setup(fake => fake.Save()).Returns(true);

            logSystem.OpenAppend(fakeWriter.Object);

            var result = logSystem.Save();

            fakeWriter.Verify(fake => fake.Save(), Times.Once);
            //fakeWriter.Verify(fake => fake.Source, Times.Once);
            //fakeWriter.VerifyNoOtherCalls();
        }

        #endregion
    }
}
