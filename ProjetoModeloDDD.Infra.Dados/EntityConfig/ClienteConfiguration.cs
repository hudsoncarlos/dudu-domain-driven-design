using ProjetoModeloDDD.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;

namespace ProjetoModeloDDD.Infra.Dados.EntityConfig
{
    public class ClienteConfiguration : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfiguration()
        {
            HasKey(c => c.ClienteId);

            Property(c => c.Nome).IsRequired().HasMaxLength(150);

            Property(c => c.Sobrenome).IsRequired().HasMaxLength(150);

            Property(c => c.Email).IsRequired();
        }
    }
}
