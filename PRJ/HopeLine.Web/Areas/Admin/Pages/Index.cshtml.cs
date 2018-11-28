using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HopeLine.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HopeLine.Web.ViewModels;
using System.ComponentModel.DataAnnotations;
using HopeLine.DataAccess.Entities;
using HopeLine.Web.Areas.Identity.Pages.Account.Manage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using static HopeLine.Web.Areas.Identity.Pages.Account.ExternalLoginModel;



namespace HopeLine.Web.Areas.Admin.Pages
{
    public class Index : PageModel
    {
        private readonly IUserService _userService;
        private readonly ICommunication _communication;


        /*For Change Password*/
        private readonly UserManager<HopeLineUser> _userManager;
        private readonly SignInManager<HopeLineUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public Index(IUserService commonResources, ICommunication communication)
        {
            _userService = commonResources;
            _communication = communication;
        }

        [BindProperty]
       public InputModel Input { get; set; }

        [BindProperty]
        public UserViewModel CurrentMentor { get; set; }

        [BindProperty]
        public List<ConversationViewModel> Conversations { get; set; }

        [BindProperty]
        public string QueryString { get; set; }

        [BindProperty]
        public List<UserViewModel> Users { get; set; }

        [BindProperty]
        public List<UserViewModel> Mentors { get; set; }
        [BindProperty]
        public List<SpecializationViewModel> Specializations { get; set; }
      


        public IActionResult OnPostSearch()
        
        {

            Users = _userService.GetAllUsers().Where(u => u.FirstName.Contains(QueryString) || u.LastName.Contains(QueryString) || u.Email.Contains(QueryString)).Select(u=> new UserViewModel {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName,
                AccountType = u.AccountType.ToString()

            }).ToList();

            return Page();
            
        }

        public async Task<IActionResult> OnGetAsync(string pin = null, string user = null)
        {
            var url = Url.Page("~/Index");

            Users = _userService.GetAllUsers().Select(c => new UserViewModel
            {
                Id = c.Id,
                Email = c.Email,
                FirstName = c.FirstName,
                LastName = c.LastName,
                AccountType = c.AccountType.ToString()

            }).ToList();


            //HopeLineUser CurrentUser = await _userManager.GetUserAsync(User);
            /*
                    CurrentMentor = new UserViewModel
                    {
                        Id = CurrentUser.Id,
                        Username = CurrentUser.UserName,
                        Email = CurrentUser.Email,
                        AccountType = CurrentUser.AccountType.ToString(),
                        Phone = CurrentUser.PhoneNumber
                    };
                    */
            /* Profile Page Logic START */
            Mentors = _userService.GetAllUsersByAccountType("Mentor").Select(m => new UserViewModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Username = m.Username,
                Email = m.Email,
                AccountType = m.AccountType,
                Phone = m.Phone

            }).ToList();

            //Specializations = _userService.GetMentorSpecializations(CurrentMentor.Id).Select(s => new SpecializationViewModel
            //{
            //    Name = s.Name,
            //    Description = s.Description
            //}).ToList();

            /* Profile Logic END */

            /* Change Password START */
            //var user_ = await _userManager.GetUserAsync(User);
            //if (user_ == null)
            //{
            //    return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            //}

            //var hasPassword = await _userManager.HasPasswordAsync(user_);
            //if (!hasPassword)
            //{
            //    return RedirectToPage("./SetPassword");
            //}
            /* Change Password END */

            /*Conversation Logic START*/
            //Conversations = _communication.GetConversationsByMentorId(CurrentMentor.Email).Select(c => new ConversationViewModel
            //{
            //    Id = c.Id,
            //    PIN = c.PIN,
            //    UserId = c.UserId,
            //    //MentorId = c.MentorId,
            //    Minutes = c.Minutes,
            //    DateOfConversation = c.DateOfConversation.ToString()
            //}).ToList();
            //System.Console.WriteLine("Convo count = " + Conversations.Count());
            //foreach (var c in Conversations)
            //{
            //    System.Console.WriteLine("User: " + c.UserId);
            //    System.Console.WriteLine("mentor: " + c.MentorId);
            //}
            /*Conversation Logic END */
            return Page();
        }




        //public async Task<IActionResult> OnPostJoinListAsync() {




        //}




    }
}