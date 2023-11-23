using Backup.Domain;
using Core.DTO.Record;
using Core.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMongoCollection<Records> _records;



        public ClinicController(IUnitOfWork unitOfWork, IOptions<ClincSettings> options)
        {
            _unitOfWork = unitOfWork;
             var mongo = new MongoClient(options.Value.ConnectionStrings);
             _records = mongo.GetDatabase(options.Value.DatabaseName).GetCollection<Records>(options.Value.RecordCollection);
        }

        [HttpPost("AddRecordData")]
        public IActionResult AddRecordData(AddRecordDTO dTO)
        {
            var recordData = new Record();
            recordData.Symptoms = dTO.Symptoms;
            recordData.PatientName= dTO.PatientName;
            recordData.TreatmentPlan= dTO.TreatmentPlan;
            recordData.Date= dTO.Date;
            recordData.Diagnosis= dTO.Diagnosis;

            var recordBackUp = new Records();
            recordBackUp.Symptoms = dTO.Symptoms;
            recordBackUp.PatientName = dTO.PatientName;
            recordBackUp.TreatmentPlan = dTO.TreatmentPlan;
            recordBackUp.Date = dTO.Date;
            recordBackUp.Diagnosis = dTO.Diagnosis;

             _unitOfWork.Repository<Record>().Create(recordData);
             _records.InsertOneAsync(recordBackUp);
            _unitOfWork.Complete();
            return Ok();    
        }
    }
}
