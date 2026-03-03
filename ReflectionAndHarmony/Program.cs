// See https://aka.ms/new-console-template for more information

using System.Reflection;
using ReflectionAndHarmony;

Console.WriteLine("Hello, World!");

// Assembly
// var reflectInfo = new ReflectInfo();
// reflectInfo.GetAssemblyInfo();
// reflectInfo.GetTypeInfo();
// reflectInfo.GetTypeContent();

HarmonyBootstrap.Init();
var service = new PaymentService();
for (int i = 0; i < 5; i++)
{
    var result = service.ProcessPaymentMethod(100);
    Console.WriteLine($"Final result: {result}");
    Console.WriteLine("------------------");
}