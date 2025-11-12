
using MySqlX.XDevAPI;

namespace Projeto1AspNet.Models
{
    public class Produto
    {
        public int CodProd { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Preco { get; set; }
        public int Quantidade { get; set; }
        public List<Produto>? ListaProduto { get; set; }
    }
}
