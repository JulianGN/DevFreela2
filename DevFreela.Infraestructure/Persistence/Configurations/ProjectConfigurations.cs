using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infraestructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            // defina as chaves primarias a partir das entidades criadas:
            builder
                //.ToTable("tb_Project") // pode definir opcionalmente o nome, caso não defina, será o nome da entidade (Project)
                .HasKey(p => p.Id); // define a chave primária

            builder
                .HasOne(p => p.Freelancer) // um projeto pode ter um freelancer
                .WithMany(f => f.FreelancerProjects) // um freelancer pode ter muitos projetos
                .HasForeignKey(p => p.IdFreelancer) // chave estrangeira que o projeto pode usar é o Id do Freelancer
                .OnDelete(DeleteBehavior.Restrict); // caso delete um projeto, ele não elimina os freelancers

            builder
                .HasOne(p => p.Client) // um projeto pode ter um cliente
                .WithMany(f => f.OwnedProjects) // um client pode ter muitos projetos próprios
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
