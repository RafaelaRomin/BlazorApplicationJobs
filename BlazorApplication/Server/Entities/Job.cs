namespace BlazorApplication.Server.Entities
{
    public class Job
    {
        public Job(string title, string description, string company, string location, decimal salary, Guid createdByUser)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Company = company;
            Location = location;
            Salary = salary;
            CreatedByUser = createdByUser;
            CreatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Company { get; private set; }
        public string Location  { get; private set; }
        public decimal Salary { get; private set; }

        public Guid CreatedByUser { get; private set; }
        public List<JobApplication> JobApplications { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void Update(string title, string description, string company, string location, decimal salary) 
        {
            Title = title;
            Description = description;
            Company = company;
            Location = location;
            Salary = salary;
        }

    }
}
