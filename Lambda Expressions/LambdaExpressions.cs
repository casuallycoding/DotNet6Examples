namespace DotNet6Examples.Lambda_Expressions
{
    public class LambdaExpressions : IExampleInterface
    {
        public void Run()
        {
            // Previously we'd have to declare the operation type as func or action
            Func<String, int> parse = (String s) => int.Parse(s);
            var oldVal = parse("10");
            //C# 10 will automatically work out the target type
            var newParse = (string s) => int.Parse(s);
            var newVal = newParse("25");

            //It works for Actions as well as Functions.
            var printNumber = (int s) => Console.WriteLine(s);
            printNumber(oldVal);
            printNumber(newVal);
            printNumber(oldVal + newVal);

        }
    }
}