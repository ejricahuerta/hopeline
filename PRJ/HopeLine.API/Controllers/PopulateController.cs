using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HopeLine.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HopeLine.API.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PopulateController : ControllerBase
    {
        private readonly UserManager<HopeLineUser> _userManager;

        public PopulateController(UserManager<HopeLineUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> CreateAdmins()
        {
            if (_userManager.Users.Where(u => u.AccountType == Account.Admin).Count() == 0)
            {
                //Populate admin
                var prf = new Profile
                {
                    FirstName = "Admin",
                    LastName = "User"
                };
                var admin = new AdminAccount
                {
                    Profile = prf,
                    Email = "admin@hopeline.ca",
                    UserName = "admin@hopeline.ca",
                    AccountType = Account.Admin
                };
                var result = await _userManager.CreateAsync(admin, "Passw0rd!");

                if (result.Succeeded)
                {
                    var newuser = await _userManager.FindByEmailAsync("admin@hopeline.ca");
                    var claimres = await _userManager.AddClaimAsync(newuser, new Claim("Account", "Admin"));
                }
                return Ok("Newly Added!");
            }
            return Ok("Already Polulated!");
        }
        public async Task<IActionResult> CreateMentors()
        {
            var mentors = new List<string>
            {
                "tester1@gmail.com",  "tester2@gmail.com",  "tester3@gmail.com",
            };

            if (_userManager.Users.Where(u => u.AccountType == Account.Mentor).Count() == 0)
            {
                foreach (var m in mentors)
                {
                    //Populate mentors
                    var prf = new Profile
                    {
                        FirstName = "tester",
                        LastName = "tester"
                    };
                    var mentor = new MentorAccount
                    {
                        Profile = prf,
                        Email = m,
                        UserName = m,
                    };
                    var result = await _userManager.CreateAsync(mentor, "Passw0rd!");
                    if (result.Succeeded)
                    {
                        var newuser = await _userManager.FindByEmailAsync(m);
                        var claimres = await _userManager.AddClaimAsync(newuser, new Claim("Account", "Mentor"));
                    }
                }

                return Ok("Newly Added!");
            }
            return Ok("Already Polulated!");
        }

    }
}