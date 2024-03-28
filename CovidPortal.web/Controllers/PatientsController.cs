using CovidPortal.web.Data;
using CovidPortal.web.Models;
using CovidPortal.web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CovidPortal.web.Controllers
{
    public class PatientsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PatientsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPatientViewModel viewModel)
        {
            var patient1 = await dbContext.Patients.FindAsync(viewModel.Id);
            if (patient1 is null)
            {
                var patient = new Patient
                {
                    Id = viewModel.Id,
                    FullName = viewModel.FullName,
                    Address = viewModel.Address,
                    Phone = viewModel.Phone,
                    MobilePhone = viewModel.MobilePhone,
                    BirthDate = viewModel.BirthDate,
                    CovidPositiveDate = viewModel.CovidPositiveDate,
                    RecoveryDate = viewModel.RecoveryDate
                };
                await dbContext.Patients.AddAsync(patient);
                await dbContext.SaveChangesAsync();
            }           

            return RedirectToAction("List", "Patients");
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var patients = await dbContext.Patients.ToListAsync();
            return View(patients);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var patient = await dbContext.Patients.FindAsync(id);
            return View(patient);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Patient viewModel)
        {
            var patient = await dbContext.Patients.FindAsync(viewModel.Id);
            if (patient is not null)
            {
                patient.FullName = viewModel.FullName;
                patient.Address = viewModel.Address;
                patient.Phone = viewModel.Phone;
                patient.MobilePhone = viewModel.MobilePhone;
                patient.BirthDate = viewModel.BirthDate;
                patient.CovidPositiveDate = viewModel.CovidPositiveDate;
                patient.RecoveryDate = viewModel.RecoveryDate;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Patients");
        }

        [HttpGet]
        public async Task<IActionResult> Vaccinations(string id)
        {
            var patient = await dbContext.Vaccins.FindAsync(id);
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Vaccinations(VaccinViewModel viewModel)
        {
            var vaccin = await dbContext.Vaccins.FindAsync(viewModel.Id);
            if (vaccin is not null)
            {
                vaccin.CoronaVaccine1 = viewModel.CoronaVaccine1;
                vaccin.CoronaVaccine2 = viewModel.CoronaVaccine2;
                vaccin.CoronaVaccine3 = viewModel.CoronaVaccine3;
                vaccin.CoronaVaccine4 = viewModel.CoronaVaccine4;
                vaccin.CoronaManufacturer1 = viewModel.CoronaManufacturer1;
                vaccin.CoronaManufacturer2 = viewModel.CoronaManufacturer2;
                vaccin.CoronaManufacturer3 = viewModel.CoronaManufacturer3;
                vaccin.CoronaManufacturer4 = viewModel.CoronaManufacturer4;
                await dbContext.SaveChangesAsync();
            }
            else
            {
                var vaccinDetails1 = new VaccinDetails
                {
                    Id = viewModel.Id,
                    CoronaVaccine1 = viewModel.CoronaVaccine1,
                    CoronaManufacturer1 = viewModel.CoronaManufacturer1,
                    CoronaManufacturer2 = viewModel.CoronaManufacturer2,
                    CoronaManufacturer3 = viewModel.CoronaManufacturer3,
                    CoronaManufacturer4 = viewModel.CoronaManufacturer4,
                    CoronaVaccine2 = viewModel.CoronaVaccine2,
                    CoronaVaccine3 = viewModel.CoronaVaccine3,
                    CoronaVaccine4 = viewModel.CoronaVaccine4
                };
                await dbContext.Vaccins.AddAsync(vaccinDetails1);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Patients");
        }



        [HttpPost]
        public async Task<IActionResult> Delete(Patient viewModel)
        {
            var patient = await dbContext.Patients
                .AsNoTracking()
                .FirstOrDefaultAsync(x=>x.Id == viewModel.Id);
            if (patient is not null)
            {
                dbContext.Patients.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            var patientVaccin = await dbContext.Vaccins
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (patientVaccin is not null)
            {
                dbContext.Vaccins.Remove(patientVaccin);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Patients");
        }
    }
}
