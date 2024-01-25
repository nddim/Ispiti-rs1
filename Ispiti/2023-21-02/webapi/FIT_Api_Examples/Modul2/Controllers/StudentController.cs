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
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public StudentController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

      

        [HttpGet]
        public ActionResult<List<Student>> GetAll(string ime_prezime)
        {
            var data = _dbContext.Student
                .Include(s => s.opstina_rodjenja.drzava)
                .Where(x => ime_prezime == null || (x.ime + " " + x.prezime).StartsWith(ime_prezime) || (x.prezime + " " + x.ime).StartsWith(ime_prezime))
                .OrderByDescending(s => s.id)
                .AsQueryable();
            return data.Take(100).ToList();
        }
        [HttpPost]
        public ActionResult<Student> Snimi([FromBody] StudentAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");
            Student student;
            if (x.id == 0)
            {
                student = new Student();
                _dbContext.Add(student);
                student.created_time = DateTime.Now;
                student.slika_korisnika = Config.SlikeURL + "empty.png";
            }
            else
            {
                student = _dbContext.Student.Find(x.id);
                if (student == null)
                    return BadRequest("Nema studenta sa ovim idom");
            }
            student.ime = x.ime;
            student.prezime = x.prezime;
            student.opstina_rodjenja_id = x.opstina_rodjenja_id;
            _dbContext.SaveChanges();
            if (student.broj_indeksa == null)
            {
                student.broj_indeksa="IB2400" + student.id;
                _dbContext.SaveChanges();
            }
            return Ok(student);
        }
        [HttpDelete]
        public ActionResult Izbrisi(int student_id)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");
            var student = _dbContext.Student.Find(student_id);
            if (student == null)
                return BadRequest();
            student.IsDeleted=true;
            _dbContext.SaveChanges();
            return Ok();
        }
    }
}
