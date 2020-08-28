using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.DTO;
using Store.WebUI.Clients.Abstract;
using Store.WebUI.Models;

namespace Store.WebUI.Controllers
{
    public class AdminController : Controller
    {
        #region CTOR
        private readonly ICategoryClient _categoryClient;
        private readonly IContractClient _contractClient;
        private readonly ICustomerClient _customerClient;
        private readonly IDealerClient _dealerClient;
        private readonly IDepartmentClient _departmentClient;
        private readonly IOrderClient _orderClient;
        private readonly IOrderDetailClient _orderDetailClient;
        private readonly IProductClient _productClient;
        private readonly IRecPersonClient _recPersonClient;
        private readonly IRoleClient _roleClient;
        private readonly ISupplierClient _supplierClient;
        private readonly ISurveysClient _surveysClient;

        public AdminController(ICategoryClient categoryClient,
                               IContractClient contractClient,
                               ICustomerClient customerClient,
                               IDealerClient dealerClient,
                               IDepartmentClient departmentClient,
                               IOrderClient orderClient,
                               IOrderDetailClient orderDetailClient,
                               IProductClient productClient,
                               IRecPersonClient recPersonClient,
                               IRoleClient roleClient,
                               ISupplierClient supplierClient,
                               ISurveysClient surveysClient
                               )
        {
            _categoryClient = categoryClient;
            _contractClient = contractClient;
            _customerClient = customerClient;
            _dealerClient = dealerClient;
            _departmentClient = departmentClient;
            _recPersonClient = recPersonClient;
            _roleClient = roleClient;
            _supplierClient = supplierClient;
            _surveysClient = surveysClient;
            _orderDetailClient = orderDetailClient;
            _productClient = productClient;
            _orderClient = orderClient;
        } 
        #endregion
        public IActionResult Index()
        {
            return View();
        }
        #region Categories
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _categoryClient.GetAll();
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryAdd(CategoryDTO dto)
        {
            await _categoryClient.AddCategory(dto);
            return RedirectToAction("CategoryList");
        }
        [HttpGet]
        public async Task<IActionResult> CategoryEdit(int id)
        {
            var category = await _categoryClient.Get(id);
            return View(category);
        }
        [HttpPut]
        public async Task<IActionResult> CategoryEdit(CategoryDTO dto)
        {
            await _categoryClient.UpdateCategory(dto);
            return RedirectToActionPermanent("CategoryList");
        }
        public async Task<IActionResult> CategoryDelete(string Id)
        {
            await _categoryClient.Delete(Id);
            return RedirectToActionPermanent("CategoryList");
        }
        #endregion

        #region Contracts
        [HttpGet]
        public async Task<IActionResult> ContractList()
        {
            var contracts = await _contractClient.GetAll();
            return View(contracts);
        }
        [HttpPost]
        public async Task<IActionResult> ContractAdd(ContractDTO dto)
        {
            await _contractClient.AddContract(dto);
            return RedirectToAction("ContractList");
        }
        [HttpGet]
        public async Task<IActionResult> ContractEdit(int id)
        {
            var contract = await _contractClient.Get(id);
            return View(contract);
        }
        [HttpPut]
        public async Task<IActionResult> ContractEdit(ContractDTO dto)
        {
            await _contractClient.UpdateContract(dto);
            return RedirectToActionPermanent("ContractList");
        }
        [HttpDelete]
        public async Task<IActionResult> ContractDelete(string Id)
        {
            await _contractClient.Delete(Id);
            return RedirectToActionPermanent("ContractList");
        }
        #endregion

        #region Customers
        [HttpGet]
        public async Task<IActionResult> CustomersList()
        {
            var customer = await _customerClient.GetAll();
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> CustomerAdd(CustomerDTO dto)
        {
             await _customerClient.AddCustomer(dto);
            return RedirectToAction("CustomersList");
        }
        [HttpGet]
        public async Task<IActionResult> CustomerEdit(int id)
        {
            var customer = await _customerClient.Get(id);
            return View(customer);
        }
        [HttpPut]
        public async Task<IActionResult> CustomerEdit(CustomerDTO dto)
        {
             await _customerClient.UpdateCustomer(dto);
            return RedirectToActionPermanent("CustomersList");
        }
        [HttpDelete]
        public async Task<IActionResult> CustomerDelete(string Id)
        {
            await _customerClient.Delete(Id);
            return RedirectToActionPermanent("CustomersList");
        }
        #endregion

        #region Dealers
        [HttpGet]
        public async Task<IActionResult> DealerList()
        {
            var dealer = await _dealerClient.GetAll();
            return View(dealer);
        }
        [HttpPost]
        public async Task<IActionResult> DealerAdd(DealerDTO dto)
        {
            await _dealerClient.AddDealer(dto);
            return RedirectToAction("DealerList");
        }
        [HttpGet]
        public async Task<IActionResult> DealerEdit(int id)
        {
            var dealer = await _dealerClient.Get(id);
            return View(dealer);
        }
        [HttpPut]
        public async Task<IActionResult> DealertEdit(DealerDTO dto)
        {
            await _dealerClient.UpdateDealer(dto);
            return RedirectToActionPermanent("DealerList");
        }
        [HttpDelete]
        public async Task<IActionResult> DealerDelete(string Id)
        {
            await _dealerClient.Delete(Id);
            return RedirectToActionPermanent("DealerList");
        }
        #endregion

        #region Departments
        [HttpGet]
        public async Task<IActionResult> DepartmentList()
        {
            var departments = await _departmentClient.GetAll();
            return View(departments);
        }
        [HttpPost]
        public async Task<IActionResult> DepartmentAdd(DepartmentDTO dto)
        {
            await _departmentClient.AddDepartment(dto);
            return RedirectToAction("DepartmentList");
        }
        [HttpGet]
        public async Task<IActionResult> DepartmentEdit(int id)
        {
            var department = await _departmentClient.Get(id);
            return View(department);
        }
        [HttpPut]
        public async Task<IActionResult> DepartmentEdit(DepartmentDTO dto)
        {
            await _departmentClient.UpdateDepartment(dto);
            return RedirectToActionPermanent("DepartmentList");
        }
        [HttpDelete]
        public async Task<IActionResult> DepartmentDelete(string Id)
        {
            await _departmentClient.Delete(Id);
            return RedirectToActionPermanent("DepartmentList");
        }
        #endregion

        #region Orders
        [HttpGet]
        public async Task<IActionResult> OrdersList()
        {
            var orderList = await _orderClient.GetAll();
            var detailList = await _orderDetailClient.GetAll();
            OrdersViewModel vm = new OrdersViewModel()
            {
                Orders = orderList,
                Details = detailList
            
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> OrdersAdd(OrderDTO dto)
        {
            await _orderClient.AddOrder(dto);
            return RedirectToAction("OrdersList");
        }
        [HttpPost]
        public async Task<IActionResult> OrderDetailAdd(OrderDetailDTO dto)
        {
            await _orderDetailClient.AddOrderDetail(dto);
            return RedirectToAction("OrdersList");
        }
        [HttpGet]
        public async Task<IActionResult> OrdersEdit(int id)
        {
            var order = await _orderClient.Get(id);
            return View(order);
        }
        [HttpPut]
        public async Task<IActionResult> OrdersEdit(OrderDTO dto)
        {
            await _orderClient.UpdateOrder(dto);
            return RedirectToActionPermanent("OrdersList");
        }
        [HttpDelete]
        public async Task<IActionResult> OrdersDelete(string Id)
        {
            await _orderClient.Delete(Id);
            return RedirectToActionPermanent("OrdersList");
        }
        #endregion

        #region Products

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var products = await _productClient.GetAll();
            return View(products);
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd(ProductDTO dto)
        {
            var product = new ProductDTO();
            if(product.SalesPoint >= 0.5)
            {
                await _productClient.AddProduct(dto);
            }
           
            return RedirectToAction("ProductList");
        }
        [HttpGet]
        public async Task<IActionResult> ProductEdit(int id)
        {
            var product = await _productClient.Get(id);
            return View(product);
        }
        [HttpPut]
        public async Task<IActionResult> ProductEdit(ProductDTO dto)
        {
            await _productClient.UpdateProduct(dto);
            return RedirectToActionPermanent("ProductList");
        }
        [HttpDelete]
        public async Task<IActionResult> ProductDelete(string Id)
        {
            await _productClient.Delete(Id);
            return RedirectToActionPermanent("ProductList");
        }
        #endregion

        #region RecPerson
        [HttpGet]
        public async Task<IActionResult> RecPersonList()
        {
            var recPeople = await _recPersonClient.GetAll();
            return View(recPeople);
        }
        [HttpPost]
        public async Task<IActionResult> RecPersonAdd(RecPersonDTO dto)
        {
             await _recPersonClient.AddRecPerson(dto);
            return RedirectToAction("RecPersonList");
        }
        [HttpGet]
        public async Task<IActionResult> RecPersonEdit(int id)
        {
            var recperson = await _recPersonClient.Get(id);
            return View(recperson);
        }
        [HttpPut]
        public async Task<IActionResult> RecPersonEdit(RecPersonDTO dto)
        {
            await _recPersonClient.UpdateRecPerson(dto);
            return RedirectToActionPermanent("RecPersonList");
        }
        [HttpDelete]
        public async Task<IActionResult> RecPersonDelete(string Id)
        {
            await _recPersonClient.Delete(Id);
            return RedirectToActionPermanent("RecPersonList");
        }
        #endregion

        #region Role
        [HttpGet]
        public async Task<IActionResult> RoleList()
        {
            var role = await _roleClient.GetAll();
            return View(role);
        }
        [HttpPost]
        public async Task<IActionResult> RoleAdd(RoleDTO dto)
        {
            await _roleClient.AddRole(dto);
            return RedirectToAction("RoleList");
        }
        [HttpGet]
        public async Task<IActionResult> RoleEdit(int id)
        {
            var role = await _roleClient.Get(id);
            return View(role);
        }
        [HttpPut]
        public async Task<IActionResult> RoleEdit(RoleDTO dto)
        {
             await _roleClient.UpdateRole(dto);
            return RedirectToActionPermanent("RoleList");
        }
        [HttpDelete]
        public async Task<IActionResult> RoleDelete(string Id)
        {
            await _roleClient.Delete(Id);
            return RedirectToActionPermanent("RoleList");
        }
        #endregion

        #region Supplier
        [HttpGet]
        public async Task<IActionResult> SupplierList()
        {
            var supplier = await _supplierClient.GetAll();
            return View(supplier);
        }
        [HttpPost]
        public async Task<IActionResult> SupplierAdd(SupplierDTO dto)
        {
            await _supplierClient.AddSupplier(dto);
            return RedirectToAction("SupplierList");
        }
        [HttpGet]
        public async Task<IActionResult> SupplierEdit(int id)
        {
            var supplier = await _roleClient.Get(id);
            return View(supplier);
        }
        [HttpPut]
        public async Task<IActionResult> SupplierEdit(SupplierDTO dto)
        {
             await _supplierClient.UpdateSupplier(dto);
            return RedirectToActionPermanent("SupplierList");
        }
        [HttpDelete]
        public async Task<IActionResult> SupplierDelete(string Id)
        {
            await _supplierClient.Delete(Id);
            return RedirectToActionPermanent("SupplierList");
        }
        #endregion

        #region Survey
        [HttpGet]
        public async Task<IActionResult> SurveyList()
        {
            var survey = await _surveysClient.GetAll();
            return View(survey);
        }
        [HttpPost]
        public async Task<IActionResult> SurveyAdd(SurveyDTO dto)
        {
             await _surveysClient.AddSurvey(dto);
            return RedirectToAction("SurveyList");
        }
        [HttpGet]
        public async Task<IActionResult> SurveyEdit(int id)
        {
            var survey = await _roleClient.Get(id);
            return View(survey);
        }
        [HttpPut]
        public async Task<IActionResult> SurveyEdit(SurveyDTO dto)
        {
             await _surveysClient.UpdateSurvey(dto);
            return RedirectToActionPermanent("SurveyList");
        }
        [HttpDelete]
        public async Task<IActionResult> SurveyDelete(string Id)
        {
            await _surveysClient.Delete(Id);
            return RedirectToActionPermanent("SurveyList");
        }
        #endregion
    }
}