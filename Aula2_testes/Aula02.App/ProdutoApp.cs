using Aula02.Domain;
using Aula02.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aula02.App
{
    public class ProdutoApp: BaseApp<Produto>
    {
        protected ProdutoRepository ProdutoRepository => (ProdutoRepository)Repository;

        public ProdutoApp() : base(new ProdutoRepository())
        {

        }

        
        public IEnumerable<Produto> GetAbaixoEstoque()
        {
            return GetAll().Where(x => x.QtdeEstoque < x.EstoqueMinimo);
        }


        protected override void ValidateDelete(int id, StringBuilder sb)
        {
            var repPedido = new PedidoRepository();
            if (repPedido.GetAll().Any(x => x.Itens.Any(y => y.Produto.Id == id)))
                sb.Append("Existem pedidos usando este produto");

        }

        protected override void ValidateSave(Produto entity, StringBuilder sb)
        {
            if (String.IsNullOrEmpty(entity.Descricao))
                sb.Append("Descricao não pode ser nula");

            if (entity.Valor < 0)
                sb.Append("Valor não pode ser negativo");
        }

        protected override void ValidateUpdate(Produto entity, StringBuilder sb)
        {
            ValidateSave(entity, sb);
        }
    }
}
