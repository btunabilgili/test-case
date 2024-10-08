using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RiskAnalysis.Application;
using RiskAnalysis.Common;
using RiskAnalysis.WebUI.Models;

namespace RiskAnalysis.WebUI.Controllers
{
    public class PartnerController(IPartnerService partnerService, IMapper mapper) : BaseController
    {
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await partnerService.GetPartnersAsync(cancellationToken);

            if (result.IsError)
                TempData[Constants.ErrorMessage] = result.FirstError.Description;

            return View(mapper.Map<List<PartnerModel>>(result.Value));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PartnerCreateModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(model);

            var partnerDto = mapper.Map<PartnerDto>(model);

            var result = await partnerService.CreatePartnerAsync(partnerDto, cancellationToken);

            if (result.IsError)
            {
                ModelState.AddModelError(string.Empty, result.FirstError.Description);
                return View(model);
            }

            TempData[Constants.SuccessMessage] = Constants.CreatedSuccessfully;

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id, CancellationToken cancellationToken)
        {
            var response = await partnerService.GetPartnerByIdAsync(id, cancellationToken);

            if (response.IsError)
            {
                ModelState.AddModelError(string.Empty, response.FirstError.Description);
                return View("Error");
            }

            var model = mapper.Map<PartnerCreateModel>(response.Value);
            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, PartnerCreateModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(model);

            var partnerDto = mapper.Map<PartnerDto>(model);

            var result = await partnerService.UpdatePartnerAsync(id, partnerDto, cancellationToken);

            if (result.IsError)
            {
                ModelState.AddModelError(string.Empty, result.FirstError.Description);
                return View(model);
            }

            TempData[Constants.SuccessMessage] = Constants.UpdatedSuccessfully;

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var result = await partnerService.DeletePartnerAsync(id, cancellationToken);

            if (result.IsError)
                TempData[Constants.ErrorMessage] = result.FirstError.Description;
            else
                TempData[Constants.SuccessMessage] = Constants.DeletedSuccessfully;

            return RedirectToAction(nameof(Index));
        }
    }
}
