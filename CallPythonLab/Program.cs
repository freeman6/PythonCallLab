using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronPython;
using IronPython.Hosting;

namespace CallPythonLab
{
    class Program
    {
        static void Main(string[] args)
        {
            //instance of python engine
            var engine = Python.CreateEngine();
            
            //reading code from file
            var source = engine.CreateScriptSourceFromFile(AppDomain.CurrentDomain.BaseDirectory + "PythonSample.py");
            var scope = engine.CreateScope();
            
            //executing script in scope
            source.Execute(scope);
            var classCalculator = scope.GetVariable("calculator");
            
            //initializing class
            var calculatorInstance = engine.Operations.CreateInstance(classCalculator);
            Console.WriteLine($"5 + 10 = {calculatorInstance.add(5, 10)}");
            Console.WriteLine($"5++ = {calculatorInstance.increment(5)}");
            Console.WriteLine($"{engine.LanguageVersion}");
            Console.ReadLine();
        }
    }
}
