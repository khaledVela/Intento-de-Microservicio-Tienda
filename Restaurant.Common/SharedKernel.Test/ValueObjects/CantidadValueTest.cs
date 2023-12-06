using Restaurant.SharedKernel.Core;
using Restaurant.SharedKernel.ValueObjects;
using System;
using Xunit;

namespace SharedKernel.Test.ValueObjects
{
    public class CantidadValueTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        public void ValorMayorOIgualACero(int valorEsperado)
        {
            
            CantidadValue valorAVerificar = new CantidadValue(valorEsperado);

            Assert.Equal(valorEsperado, valorAVerificar.Value);
        }

        [Fact]
        public void ValorMenoraCero()
        {
            int valorEsperado = -5;

            Assert.Throws<BussinessRuleValidationException>(() => new CantidadValue(valorEsperado));
        }
        [Fact]
        public void DeEnteroACantidad()
        {
            int valorEsperado = 5;

            CantidadValue valorConvertido = valorEsperado;

            Assert.Equal(valorEsperado, valorConvertido.Value);

        }
        [Fact]
        public void DeCantidadAEntero()
        {

            CantidadValue valorEsperado = new CantidadValue(5);

            int valorConvertido = valorEsperado;

            Assert.Equal(valorEsperado.Value, valorConvertido);

        }
    }
}