using TestesUnitarios;
using WebApplication1.Models;
using WebApplication1.Service;

namespace TestesNUnit
{
    public class Tests
    {
        private Calculadora calculadora = null;
        private ProdutoService produtoService;

        [SetUp]
        public void Setup()
        {
            calculadora = new Calculadora();
            produtoService = new ProdutoService();
        }

        [Test]
        public void SomarRetorna15QuandoSoma10Mais5()
        {
            Assert.AreEqual(15, calculadora.Somar(10, 5));
        }

        [Test]
        public void DividirLancaDivideByZeroExceptionQuandoDivideporZero()
        {
            // var ex = Assert.Throws<ArgumentException>(() => calculadora.Dividir(10, 0));
            // Assert.That(ex.Message, "Divisão por zero não é permitida.");

            var ex = Assert.Throws<DivideByZeroException>(() => calculadora.Dividir(10, 0));

            Assert.That(ex.Message, Is.EqualTo("Divisão por zero não é permitida."));
        }

        [Test]
        public void retornaProdutoQuantiSalvaProdutoCorretamente()
        {
            //arrange
            var produto = new Produto()
            {
                Descricao = "Feijao",
                Preco = 13.45m
            };
            // act 
            var produtoCriado = produtoService.Save(produto);

            //Assert
            Assert.IsNotNull(produtoCriado);

            //Assert.IsTrue(produtoCriado.Id > 0);

        }

        [Test]
        public void retornaProdutoPorIDQuandoEncontrado()
        {
            // Arrange
            var produto = new Produto()
            {
                Descricao = "Feijao",
                Preco = 13.45m
            };

            // Act
            var produtoSalvo = produtoService.Save(produto);
            var produtoEncontrado = produtoService.Get(produtoSalvo.Id);

            // Assert
            Assert.IsNotNull(produtoEncontrado);
            Assert.AreEqual(produtoSalvo.Id, produtoEncontrado.Id);

        }

        [Test]
        public void lancaExcptionQuandoProdutoNaoEncontradoNoGetById()
        {
            //produtoService.Get(999);

            var ex = Assert.Throws<Exception>(() => produtoService.Get(999));

            Assert.That(ex.Message, Is.EqualTo("Produto nao Encontrado"));
        }
    }
}