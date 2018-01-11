using Aula02.Domain;
using System;

namespace Aula02.Repository
{
    public class PedidoRepository : BaseRepository<Pedido>
    {
        protected override void PopularLista()
        {
            var repCliente = new ClienteRepository();
            var repProduto = new ProdutoRepository();

            var p = new Pedido() { Id = 1, Cliente = repCliente.GetById(1), DataEmissao = DateTime.Today.AddDays(-5) };
            p.AddItem(new PedidoItem() { Produto = repProduto.GetById(1), Qtde = 100 });
            p.AddItem(new PedidoItem() { Produto = repProduto.GetById(3), Qtde = 100 });

            Lista.Add(p);
        }
    }
}
