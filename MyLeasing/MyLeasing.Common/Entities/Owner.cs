using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace MyLeasing.Common.Entities
{
    public class Owner
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The document number is mandatory.")]
        public string Document { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        public string FixedPhone { get; set; }


        [Required(ErrorMessage = "Cell phone is mandatory.")]
        public string CellPhone { get; set; }


        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }


    }
}
