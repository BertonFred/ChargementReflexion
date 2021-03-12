using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using AssemblyInterface;

namespace ChargementInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            string AssemblyName = "AssemblySample";
            string ClassName = "ClassSample";
            string AssemblyCompleteFileName = $@"..\..\..\{AssemblyName}\bin\debug\{AssemblyName}.dll";

            try
            {
                // Chargement de l'assembly par le nom de fichier complet 
                Console.WriteLine($"Chargement de l'assembly par le nom de fichier complet [{AssemblyCompleteFileName}]");
                Assembly assem = Assembly.Load(AssemblyName);

                // Type depuis une string avec le type name
                Console.WriteLine($"Type depuis GetType({AssemblyName}.{ClassName})");
                Type type = assem.GetType($"{AssemblyName}.{ClassName}");
                Console.WriteLine($"{type.Name} / {type.FullName}");

                // La liste des types GetTypes()
                Console.WriteLine("\nLa liste des types GetTypes()");
                Type[] types = assem.GetTypes();
                foreach(Type t in types)
                    Console.WriteLine($"{t.Name} / {t.FullName}");

                // La liste des types exportés
                Console.WriteLine("\nLa liste des types GetExportedTypes()");
                Type[] typesExported = assem.GetExportedTypes();
                foreach (Type t in typesExported)
                    Console.WriteLine($"{t.Name} / {t.FullName}");

                // Creation des instances
                Console.WriteLine("\nCreation des instances");
                object obj1 = Activator.CreateInstance(type);
                object obj2 = Activator.CreateInstance("AssemblySample", "AssemblySample.ClassSample");
                object obj3 = Activator.CreateInstance("AssemblySample", "AssemblySample.ClassePrivate");

                // Api a la main
                Console.WriteLine($"Appel a la main de la propriété StringProperty");
                PropertyInfo prop = type.GetProperty("StringProperty");
                prop.SetValue(obj1, "Fred");
                Console.WriteLine($"StringProperty = {prop.GetValue(obj1)}");

                // appel de methode
                Console.WriteLine($"Appel a la main de la méthode InitMethod");
                MethodInfo method = type.GetMethod("InitMethod");
                method.Invoke(obj1, new object[] { 10, 20, "Zorg" }); ;
                Console.WriteLine($"StringProperty = {prop.GetValue(obj1)}");

                // Utilisation d'un interface
                Type typeClassSample2 = assem.GetType("AssemblySample.ClassSample2");
                IInterfaceCommun objByIC = (IInterfaceCommun) Activator.CreateInstance(typeClassSample2);

                // utilisation de dynamic
                // Ce code compile malgré que dyn ne connais pas le methode qu'il appelle
                dynamic dyn = Activator.CreateInstance(typeClassSample2);
                dyn.InitMethod(10, 20, "string");
                string s = dyn.StringProperty;
                
                // exception car le methode n'existe pas
                dyn.ini();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[KO]Exception \n {ex.Message}");
            }

            Console.WriteLine("\nAppuyez sur une touche pour fermer");
            Console.ReadKey();
        }
    }
}
