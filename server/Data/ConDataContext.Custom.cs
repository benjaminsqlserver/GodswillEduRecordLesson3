using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using GodswillEduRecord.Models;

using GodswillEduRecord.Models.ConData;

namespace GodswillEduRecord.Data
{
  public partial class ConDataContext 
  {
     partial void OnModelBuilding(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers");
        }
  }

}