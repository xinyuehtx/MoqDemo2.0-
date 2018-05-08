using System;
using System.Text;

namespace Log
{
    public class LogSystem : ILogSystem
    {
        public ILogReader Reader { get; private set; } = null;
        public ILogWriter Writer { get; private set; } = null;
        public DateTime? UpdatedTime { get; set; } = null;

        public void OpenRead(ILogReader reader)
        {
            Reader = reader;
        }

        public void OpenAppend(ILogWriter writer)
        {
            Writer = writer;
            Writer.Source.Updated += Source_Updated;
        }

        public string Save()
        {
            if (Writer is null)
            {
                throw new InvalidOperationException();
            }

            return Writer.Save() ? "保存成功" : "保存失败";
        }

        public void Close()
        {
            Reader = null;
            if (Writer != null)
            {
                Writer.Source.Updated -= Source_Updated;
            }

            Writer = null;
        }

        public string ReadLine()
        {
            return Reader.ReadLine();
        }

        public string ReadLineAt(int line)
        {
            try
            {
                return Reader.ReadLineAt(line);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return "查无此行";
            }
        }

        public string ReadAll()
        {
            const string split = ";";
            var builder = new StringBuilder();
            while (true)
            {
                try
                {
                    builder.Append(Reader.ReadLine());
                    builder.Append(split);
                }
                catch (InvalidOperationException e)
                {
                    return builder.ToString();
                }
            }
        }

        public int AppendLine(string text)
        {
            Writer.AppendLine(text);
            return Writer.Line;
        }

        public int InsertLineAt(int line, string text, out string result)
        {
            try
            {
                Writer.InsertLineAt(line, text);
                result = "写入成功";
            }
            catch (ArgumentOutOfRangeException e)
            {
                result = "指定行号有误";
            }

            return Writer.Line;
        }

        public string Find(string word)
        {
            return Reader.Find(word);
        }

        public string ShowUri()
        {
            if (Reader != null)
            {
                return Reader.Source.Uri.ToString();
            }

            if (Writer != null)
            {
                return Writer.Source.Uri.ToString();
            }

            return string.Empty;
        }

        private void Source_Updated(object sender, DateTime e)
        {
            UpdatedTime = e;
        }
    }
}
