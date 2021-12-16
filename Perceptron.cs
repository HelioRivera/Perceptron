using Perceptron;
using System;

namespace PerceptronSimple
{
    internal class Perceptron
    {
        private double P0;// un parametro ajustable del perceptron
        private double P1;// otro parametro ajustable del perceptron
        private double U; // bias del perceptron
        private Random azar; //para inicializar los parametros ajustables de la red
        private DatosTrain datos;
        private int iteracion;
        private int funcion_A_aprender;
        private bool entrenada;
        private int[,] entradas;
        private int[] tablaAND;
        private int[] tablaOR;

        public Perceptron(int tipo)
        {
            datos = new DatosTrain();
            azar = new Random(10);
            entrenada = false;// define si la red ha sido entrenada
            funcion_A_aprender = tipo; // determina si el perceptron aprendera AND o OR
            iteracion = 0;//Cuenta el número de iteraciones

            //Inicializa los pesos al azar
            P0 = azar.NextDouble();
            P1 = azar.NextDouble();
            U = azar.NextDouble();

            //recuperacion del data set de entrenamiento
            entradas = datos.GetEntradas(); 
            tablaAND = datos.GetSalidsEsperadasAnd();
            tablaOR = datos.GetSalidsEsperadasOr();
        }
        
        //Muestra que el perceptrón simple aprendió.
        internal void MostrarValoresAprendidos(int funcionaprendida)
        {
            Console.WriteLine("_______________________________________________________________");
            if (funcionaprendida == 1)
                Console.WriteLine("Probando el  perceptron que aprendio la funcion AND :");
            else
                Console.WriteLine("Probando el  perceptron que aprendio la funcion OR :");
            for (int cont = 0; cont <= 3; cont++)
            {
                double operacion = entradas[cont, 0] * P0 + entradas[cont, 1] * P1 + U;
                //La función de activación
                int salidaEntera = funcionActivacion(operacion);

                //Imprime
                if (funcion_A_aprender == 1)
                {
                    Console.WriteLine("Entradas: " + entradas[cont, 0].ToString() + " y " + entradas[cont, 1].ToString() + " = " +
                    tablaAND[cont].ToString() + " perceptron: " + salidaEntera.ToString());
                }
                if (funcion_A_aprender == 2)
                {
                    Console.WriteLine("Entradas: " + entradas[cont, 0].ToString() + " y " + entradas[cont, 1].ToString() + " = " +
                   tablaOR[cont].ToString() + " perceptron: " + salidaEntera.ToString());
                }


            }
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("Valores para los parámetros ajustables del perceptron");
            Console.WriteLine("Pesos encontrados P0= " + P0.ToString() + " P1= " + P1.ToString() + " U= " + U.ToString());
            Console.WriteLine("Iteraciones requeridas: " + iteracion.ToString());
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("Presione ENTER para continuar... " );
            Console.ReadKey();
        }


        internal bool entrenar()
        {
            Console.WriteLine("_______________________________________________________________");
            Console.WriteLine("Iniciando el proceso de entrenamiento...");

            bool proceso = true;//Variable que mantiene el proceso activo de busqueda de los pesos

            //Hasta que aprenda la tabla AND
            while (proceso)
            {
                iteracion++;

                //Optimista, en esta iteración se encuentra los pesos
                proceso = false;

                for (int cont = 0; cont <= 3; cont++)  //Va por todas las reglas de la tabla AND
                {
                    //Calcula la preactivacion de la neurona en la teoria esto es conocido como feedforward pass
                    double salidacalculada = entradas[cont, 0] * P0 + entradas[cont, 1] * P1 + U;

                    //La función de activación
                    int target = funcionActivacion(salidacalculada);

                    //Si la salida calculada no coincide con la salida esperada proporcionada por el data set de entrenamiento
                    //proporcionado por las tablas de aprendizaje , cambia los pesos al azar
                    //aqui es donde se produce el ajuste de los pesos. En la teoria esto es conocido como backforward pass
                    if(funcion_A_aprender == 1)
                    {
                        if (target != tablaAND[cont]) 
                        {
                            P0 = azar.NextDouble();
                            P1 = azar.NextDouble();
                            U = azar.NextDouble();
                            proceso = true; //Y sigue buscando
                        }

                    }
                    if (funcion_A_aprender == 2)
                    {
                        if (target != tablaOR[cont])
                        {
                            P0 = azar.NextDouble();
                            P1 = azar.NextDouble();
                            U = azar.NextDouble();
                            proceso = true; //Y sigue buscando
                        }

                    }


                }
            }
            Console.WriteLine("Proceso de entrenamiento finalizado.");
            Console.WriteLine("_______________________________________________________________");
            entrenada = true;
            return entrenada;
        }
        
        private int funcionActivacion(double operacion)
        {
            if (operacion > 0.7)
                return  1;
            else
                return  0;
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