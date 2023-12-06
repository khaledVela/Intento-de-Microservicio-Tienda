using Restaurant.SharedKernel.Rules;
using Restaurant.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SharedKernel.Test.Rules
{
    public class NotNullRuleTest
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("Hola", true)]
        public void ValorMayorOIgualACero(string valorEsperado, bool resultadoEsperado)
        {
            NotNullRule rule = new NotNullRule(valorEsperado);
            bool esValido = rule.IsValid();
            Assert.Equal(resultadoEsperado, esValido);
        }
    }
}
