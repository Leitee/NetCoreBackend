﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pandora.NetStandard.Business.Services.Contracts;
using Pandora.NetStandard.Model.Dtos;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Pandora.NetCore.ApiHost.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountSvc _accountSvc;

        public AccountController(IAccountSvc accountSvc)
        {
            _accountSvc = accountSvc;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountSvc.LoginAsync(model);
                if (!response.HasError && response.Data.HasToken)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }
                ErrorMessage = response.HasError ? string.Concat(response.Errors) : response.Data.MessageResponse;
            }

            ModelState.AddModelError(string.Empty, ErrorMessage);
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(int userId, string token)
        {
            if (userId == 0 || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var response = await _accountSvc.GetUserByIdAsync(userId);
            if (response == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            var result = await _accountSvc.ConfirmEmailAsync(response.Data, token);
            if (result.HasError)
            {
                throw new InvalidOperationException($"Error confirming email for user with ID '{userId}':");
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _accountSvc.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}