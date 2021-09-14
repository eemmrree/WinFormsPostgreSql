using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostgreSQLEntityFramework.Model
{
    public class Personel
    {
        [Key]
        public int personelid { get; set; }
        public string personelad { get; set; }
        public string personelsoyad { get; set; }
        public string birim { get; set; }
    }
}
