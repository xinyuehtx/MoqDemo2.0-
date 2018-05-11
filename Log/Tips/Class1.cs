using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("TipsTests")]
//[assembly:InternalsVisibleTo("DynamicProxyGenAssembly2")]

namespace Tips
{
    public abstract class Man
    {
        public string Name { get; set; }
        protected virtual string FamilyName { get; set; }

        internal virtual string GetFullName()
        {
            return FamilyName+Name;
        }

        internal abstract string SelfIntrodution();
    }

    public static class Introdution
    {
        public static string SelfIntrodution(Man man)
        {
            return man.SelfIntrodution();
        }
    }
}
