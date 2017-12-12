using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dopravio.Models
{
    public class DriverDTO: EmployeeDTO
    {
        public DriverDTO(Driver d)
        {
            this.id = d.id;
            this.name = d.name;
            this.surname = d.surname;
            this.dateOfBirth = d.dateOfBirth;
            this.phone = d.phone;
            this.email = d.email;
            this.salary = d.salary;
            this.accidentCount = d.accidentCount;
            this.address = d.address;
        }


        public int id { get; set; }

        public int accidentCount { get; set; }
    }
}
