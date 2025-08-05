using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyLeasing.Common.Entities;
using MyLeasing.Web.Data;

namespace MyLeasing.Web.Controllers
{
    public class OwnersController : Controller
    {
        //private readonly IRepository _repository;
        //private readonly DataContext _context;

        private readonly IOwnersRepository _ownersRepository;

        //public OwnersController(DataContext context)

        //public OwnersController(IRepository repository)
        public OwnersController(IOwnersRepository ownersRepository)
        {
            //_repository = repository;
            //_context = context;
            _ownersRepository = ownersRepository;
        }

        // GET: Owners
        //public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            //return View(await _context.Owners.ToListAsync());
            //return View(_repository.GetOwners());
            return View(_ownersRepository.GetAll());
        }

        // GET: Owners/Details/5
        //public async Task<IActionResult> Details(int? id)
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var owner = await _context.Owners
                //.FirstOrDefaultAsync(m => m.Id == id);
                //var owner = _repository.GetOwner(id.Value);
                var owner =await _ownersRepository.GetByIdAsync(id.Value); 
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // GET: Owners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Owners/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Document,FirstName,LastName,FixedPhone,CellPhone,Address")] Owner owner)
        {
            if (ModelState.IsValid)
            {
                
                //_repository.AddOwner(owner);
                await _ownersRepository.CreateAsync(owner);

                //await _repository.SaveAllAsync();
               
                return RedirectToAction(nameof(Index));
            }
            return View(owner);
        }

        // GET: Owners/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var owner = _repository.GetOwner(id.Value);
            var owner = await _ownersRepository.GetByIdAsync(id.Value);
            if (owner == null)
            {
                return NotFound();
            }
            return View(owner);
        }

        // POST: Owners/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Document,FirstName,LastName,FixedPhone,CellPhone,Address")] Owner owner)
        {
            if (id != owner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    //_repository.UpdateOwner(owner);
                    await _ownersRepository.UpdateAsync(owner);

                }
                catch (DbUpdateConcurrencyException)
                {
                    
                    //if (!_repository.OwnerExists(owner.Id))
                    if (!await _ownersRepository.ExistAsync(owner.Id))
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
            return View(owner);
        }

        // GET: Owners/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var owner = _repository.GetOwner(id.Value);
            var owner =await _ownersRepository.GetByIdAsync(id.Value);
            if (owner == null)
            {
                return NotFound();
            }

            return View(owner);
        }

        // POST: Owners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            //var owner = _repository.GetOwner(id);
            var owner = await _ownersRepository.GetByIdAsync(id);

           await _ownersRepository.DeleteAsync(owner);

            return RedirectToAction(nameof(Index));
        }

    }
}
