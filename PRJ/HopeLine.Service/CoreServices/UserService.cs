﻿using HopeLine.DataAccess.Entities;
using HopeLine.DataAccess.Interfaces;
using HopeLine.Service.Interfaces;
using HopeLine.Service.Models;
using System.Collections.Generic;
using System.Linq;

namespace HopeLine.Service.CoreServices
{
    public class UserService : IUserService
    {
        private readonly IRepository<HopeLineUser> _repository;

        public UserService(IRepository<HopeLineUser> repository)
        {
            _repository = repository;
        }
        public IEnumerable<UserModel> GetAllUsers()
        {
            try
            {
                return _repository.GetAll().Select(u =>

                     new UserModel
                     {
                         Id = u.Id,
                         FirstName = (u.Profile != null) ? u.Profile.FirstName : "",
                         LastName = (u.Profile != null) ? u.Profile.LastName : "",
                         Languages = new List<string>(),
                         AccountType = u.AccountType.ToString(),
                         Username = u.UserName,
                         Email = u.Email
                     });

            }
            catch (System.Exception ex)
            {

                throw new System.Exception("Unable to process Service :", ex);
            }
        }

        public IEnumerable<UserModel> GetAllUsersByAccountType(HopeLineUser.Account accountType)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ActivityModel> GetMentorActivities(string mentorId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ConversationModel> GetMentorConversations(string mentorId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ScheduleModel> GetMentorSchedules(string mentorId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<SpecializationModel> GetMentorSpecializations(string mentorId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ActivityModel> GetUserActivities(string userId)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ConversationModel> GetUserConversations(string username)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateUserLogin(UserModel model, string password)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateUserProfile(UserModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}
