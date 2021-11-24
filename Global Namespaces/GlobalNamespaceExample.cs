namespace DotNet6ExamplesOddNamespace
{
    public class GlobalNamespaceExample : IExampleInterface
    {

        public void print() => Console.WriteLine("Hello, World!");

        public void Run()
        {
            //Awesomely, all of this code works without importing a single namespace. This is because libraries like "linq" are now global namespace by default.
            var quickList = new List<String>() { "Value1", "Value2" };
            quickList.ForEach(q => Console.WriteLine(q));
        }


    }

}