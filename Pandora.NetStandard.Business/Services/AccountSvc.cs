﻿using Microsoft.AspNetCore.Identity;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Identity;
using System;
using System.Threading.Tasks;

namespace Pandora.NetStandard.Business.Services
{
    public class AccountSvc : BaseService, IAccountSvc
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountSvc(IApplicationUow applicationUow,
            SignInManager<ApplicationUser> signInManager) : base(applicationUow)
        {
            _signInManager = signInManager;
        }

        public Task<BLSingleResponse<ApplicationRole>> CreateRoleAsync(ApplicationRole pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<ApplicationUser>> CreateUserAsync(ApplicationUser pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<bool>> DeleteRoleAsync(ApplicationRole pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<bool>> DeleteUserAsync(ApplicationUser pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLListResponse<ApplicationRole>> GetAllRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BLListResponse<ApplicationUser>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<ApplicationRole>> GetRoleByIdAsync(string pId)
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<ApplicationRole>> GetRoleByNameAsync(string pRolName)
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<ApplicationUser>> GetUserByIdAsync(string pId)
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<ApplicationUser>> GetUserByNameAsync(string pUserName)
        {
            throw new NotImplementedException();
        }

        

        public Task<BLSingleResponse<bool>> UpdateRoleAsync(ApplicationRole pDto)
        {
            throw new NotImplementedException();
        }

        public Task<BLSingleResponse<bool>> UpdateUserAsync(ApplicationUser pDto)
        {
            throw new NotImplementedException();
        }
    }
}