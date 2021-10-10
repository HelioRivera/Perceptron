using System;

namespace PerceptronSimple
{
    internal class Perceptron
    {
        double P0;
        double P1;
        double U;
        Random azar;

        //Tabla de verdad AND. estos valores corresponden al conjunto de entrenamiento de los datos de entrada y sus
        //respectivas salidas esperadas para cada uno de ellos 
        readonly int[,] entradas = { { 1, 1 }, { 1, 0 }, { 0, 1 }, { 0, 0 } };
        readonly int[] salidasesperadasAND = { 1, 0, 0, 0 };
        readonly int[] salidasesperadasOR = { 0, 1, 1, 1 };

        int iteracion;

        int funcionAaprender;

        private bool entrenada;

        internal void inizializar(int tipo)
        {
            //Único generador de números aleatorios
            azar = new Random(10);

            funcionAaprender = tipo;
            //Cuenta el número de iteraciones
            iteracion = 0;

            // define si la red ha sido entrenada
            entrenada = false;

            //Inicializa los pesos al azar
            P0 = azar.NextDouble();
            P1 = azar.NextDouble();
            U = azar.NextDouble();
        }

        //Muestra que el perceptrón simple aprendió.
        internal void comprobarAprendizaje()
        {

            for (int cont = 0; cont <= 3; cont++)
            {
                double operacion = entradas[cont, 0] * P0 + entradas[cont, 1] * P1 + U;
                //La función de activación
                int salidaEntera = funcionActivacion(operacion);

                //Imprime
                if (funcionAaprender == 1)
                {
                    Console.WriteLine("Entradas: " + entradas[cont, 0].ToString() + " y " + entradas[cont, 1].ToString() + " = " +
                    salidasesperadasAND[cont].ToString() + " perceptron: " + salidaEntera.ToString());
                }
                if (funcionAaprender == 2)
                {
                    Console.WriteLine("Entradas: " + entradas[cont, 0].ToString() + " y " + entradas[cont, 1].ToString() + " = " +
                   salidasesperadasOR[cont].ToString() + " perceptron: " + salidaEntera.ToString());
                }


            }
            Console.WriteLine("Pesos encontrados P0= " + P0.ToString() + " P1= " + P1.ToString() + " U= " + U.ToString());
            Console.WriteLine("Iteraciones requeridas: " + iteracion.ToString());
            Console.WriteLine("Presione ENTER para continuar... " );
            Console.ReadKey();
        }


        internal void entrenar()
        {
            
            //Variable que mantiene el proceso activo de buscar los pesos
            bool proceso = true;

            //Hasta que aprenda la tabla AND
            while (proceso)
            {
                iteracion++;

                //Optimista, en esta iteración se encuentra los pesos
                proceso = false;

                //Va por todas las reglas de la tabla AND
                for (int cont = 0; cont <= 3; cont++)
                {
                    //Calcula el valor de entrada a la función
                    double operacion = entradas[cont, 0] * P0 + entradas[cont, 1] * P1 + U;

                    //La función de activación
                    int target = funcionActivacion(operacion);

                    //Si la salida no coincide con lo esperado, cambia los pesos al azar
                    //aqui es donde se produce el ajuste de los pesos
                    if(funcionAaprender == 1)
                    {
                        if (target != salidasesperadasAND[cont])
                        {
                            P0 = azar.NextDouble();
                            P1 = azar.NextDouble();
                            U = azar.NextDouble();
                            proceso = true; //Y sigue buscando
                        }

                    }
                    if (funcionAaprender == 2)
                    {
                        if (target != salidasesperadasOR[cont])
                        {
                            P0 = azar.NextDouble();
                            P1 = azar.NextDouble();
                            U = azar.NextDouble();
                            proceso = true; //Y sigue buscando
                        }

                    }


                }
            }
            entrenada = true;
        }

        private int  funcionActivacion(double operacion)
        {
            if (operacion > 0.7)
                return  1;
            else
                return  0;
        }

        internal bool EsEntrenado()
        {
            if (entrenada)
                return true;
            else
                return false;
        }

        internal void imput(int v1, int v2)
        {
            double operacion = v1 * P0 + v2 * P1 + U;
            int valor = funcionActivacion(operacion);
            Console.WriteLine("Perceptron:"+ valor);
            Console.WriteLine("_______________________________________________________________");

        }
    }
}