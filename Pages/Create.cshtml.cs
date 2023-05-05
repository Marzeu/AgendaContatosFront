using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AgendaContatos.Data;
using AgendaContatos.Models;
using AgendaContatos.ViewModel;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text;

namespace AgendaContatos.Pages
{
    public class CreateModel : PageModel
    {    
        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pessoa Pessoa { get; set; } = default!;       

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
           

            var pessoa = JsonConvert.SerializeObject(Pessoa);

            using (var client = new HttpClient())
            {
                var content = new StringContent(pessoa, Encoding.UTF8, "application/json");
                var response = await client.PostAsync("http://localhost:5183/api/v1/pessoa/", content);
                string resultContent = await response.Content.ReadAsStringAsync();                
            }

            return RedirectToPage("./Index");           
        }
    }
}
