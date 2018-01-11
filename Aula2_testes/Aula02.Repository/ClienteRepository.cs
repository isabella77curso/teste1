using Aula02.Domain;
using System;

namespace Aula02.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>
    {
        protected override void PopularLista()
        {
            Lista.Add(new Cliente() { Id = 1, Nome = "Cliente A", DataNascimento = new DateTime(1985, 10, 28), Sexo = "M", Ativo = true });
            Lista.Add(new Cliente() { Id = 2, Nome = "Cliente B", DataNascimento = new DateTime(1985, 11, 28), Sexo = "F", Ativo = true });
            Lista.Add(new Cliente() { Id = 3, Nome = "Cliente C", DataNascimento = new DateTime(1985, 12, 28), Sexo = "F", Ativo = false });
        }
    }
}
