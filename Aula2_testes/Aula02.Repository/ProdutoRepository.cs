using Aula02.Domain;

namespace Aula02.Repository
{
    public class ProdutoRepository: BaseRepository<Produto>
    {
        protected override void PopularLista()
        {
            Lista.Add(new Produto() { Id = 1, Descricao = "Produto A", Valor = 100, QtdeEstoque = 100, EstoqueMinimo = 10 });
            Lista.Add(new Produto() { Id = 2, Descricao = "Produto B", Valor = 200, QtdeEstoque = 200, EstoqueMinimo = 20 });
            Lista.Add(new Produto() { Id = 3, Descricao = "Produto C", Valor = 300, QtdeEstoque = 10, EstoqueMinimo = 30 });
            Lista.Add(new Produto() { Id = 4, Descricao = "Produto D", Valor = 400, QtdeEstoque = 10, EstoqueMinimo = 40 });
        }
    }
}
