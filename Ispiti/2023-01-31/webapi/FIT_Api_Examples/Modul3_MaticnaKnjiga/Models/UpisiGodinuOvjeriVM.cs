using System;
using System.ComponentModel.DataAnnotations.Schema;
using FIT_Api_Examples.Modul2.Models;

namespace FIT_Api_Examples.Modul3_MaticnaKnjiga.Models
{
    public class UpisiGodinuOvjeriVM  
    {
        public int Id { get; set; }
        public DateTime DatumOvjere { get; set; }
        public string Napomena { get; set; }


    }
}
