using System;

class DiagnosticoServidor
{
    static void Main()
    {
        // --- Datos de Entrada (Probabilidades Previas y Verosimilitudes) ---
        double pC = 0.05;   // P(C) [Prior Caída]
        double pN = 0.95;   // P(N) [Prior Normal]
        double pPC = 0.90;  // P(P | C) [Likelihood de Pico dado Caída]
        double pPN = 0.15;  // P(P | N) [Likelihood de Pico dado Normal]

        Console.WriteLine("=== DIAGNÓSTICO DE FALLA EN UN SERVIDOR (BAYES) ===\n");

        // --- Paso 1: Calcular la Evidencia Total P(P) ---
        // P(P) = P(P | C) * P(C) + P(P | N) * P(N)
        double pP = (pPC * pC) + (pPN * pN);

        Console.WriteLine($"Paso 1: Calcular la Evidencia Total P(P)");
        Console.WriteLine($"P(P) = ({pPC} * {pC}) + ({pPN} * {pN})");
        Console.WriteLine($"P(P) = {pPC * pC} + {pPN * pN} = {pP}\n");

        // --- Paso 2: Calcular la Probabilidad A Posteriori P(C | P) ---
        // P(C | P) = [P(P | C) * P(C)] / P(P)
        double pCP = (pPC * pC) / pP;

        Console.WriteLine($"Paso 2: Calcular la Probabilidad A Posteriori P(C | P)");
        Console.WriteLine($"P(C | P) = ({pPC} * {pC}) / {pP}");
        Console.WriteLine($"P(C | P) = {pPC * pC} / {pP} = {pCP} ({pCP * 100:F0}%)\n");
    }
}
