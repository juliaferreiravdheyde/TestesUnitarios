using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class ProdutoService
    {
        private List<Produto> produtos = new List<Produto>();

        public Produto Save(Produto produto)
        {
            try
            {
                produto.Id = produtos.Count + 1;
                produtos.Add(produto);
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
            return produto;
        }

        public Produto Get(int Id)
        {
            try
            {
                var produto = produtos.FirstOrDefault(p => p.Id == Id);

                if (produto == null)
                {
                    throw new Exception("Produto nao Encontrado");
                }

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
