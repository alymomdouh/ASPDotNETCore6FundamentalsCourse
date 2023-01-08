using PizzaPieShop.Models;
using Microsoft.AspNetCore.Components;

namespace PizzaPieShop.Pages.App
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
