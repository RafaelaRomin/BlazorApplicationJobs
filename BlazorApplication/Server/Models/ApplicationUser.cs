using BlazorApplication.Server.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlazorApplication.Server.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<JobApplication> JobApplications { get; private set; }
    }
}