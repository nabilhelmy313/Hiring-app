using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dto.Home
{
    public class GetHomeJobCategoriesDto
    {
        public Guid Id { get; set; }    
        public string TitleEn { get; set; }
        public string TitleFr { get; set; }
        public string Titledu { get; set; }
        public string CategoryPic { get; set; }
        public int JobCount { get; set; }
    }
}
