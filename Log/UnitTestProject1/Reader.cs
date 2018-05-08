using Log;

namespace UnitTestProject1
{
    public class Reader : ILogReader
    {
        public ISource Source { get; set; }
        public int Line { get; set; }

        public string ReadLine()
        {
            return "运行正常";
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
