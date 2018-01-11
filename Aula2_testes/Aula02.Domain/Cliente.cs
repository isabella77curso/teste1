using System;


namespace Aula02.Domain
{
    public class Cliente: Entity
    {
        public string Nome { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Sexo { get; set; }
        public bool Ativo { get; set; }

    }
}
