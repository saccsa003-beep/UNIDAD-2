using System;

namespace ProblemaUrnas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Probabilidad de elegir cualquiera de las tres urnas al azar
            double pUrna = 1.0 / 3.0;

            // Composición de la Urna A: 3 rojas, 5 negras (Total = 8)
            double pRojaDadoA = 3.0 / 8.0;

            // Composición de la Urna B: 2 rojas, 1 negra (Total = 3)
            double pRojaDadoB = 2.0 / 3.0;

            // Composición de la Urna C: 2 rojas, 3 negras (Total = 5)
            double pRojaDadoC = 2.0 / 5.0;

            // 1. Calcular la probabilidad total de extraer una bola roja
            double pRoja = (pUrna * pRojaDadoA) + (pUrna * pRojaDadoB) + (pUrna * pRojaDadoC);

            // 2. Aplicar el Teorema de Bayes para calcular P(A | Roja)
            double pADadoRoja = (pUrna * pRojaDadoA) / pRoja;

            // --- Mostrar resultados en consola ---
            Console.WriteLine("=== RESOLUCIÓN DEL PROBLEMA DE LAS URNAS ===\n");

            Console.WriteLine("Datos iniciales:");
            Console.WriteLine($"- P(Roja | Urna A) = 3/8 ({pRojaDadoA:F4})");
            Console.WriteLine($"- P(Roja | Urna B) = 2/3 ({pRojaDadoB:F4})");
            Console.WriteLine($"- P(Roja | Urna C) = 2/5 ({pRojaDadoC:F4})\n");

            Console.WriteLine($"-> Probabilidad total de que la bola sea roja:");
            Console.WriteLine($"   P(Roja) = {pRoja:P2} ({pRoja:F4})\n");

            Console.WriteLine($"-> Si la bola ha sido roja, probabilidad de que sea de la urna A:");
            Console.WriteLine($"   P(Urna A | Roja) = {pADadoRoja:P2} ({pADadoRoja:F4})");

            Console.ReadLine();
        }
    }
}
