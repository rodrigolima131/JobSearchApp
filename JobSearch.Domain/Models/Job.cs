using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JobSearch.Domain.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Company", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        [Required(ErrorMessageResourceType = typeof(JobSearch.Domain.Utility.Language.Message), ErrorMessageResourceName = "MSG_E001")]
        public string Company { get; set; }

        [Display(Name = "JobTitle", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        [Required(ErrorMessageResourceType = typeof(JobSearch.Domain.Utility.Language.Message), ErrorMessageResourceName = "MSG_E001")]
        public string JobTitle { get; set; }

        [Display(Name = "CityState", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        [Required(ErrorMessageResourceType = typeof(JobSearch.Domain.Utility.Language.Message), ErrorMessageResourceName = "MSG_E001")]
        public string  CityState { get; set; }


        [Display(Name = "Salary", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        [Required(ErrorMessageResourceType = typeof(JobSearch.Domain.Utility.Language.Message), ErrorMessageResourceName = "MSG_E001")]
        public double Salary { get; set; }
                       
        [Display(Name = "ConctractType", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        [Required(ErrorMessageResourceType = typeof(JobSearch.Domain.Utility.Language.Message), ErrorMessageResourceName = "MSG_E001")]
        public string ConctractType { get; set; }
       
        [Display(Name = "TecnlogyTools", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        [Required(ErrorMessageResourceType = typeof(JobSearch.Domain.Utility.Language.Message), ErrorMessageResourceName = "MSG_E001")]
        public string TecnlogyTools { get; set; }

        [Display(Name = "CompanyDescription", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        public string CompanyDescription { get; set; }

        [Display(Name = "JobDescription", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        [Required(ErrorMessageResourceType = typeof(JobSearch.Domain.Utility.Language.Message), ErrorMessageResourceName = "MSG_E001")]
        public string JobDescription { get; set; }

        [Display(Name = "Benefits", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        public string Benefits { get; set; }

        [Display(Name = "InterestedSendEmailTo", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        public string InterestedSendEmailTo { get; set; }
        
        [Display(Name = "PublicationDate", ResourceType = typeof(JobSearch.Domain.Utility.Language.filds))]
        public DateTime PublicationDate { get; set; }


        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
