using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class IndexModel : PageModel
{
    public string Name => (string)TempData[nameof(Name)];

    public void OnGet()
    {
    }

    public IActionResult OnPost([FromForm] string name)
    {
        TempData["Name"] = name;
        return RedirectToPage("Index");
    }
}