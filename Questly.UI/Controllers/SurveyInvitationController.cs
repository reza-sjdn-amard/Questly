using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Questly.Services.DTOs.Survey;
using Questly.Services.Interfaces;
using Questly.UI.Models.Survey;

namespace Questly.UI.Controllers
{
    public class SurveyInvitationController(ISurveyInvitationService _surveyInvitationService,
                                            IMapper _mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Invite(int id)
        {
            var dto = await _surveyInvitationService.GetInvitationAsync(id);

            if (dto == null)
                return NotFound();

            var model = _mapper.Map<SendInvitationViewModel>(dto);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Invite(SendInvitationViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var dto = _mapper.Map<SendInvitationDto>(model);

            await _surveyInvitationService.SendInvitationsAsync(dto);

            TempData["Success"] = "Invitations sent successfully.";

            return RedirectToAction("Details", "Survey",
                new { id = model.SurveyId });
        }
    }
}
