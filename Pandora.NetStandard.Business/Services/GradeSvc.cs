﻿using Microsoft.Extensions.Logging;
using Pandora.NetStandard.Business.Mappers;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Model.Dtos;
using Pandora.NetStandard.Model.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class GradeSvc : BaseService<Grade, GradeDto>, IGradeSvc
    {

        public GradeSvc(IApplicationUow applicationUow, ILogger<GradeSvc> logger) : base(applicationUow, logger, new GradeToDtoMapper())
        {

        }

        public async Task<BLSingleResponse<GradeDto>> CreateAsync(GradeDto pDto)
        {
            var response = new BLSingleResponse<GradeDto>();

            try
            {
                var entity = await _uow.GetRepo<Grade>().InsertAsync(pDto);
                if (!await _uow.CommitAsync())
                {
                    HandleSVCException(response, "New Grade creation failed.");
                }
                response.Data = _mapper.MapEntity(entity);

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> DeleteAsync(GradeDto pDto)
        {
            var response = new BLSingleResponse<bool>();

            try
            {
                //var entity = await _uow.GetRepo<Grade>().GetByIdAsync(pDto.Id);
                await _uow.GetRepo<Grade>().DeleteAsync(pDto);
                if (await _uow.CommitAsync())
                {
                    response.Data = true;
                }
                else
                {
                    HandleSVCException(response, "This grade was not deleted.");
                }
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLListResponse<GradeDto>> GetAllAsync()
        {
            var response = new BLListResponse<GradeDto>();

            try
            {
                var entity = await _uow.GetRepo<Grade>().AllAsync(null, o => o.OrderBy(g => g.Id), null);
                response.Data = _mapper.MapEntity(entity);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<GradeDto>> GetByIdAsync(int pId)
        {
            var response = new BLSingleResponse<GradeDto>();

            try
            {
                var entity = await _uow.GetRepo<Grade>().GetByIdAsync(pId);
                response.Data = _mapper.MapEntity(entity);
            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }

        public async Task<BLSingleResponse<bool>> UpdateAsync(GradeDto pDto)
        {
            var response = new BLSingleResponse<bool>();

            try
            {

            }
            catch (Exception ex)
            {
                HandleSVCException(response, ex);
            }

            return response;
        }
    }
}