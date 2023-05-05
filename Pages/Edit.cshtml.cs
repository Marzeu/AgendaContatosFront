using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaContatos.Data;
using AgendaContatos.Models;
using AgendaContatos.ViewModel;
using Newtonsoft.Json;
using System.Text;

namespace AgendaContatos.Pages
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public PessoaContatoViewModel Pessoa { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using (var client = new HttpClient())
            {
                var request = await client.GetAsync($"http://localhost:5183/api/v1/pessoas/{id}");
                var response = await request.Content.ReadAsStringAsync();
                var pessoa = JsonConvert.DeserializeObject<ResultViewModel<PessoaContatoViewModel>>(response);

                if (pessoa.Data == null)
                {
                    return NotFound();
                }
                else
                {
                    Pessoa = pessoa.Data;
                }
                return Page();
            }
        }
        
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (Pessoa == null)
            {
                return NotFound();
            }

            var pessoa = JsonConvert.SerializeObject(Pessoa);

            using (var client = new HttpClient())
            {
                var content = new StringContent(pessoa, Encoding.UTF8, "application/json");
                var response = await client.PutAsync("http://localhost:5183/api/v1/pessoa/", content);
                string resultContent = await response.Content.ReadAsStringAsync();
            }

            return RedirectToPage("./Index");

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!PessoaExists(Pessoa.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return RedirectToPage("./Index");
        }
    }
}
