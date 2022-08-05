﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyAutoService.Data;
using MyAutoService.Models;

namespace MyAutoService.Pages.ServiceTypes
{
    public class DetailsModel : PageModel
    {
        private readonly MyAutoService.Data.ApplicationDbContext _context;

        public DetailsModel(MyAutoService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public ServiceType ServiceType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.serviceTypes == null)
            {
                return NotFound();
            }

            var servicetype = await _context.serviceTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (servicetype == null)
            {
                return NotFound();
            }
            else 
            {
                ServiceType = servicetype;
            }
            return Page();
        }
    }
}
