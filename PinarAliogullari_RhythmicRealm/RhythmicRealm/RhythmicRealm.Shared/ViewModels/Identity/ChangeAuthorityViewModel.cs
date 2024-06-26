﻿namespace RhythmicRealm.Shared.ViewModels.Identity
{
	public class ChangeAuthorityViewModel
    {
        public ChangeAuthorityViewModel()
        {
            AssignRole = new List<AssignRoleViewModel>();
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public List<AssignRoleViewModel> AssignRole { get; set; }
    }
}
