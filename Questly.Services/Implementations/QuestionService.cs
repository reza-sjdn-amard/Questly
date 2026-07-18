using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Questly.Data.Context;
using Questly.Domain.Entities;
using Questly.Services.DTOs.Question;
using Questly.Services.DTOs.Survey;
using Questly.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questly.Services.Implementations
{
    public class QuestionService(QuestlyDbContext _context, IMapper _mapper) : IQuestionService
    {
        public async Task<int> CreateQuestionAsync(CreateQuestionDto questionDto)
        {
            var question = _mapper.Map<Question>(questionDto);
            var maxOrder = await _context.Questions
                .Where(q => q.SurveyId == questionDto.SurveyId)
                .MaxAsync(q => (int?)q.DisplayOrder) ?? 0;
            question.DisplayOrder = maxOrder + 1;
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question.Id;
        }

        public async Task<GetQuestionDto?> GetQuestionByIdAsync(int id)
        {
            var question = await _context.Questions.Where(q => q.Id == id)
                .Include(q => q.Options)
                .FirstOrDefaultAsync();
            return _mapper.Map<GetQuestionDto>(question);
        }

        public async Task<bool> UpdateQuestionAsync(UpdateQuestionDto questionDto)
        {
            var question = await _context.Questions
                .Include(q => q.Options)
                .FirstOrDefaultAsync(q => q.Id == questionDto.Id);
            var mappedQuestion = _mapper.Map(questionDto, question);
            _context.Questions.Update(mappedQuestion);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null) return false;
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task ReorderQuestionsAsync(int surveyId, List<int> questionIds)
        {
            var questions = await _context.Questions
                .Where(q => q.SurveyId == surveyId)
                .ToListAsync();

            for (int i = 0; i < questionIds.Count; i++)
            {
                var question = questions.First(q => q.Id == questionIds[i]);
                question.DisplayOrder = i + 1;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<SkipLogicDto?> GetSkipLogicAsync(int questionId)
        {
            var question = await _context.Questions
                .Include(q => q.Options.OrderBy(o => o.DisplayOrder))
                .FirstOrDefaultAsync(q => q.Id == questionId);

            if (question == null)
                return null;

            var dto = new SkipLogicDto
            {
                QuestionId = question.Id,
                QuestionText = question.Text,
                SurveyId = question.SurveyId
            };

            dto.Options = question.Options.Select(o => new SkipLogicOptionDto
            {
                OptionId = o.Id,
                OptionText = o.Text,
                NextQuestionId = o.NextQuestionId
            }).ToList();

            dto.Questions = await _context.Questions
                .Where(q => q.SurveyId == question.SurveyId && q.Id != question.Id)
                .OrderBy(q => q.DisplayOrder)
                .Select(q => new QuestionLookupDto
                {
                    Id = q.Id,
                    Text = q.Text
                })
                .ToListAsync();

            return dto;
        }

        public async Task SaveSkipLogicAsync(SkipLogicDto dto)
        {
            var optionIds = dto.Options.Select(o => o.OptionId).ToList();

            var options = await _context.QuestionOptions
                .Where(o => optionIds.Contains(o.Id))
                .ToListAsync();

            foreach (var option in options)
            {
                var dtoOption = dto.Options.First(o => o.OptionId == option.Id);
                option.NextQuestionId = dtoOption.NextQuestionId;
            }

            await _context.SaveChangesAsync();
        }

        public async Task<MatrixQuestionDto?> GetMatrixQuestionAsync(int questionId)
        {
            var question = await _context.Questions
                .Include(q => q.MatrixRows.OrderBy(r => r.DisplayOrder))
                .Include(q => q.Options.OrderBy(c => c.DisplayOrder))
                .FirstOrDefaultAsync(q => q.Id == questionId);

            if (question == null)
                return null;

            return new MatrixQuestionDto
            {
                QuestionId = question.Id,
                QuestionText = question.Text,
                SurveyId = question.SurveyId,
                Rows = question.MatrixRows.Select(r => new MatrixRowDto
                {
                    Id = r.Id,
                    Text = r.Text
                }).ToList(),
                Options = question.Options.Select(c => new GetQuestionOptionDto
                {
                    Id = c.Id,
                    Text = c.Text
                }).ToList()
            };
        }

        public async Task SaveMatrixQuestionAsync(MatrixQuestionDto dto)
        {
            var question = await _context.Questions
                .Include(q => q.MatrixRows)
                .Include(q => q.Options)
                .FirstAsync(q => q.Id == dto.QuestionId);

            question.MatrixRows.Clear();
            question.Options.Clear();

            int order = 1;

            foreach (var row in dto.Rows)
            {
                question.MatrixRows.Add(new MatrixRow
                {
                    Text = row.Text,
                    DisplayOrder = order++
                });
            }

            order = 1;

            foreach (var option in dto.Options)
            {
                question.Options.Add(new QuestionOption
                {
                    Text = option.Text,
                    DisplayOrder = order++
                });
            }

            await _context.SaveChangesAsync();
        }
    }
}
