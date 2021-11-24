namespace DotNet6Examples
{
    public class GlobalNamespaceExample2 : ExampleInterface
    {
        //Despite being on a seperate namespace, we can access this perfectly as it's declared as a global namespace in "Program.cs"
        public void Run() => new GlobalNamespaceExample().Run();

    }
}