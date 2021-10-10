using System;

namespace PerceptronSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PERCEPTRON SIMPLE");
            Console.WriteLine("_______________________________________________________________");
            Perceptron p = new Perceptron();
            Console.WriteLine("seleccione la funcion a aprender (AND o OR)");
            Console.WriteLine("ingrese 1 para AND o 2 para OR");
            int tipo = int.Parse(Console.ReadLine());
            p.inizializar(tipo);
            p.entrenar();
            p.comprobarAprendizaje();
            if (p.EsEntrenado())
                Console.WriteLine("ingrese los valores de entrada para la funcion logica escogida");
            
                int i_1,i_2;
                i_1 = int.Parse(Console.ReadLine());
                i_2 = int.Parse(Console.ReadLine());
                p.imput(i_1, i_2);
        }
    }
}
