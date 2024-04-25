using IsKapisi.Business.Abstract;
using IsKapisi.Core.ViewModels;
using IsKapisi.Data.Abstract;
using IsKapisi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsKapisi.Business.Concrete
{
    public class JobManager : IJobService

    {

        private IJobRepository _jobRepository;

        public JobManager(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }

        public void Create(JobViewModel model)
        {
            var job = new Job
            {
                Name = model.Name,
               
                Properties = model.Properties,
                Url = model.Url,
                ImageUrl = model.ImageUrl,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsActive = true,
                IsHome = model.IsHome


            };
            _jobRepository.Create(job);
        }

        public List<JobViewModel> GetAll(bool? isHome = null, bool? isActive = null, bool? isDelete = null)
        {
            List<Job> jobs;
            if (isHome == null)
            {
                if (isDelete == null)
                {
                    jobs = _jobRepository.GetAll();
                }
                else
                {
                    jobs = _jobRepository.GetDeletedJobs(isDelete);
                }


            }
            else
            {
                jobs = _jobRepository.GetHomePageProducts(isHome);
            }
            List<JobViewModel> jobViewModels = jobs
                .Select(p => new JobViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Url = p.Url,
                    ImageUrl = p.ImageUrl,
                    Properties = p.Properties
                }).ToList();
            return jobViewModels;


        }

        public JobViewModel GetById(int id)
        {
            Job job = _jobRepository.GetById(id);
            JobViewModel jobViewModel = new JobViewModel
            {
                Id = job.Id,
                Name = job.Name,           
                Url = job.Url,
                ImageUrl = job.ImageUrl,
                Properties = job.Properties
            };
            return jobViewModel;
        }

        public void HardDelete(int id)
        {
            Job deletedJob = _jobRepository.GetById(id);
            _jobRepository.HardDelete(deletedJob);
        }

        public void HardDelete(JobViewModel model)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(JobViewModel model)
        {
            throw new NotImplementedException();
        }

        public void SoftDelete(int id)
        {
            Job deletedProduct = _jobRepository.GetById(id);
            deletedProduct.IsDelete = !deletedProduct.IsDelete;
            _jobRepository.SoftDelete(deletedProduct);
        }

        public void Update(JobViewModel model)
        {
           Job editedJob = _jobRepository.GetById(model.Id);
            editedJob.Name = model.Name;
       
            editedJob.Url = model.Url;
            editedJob.ImageUrl = model.ImageUrl;
            editedJob.Properties = model.Properties;
            editedJob.IsHome = model.IsHome;
            _jobRepository.Update(editedJob);
        }
    }
}
