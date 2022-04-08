﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Core.QueryFilters
{
  public  class POSTQueryFilter
    {

             public int? UserId { get; set; }
             public DateTime? Date { get; set; }
             public string? Description { get; set; }
             public int PageSize { get; set; }
             public int PageNumber { get; set; }

    }
}
