using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace WebApplication1.Pages.BelongingsPot
{
    public class IndexModel : PageModel
    {
        private static List<Doel> _opslag = new();

        public List<Doel> Doelen { get; set; } = new();

        [BindProperty] public string Titel { get; set; } = string.Empty;
        [BindProperty] public string Beschrijving { get; set; } = string.Empty;
        [BindProperty] public int Minuten { get; set; } = 10;
        [BindProperty] public string Beloning { get; set; } = string.Empty;

        public void OnGet()
        {
            Doelen = _opslag;
        }

        public IActionResult OnPost()
        {
            _opslag.Add(new Doel
            {
                Titel = Titel,
                Beschrijving = Beschrijving,
                Minuten = Minuten,
                Beloning = Beloning
            });

            return RedirectToPage();
        }

        public IActionResult OnPostVerwijder(int index)
        {
            if (index >= 0 && index < _opslag.Count)
            {
                _opslag.RemoveAt(index);
            }

            return RedirectToPage();
        }
    }
}