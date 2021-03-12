using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChargementReflexion
{
    class Program
    {
        static void Main(string[] args)
        {
            string AssemblyName = @"AssemblySample";
            string AssemblyFileName = $@"..\..\..\{AssemblyName}\bin\debug\{AssemblyName}.dll";
            string ClassName = "ClassSample";
            string FullClassName = $"{AssemblyName}.{ClassName}";

            // Chargement de l'assembly dans un contexte de reflexion uniquement
            Assembly asm = Assembly.ReflectionOnlyLoadFrom(AssemblyFileName);
            Type t = asm.GetType(FullClassName);

            // Liste des constructeurs de la classe
            Console.WriteLine($"** Liste des constructeurs de la classe : {ClassName}");
            foreach (ConstructorInfo ci in t.GetConstructors())
            {
                Console.Write($"{ci.Name}(");
                foreach (ParameterInfo pi in ci.GetParameters())
                    Console.Write($"{pi.ParameterType} {pi.Name} ");
                Console.WriteLine(")");
            }

            // Liste des methodes de la classe
            Console.WriteLine($"** Liste des méthodes de la classe : {ClassName}");
            foreach (MethodInfo mi in t.GetMethods())
            {
                Console.Write($"{mi.ReturnType} {mi.Name}(");
                foreach (ParameterInfo pi in mi.GetParameters())
                    Console.Write($"{pi.ParameterType} {pi.Name} ");
                Console.WriteLine(")");
            }

            // Liste des propriétés de la classe
            Console.WriteLine($"** Liste des propriétés de la classe : {ClassName}");
            foreach (PropertyInfo pi in t.GetProperties())
            {
                Console.Write($"{pi.PropertyType} {pi.Name} {{");
                if (pi.CanRead == true) Console.Write("get; ");
                if (pi.CanWrite == true) Console.Write("set; ");
                Console.WriteLine("}");
            }

            // Liste des interfaces de la classe
            Console.WriteLine($"** Liste des interfaces de la classe : {ClassName}");
            foreach (Type ti in t.GetInterfaces())
            {
                Console.WriteLine($"{ti.Name}");
            }

            // Dans un contexte de reflexion uniquement, pas d'instance possible
            // Le code ci-dessous provoque donc une exception
            try
            {
                Console.WriteLine($"** Essai de creation d'une instance de la classe : {t.Name} ");
                Object objInstacnce = Activator.CreateInstance(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception : {ex.Message}");
            }

            Console.WriteLine("\nAppuyez sur une touche pour fermer");
            Console.ReadKey();
        }
    }
}
