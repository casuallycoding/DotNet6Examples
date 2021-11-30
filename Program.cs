global using DotNet6ExamplesOddNamespace;
global using DotNet6Interface;


using DotNet6Examples;
using DotNet6Examples.InterpolatedStringHandler;
using DotNet6Examples.Lambda_Expressions;
using DotNet6Examples.LambdaAttributes;
using DotNet6Examples.StructImprovements;

// This class accesses a class in a namespace that is only declared globally in this method.
// Other default namespaces found here: https://docs.microsoft.com/en-us/dotnet/core/compatibility/sdk/6.0/implicit-namespaces-rc1
new GlobalNamespaceExample2().Run();

new LambdaExpressions().Run();
//new LambdaAttributes().Run();
new StructImprovementExample().Run();


new InterpolatedStringHandlerExample().Run();