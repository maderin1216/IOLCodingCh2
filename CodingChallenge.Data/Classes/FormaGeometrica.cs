/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

//Pasos para implementar nueva FormaGeometrica:
//1) Agregar nueva forma en el enum TipoForma
//2) Definir el cálculo de perímetro y área en el constructor de FormaGeometrica
//3) Agregar nombre singular y plural en paquetes de idioma (lista paquetesIdiomas de clase PaqueteDeIdiomas)

//Pasos para implementar nuevo Idioma:
//1) Agregar en paquetes de idioma (lista paquetesIdiomas de clase PaqueteDeIdiomas) todas las lineas necesarias. Tener en cuenta el Id que será el que indica el idioma a la hora de imprimir el reporte.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public enum TipoForma
    {
        Cuadrado = 1,
        TrianguloEquilatero = 2,
        Circulo = 3,
        Trapecio = 4
    }

    public static class PaqueteDeIdiomas
    {
        public static string IdiomaInexistente = "<h1>Error: Idioma inexistente</h1>";
        public static List<Idioma> paqueteIdiomas = new List<Idioma>(){
            
            //Castellano
            new Idioma()
            {
                Id = 1,
                Nombre = "Castellano",
                Header = "<h1>Reporte de Formas</h1>",
                Body = "{0} {1} | Área {2} | Perímetro {3} <br/>",
                Footer = @"TOTAL:<br/>{0} formas Perímetro {1} Área {2}",
                ListaVacia = "<h1>Lista vacía de formas!</h1>",
                NombresFigurasSingular = new Dictionary<TipoForma, string>(){
                    { TipoForma.Cuadrado, "Cuadrado" },
                    { TipoForma.Circulo, "Círculo"},
                    { TipoForma.TrianguloEquilatero, "Triángulo"},
                    { TipoForma.Trapecio, "Trapecio"}
                },
                NombresFigurasPlural = new Dictionary<TipoForma, string>(){
                    { TipoForma.Cuadrado, "Cuadrados" },
                    { TipoForma.Circulo, "Círculos"},
                    { TipoForma.TrianguloEquilatero, "Triángulos"},
                    { TipoForma.Trapecio, "Trapecios"}
                }
            },

            //Ingles
            new Idioma()
            {
                Id = 2,
                Nombre = "Ingles",
                Header = "<h1>Shapes report</h1>",
                Body = "{0} {1} | Area {2} | Perimeter {3} <br/>",
                Footer = @"TOTAL:<br/>{0} shapes Perimeter {1} Area {2}",
                ListaVacia = "<h1>Empty list of shapes!</h1>",
                NombresFigurasSingular = new Dictionary<TipoForma, string>(){ 
                    { TipoForma.Cuadrado, "Square" },
                    { TipoForma.Circulo, "Circle"},
                    { TipoForma.TrianguloEquilatero, "Triangle"},
                    { TipoForma.Trapecio, "Trapeze"}
                },
                NombresFigurasPlural = new Dictionary<TipoForma, string>(){
                    { TipoForma.Cuadrado, "Squares" },
                    { TipoForma.Circulo, "Circles"},
                    { TipoForma.TrianguloEquilatero, "Triangles"},
                    { TipoForma.Trapecio, "Trapezoids"}
                }
            },

            //Portugues
            new Idioma()
            {
                Id = 3,
                Nombre = "Portugues",
                Header = "<h1>Relatório de formas geométricas</h1>",
                Body = "{0} {1} | Área {2} | Perímetro {3} <br/>",
                Footer = @"TOTAL:<br/>{0} formas Perímetro {1} Área {2}",
                ListaVacia = "<h1>Lista vazia de formas!</h1>",
                NombresFigurasSingular = new Dictionary<TipoForma, string>(){
                    { TipoForma.Cuadrado, "Quadrado" },
                    { TipoForma.Circulo, "Círculo"},
                    { TipoForma.TrianguloEquilatero, "Triângulo"},
                    { TipoForma.Trapecio, "Trapézio"}
                },
                NombresFigurasPlural = new Dictionary<TipoForma, string>(){
                    { TipoForma.Cuadrado, "Quadrados" },
                    { TipoForma.Circulo, "Círculos"},
                    { TipoForma.TrianguloEquilatero, "Triângulos"},
                    { TipoForma.Trapecio, "Trapézios"}
                }
            }
        };
    }

    public class Idioma
    {
        public int Id;
        public string Nombre;
        
        //Lineas del reporte
        public string Header;
        public string Body;
        public string Footer;
        public string ListaVacia;

        //Nombres de figuras
        public Dictionary<TipoForma, string> NombresFigurasSingular = new Dictionary<TipoForma, string>();
        public Dictionary<TipoForma, string> NombresFigurasPlural = new Dictionary<TipoForma, string>();

        public string TraducirForma(TipoForma tipo, int cantidad)
        {
            try
            {
                return cantidad == 1 ? NombresFigurasSingular[tipo] : NombresFigurasPlural[tipo];
            }
            catch (Exception ex)
            { 
                return string.Empty;
            }
        }
    }

    public class FormaGeometrica
    {
        #region Propiedades viejas
        //#region Formas

        //public const int Cuadrado = 1;
        //public const int TrianguloEquilatero = 2;
        //public const int Circulo = 3;
        //public const int Trapecio = 4;

        //#endregion

        //#region Idiomas
        //public const int Castellano = 1;
        //public const int Ingles = 2;

        //#endregion
        #endregion

        //Reemplazar _lado por Lado1 y agregar lados extras con valores default para casos particulares (por ej el trapecio)
        private readonly decimal Lado1;
        private readonly decimal Lado2;
        private readonly decimal Lado3;
        private readonly decimal Lado4;
        private readonly decimal Altura;
        private readonly decimal Area;
        private readonly decimal Perimetro;

        public TipoForma Tipo { get; set; }

        public FormaGeometrica(TipoForma tipo, decimal lado1, decimal lado2 = 0, decimal lado3 = 0, decimal lado4 = 0, decimal altura = 0)
        {
            Tipo = tipo;
            Lado1 = lado1;
            Lado2 = lado2;
            Lado3 = lado3;
            Lado4 = lado4;
            Altura = altura;

            switch (Tipo)
            {
                case TipoForma.Cuadrado:
                    Area = Lado1 * Lado1;
                    Perimetro = Lado1 * 4;
                    break;

                case TipoForma.Circulo:
                    Area = (decimal)Math.PI * (Lado1 / 2) * (Lado1 / 2);
                    Perimetro = (decimal)Math.PI * Lado1;
                    break;

                case TipoForma.TrianguloEquilatero:
                    Area = ((decimal)Math.Sqrt(3) / 4) * Lado1 * Lado1;
                    Perimetro = Lado1 * 3;
                    break;

                case TipoForma.Trapecio:
                    Area = ((Lado1 + Lado3)/2) * Altura;
                    Perimetro = Lado1 + Lado2 + Lado3 + Lado4;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(@"Forma desconocida");
            }
        }

        public static string Imprimir(List<FormaGeometrica> formas, int idioma = 2) //Default es ingles
        {
            Idioma idiomaReporte = PaqueteDeIdiomas.paqueteIdiomas.Where(i => i.Id == idioma).FirstOrDefault();
            StringBuilder sb = new StringBuilder();

            if (idiomaReporte != null)
            {
                if (!formas.Any())
                {
                    sb.Append(ObtenerMensajeListaVacia(idiomaReporte));
                }
                else
                {
                    // HEADER
                    sb.Append(ObtenerHeader(idiomaReporte));

                    // BODY
                    sb.Append(ObtenerBody(formas, idiomaReporte));

                    // FOOTER
                    sb.Append(ObtenerFooter(formas.Count, formas.Sum(f => f.Perimetro), formas.Sum(f => f.Area), idiomaReporte));
                }
            }
            else
            {
                sb.Append(PaqueteDeIdiomas.IdiomaInexistente);
            }
            
            return sb.ToString();
        }

        private static string ObtenerBody(List<FormaGeometrica> formas, Idioma idioma)
        {
            string retorno = "";
            var gruposFormas = formas.GroupBy(f => f.Tipo);

            foreach (var grupo in gruposFormas)
            {
                retorno += ObtenerLinea(grupo.Count(), grupo.Sum(f => f.Area), grupo.Sum(f => f.Perimetro), grupo.Key, idioma);
            }

            return retorno;
        }

        private static string ObtenerLinea(int cantidad, decimal area, decimal perimetro, TipoForma tipo, Idioma idioma)
        {
            if (cantidad > 0)
            {
                return string.Format(idioma.Body, cantidad, idioma.TraducirForma(tipo, cantidad), area.ToString("#.##"), perimetro.ToString("#.##"));
            }

            return string.Empty;
        }

        private static string ObtenerMensajeListaVacia(Idioma idioma)
        {
            return idioma.ListaVacia;
        }

        private static string ObtenerHeader(Idioma idioma)
        {
            return idioma.Header;
        }

        private static string ObtenerFooter(int cantidadFormas, decimal totalPerimetros, decimal totalAreas, Idioma idioma)
        {
            return string.Format(idioma.Footer, cantidadFormas, totalPerimetros.ToString("#.##"), totalAreas.ToString("#.##")); ;
        }

        #region Código viejo
        //public static string ImprimirViejo(List<FormaGeometrica> formas, int idioma)
        //{
        //    var sb = new StringBuilder();

        //    if (!formas.Any())
        //    {
        //        if (idioma == Castellano)
        //            sb.Append("<h1>Lista vacía de formas!</h1>");
        //        else
        //            sb.Append("<h1>Empty list of shapes!</h1>");
        //    }
        //    else
        //    {
        //        // Hay por lo menos una forma
        //        // HEADER
        //        if (idioma == Castellano)
        //            sb.Append("<h1>Reporte de Formas</h1>");
        //        else
        //            // default es inglés
        //            sb.Append("<h1>Shapes report</h1>");

        //        var numeroCuadrados = 0;
        //        var numeroCirculos = 0;
        //        var numeroTriangulos = 0;

        //        var areaCuadrados = 0m;
        //        var areaCirculos = 0m;
        //        var areaTriangulos = 0m;

        //        var perimetroCuadrados = 0m;
        //        var perimetroCirculos = 0m;
        //        var perimetroTriangulos = 0m;

        //        for (var i = 0; i < formas.Count; i++)
        //        {
        //            if (formas[i].Tipo == TipoForma.Cuadrado)
        //            {
        //                numeroCuadrados++;
        //                areaCuadrados += formas[i].CalcularArea();
        //                perimetroCuadrados += formas[i].CalcularPerimetro();
        //            }
        //            if (formas[i].Tipo == TipoForma.Circulo)
        //            {
        //                numeroCirculos++;
        //                areaCirculos += formas[i].CalcularArea();
        //                perimetroCirculos += formas[i].CalcularPerimetro();
        //            }
        //            if (formas[i].Tipo == TipoForma.TrianguloEquilatero)
        //            {
        //                numeroTriangulos++;
        //                areaTriangulos += formas[i].CalcularArea();
        //                perimetroTriangulos += formas[i].CalcularPerimetro();
        //            }
        //        }

        //        sb.Append(ObtenerLineaViejo(numeroCuadrados, areaCuadrados, perimetroCuadrados, Cuadrado, idioma));
        //        sb.Append(ObtenerLineaViejo(numeroCirculos, areaCirculos, perimetroCirculos, Circulo, idioma));
        //        sb.Append(ObtenerLineaViejo(numeroTriangulos, areaTriangulos, perimetroTriangulos, TrianguloEquilatero, idioma));

        //        // FOOTER
        //        sb.Append("TOTAL:<br/>");
        //        sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Castellano ? "formas" : "shapes") + " ");
        //        sb.Append((idioma == Castellano ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
        //        sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
        //    }

        //    return sb.ToString();
        //}

        //private static string ObtenerLineaViejo(int cantidad, decimal area, decimal perimetro, int tipo, int idioma)
        //{
        //    if (cantidad > 0)
        //    {
        //        if (idioma == Castellano)
        //            return $"{cantidad} {TraducirFormaViejo(tipo, cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";

        //        return $"{cantidad} {TraducirFormaViejo(tipo, cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
        //    }

        //    return string.Empty;
        //}

        //private static string TraducirFormaViejo(int tipo, int cantidad, int idioma)
        //{
        //    switch (tipo)
        //    {
        //        case Cuadrado:
        //            if (idioma == Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
        //            else return cantidad == 1 ? "Square" : "Squares";
        //        case Circulo:
        //            if (idioma == Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
        //            else return cantidad == 1 ? "Circle" : "Circles";
        //        case TrianguloEquilatero:
        //            if (idioma == Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
        //            else return cantidad == 1 ? "Triangle" : "Triangles";
        //    }

        //    return string.Empty;
        //}

        //public decimal CalcularArea()
        //{
        //    switch (Tipo)
        //    {
        //        case TipoForma.Cuadrado:
        //            return Lado1 * Lado1;

        //        case TipoForma.Circulo:
        //            return (decimal)Math.PI * (Lado1 / 2) * (Lado1 / 2);

        //        case TipoForma.TrianguloEquilatero:
        //            return ((decimal)Math.Sqrt(3) / 4) * Lado1 * Lado1;

        //        default:
        //            throw new ArgumentOutOfRangeException(@"Forma desconocida");
        //    }
        //}

        //public decimal CalcularPerimetro()
        //{
        //    switch (Tipo)
        //    {
        //        case TipoForma.Cuadrado:
        //            return Lado1 * 4;

        //        case TipoForma.Circulo:
        //            return (decimal)Math.PI * Lado1;

        //        case TipoForma.TrianguloEquilatero:
        //            return Lado1 * 3;

        //        default:
        //            throw new ArgumentOutOfRangeException(@"Forma desconocida");
        //    }
        //}
        #endregion
    }
}
