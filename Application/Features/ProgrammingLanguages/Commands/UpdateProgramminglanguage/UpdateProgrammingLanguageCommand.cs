using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgramminglanguage
{
    public class UpdateProgrammingLanguageCommand : IRequest<UpdatedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string  Name { get; set; }

        public class UpdateProgrammingLanguageCommandHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public UpdateProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<UpdatedProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {

                await _programmingLanguageBusinessRules.ProgrammingLanguageIdShouldBeExist(request.Id);

                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p=>p.Id==request.Id);
                _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

                var mappedProgramminglaguage = _mapper.Map(request,programmingLanguage);
                ProgrammingLanguage updateProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedProgramminglaguage);
                UpdatedProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdatedProgrammingLanguageDto>(updateProgrammingLanguage);
                return updatedProgrammingLanguageDto;
            }
        }
    }
}
