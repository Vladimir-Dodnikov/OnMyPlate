namespace OnMyPlate.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using OnMyPlate.Data;
    using OnMyPlate.Data.Common.Repositories;
    using OnMyPlate.Data.Models;

    [Area("Administration")]
    public class PlacesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Place> placesRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public PlacesController(
            IDeletableEntityRepository<Place> placesRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.placesRepository = placesRepository;
            this.usersRepository = usersRepository;
        }

        // GET: Administration/Places
        public async Task<IActionResult> Index()
        {
            return this.View(await this.placesRepository.All().ToListAsync());
        }

        // GET: Administration/Places/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var place = await this.placesRepository.All()
                .Include(p => p.CreatedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return this.NotFound();
            }

            return this.View(place);
        }

        // GET: Administration/Places/Create
        public IActionResult Create()
        {
            this.ViewData["CreatedByUserId"] = new SelectList(this.usersRepository.All(), "Id", "Id");
            return this.View();
        }

        // POST: Administration/Places/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,VisitsCount,Likes,Dislikes,WebUrl,CreatedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Place place)
        {
            if (this.ModelState.IsValid)
            {
                await this.placesRepository.AddAsync(place);
                await this.placesRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CreatedByUserId"] = new SelectList(this.usersRepository.All(), "Id", "Id", place.CreatedByUserId);
            return this.View(place);
        }

        // GET: Administration/Places/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var place = this.placesRepository.All().FirstOrDefault(x => x.Id == id);
            if (place == null)
            {
                return this.NotFound();
            }

            this.ViewData["CreatedByUserId"] = new SelectList(this.usersRepository.All(), "Id", "Id", place.CreatedByUserId);
            return this.View(place);
        }

        // POST: Administration/Places/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,VisitsCount,Likes,Dislikes,WebUrl,CreatedByUserId,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Place place)
        {
            if (id != place.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.placesRepository.Update(place);
                    await this.placesRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.PlaceExists(place.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            this.ViewData["CreatedByUserId"] = new SelectList(this.usersRepository.All(), "Id", "Id", place.CreatedByUserId);
            return this.View(place);
        }

        // GET: Administration/Places/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var place = await this.placesRepository.All()
                .Include(p => p.CreatedByUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (place == null)
            {
                return this.NotFound();
            }

            return this.View(place);
        }

        // POST: Administration/Places/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var place = this.placesRepository.All().FirstOrDefault(x => x.Id == id);
            this.placesRepository.Delete(place);
            await this.placesRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool PlaceExists(int id)
        {
            return this.placesRepository.All().Any(e => e.Id == id);
        }
    }
}
