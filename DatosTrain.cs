using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Perceptron
{
    class DatosTrain
    {
        //estos valores corresponden al conjunto de entrenamiento de los datos de entrada y sus
        //respectivas salidas esperadas para cada una de esas salidas dependiendo de la funcion que el preceptro aprenda

        //conjunto de datos de entrada
        readonly int[,] entradas = { { 1, 1 }, { 1, 0 }, { 0, 1 }, { 0, 0 } };

        //conjunto de datos de salidas esperadas para la funcion AND
        readonly int[] salidasesperadasAND =  { 1, 0, 0, 0 };

        //conjunto de datos de salidas esperadas para la funcion OR
        readonly int[] salidasesperadasOR = { 1, 1, 1, 0 };

        public int[,] GetEntradas()
        {
            return entradas;
        }

        public int[] GetSalidsEsperadasAnd()
        {
            return salidasesperadasAND;
        }

        public int[] GetSalidsEsperadasOr()
        {
            return salidasesperadasOR;
        }
    }
}
