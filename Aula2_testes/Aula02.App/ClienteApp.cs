using Aula02.Domain;
using Aula02.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Aula02.App
{
    public class ClienteApp : BaseApp<Cliente>
    {

        ClienteRepository ClienteRepository => (ClienteRepository)Repository;

        public ClienteApp(): base(new ClienteRepository())
        {

        }

        
        public IEnumerable<Cliente> GetOrdenadoNome()
        {
            return GetAll().OrderBy(x => x.Nome);
        }

        
        public IEnumerable<Cliente> GetAniversariantes(int dia, int mes)
        {
            return GetAll().Where(x => x.DataNascimento.HasValue
                    && x.DataNascimento.Value.Day == dia
                    && x.DataNascimento.Value.Month == mes);
        }

        
        public IEnumerable<Cliente> GetPorSexo(string sexo)
        {
            return GetAll().Where(x => x.Sexo == sexo);
        }

        
        public IEnumerable<Cliente> GetPorSituacao(bool situacao)
        {
            return GetAll().Where(x => x.Ativo == situacao);
        }

        
        public Cliente AlterarSituacao(int id)
        {
            var cliente = GetById(id);
            cliente.Ativo = !cliente.Ativo;
            Update(cliente);

            return cliente;
        }


        protected override void ValidateDelete(int id, StringBuilder sb)
        {
            var repPedido = new PedidoRepository();
            if (repPedido.GetAll().Any(x => x.Cliente.Id == id))
                sb.Append("Existem pedidos para este cliente");
        }

        protected override void ValidateSave(Cliente entity, StringBuilder sb)
        {
            if (String.IsNullOrEmpty(entity.Nome))
                sb.Append("Nome obrigatório");
            if (entity.Sexo != "M" && entity.Sexo != "F")
                sb.Append("Sexo inválido");
        }

        protected override void ValidateUpdate(Cliente entity, StringBuilder sb)
        {
            ValidateSave(entity, sb);
        }
    }
}
