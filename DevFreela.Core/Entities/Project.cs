using DevFreela.Core.Enums;

namespace DevFreela.Core.Entities
{
    public  class Project : BaseEntity
    {
        public Project(string title, string description, int idCliente, int idFreelancer, decimal totalCost)
        {
            Title = title;
            Description = description;
            IdCliente = idCliente;
            IdFreelancer = idFreelancer;
            TotalCost = totalCost;

            CreatedAt = DateTime.Now;
            Status = ProjectStatusEnum.Created;
            Comments = new List<ProjectComment>();
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public int IdCliente { get; private set; }
        public int IdFreelancer { get; private set; }
        public decimal TotalCost { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinisheAt { get; private set; }
        public ProjectStatusEnum Status { get; private set; }
        public List<ProjectComment> Comments { get; private set; }

        public void Cancel()
        {
            if (Status.Equals(ProjectStatusEnum.InProcess) || Status.Equals(ProjectStatusEnum.InProcess))
            {
                Status = ProjectStatusEnum.Cancelled;
            }
        }
        public void Start()
        {
            if (Status.Equals(ProjectStatusEnum.Created))
            {
                Status = ProjectStatusEnum.InProcess;
                StartedAt = DateTime.Now;
            }
        }
        public void Finish()
        {
            if (Status.Equals(ProjectStatusEnum.InProcess) )
            {
                Status = ProjectStatusEnum.Finished;
                FinisheAt = DateTime.Now;
            }
        }

        public void Update(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
