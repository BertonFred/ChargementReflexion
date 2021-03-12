using System;
using System.Reflection;

public class Example
{
    public static void Main() 
    {
        Main_Load();
        Main_LoadFrom();
        Main_GetAssemblyName();
    }

    /// <summary>
    /// Test AssemblyName.GetAssemblyName
    /// </summary>
    public static void Main_GetAssemblyName()
    {
        string sAssemblyName = "AssemblySample";
        string sAssemblyCompleteFileName = $@"..\..\..\{sAssemblyName}\bin\debug\{sAssemblyName}.dll";
        string sAssemblyCompleteFileNameError = $@"..\..\..\{sAssemblyName}\bin\debug\{sAssemblyName}.pdb";

        try
        {
            // Test d'un fichier qui est un assembly 
            Console.WriteLine($"Test d'un fichier qui est un assembly {sAssemblyCompleteFileName}");
            AssemblyName testAssembly = AssemblyName.GetAssemblyName(sAssemblyCompleteFileName);
            Console.WriteLine($"[OK] le fichier {sAssemblyCompleteFileName}\nest un assembly\n{testAssembly.FullName}");

            // Test d'un fichier qui n'est pas un assembly 
            Console.WriteLine($"\nTest d'un fichier qui n'est pas un assembly {sAssemblyCompleteFileNameError}");
            AssemblyName testAssemblyError = AssemblyName.GetAssemblyName(sAssemblyCompleteFileNameError);
            Console.WriteLine($"[OK] le fichier {sAssemblyCompleteFileNameError}\nest un assembly\n{testAssembly.FullName}");
        }
        catch (System.IO.FileNotFoundException fnfe)
        {
            Console.WriteLine($"[KO] Exception fichier non trouvé\n{fnfe.Message}.");
        }
        catch (System.BadImageFormatException bife)
        {
            Console.WriteLine($"[KO] Exception le fichier n'est pas un assembly\n{bife.Message}.");
        }
        catch (System.IO.FileLoadException fle)
        {
            Console.WriteLine($"[KO] L'assembly est déjà chargé\n{fle.Message}.");
        }

        Console.WriteLine("\nAppuyez sur une touche pour fermer");
        Console.ReadKey();
    }

    /// <summary>
    /// Test Assembly.LoadFrom
    /// </summary>
    public static void Main_LoadFrom()
    {
        string AssemblyName = "AssemblySample";
        string AssemblyCompleteFileName = $@"..\..\..\{AssemblyName}\bin\debug\{AssemblyName}.dll";
        string AssemblyCompleteFileNameError = $@"..\..\..\{AssemblyName}\ERROR\debug\{AssemblyName}.dll";

        try
        {
            // Chargement de l'assembly par le nom de fichier complet 
            Console.WriteLine($"Chargement de l'assembly par le nom de fichier complet [{AssemblyCompleteFileName}]");
            Assembly assem = Assembly.LoadFrom(AssemblyCompleteFileName);
            if (assem == null)
                Console.WriteLine($"[KO] Impossible de charger l'assembly {AssemblyCompleteFileName}");
            else
                Console.WriteLine($"[OK] assembly charger {assem.FullName}");


            // Chargement de l'assembly par le nom de fichier complet avec erreur 
            Console.WriteLine($"Chargement de l'assembly par le nom de fichier complet avec erreur [{AssemblyCompleteFileNameError}]");
            assem = Assembly.LoadFrom(AssemblyCompleteFileNameError);
            if (assem == null)
                Console.WriteLine($"[KO] Impossible de charger l'assembly {AssemblyCompleteFileNameError}");
            else
                Console.WriteLine($"[OK] assembly charger {assem.FullName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[KO]Exception \n {ex.Message}");
        }

        Console.WriteLine("\nAppuyez sur une touche pour fermer");
        Console.ReadKey();
    }

    /// <summary>
    /// Test Assembly.Load
    /// </summary>
    public static void Main_Load()
    {
        string AssemblyName = "AssemblySample";
        string AssemblyLongName = $"{AssemblyName}, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
        string AssemblyLongNameError = $"{AssemblyName}, Version=1.0.0.0, Culture=fr, PublicKeyToken=null";

        try
        {
            // Chargement de l'assembly avec le nom court
            Console.WriteLine($"Chargement de l'assembly par le nom [{AssemblyName}]");
            Assembly assem = Assembly.Load(AssemblyName);
            if (assem == null)
                Console.WriteLine($"[KO] Impossible de charger l'assembly {AssemblyName}");
            else
                Console.WriteLine($"[OK] assembly charger {assem.FullName}");

            // Chargement de l'assembly avec le nom complet
            Console.WriteLine($"Chargement de l'assembly par le nom [{AssemblyLongName}]");
            assem = Assembly.Load(AssemblyLongName);
            if (assem == null)
                Console.WriteLine($"[KO] Impossible de charger l'assembly {AssemblyLongName}");
            else
                Console.WriteLine($"[OK] assembly charger {assem.FullName}");

            // Chargement de l'assembly avec une erreur dans le nom complet
            Console.WriteLine($"Chargement de l'assembly avec une erreur dans le nom complet [{AssemblyLongNameError}]");
            assem = Assembly.Load(AssemblyLongNameError);
            if (assem == null)
                Console.WriteLine($"[KO] Impossible de charger l'assembly {AssemblyLongNameError}");
            else
                Console.WriteLine($"[OK] assembly charger {assem.FullName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[KO]Exception {ex.Message}");
        }

        Console.WriteLine("\nAppuyez sur une touche pour fermer");
        Console.ReadKey();
    }
}
