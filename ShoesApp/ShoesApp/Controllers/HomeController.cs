using Microsoft.AspNetCore.Mvc;
using ShoesApp.Entities;
using ShoesApp.Interfaces;

// Controller per la gestione delle pagine pubbliche
namespace ShoesApp.Controllers
{
    
    public class HomeController : Controller
    {
        // Dichiarazione dei servizi utilizzati dal controller
        private readonly ILogger<HomeController> _logger;
        private readonly IInventoryService _inventoryService;
        private readonly IImgService _imgService;

        // Costruttore del controller
        public HomeController(ILogger<HomeController> logger, IInventoryService inventoryService, IImgService imgService)
        {
            // Inizializzazione dei servizi
            _logger = logger;
            _inventoryService = inventoryService;
            _imgService = imgService;
        }

        // Azione per la visualizzazione della home page
        public IActionResult Index()
        {
            var shoes = _inventoryService.GetAllShoes().OrderByDescending(s => s.CreatedAt);

            // Aggiungo l'URL delle immagini alle scarpe
            foreach (var shoe in shoes)
            {
                shoe.Cover.Url = _imgService.GetImageUrl(shoe.Id.ToString(), "cover");
                shoe.Image1.Url = _imgService.GetImageUrl(shoe.Id.ToString(), "image1");
                shoe.Image2.Url = _imgService.GetImageUrl(shoe.Id.ToString(), "image2");
            }

            return View(shoes);
        }

        // Azione per la visualizzazione dei dettagli di una scarpa
        public IActionResult Details(int id)
        {
            var shoe = _inventoryService.GetById(id);
            shoe.Cover.Url = _imgService.GetImageUrl(shoe.Id.ToString(), "cover");
            shoe.Image1.Url = _imgService.GetImageUrl(shoe.Id.ToString(), "image1");
            shoe.Image2.Url = _imgService.GetImageUrl(shoe.Id.ToString(), "image2");
            return View(shoe);
        }

        // Azione per la visualizzazione del form di creazione di una nuova scarpa
        public IActionResult Create()
        {
            return View(new TennisShoes());
        }

        // Azione per la creazione di una nuova scarpa
        [HttpPost]
        public IActionResult Create(TennisShoes shoe)
        {
            if (!ModelState.IsValid)
            {
                return View(shoe);
            }

            else 
            { 
            var newShoe = new TennisShoes
            {
                Name = shoe.Name,
                Description = shoe.Description,
                Price = shoe.Price,
                Cover = new ImageModel(),
                Image1 = new ImageModel(),
                Image2 = new ImageModel()
            };

            _inventoryService.Create(newShoe);

            // Salvo le immagini sul server
            if (shoe.Cover.File != null && shoe.Cover.File.Length > 0)
            {
                newShoe.Cover.Url = _imgService.SaveImage(shoe.Cover.File, newShoe.Id.ToString(), "cover");
            }
            if (shoe.Image1.File != null && shoe.Image1.File.Length > 0)
            {
                newShoe.Image1.Url = _imgService.SaveImage(shoe.Image1.File, newShoe.Id.ToString(), "image1");
            }
            if (shoe.Image2.File != null && shoe.Image2.File.Length > 0)
            {
                newShoe.Image2.Url = _imgService.SaveImage(shoe.Image2.File, newShoe.Id.ToString(), "image2");
            }

            return RedirectToAction(nameof(Index));
            }
        }

        // Azione per la visualizzazione del form di modifica di una scarpa
        public IActionResult Edit(int id)
        {
            var shoe = _inventoryService.GetById(id);
            if (shoe == null)
            {
                return NotFound();
            }
            // Riutilizzo la vista Create per la modifica
            return View("Create", shoe);
        }

        // Azione per la modifica di una scarpa
        [HttpPost]
        public IActionResult Edit(TennisShoes shoe)
        {
            if (ModelState.IsValid)
            {
                _inventoryService.Update(shoe);
                return RedirectToAction(nameof(Index));
            }
            return View("Create", shoe);
        }

        // Azione per la cancellazione di una scarpa
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var shoe = _inventoryService.GetById(id);
            if (shoe != null)
            {
                _inventoryService.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
