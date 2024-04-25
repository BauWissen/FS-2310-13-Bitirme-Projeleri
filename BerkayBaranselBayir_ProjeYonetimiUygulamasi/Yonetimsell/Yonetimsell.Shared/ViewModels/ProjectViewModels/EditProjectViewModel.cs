﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Yonetimsell.Shared.ComplexTypes;
using Yonetimsell.Shared.ViewModels.IdentityViewModels;
using Yonetimsell.Shared.ViewModels.PTaskViewModels;
using Yonetimsell.Shared.ViewModels.SubscriptionViewModels;
using Yonetimsell.Shared.ViewModels.TeamMemberViewModels;

namespace Yonetimsell.Shared.ViewModels.ProjectViewModels
{
    public class EditProjectViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Proje Adı")]
        public string Name { get; set; }
        [Required]
        public string UserId { get; set; }
        public UserViewModel User { get; set; }
        [Required]
        [DisplayName("Proje Açıklaması")]
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [DisplayName("Bitiş tarihi")]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        [Required]
        [DisplayName("Bütçe")]
        [DataType(DataType.Currency)]
        public decimal Budget { get; set; }
        [Required]
        [DisplayName("Öncelik")]
        public Priority Priority { get; set; }
        [Required]
        [DisplayName("Durum")]
        public Status Status { get; set; }
        public bool IsDeleted { get; set; }
        public List<PTaskViewModel> PTasks { get; set; }
        public List<TeamMemberViewModel> TeamMembers { get; set; }
        public List<SubscriptionViewModel> Subscriptions { get; set; }
    }
}