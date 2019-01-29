using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoCorePush.Model;

namespace ToDoCorePush.Pages.Shared
{
    public class _ToDoTableTemplateModel : PageModel
    {
        public ToDosListe todos { get; set; }
        public void OnGet()
        {

        }
    }
}