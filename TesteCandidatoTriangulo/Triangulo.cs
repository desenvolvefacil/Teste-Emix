using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteCandidatoTriangulo
{
    public class Triangulo
    {
        /// <summary>
        ///    6
        ///   3 5
        ///  9 7 1
        /// 4 6 8 4
        /// Um elemento somente pode ser somado com um dos dois elementos da próxima linha. Como o elemento 5 na Linha 2 pode ser somado com 7 e 1, mas não com o 9.
        /// Neste triangulo o total máximo é 6 + 5 + 7 + 8 = 26
        /// 
        /// Seu código deverá receber uma matriz (multidimensional) como entrada. O triângulo acima seria: [[6],[3,5],[9,7,1],[4,6,8,4]]
        /// </summary>
        /// <param name="dadosTriangulo"></param>
        /// <returns>Retorna o resultado do calculo conforme regra acima</returns>
        public int ResultadoTriangulo(string dadosTriangulo)
        {

            string aux = dadosTriangulo.Replace("],[", "#");

            aux = aux.Replace("[", "").Replace("]","");

            string[] l = aux.Split('#');

            int[,] lista = new int[l.Length, l.Length];

            //extrai os valores para montar a matriz
            int linha = 0;
            int coluna = 0;

            foreach (var item in l)
            {
                coluna = 0;

                string[] valores = item.Split(',');

                foreach (var val in valores)
                {
                    lista[linha,coluna] = int.Parse(val);

                    coluna++;
                }

                linha++;
            }


            int soma = lista[0,0];
            linha = 0;
            coluna = 0;

            for (linha = 1; linha < l.Length; linha++)
            {

                if(lista[linha,coluna]> lista[linha, coluna + 1])
                {
                    soma += lista[linha, coluna];
                }
                else
                {
                    soma += lista[linha, coluna+1];

                    coluna++;
                }

            }

            return soma;
            //return CalculaMaiorCaminho(lista,0,0, l.Length);
        }

        public int CalculaMaiorCaminho(int[,] m,int linha, int coluna, int tamanho)
        {

            if (linha + 2 >= tamanho)
            {
                int val = m[linha, coluna] + Math.Max(m[linha + 1, coluna], m[linha + 1, coluna + 1]);


                return val;
            }

            int esq =  m[linha, coluna] + CalculaMaiorCaminho(m, linha + 1, coluna, tamanho);

            int dir = m[linha, coluna] + CalculaMaiorCaminho(m, linha + 1, coluna+1, tamanho);


            int max = Math.Max(esq, dir);
            return max;

        }
    }
}
