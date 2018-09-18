﻿using HopeLine.Service.Models;
using System.Collections.Generic;

namespace HopeLine.Service.Interfaces
{
    public interface IUserService
    {

        IEnumerable<UserModel> GetAllUsers();
        IEnumerable<UserModel> GetAllUsersByAccountType(string userType);


        //Can be refactored
        #region Users and Mentors

        IEnumerable<ActivityModel> GetUserActivities(string userId);
        IEnumerable<ActivityModel> GetMentorActivities(string mentorId);
        IEnumerable<ConversationModel> GetUserConversations(string username);
        IEnumerable<ConversationModel> GetMentorConversations(string mentorId);
        IEnumerable<ScheduleModel> GetMentorSchedules(string mentorId);
        IEnumerable<SpecializationModel> GetMentorSpecializations(string mentorId);
        #endregion

        bool UpdateUserProfile(UserModel model);


    }
}
