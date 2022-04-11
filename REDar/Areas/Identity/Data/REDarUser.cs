using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REDar.Areas.Identity.Data;

// Add profile data for application users by adding properties to the REDarUser class
public class REDarUser : IdentityUser
{
    [PersonalData]
    [Display(Name = "Body Mass Index")]
    public float? BMI { get; set; }
    [PersonalData]
    [Display(Name = "Date of Birth")]
    public DateTime DOB { get; set; }
}

