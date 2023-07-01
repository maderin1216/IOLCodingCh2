using CodingChallenge.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbadorFiguras
{
    class Program
    {
        static void Main(string[] args)
        {
            string reporte;
            FormaGeometrica cuadrado1 = new FormaGeometrica(TipoForma.Cuadrado, 3);
            FormaGeometrica cuadrado2 = new FormaGeometrica(TipoForma.Cuadrado, 4);
            FormaGeometrica triangulo1 = new FormaGeometrica(TipoForma.TrianguloEquilatero, 1);
            FormaGeometrica triangulo2 = new FormaGeometrica(TipoForma.TrianguloEquilatero, 2);
            FormaGeometrica triangulo3 = new FormaGeometrica(TipoForma.TrianguloEquilatero, 5);
            FormaGeometrica trapecio1 = new FormaGeometrica(TipoForma.Trapecio, 6, 5, 4, 5.5m, 4.99m);
            FormaGeometrica trapecio2 = new FormaGeometrica(TipoForma.Trapecio, 12, 5, 9, 7, 4.33m);
            List<FormaGeometrica> lFormasGeometricas = new List<FormaGeometrica>();

            lFormasGeometricas.Add(cuadrado1);
            lFormasGeometricas.Add(cuadrado2);
            lFormasGeometricas.Add(triangulo1);
            lFormasGeometricas.Add(triangulo2);
            lFormasGeometricas.Add(triangulo3);
            lFormasGeometricas.Add(trapecio1);
            lFormasGeometricas.Add(trapecio2);

            Console.WriteLine("\n\n**********************************************");
            Console.WriteLine("*                 CASTELLANO                 *");
            Console.WriteLine("**********************************************");
            reporte = FormaGeometrica.Imprimir(lFormasGeometricas, 1);
            Console.WriteLine(reporte);

            Console.WriteLine("\n\n**********************************************");
            Console.WriteLine("*                  INGLÉS                    *");
            Console.WriteLine("**********************************************");
            reporte = FormaGeometrica.Imprimir(lFormasGeometricas, 2);
            Console.WriteLine(reporte);

            Console.WriteLine("\n\n**********************************************");
            Console.WriteLine("*                  PORTUGUES                 *");
            Console.WriteLine("**********************************************");
            reporte = FormaGeometrica.Imprimir(lFormasGeometricas, 3);
            Console.WriteLine(reporte);

            Console.WriteLine("\n\n**********************************************");
            Console.WriteLine("*                   VACÍO                    *");
            Console.WriteLine("**********************************************");
            reporte = FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1);
            Console.WriteLine(reporte);
            reporte = FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2);
            Console.WriteLine(reporte);
            reporte = FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 3);
            Console.WriteLine(reporte);


            Console.WriteLine("Press enter to close...");
            Console.ReadLine();
        }
    }
}
