using Log;

namespace UnitTestProject1
{
    public class StubReader : ILogReader
    {
        public ISource Source { get; set; }
        public int CurrentLine { get; set; }

        public string ReadLine()
        {
            return "��������";
        }

        public string ReadLineAt(int line)
        {
            throw new System.NotImplementedException();
        }

        public string Find(string word)
        {
            throw new System.NotImplementedException();
        }
    }
}
