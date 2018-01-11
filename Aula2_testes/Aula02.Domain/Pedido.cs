using System;
using System.Collections.Generic;
using System.Linq;

namespace Aula02.Domain
{
    public class Pedido: Entity
    {
        public DateTime DataEmissao { get; set; }
        public Cliente Cliente { get; set; }
        public IEnumerable<PedidoItem> Itens { get; set; }
        public decimal Total => Itens.Sum(x => x.Total);

        public Pedido()
        {
            Itens = new List<PedidoItem>();
        }

        public void AddItem(PedidoItem item)
        {
            ((List<PedidoItem>)Itens).Add(item);
        }

    }

    public class PedidoItem
    {
        public Produto Produto { get; set; }
        public decimal Qtde { get; set; }
        public decimal Total => Produto?.Valor * Qtde ?? 0;
    }
}
