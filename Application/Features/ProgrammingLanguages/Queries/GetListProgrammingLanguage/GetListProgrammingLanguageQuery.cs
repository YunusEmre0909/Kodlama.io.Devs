using Application.Features.ProgrammingLanguages.Models;
using Application.Services;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage
{
    public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
        {
            private readonly IMapper _mappper;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

            public GetListProgrammingLanguageQueryHandler(IMapper mappper, IProgrammingLanguageRepository programmingLanguageRepository)
            {
                _mappper = mappper;
                _programmingLanguageRepository = programmingLanguageRepository;
            }

            public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> programmingLanguages = await _programmingLanguageRepository.GetListAsync
                                                    (index: request.PageRequest.Page,size:request.PageRequest.PageSize);

                ProgrammingLanguageListModel mappedProgrammingLanguageListModel = _mappper.Map
                                                    <ProgrammingLanguageListModel>(programmingLanguages);

                return mappedProgrammingLanguageListModel;
            }
        }
    }
}
