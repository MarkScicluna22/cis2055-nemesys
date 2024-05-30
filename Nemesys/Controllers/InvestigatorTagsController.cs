
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nemesys.Data;
using Nemesys.Models.Domain;
using Nemesys.Models.ViewModels;
using Nemesys.Repositories;


namespace Nemesys.Controllers
{

    [Authorize(Roles = "Investigator")]
    public class InvestigatorTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        public InvestigatorTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            } 
            //Mapping AddTagRequest to Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };

           await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }


        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            // use dbContext to read the tags
            var tags = await tagRepository.GetAllAsync();

            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var tag = await tagRepository.GetAsync(id);

            if(tag != null) 
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name= tag.Name,
                    DisplayName= tag.DisplayName
                };

                return View(editTagRequest);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id=editTagRequest.Id,
                Name=editTagRequest.Name,
                DisplayName=editTagRequest.DisplayName
            };

            var updatedTag = await tagRepository.UpdateAsync(tag);

            if(updatedTag != null)
            {
                //Show success notif
            }
            else
            {
                //show error notif
            }

            //Show error notif
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if(deletedTag != null)
            {
                //show success notif
                return RedirectToAction("List");
            }


            //Show an Error notif
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }
    }
}
