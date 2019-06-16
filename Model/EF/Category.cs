namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        public long ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(250)]
        public string MetaTitle { get; set; }

        public long? ParentID { get; set; }

        public int? DisplayOrder { get; set; }

        [StringLength(250)]
        public string SeoTitle { get; set; }

        public DateTime? CreatedDate { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }

        [StringLength(250)]
        public string MetaKeywords { get; set; }

        [StringLength(10)]
        public string MetaDescription { get; set; }

        public bool? Status { get; set; }

        public bool? ShowOnHome { get; set; }
        public string Language { get; set; }


        //public long ID { get; set; }

        //[StringLength(50)]
        //[Display(Name = "Category_Name", ResourceType = typeof(StaticRescouce.Resources))]
        //public string Name { get; set; }

        //[StringLength(250)]
        //[Display(Name = "Category_MetaTitle", ResourceType = typeof(StaticRescouce.Resources))]
        //public string MetaTitle { get; set; }

        //[Display(Name = "Category_ParentID", ResourceType = typeof(StaticRescouce.Resources))]
        //public long? ParentID { get; set; }

        //[Display(Name = "Category_DisplayOrder", ResourceType = typeof(StaticRescouce.Resources))]
        //public int? DisplayOrder { get; set; }

        //[StringLength(250)]
        //[Display(Name = "Category_SeoTitle", ResourceType = typeof(StaticRescouce.Resources))]
        //public string SeoTitle { get; set; }

        //public DateTime? CreatedDate { get; set; }

        //[StringLength(50)]
        //public string CreatedBy { get; set; }

        //public DateTime? ModifiedDate { get; set; }

        //[StringLength(50)]
        //public string ModifiedBy { get; set; }

        //[StringLength(250)]
        //[Display(Name = "Category_MetaKeywords", ResourceType = typeof(StaticRescouce.Resources))]
        //public string MetaKeywords { get; set; }

        //[StringLength(10)]
        //[Display(Name = "Category_MetaDescription", ResourceType = typeof(StaticRescouce.Resources))]
        //public string MetaDescription { get; set; }

        //[Display(Name = "Category_Status", ResourceType = typeof(StaticRescouce.Resources))]
        //public bool? Status { get; set; }

        //[Display(Name = "Category_ShowOnHome", ResourceType = typeof(StaticRescouce.Resources))]
        //public bool? ShowOnHome { get; set; }
        //public string Language { get; set; }
    }
}
