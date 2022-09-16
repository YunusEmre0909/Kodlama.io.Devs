using Application.Services;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeRepeated(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(p=>p.Name==name);
            if (result.Items.Any()) throw new BusinessException("Programming Language Exists");
        }
        public async Task ProgrammingLanguageIdShouldBeExist(int id)
        {
            var result = await _programmingLanguageRepository.GetListAsync(p=>p.Id==id);
            if (!result.Items.Any()) throw new BusinessException("Programming Language Not Found.");
        }
        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested Programming Language does not exists.");
        }
    }
}
