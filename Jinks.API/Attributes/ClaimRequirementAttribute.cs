using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jinks.API.Attributes
{
  public class ClaimRequirementAttribute : TypeFilterAttribute
  {
    public ClaimRequirementAttribute()
      : base(typeof(ClaimRequirementFilter))
    { }
  }
}
