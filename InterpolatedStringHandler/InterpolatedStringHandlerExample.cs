using System.Runtime.CompilerServices;
using System.Text;

namespace DotNet6Examples.InterpolatedStringHandler
{

    [InterpolatedStringHandler]
    public ref struct TestInterpolatedStringHandler
    {
        // Storage for the built-up string
        StringBuilder builder;

        // Add the receiver argument:
        public TestInterpolatedStringHandler(int literalLength, int formattedCount)
        {
            builder = new StringBuilder(literalLength);
        }

        public void AppendLiteral(string s)
        {
            builder.Append(quoteString(s));
        }

        public void AppendFormatted<T>(T s)
        {
            builder.Append(quoteString(s?.ToString()));
        }


        private String quoteString(String val) => "\"" + val + "\",";
        internal string GetFormattedText() => builder.Remove(builder.Length - 1, 1).ToString(); //Remove the final comma
    }



    public class InterpolatedStringHandlerExample : IExampleInterface
    {
        public void Run()
        {
            var commaSeperate = new CommaSeperator();
            var time = DateTime.Now;
            var user = new User("John");

            commaSeperate.CommaSeperate($"{time}Comma seporated between values{user}");
            commaSeperate.CommaSeperate($"This should just hit the literal string and be printed");
            commaSeperate.CommaSeperate($"{time}This will be comma seporated");


        }
    }

    public class CommaSeperator
    {
        public void CommaSeperate(string msg)
        {
            Console.WriteLine(msg);
        }



        public void CommaSeperate(TestInterpolatedStringHandler builder)
        {
            Console.WriteLine(builder.GetFormattedText());
        }
    }




    public class User
    {
        public User(String name) => Name = name;
        string Name { get; set; } = "";
        public override string ToString() => Name;
    }



}


