using DevFreela.Core.Entities;

namespace DevFreela.Infrastructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
              new Project("Meu projeto ASPNET Core","Minha Descricao de Projeto 1", 1, 1, 1000),
              new Project("Meu projeto ASPNET Core","Minha Descricao de Projeto 2", 1, 1, 2000),
              new Project("Meu projeto ASPNET Core","Minha Descricao de Projeto 3", 1, 1, 3000)
            };

            Users = new List<User> 
            {
              new User("Adenilson Sena","asena.developer@gmail.com", new DateTime(1981, 4, 4)),
              new User("Nilson Sena","nilson.developer@gmail.com", new DateTime(1982, 4, 4)),
              new User("Almeida Sena","almeida.developer@gmail.com", new DateTime(1983, 4, 4))
            };

            Skills = new List<Skill>
            {
              new Skill(".Net Core"),
              new Skill("C#"),
              new Skill("SQl")
            };
        }
        public List<Project> Projects { get; set; }
        public List<User> Users { get; set; }
        public List<Skill> Skills { get; set; }
        public List<ProjectComment> ProjectComments { get; set; }
    }
}
