using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTO
{
    public class CustomerUpdateDto
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateOnly DateOfBirth { get; set; }

    }
}