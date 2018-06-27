using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ManytoMany.Models {
    public class PersonPerson {
        public int PersonPersonID { get; set; }
        public int PersonID { get; set; }
        public int FriendID { get; set; }

        public Person Person { get; set; }
        public Person Friend { get; set; }

    }
}
