
using IsKapisi.Core.ViewModels;
using IsKapisi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsKapisi.Business.Abstract
{
    public interface IJobService
    {   
        void Create(JobViewModel model);
        List<JobViewModel> GetAll(bool? isHome= null, bool? isActive=null , bool? isDelete = null);
        JobViewModel GetById(int id);
       
        void Update(JobViewModel model);
        void HardDelete(JobViewModel model);
        void SoftDelete(JobViewModel model);
        void HardDelete(int id);
        void SoftDelete(int id);
    }
}
