namespace Aula02.Domain
{
    public class Produto: Entity
    {
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public decimal QtdeEstoque { get; set; }
        public decimal EstoqueMinimo { get; set; }
    }
}
