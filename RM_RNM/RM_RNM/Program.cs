using System;
using System.Collections.Generic;

namespace EvaluacionLogica
{
    // ==========================================
    // PARTE 1: Módulo Monótono (Acumulación estricta)
    // ==========================================
    public class SistemaMonotono
    {
        private HashSet<string> hechos = new HashSet<string>();
        private HashSet<string> conclusiones = new HashSet<string>();

        public void AgregarHecho(string hecho)
        {
            hechos.Add(hecho);
        }

        public void EjecutarInferencia()
        {
            // Las verdades deducidas previamente no se borran del HashSet (monotonía)

            // Regla 1: Si "latencia_alta" -> "posible_falla"
            if (hechos.Contains("latencia_alta"))
            {
                conclusiones.Add("posible_falla");
            }

            // Regla 2: Si "posible_falla" O "servidor_caido" -> "notificar_admin"
            if (conclusiones.Contains("posible_falla") || hechos.Contains("servidor_caido"))
            {
                conclusiones.Add("notificar_admin");
            }
        }

        public void MostrarConclusiones()
        {
            Console.WriteLine("Hechos actuales: " + string.Join(", ", hechos));
            Console.WriteLine("Conclusiones deducidas: " + (conclusiones.Count > 0 ? string.Join(", ", conclusiones) : "Ninguna"));
        }
    }

    // ==========================================
    // PARTE 2: Módulo No Monótono (Retracción por excepciones)
    // ==========================================
    public class SistemaNoMonotono
    {
        private HashSet<string> hechos = new HashSet<string>();

        public void AgregarHecho(string hecho)
        {
            hechos.Add(hecho);
        }

        public string EvaluarEstado()
        {
            // Excepciones (Defeaters) que retractan el comportamiento por defecto
            if (hechos.Contains("mantenimiento_programado") || hechos.Contains("disco_lleno"))
            {
                return "servidor_NO_operativo (excepción detectada)";
            }

            // Regla por defecto
            if (hechos.Contains("servidor_encendido"))
            {
                return "servidor_OPERATIVO";
            }

            return "Estado desconocido (sin evidencias)";
        }

        public void MostrarHechos()
        {
            Console.WriteLine("Hechos actuales: " + string.Join(", ", hechos));
        }
    }

    // ==========================================
    // PARTE 3: Método Main (Clase Principal)
    // ==========================================
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("====================================================");
            Console.WriteLine(" DEMOSTRACIÓN DE RAZONAMIENTO LOGÍCO EN C# ");
            Console.WriteLine("====================================================\n");

            // --- EJECUCIÓN PARTE 1 ---
            Console.WriteLine("--- PARTE 1: SISTEMA MONÓTONO ---");
            SistemaMonotono sm = new SistemaMonotono();

            Console.WriteLine("[Paso 1] Agregando hecho: 'latencia_alta'...");
            sm.AgregarHecho("latencia_alta");
            sm.EjecutarInferencia();
            sm.MostrarConclusiones();
            Console.WriteLine();

            Console.WriteLine("[Paso 2] Agregando hecho contradictorio: 'conexion_restablecida'...");
            sm.AgregarHecho("conexion_restablecida");
            sm.EjecutarInferencia();
            sm.MostrarConclusiones();
            Console.WriteLine("-> Explicación: Las conclusiones previas se MANTIENEN porque el sistema no destruye verdades viejas.");
            Console.WriteLine("\n----------------------------------------------------\n");

            // --- EJECUCIÓN PARTE 2 ---
            Console.WriteLine("--- PARTE 2: SISTEMA NO MONÓTONO ---");
            SistemaNoMonotono snm = new SistemaNoMonotono();

            Console.WriteLine("[Paso 1] Agregando hecho por defecto: 'servidor_encendido'...");
            snm.AgregarHecho("servidor_encendido");
            snm.MostrarHechos();
            Console.WriteLine("Resultado: " + snm.EvaluarEstado());
            Console.WriteLine();

            Console.WriteLine("[Paso 2] Agregando una excepción: 'mantenimiento_programado'...");
            snm.AgregarHecho("mantenimiento_programado");
            snm.MostrarHechos();
            Console.WriteLine("Resultado: " + snm.EvaluarEstado());
            Console.WriteLine("-> Explicación: La conclusión anterior cambió automáticamente porque la excepción invalidó la regla por defecto.");

            Console.WriteLine("\n====================================================");
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
