using System;

namespace BuffTeks.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string ProjectName {get; set; }
        public string ProjectClient { get; set; }
        public string MemberLiaison { get; set; }
        public string CompanyLiaison { get; set; }
    }
}