using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Front_to_Backend.DataAccesLayer;
using Pronia_Front_to_Backend.Models;
using Pronia_Front_to_Backend.ViewModels.Sliders;

namespace Pronia_Front_to_Backend.Areas.Admin.Controllers
{
	[Area("admin")]
	public class HomeController(ProniaContext _context) : Controller
	{
		public async Task<IActionResult> Index()
		{
			var data = await _context.Sliders
				.Select(s => new GetSliderVM
				{
					Discount = s.Discount,
					Id = s.Id,
					ImageUrl = s.ImageUrl,
					Subtitle = s.Subtitle,
					Title = s.Title,
				}).ToListAsync();
			return View(data);
		}
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(CreateSliderVM vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}
			Slider slider = new Slider
			{
				Discount = vm.Discount,
				ImageUrl = vm.ImageUrl,
				CreatedTime = DateTime.Now,
				IsDeleted = false,
				Subtitle = vm.Subtitle,
				Title = vm.Title,
			};
			await _context.Sliders.AddAsync(slider);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Update(int? id)
		{
			if (id == null || id < 1) return BadRequest();
			Slider slider = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id);
			if (slider is null) return NotFound();
			return View(slider);	
		}
		[HttpPost]
		public async Task<IActionResult> Update(int? id, Slider slider)
		{
			if (id == null || id < 1) return BadRequest();
			Slider existed = await _context.Sliders.FirstOrDefaultAsync(s => s.Id == id); 
			if (existed is null) return NotFound();
			existed.Discount = slider.Discount;
			existed.Title = slider.Title;
			existed.Subtitle = slider.Subtitle;
			existed.ImageUrl = slider.ImageUrl;
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || id < 1) return BadRequest();

			var item = await _context.Sliders.FindAsync(id);
			if (item == null) return NotFound();
			_context.Remove(item);
			await _context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
	}
}














