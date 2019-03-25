﻿using Microsoft.AspNetCore.Identity;
using Pandora.NetStandard.BusinessData.Dtos;
using Pandora.NetStandard.BusinessData.Services.Contracts;
using Pandora.NetStandard.Core.Bases;
using Pandora.NetStandard.Core.Interfaces;
using Pandora.NetStandard.Core.Interfaces.Identity;
using Pandora.NetStandard.Core.Security.Identity;
using System.Threading.Tasks;

namespace Pandora.NetStandard.BusinessData.Services
{
    public class AuthSvc : BaseService, IAuthSvc
    {
        private readonly ISignInManagerFacade<ApplicationUser> _signInManager;

        public AuthSvc(IApplicationUow applicationUow, ISignInManagerFacade<ApplicationUser> signInManager) : base(applicationUow)
        {
            _signInManager = signInManager;
        }

        public async Task<BLSingleResponse<TokenRespDto>> LoginAsync(LoginDto model)
        {
            var response = new BLSingleResponse<TokenRespDto>();

            var signInResul = await _signInManager.SignInAsync(model.Username, model.Password, model.RememberMe);

            if (signInResul == SignInResult.Failed)
            {
                HandleSVCException(response, "Username or Password is invalid.");
            }

            if (signInResul == SignInResult.TwoFactorRequired)
            {
                HandleSVCException(response, "User did not confirm email.");
            }

            if (signInResul == SignInResult.LockedOut)
            {
                HandleSVCException(response, "This User is currently locked out.");
            }

            return response;
        }

        public async Task<BLSingleResponse<TokenRespDto>> RegisterAsync(RegisterDto model)
        {
            var response = new BLSingleResponse<TokenRespDto>();

            var role = new ApplicationRole("User", "El mas user");
            var user = new ApplicationUser(model.Username, model.Email, model.Firstname, model.Lastname);

            var signInResul = await _signInManager.SignUpAsync(user, model.Password);

            if (response.HasErrors)
            {
                HandleSVCException(response, "There was an error, user was not created");
            }

            return response;
        }
    }
}