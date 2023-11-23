using Backup.Domain;
using Core.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicBackupController : ControllerBase
    {
        private readonly IRepositoryBase<Records> _ClinicRepo;


        public ClinicBackupController(IRepositoryBase<Records> ClinicRepo, BackupDBContext backupDBContext)
        {
            _ClinicRepo = ClinicRepo;
        }
        [HttpGet]
        public IActionResult GetRecordsData()
        {
            return Ok(_ClinicRepo.FindAll());
        }
    }
}
