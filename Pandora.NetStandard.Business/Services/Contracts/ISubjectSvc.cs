﻿using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Utils;
using Pandora.NetStandard.Model.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services.Contracts
{
    public interface ISubjectSvc : IBasicCrudOperations<SubjectDto>
    {
        Task<BLSingleResponse<bool>> TryEnrollAsync(int subjectId, int studentId);
        Task<BLSingleResponse<bool>> EnrollStudentAsync(int subjectId, int userId);
        Task<BLSingleResponse<bool>> SaveExamResultAsync(IList<ExamDto> examDtos);
        Task<BLListResponse<SubjectDto>> GetByTeacherIdAsync(int teacherId);
        
    }
}
