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
         private readonly IMongoCollection<Records> _records;



        public ClinicBackupController(BackupDBContext backupDBContext, IOptions<ClincSettings> options)
        {
           var mongo = new MongoClient(options.Value.ConnectionStrings);
            _records = mongo.GetDatabase(options.Value.DatabaseName).GetCollection<Records>(options.Value.RecordCollection);
        }
        [HttpGet]
         public async Task<List<Records>> GetData()
   {

       return await _records.Find(_ => true).ToListAsync();
   }
    }
}
