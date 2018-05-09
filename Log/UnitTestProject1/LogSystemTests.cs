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
            // �½�һ��ILogReader��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeReader = new Mock<ILogReader>();

            // ������ILogReader�ӿڵ�ReadLine()����ʱ�����������������ַ���
            fakeReader.Setup(fake => fake.ReadLine()).Returns("��������");

            //��α����ע�뵽��������
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

            // �½�һ��ILogReader��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeReader = new Mock<ILogReader>();

            // ������ILogReader�ӿڵ�ReadLineAt(3)����ʱ�����������������ַ���
            fakeReader.Setup(fake => fake.ReadLineAt(3)).Returns("��������");

            //��α����ע�뵽��������
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

            // �½�һ��ILogReader��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeReader = new Mock<ILogReader>();

            // ������ILogReader�ӿڵ�ReadLineAt(3)����ʱ�����������������ַ���
            fakeReader.Setup(fake => fake.ReadLineAt(3)).Returns("��������");
            // ������ILogReader�ӿڵ�ReadLineAt(4)����ʱ�����������������ַ���
            fakeReader.Setup(fake => fake.ReadLineAt(4)).Returns("��������");

            //��α����ע�뵽��������
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

            // �½�һ��ILogReader��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeReader = new Mock<ILogReader>();

            // ������ILogReader�ӿڵ�ReadLineAt()����������������int���Ͳ���ʱ�����������������ַ���
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsAny<int>())).Returns("��������");

            //��α����ע�뵽��������
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

            // �½�һ��ILogReader��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeReader = new Mock<ILogReader>();

            // ������ILogReader�ӿڵ�Find()����������������string���Ͳ���ʱ��������$"{/*��������ַ���*/}��λ����line1"�ַ���
            fakeReader.Setup(fake => fake.Find(It.IsAny<string>())).Returns((string value) => $"{value}��λ����line1");

            //��α����ע�뵽��������
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

            // �½�һ��ILogReader��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeReader = new Mock<ILogReader>();

            // ������ILogReader�ӿڵ�ReadLineAt(-1)����ʱ���׳�ArgumentOutOfRangeException�쳣
            fakeReader.Setup(fake => fake.ReadLineAt(-1)).Throws<ArgumentOutOfRangeException>();

            //��α����ע�뵽��������
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

            // �½�һ��ILogReader��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeReader = new Mock<ILogReader>();

            // α��ILogReader�ӿڵ�CurrentLine����ʱ�����Ҹ���ֵΪ3
            fakeReader.SetupProperty(fake => fake.CurrentLine, 3);

            // ������ILogReader�ӿڵ�ReadLine()����ʱ�������ص���������α�����CurrentLine����ֵ+1
            fakeReader.Setup(fake => fake.ReadLine()).Callback(() => fakeReader.Object.CurrentLine++);

            //��α����ע�뵽��������
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

            // �½�һ��ILogReader��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeReader = new Mock<ILogReader>();
            // ����������ILogReader�ӿڵ�ReadLine()����ʱ�����η���"��������"��"�����쳣"��"�洢�ռ䲻��"
            // ��������׳�InvalidOperationException�쳣
            fakeReader.SetupSequence(fake => fake.ReadLine())
                      .Returns("��������")
                      .Returns("�����쳣")
                      .Returns("�洢�ռ䲻��")
                      .Throws<InvalidOperationException>();

            //��α����ע�뵽��������
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

            // �½�һ��ILogWriter��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeWriter = new Mock<ILogWriter>();
            // �½�һ��ISource��Mock������Object���Լ�Ϊ������Ҫ��ISourceα����
            var fakeSource = new Mock<ISource>();
            //��ISourceα����ע�뵽ILogWriterα���������
            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            int count = 3;

            // ����������ILogWriter�ӿڵ�CurrentLine���Ե�Get����ʱ������count��ֵ
            fakeWriter.SetupGet(fake => fake.CurrentLine).Returns(() => count);

            // ����������ILogWriter�ӿڵ�AppendLine����������������string���Ͳ���ʱ�������ص�ʹcount��ֵ+1
            fakeWriter.Setup(fake => fake.AppendLine(It.IsAny<string>())).Callback(() => count++);

            //��α����ע�뵽��������
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

            // �½�һ��ILogWriter��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeWriter = new Mock<ILogWriter>();
            // �½�һ��ISource��Mock������Object���Լ�Ϊ������Ҫ��ISourceα����
            var fakeSource = new Mock<ISource>();
            //��ISourceα����ע�뵽ILogWriterα���������
            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            // α��ILogWriter�ӿڵ�CurrentLine����
            fakeWriter.SetupProperty(fake => fake.CurrentLine);
            fakeWriter.Object.CurrentLine = 3;
            // ����������ILogWriter�ӿڵ�AppendLine����������������string���Ͳ���ʱ�������ص�ʹα����CurrentLine���Ե�ֵ+1
            fakeWriter.Setup(fake => fake.AppendLine(It.IsAny<string>()))
                      .Callback(() => fakeWriter.Object.CurrentLine++);

            //��α����ע�뵽��������
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

            // �½�һ��ILogWriter��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeWriter = new Mock<ILogWriter>();
            // α��ILogWriter�ӿڵ�Source���Ե�Uri���ԣ����Ҹ���ֵnew Uri("Log.txt", UriKind.Relative)
            fakeWriter.SetupProperty(fake => fake.Source.Uri, new Uri("Log.txt", UriKind.Relative));

            //��α����ע�뵽��������
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

            // �½�һ��ILogWriter��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeWriter = new Mock<ILogWriter>();
            // �½�һ��ISource��Mock������Object���Լ�Ϊ������Ҫ��ISourceα����
            var fakeSource = new Mock<ISource>();
            //��ISourceα����ע�뵽ILogWriterα���������
            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            //��α����ע�뵽��������
            logSystem.OpenAppend(fakeWriter.Object);

            // ����ISource�ӿڵ�Updated�¼���������senderΪISourceα���󣬲���Ϊnew DateTime(2018, 10, 10)
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

            // �½�һ��ILogReader��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeReader = new Mock<ILogReader>();

            // ������ILogReader�ӿڵ�ReadLineAt()������������[0,10]��Χ��int���Ͳ���ʱ�����������������ַ���
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns("��������");
            // ������ILogReader�ӿڵ�ReadLineAt()������������(int.MinValue,0)��Χ��int���Ͳ���ʱ��
            // �׳�ArgumentOutOfRangeException�쳣
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(int.MinValue, 0, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();
            // ������ILogReader�ӿڵ�ReadLineAt()������������(10,int.MaxValue)��Χ��int���Ͳ���ʱ��
            // �׳�ArgumentOutOfRangeException�쳣
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(10, int.MaxValue, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();

            //��α����ע�뵽��������
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

            // �½�һ��ILogReader��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeReader = new Mock<ILogReader>();

            // ������ILogReader�ӿڵ�ReadLineAt()������������[0,10]��Χ��int���Ͳ���ʱ�����������������ַ���
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns("��������");
            // ������ILogReader�ӿڵ�ReadLineAt()������������(int.MinValue,0)��Χ��int���Ͳ���ʱ��
            // �׳�ArgumentOutOfRangeException�쳣
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(int.MinValue, 0, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();
            // ������ILogReader�ӿڵ�ReadLineAt()������������(10,int.MaxValue)��Χ��int���Ͳ���ʱ��
            // �׳�ArgumentOutOfRangeException�쳣
            fakeReader.Setup(fake => fake.ReadLineAt(It.IsInRange<int>(10, int.MaxValue, Range.Exclusive)))
                      .Throws<ArgumentOutOfRangeException>();

            //��α����ע�뵽��������
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

            // �½�һ��ILogWriter��Mock������Object���Լ�Ϊ������Ҫ��α����
            var fakeWriter = new Mock<ILogWriter>();
            // �½�һ��ISource��Mock������Object���Լ�Ϊ������Ҫ��ISourceα����
            var fakeSource = new Mock<ISource>();
            //��ISourceα����ע�뵽ILogWriterα���������
            fakeWriter.SetupProperty(fake => fake.Source, fakeSource.Object);

            // ������ILogReader�ӿڵ�Save()����ʱ������true
            fakeWriter.Setup(fake => fake.Save()).Returns(true);

            //��α����ע�뵽��������
            logSystem.OpenAppend(fakeWriter.Object);

            var result = logSystem.Save();

            fakeWriter.Verify(fake => fake.Save(), Times.Once);
            //fakeWriter.Verify(fake => fake.Source, Times.Once);
            //fakeWriter.VerifyNoOtherCalls();
        }

        #endregion
    }
}
