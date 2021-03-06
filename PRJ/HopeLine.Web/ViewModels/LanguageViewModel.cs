﻿using HopeLine.DataAccess.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HopeLine.Web.ViewModels
{

    /// <summary>
    /// this class with hold info for available speaking languages
    /// </summary>
    public class LanguageViewModel : BaseEntity
    {
        public LanguageViewModel()
        {
            ProfileLanguages = new List<ProfileLanguageViewModel>();
        }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        [Required]
        [StringLength(40)]
        public string CountryOrigin { get; set; }

        public ICollection<ProfileLanguageViewModel> ProfileLanguages { get; set; }
    }
}
