using System;
using System.Collections.Generic;
using CodingChallenge.Data.Classes;
using NUnit.Framework;

namespace CodingChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 1));
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            Assert.AreEqual("<h1>Empty list of shapes!</h1>",
                FormaGeometrica.Imprimir(new List<FormaGeometrica>(), 2));
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var cuadrados = new List<FormaGeometrica> {new FormaGeometrica(TipoForma.Cuadrado, 5)};

            var resumen = FormaGeometrica.Imprimir(cuadrados, 1);

            Assert.AreEqual("<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 formas Perímetro 20 Área 25", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var cuadrados = new List<FormaGeometrica>
            {
                new FormaGeometrica(TipoForma.Cuadrado, 5),
                new FormaGeometrica(TipoForma.Cuadrado, 1),
                new FormaGeometrica(TipoForma.Cuadrado, 3)
            };

            var resumen = FormaGeometrica.Imprimir(cuadrados, 2);

            Assert.AreEqual("<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35", resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(TipoForma.Cuadrado, 5),
                new FormaGeometrica(TipoForma.Circulo, 3),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4),
                new FormaGeometrica(TipoForma.Cuadrado, 2),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 9),
                new FormaGeometrica(TipoForma.Circulo, 2.75m),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, 2);

            Assert.AreEqual(
                "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65",
                resumen);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(TipoForma.Cuadrado, 5),
                new FormaGeometrica(TipoForma.Circulo, 3),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4),
                new FormaGeometrica(TipoForma.Cuadrado, 2),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 9),
                new FormaGeometrica(TipoForma.Circulo, 2.75m),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4.2m)
            };

            var resumen = FormaGeometrica.Imprimir(formas, 1);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 13,01 | Perímetro 18,06 <br/>3 Triángulos | Área 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Área 91,65",
                resumen);
        }

        [TestCase]
        public void TestImpresionReporteIdiomaInexistente()
        {
            var formas = new List<FormaGeometrica>
            {
                new FormaGeometrica(TipoForma.Cuadrado, 5),
                new FormaGeometrica(TipoForma.Circulo, 3),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4),
                new FormaGeometrica(TipoForma.Cuadrado, 2),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 9),
                new FormaGeometrica(TipoForma.Circulo, 2.75m),
                new FormaGeometrica(TipoForma.TrianguloEquilatero, 4.2m)
            };

            Assert.AreEqual("<h1>Error: Idioma inexistente</h1>", FormaGeometrica.Imprimir(formas, 5));
        }
    }
}
