using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BuffTeks.Models
{
    public class MemberMajorViewModel
    {
        public List<Members> members;
        public SelectList major;
        public string MemberMajor { get; set; }
    }
}