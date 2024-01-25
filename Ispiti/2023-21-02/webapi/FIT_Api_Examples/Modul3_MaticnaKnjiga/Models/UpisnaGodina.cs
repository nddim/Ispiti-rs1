using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul0_Autentifikacija.Models;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    [Table("UpisnaGodina")]
    public class UpisnaGodina
    {
        [Key]
        public int id { get; set; }
        public DateTime DatumUpisa { get; set; }
        public int GodinaStudija { get; set; }
        [ForeignKey(nameof(AkademskaGodinaID))]
        public AkademskaGodina AkademskaGodina { get; set; }
        public int AkademskaGodinaID { get; set; }
        public int CijenaSkolarine { get; set; }
        public bool Obnova { get; set; }
        public DateTime? DatumOvjere { get; set; }
        public string Napomena { get; set; }
        [ForeignKey(nameof(StudentID))]
        public Student Student { get; set; }
        public int  StudentID { get; set; }
        public string Evidentirao { get; set; }
  
    }
}
