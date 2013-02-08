using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcExamples.FakeDatabase;
using MvcExamples.ViewModels;

namespace MvcExamples.Controllers
{
    public class AjaxPartialController : Controller
    {
        public ActionResult Index()
        {
            return View(GetViewModel());
        }

        [HttpPost]
        public ActionResult Update(ContactListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                MvcApplication.MainContactDb.Update(MapViewModel(viewModel));

                if (Request.IsAjaxRequest())
                {
                    ModelState.Clear();

                    return PartialView("_Contacts", GetViewModel());
                }
                
                return RedirectToRoute("AjaxPartial");
            }

            return PartialView("_Contacts", viewModel);
        }

        private IEnumerable<Contact> MapViewModel(ContactListViewModel viewModel)
        {
            return viewModel.Contacts.Where(x => !x.IsEmpty && !x.DeleteMe).Select(x => new Contact
                {
                    Email = x.Email,
                    Id = x.Id,
                    Name = x.Name
                }).ToList();
        }

        private ContactListViewModel GetViewModel()
        {
            var contacts = MvcApplication.MainContactDb.Contacts.Select(x => new ContactViewModel()
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name
                }).ToList();

            contacts.AddRange(Enumerable.Range(1, 10 - contacts.Count).Select(x => new ContactViewModel()));

            return new ContactListViewModel
                {
                    Contacts = contacts
                };
        }
    }

    

}
