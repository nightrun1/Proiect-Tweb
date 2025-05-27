using System.Linq;
using System.Web.Mvc;
using NextGenPC.BusinessLogic.Interfaces;
using NextGenPC.LogicHelper;

namespace NextGenPC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProduct _product;

        public ProductsController()
        {
            var bl = new BusinessLogic.BusinessLogic();
            _product = bl.GetProductBL();
        }
        // GET: Products
        public ActionResult Index()
        {
            var products = _product.GetAllProductsLogic();
            var viewModel = products.Select(ProductMapper.ToViewModel).ToList();
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var product = _product.GetProductByIdLogic(id);
            var viewModel = ProductMapper.ToViewModel(product);
            return View(viewModel);
        }
    }
}