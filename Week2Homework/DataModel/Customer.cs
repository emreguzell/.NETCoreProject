using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Week2Homework.DataModel
{
    
    public class Customer
    {
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Id'yi otamatik olarak arttırması için
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public long Age { get; set; }

        public string PhoneNumber { get; set; }
    }
}
