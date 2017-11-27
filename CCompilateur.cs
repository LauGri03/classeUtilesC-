//Classe statique pour la compilation de code C#
using System;
using System.CodeDom.Compiler;
using System.Diagnostics;

namespace Compilation
{
    static class CCompilateur
    {
        
        public static string build(string output, string code, bool run) //output = nom de l'executable de sortie; code = code c#; run = Rouler le programme apres compilation ou non ?;
        {
            string result = null;
            CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters parameters = new CompilerParameters();
            parameters.GenerateExecutable = true;                       //Declaration des parametres pour la creation de l'executable
            parameters.OutputAssembly = output + ".exe";
            CompilerResults results = codeProvider.CompileAssemblyFromSource(parameters, code); //Compilqtion du code

            if (results.Errors.Count > 0)
            {
                
                foreach (CompilerError CompErr in results.Errors)
                {
                    result = result +
                                "Line number " + CompErr.Line +
                                ", Error Number: " + CompErr.ErrorNumber + //Retour de l'erreur si erreur il y a
                                ", '" + CompErr.ErrorText + ";" +
                                Environment.NewLine + Environment.NewLine;
                }
            }
            else
            {
                result = "Success!";
                if (run)                     
                    Process.Start(output); //Run de l'executable
            }

            return result;

        }
    }
}
