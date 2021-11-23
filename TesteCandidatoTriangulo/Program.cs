using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            int retorno = 0;

            retorno = new Triangulo().ResultadoTriangulo("[[6],[3,5]]");
            Console.WriteLine(retorno + " = " + 11);


            retorno = new Triangulo().ResultadoTriangulo("[[6],[3,5],[9,7,1],[4,6,8,4]]");
            Console.WriteLine(retorno+" = "+26);

            retorno = new Triangulo().ResultadoTriangulo("[[6],[3,5],[9,7,1]]");
            Console.WriteLine(retorno + " = " + 18);

            retorno = new Triangulo().ResultadoTriangulo("[[6],[3,5],[9,1,3],[4,6,1,4]]");
            Console.WriteLine(retorno + " = " + 18);

            
            retorno = new Triangulo().ResultadoTriangulo("[[6],[3,5],[9,1,3],[4,6,6,4]]");
            Console.WriteLine(retorno + " = " + 20);

            retorno = new Triangulo().ResultadoTriangulo("[[1],[1,1],[1,1,1],[1,1,1,1]]");
            Console.WriteLine(retorno + " = " + 4);

            retorno = new Triangulo().ResultadoTriangulo("[[1],[1,1],[1,1,1]]");
            Console.WriteLine(retorno + " = " + 3);
            



            Console.ReadLine();
        }
    }
}
