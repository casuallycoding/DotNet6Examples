using System.Reflection;

namespace DotNet6Examples.LambdaAttributes
{
    public class LambdaAttributes : IExampleInterface
    {
        public void Run()
        {
            var choose =[ExampleAttribute("Test")] object (bool b) => b ? 1 : "two";

            var trueChoice = choose(true);
            var falseChoice = choose(false);



        }


        public static void GetAttribute(Type t)
        {   // Get the method-level attributes.
            // Get all methods in this class, and put them
            // in an array of System.Reflection.MemberInfo objects.
            MemberInfo[] MyMemberInfo = t.GetMethods();

            // Loop through all methods in this class that are in the
            // MyMemberInfo array.
            for (int i = 0; i < MyMemberInfo.Length; i++)
            {
                var att = (ExampleAttribute)Attribute.GetCustomAttribute(MyMemberInfo[i], typeof(ExampleAttribute));
                if (att == null)
                {
                    Console.WriteLine("No attribute in member function {0}.\n", MyMemberInfo[i].ToString());
                }
                else
                {
                    Console.WriteLine("The Name Attribute for the {0} member is: {1}.",
                        MyMemberInfo[i].ToString(), att.name);

                }
            }
        }











    }

    [System.AttributeUsage(System.AttributeTargets.Method)]
    public class ExampleAttribute : System.Attribute
    {
        public string name;
        public double version;

        public ExampleAttribute(string name)
        {
            this.name = name;
            version = 1.0;
        }

    }
}