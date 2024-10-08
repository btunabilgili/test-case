using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiskAnalysis.Application;
using RiskAnalysis.Common;
using RiskAnalysis.Common.Enums;
using RiskAnalysis.WebUI.Helpers;
using RiskAnalysis.WebUI.Models;

namespace RiskAnalysis.WebUI.Controllers
{
    public class AgreementController(IAgreementService agreementService, IPartnerService partnerService, IMapper mapper) : BaseController
    {
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var result = await agreementService.GetAgreementsAsync(cancellationToken);

            if (result.IsError)
                TempData[Constants.ErrorMessage] = result.FirstError.Description;

            return View(mapper.Map<List<AgreementModel>>(result.Value));
        }

        public async Task<IActionResult> Create(CancellationToken cancellationToken)
        {
            var model = new AgreementCreateModel
            {
                Statuses = EnumHelpers.ToSelectList<AgreementStatus>()
            };

            var result = await partnerService.GetPartnersAsync(cancellationToken);

            if (result.IsError)
                TempData[Constants.ErrorMessage] = result.FirstError.Description;
            else
            {
                var selectList = new List<SelectListItem>
                {
                    new()
                    {
                        Text = "Please Select",
                        Value = string.Empty
                    }
                };

                var partners = result.Value.Select(x => new SelectListItem
                {
                    Text = x.PartnerName,
                    Value = x.Id.ToString()
                }).ToList();

                selectList.AddRange(partners);

                model.Partners = selectList;
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgreementCreateModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(model);

            var agreementDto = mapper.Map<AgreementDto>(model);

            var result = await agreementService.CreateAgreementAsync(agreementDto, cancellationToken);

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
            var response = await agreementService.GetAgreementByIdAsync(id, cancellationToken);

            if (response.IsError)
            {
                ModelState.AddModelError(string.Empty, response.FirstError.Description);
                return View("Error");
            }

            var model = mapper.Map<AgreementCreateModel>(response.Value);

            var result = await partnerService.GetPartnersAsync(cancellationToken);

            if (result.IsError)
                TempData[Constants.ErrorMessage] = result.FirstError.Description;
            else
            {
                var selectList = new List<SelectListItem>
                {
                    new()
                    {
                        Text = "Please Select",
                        Value = string.Empty
                    }
                };

                var partners = result.Value.Select(x => new SelectListItem
                {
                    Text = x.PartnerName,
                    Value = x.Id.ToString()
                }).ToList();

                selectList.AddRange(partners);

                model.Partners = selectList;
            }

            model.Statuses = EnumHelpers.ToSelectList<AgreementStatus>();

            return View("Create", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Guid id, AgreementCreateModel model, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(model);

            var agreementDto = mapper.Map<AgreementDto>(model);

            var result = await agreementService.UpdateAgreementAsync(id, agreementDto, cancellationToken);

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
            var result = await agreementService.DeleteAgreementAsync(id, cancellationToken);

            if (result.IsError)
                TempData[Constants.ErrorMessage] = result.FirstError.Description;
            else
                TempData[Constants.SuccessMessage] = Constants.DeletedSuccessfully;

            return RedirectToAction(nameof(Index));
        }
    }
}
