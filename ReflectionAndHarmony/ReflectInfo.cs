using System.Reflection;

namespace ReflectionAndHarmony;

public class ReflectInfo
{
    public void GetAssemblyInfo()
    {
        var assembly = Assembly.GetAssembly(typeof(ReflectInfo));
        Console.WriteLine(assembly);
        
        var entryAssembly = Assembly.GetEntryAssembly();
        Console.WriteLine(entryAssembly);
        
        var callingAssembly = Assembly.GetCallingAssembly();
        Console.WriteLine(callingAssembly);
        Console.WriteLine();
    }
    
    // A TypeInfo instance contains the definition for a Type.
    // a Type contains only reference data.
    public void GetTypeInfo()
    {
        var studentInfo = typeof(Student).GetTypeInfo();
        Console.WriteLine(studentInfo);
        Console.WriteLine();
        
        var declaredProperties = studentInfo.DeclaredProperties;
        Console.WriteLine("====Declared properties====");
        declaredProperties.ToList().ForEach(Console.WriteLine);
        Console.WriteLine();
        
        var declaredMethods = studentInfo.DeclaredMethods;
        Console.WriteLine("====Declared methods====");
        declaredMethods.ToList().ForEach(Console.WriteLine);
        Console.WriteLine();
    }

    public void GetTypeContent()
    {
        var studentType = typeof(Student);
        Console.WriteLine(studentType);
        Console.WriteLine("name: " + studentType.Name);
        Console.WriteLine("nameSpace: " + studentType.Namespace);
        Console.WriteLine();
        
        var members = studentType.GetMembers();
        Console.WriteLine("====Members members====");
        members.ToList().ForEach(m =>
        {
            Console.WriteLine( "{0}			{1}", m.MemberType, m.Name );
        });
        Console.WriteLine();
        
        var fields = studentType.GetFields();
        Console.WriteLine("====Fields fields====");
        fields.ToList().ForEach(Console.WriteLine);
        Console.WriteLine();
        
        var properties = studentType.GetProperties();
        Console.WriteLine("====Properties properties====");
        properties.ToList().ForEach(Console.WriteLine);
        Console.WriteLine();
        
        var method = studentType.GetMethod("GetCharacteristics");
        Console.WriteLine("====GetCharacteristics====");
        Console.WriteLine(method);
        var instance = new Student();
        Console.WriteLine(method!.Invoke(instance, null));
    }
}