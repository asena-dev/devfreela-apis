﻿
namespace DevFreela.Application.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public ProjectDetailsViewModel(int id, string title, string description, decimal totalCost, DateTime? startedAt, DateTime? finishdAt,
            string clienteFullName, string freelancerFullName)
        {
            Id = id;
            Title = title;
            Description = description;
            TotalCost = totalCost;
            StartedAt = startedAt;
            FinishdAt = finishdAt;
            ClienteFullName = clienteFullName;
            FreelancerFullName = freelancerFullName;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal TotalCost { get; set; }
        public DateTime? StartedAt { get; private set; }
        public DateTime? FinishdAt { get; private set; }
        public string ClienteFullName { get; private set; }
        public string FreelancerFullName { get; private set; }
    }
}
