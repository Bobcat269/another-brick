using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PantryWebApp.Data;
using PantryWebApp.Models;

namespace PantryWebApp.Controllers
{
    public class IngredientsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IngredientsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ingredients
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ingredient.ToListAsync());
        }

        // GET: Ingredients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // GET: Ingredients/LoadSearchForm
        public async Task<IActionResult> SearchForm()
        {
            //return View(await _context.Ingredient.ToListAsync());
            //return View("SearchForm");
            return View(); //You don't have to pass anything since we are calling the method above.
        }

        //POST: Ingredients/SearchResults
        //Verify this, it seems wrong.
        //
        //
        //VERIFY!!!!!!!!!
        public async Task<IActionResult> SearchResults(String Search)
        {
            if (Search == null) {
                return View("You didn't enter anything in the search bar silly!");
                //^^this is still not correct but it works for now
                    }
            else
            {
                return View("SearchResults", await _context.Ingredient.Where( i => i.Name.Contains(Search)).ToListAsync());
            } //The reason we use i.Name.Contains instead of StartsWith is because we want the user to be able to enter
            //"Pepper" and find both [Pepper] and [Red Bell Peppers]
        }

        //public String SearchResults(String Search)
        //{

        //    //return View(); //You don't have to pass anything since we are calling the method above.
        //    return "test " + Search;
        //}

        // GET: Ingredients/Create
        [Authorize]//Decorator
        //[Microsoft.AspNetCore.Authorization.Authorize] 
        //Can also be written above way but seems redundant given the 
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Expiration")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ingredient);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity,Expiration")] Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ingredient);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IngredientExists(ingredient.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingredient = await _context.Ingredient
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ingredient == null)
            {
                return NotFound();
            }

            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ingredient = await _context.Ingredient.FindAsync(id);
            if (ingredient != null)
            {
                _context.Ingredient.Remove(ingredient);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredient.Any(e => e.Id == id);
        }
    }
}
