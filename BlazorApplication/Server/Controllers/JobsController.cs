using BlazorApplication.Server.Data;
using BlazorApplication.Server.Entities;
using BlazorApplication.Shared.Models.InputModels;
using BlazorApplication.Shared.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BlazorApplication.Server.Controllers
{
    [ApiController]
    [Route("api/jobs")]
    public class JobsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public JobsController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        [Authorize]

        public async Task<IActionResult> GetAll()
        {
            var jobs = await _context.Jobs.ToListAsync();

            var model = jobs.Select (j => 

            new JobViewModel(j.Id, j.Title, j.Description, j.Company, j.Location, j.Salary)).ToList();

            return Ok(model);
        }

        [HttpGet("{id}")]
        [Authorize]

        public async Task<IActionResult> GetById(Guid id)
        {
            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);

            if (job is null)
            {
                return NotFound();
            }

            var viewModel = new JobViewModel(job.Id, job.Title, job.Description, job.Company, job.Location, job.Salary);

            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(JobInputModel inputModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var job = new Job(inputModel.Title, inputModel.Description, inputModel.Company, inputModel.Location, inputModel.Salary, new Guid(userId));

            await _context.Jobs.AddAsync(job);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, JobInputModel inputModel)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var job = _context.Jobs.SingleOrDefault(j => j.Id == id);

            if (job is null)
            {
                return NotFound();
            }

            job.Update(inputModel.Title, inputModel.Description, inputModel.Company, inputModel.Location, inputModel.Salary);

            _context.Jobs.Update(job);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("{id}/applications")]
        [Authorize]
        public async Task<IActionResult> PostApplication(Guid id)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest();
            }

            var jobApplication = new JobApplication(userId, id);
            
            await _context.AddAsync(jobApplication);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("applications")]
        [Authorize]
        public async Task<IActionResult> GetApplications()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(string.IsNullOrWhiteSpace(userId))
            {
                return BadRequest();
            }

            var applications = await _context.JobApplications
                .Include(ja => ja.Job)
                .Where(j => j.UserId == userId).ToListAsync();

            var modelApplications = applications.Select(a =>
                new JobApplicationViewModel(
                    a.Id,
                    a.JobId,
                    a.Job.Title,
                    a.Job.Company,
                    a.Job.Location,
                    a.Job.Salary,
                    a.AppliedAt
                    )).ToList();

            return Ok(modelApplications);
        }
            
    }
}
