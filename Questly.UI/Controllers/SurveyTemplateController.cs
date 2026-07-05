using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Questly.Services.Interfaces;
using Questly.UI.Models.Survey;
using System.Security.Claims;

namespace Questly.UI.Controllers
{
    public class SurveyTemplateController(ISurveyTemplateService _surveyTemplateService,
                                          IMapper _mapper) : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Templates()
        {
            var templates = await _surveyTemplateService.GetTemplatesAsync();
            var model = _mapper.Map<List<SurveyTemplateViewModel>>(templates);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFromTemplate(int templateId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var surveyId = await _surveyTemplateService.CreateSurveyFromTemplateAsync(templateId, userId);

            return RedirectToAction(nameof(SurveyController.Details), "Survey", new { id = surveyId });
        }
    }
}
