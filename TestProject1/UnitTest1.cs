using System.Reflection.Metadata;
using TestesUnitarios;

namespace TestProject1
{

    [TestClass]
    public class UnitTest1
    {
        private Calculadora _calculadora;
        private int resultado;


        [TestInitialize]
        public void Setup()
        {
            _calculadora = new Calculadora();
            resultado = 0;
        }

        [TestMethod]
        public void SomaRetorna15QuandoSoma10Mais5()
        {
            //arrange
            //var calculadora = new Calculadora();
            //act 
            //var resultado = calculadora.Somar(10, 5);
            resultado = _calculadora.Somar(10, 5);

            // assert 
            Assert.AreEqual(15, resultado);

        }

        [TestMethod]
        public void SubtraiRetorna15QuandoSubtrair20de5()
        {
             resultado = _calculadora.Subtrair(20, 5);

            // assert 
            Assert.AreEqual(15, resultado);

        }
        [TestMethod]
        public void TestaDivisao10Por5DeveRetornar2()
        {
             resultado = _calculadora.Dividir(10, 5);

            // assert 
            Assert.AreEqual(2, resultado);

        }
        [TestMethod]
        public void TestaMultiplicacao2Por2DeveRetornar4()
        {
            resultado = _calculadora.Multiplicar(2, 2);

            // assert 
            Assert.AreEqual(4, resultado);

        }
        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void Dividir_PorZero_DeveLancarExcecao()
        {
            _calculadora.Dividir(10, 0);
        }



    }
}
