using System;

namespace ProblemaProbabilidad
{
    class Program
    {
        static void Main(string[] args)
        {
            // Datos de producción de las máquinas
            double pA = 0.45; // 45%
            double pB = 0.30; // 30%
            double pC = 0.25; // 25%

            // Porcentajes de producción defectuosa de cada máquina
            double pDefectoDadoA = 0.03; // 3%
            double pDefectoDadoB = 0.04; // 4%
            double pDefectoDadoC = 0.05; // 5%

            // ==========================================
            // a. Probabilidad total de que sea defectuosa
            // ==========================================
            double pDefecto = (pA * pDefectoDadoA) + (pB * pDefectoDadoB) + (pC * pDefectoDadoC);

            // ==========================================
            // b. Probabilidad de que sea de la máquina B dado que es defectuosa (Bayes)
            // ==========================================
            double pBDadoDefecto = (pB * pDefectoDadoB) / pDefecto;

            // ==========================================
            // c. Determinar qué máquina tiene la mayor probabilidad
            // ==========================================
            double pADadoDefecto = (pA * pDefectoDadoA) / pDefecto;
            double pCDadoDefecto = (pC * pDefectoDadoC) / pDefecto;

            string maquinaMayor = "A";
            double mayorProbabilidad = pADadoDefecto;

            if (pBDadoDefecto > mayorProbabilidad)
            {
                maquinaMayor = "B";
                mayorProbabilidad = pBDadoDefecto;
            }
            if (pCDadoDefecto > mayorProbabilidad)
            {
                maquinaMayor = "C";
                mayorProbabilidad = pCDadoDefecto;
            }

            // --- Mostrar resultados en consola ---
            Console.WriteLine("=== RESULTADOS DEL PROBLEMA DE PROBABILIDAD ===\n");

            Console.WriteLine($"a. Probabilidad de que una pieza elegida al azar sea defectuosa:");
            Console.WriteLine($"   P(Defecto) = {pDefecto:P2} ({pDefecto})\n");

            Console.WriteLine($"b. Si resulta ser defectuosa, probabilidad de haber sido producida por la máquina B:");
            Console.WriteLine($"   P(B | Defecto) = {pBDadoDefecto:P2} ({pBDadoDefecto:F4})\n");

            Console.WriteLine($"c. ¿Qué máquina tiene la mayor probabilidad de haber producido la pieza defectuosa?:");
            Console.WriteLine($"   La máquina {maquinaMayor} con un {mayorProbabilidad:P2} de probabilidad.");
            Console.WriteLine($"   [Comparativa -> A: {pADadoDefecto:P2} | B: {pBDadoDefecto:P2} | C: {pCDadoDefecto:P2}]");

            Console.ReadLine();
        }
    }
}
