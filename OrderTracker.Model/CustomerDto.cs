using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracker.Model
{
    public record CustomerDto(string FirstName, string LastName, 
        string StreetAddress, string City, string ZIP, string State, 
        string PhoneNumber, string Email);
    
}
