using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FIT_Api_Examples.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;
using FIT_Api_Examples.Modul2.ViewModels;
using FIT_Api_Examples.Modul3_MaticnaKnjiga.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FIT_Api_Examples.Modul2.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class MaticnaKnjigaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public MaticnaKnjigaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        [HttpGet]
        public List<UpisiGodinu> GetAll(int student_id)
        {
            return _dbContext.UpisiGodinu.Where(x => x.StudentID == student_id).Include(x => x.AkademskaGodina)
                .ToList();
        }
        [HttpPost]
        public ActionResult Ovjeri([FromBody] UpisiGodinuOvjeriVM obj)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");
            var upisanaGodina = _dbContext.UpisiGodinu.Find(obj.Id);
            if (upisanaGodina == null)
            {
                return BadRequest();
            }
            upisanaGodina.DatumOvjere = obj.DatumOvjere;
            upisanaGodina.Napomena = obj.Napomena;
            _dbContext.SaveChanges();
            return Ok();
        }
        [HttpPost]
        public ActionResult Snimi([FromBody] UpisiGodinuAddVM obj)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");
            var evidentirao = HttpContext.GetLoginInfo().korisnickiNalog.korisnickoIme;
            var pronadjen = _dbContext.UpisiGodinu
                .Where(x => x.StudentID == obj.StudentID && 
                            x.GodinaStudija == obj.GodinaStudija && !obj.Obnova)
                .FirstOrDefault();
            if (pronadjen == null || obj.Obnova)
            {
                var ug = new UpisiGodinu()
                {
                    DatumUpisa = obj.DatumUpisa,
                    Napomena = "text",
                    GodinaStudija = obj.GodinaStudija,
                    AkademskaGodinaID = obj.AkademskaGodinaID,
                    CijenaSkolarine = obj.CijenaSkolarine,
                    Obnova = obj.Obnova,
                    DatumOvjere = null,
                    StudentID = obj.StudentID,
                    Evidentirao = evidentirao

                };
                _dbContext.Add(ug);
                _dbContext.SaveChanges();
            }
            else 
                return BadRequest("Godian vec upisana");

            return Ok();
        }
    }
}
