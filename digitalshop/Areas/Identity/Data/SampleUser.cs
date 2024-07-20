using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace digitalshop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SampleUser class
public class SampleUser : IdentityUser

{
    public string Name { get; set; }

}

