using Domain.Models.CommonEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Blogs.Categories
{
    public class BlogCategorie: CommanEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }    

        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string Icon { get;set; }
        public string ImageUrl { get;set; }
        public int? ParentId { get; set; }

    }
}
