﻿using AutoMapper;
using Pandora.NetStdLibrary.Base.Mapper;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;

namespace Pandora.NetStandard.Business.Mappers
{
    public class GradeToDtoMapper : GenericMapper<Grade, GradeDto>
    {
        protected override IMapper CreateMapConfiguration()
        {
            return DefaultMapConfiguration();
        }
    }
}
