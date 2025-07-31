using Com.Efrata.Service.Core.Lib.Services;
using Com.Moonlay.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Com.Efrata.Service.Core.Lib.Models
{
    public class GarmentCategory : StandardEntity, IValidatableObject
    {
        [MaxLength(255)]
        public string UId { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(255)]
        public string CodeRequirement { get; set; }
        [MaxLength(255)]
        public string CategoryType { get; set; }
        public int? UomId { get; set; }
        [MaxLength(255)]
        public string UomUnit { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validationResult = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Code))
                validationResult.Add(new ValidationResult("Code is required", new List<string> { "Code" }));

            if (string.IsNullOrWhiteSpace(this.Name))
                validationResult.Add(new ValidationResult("Name is required", new List<string> { "Name" }));

            if (string.IsNullOrWhiteSpace(this.CodeRequirement))
                validationResult.Add(new ValidationResult("CodeRequirement is required", new List<string> { "CodeRequirement" }));

            if (string.IsNullOrWhiteSpace(this.CategoryType))
                validationResult.Add(new ValidationResult("CategoryType is required", new List<string> { "CategoryType" }));

            if (this.UomId.Equals(null))
                validationResult.Add(new ValidationResult("Uom is required", new List<string> { "UomId" }));

            if (validationResult.Count.Equals(0))
            {
                /* Service Validation */
                GarmentCategoryService service = (GarmentCategoryService)validationContext.GetService(typeof(GarmentCategoryService));

                //if (service.DbContext.Set<GarmentCategory>().Count(r => r._IsDeleted.Equals(false) && r.Id != this.Id && r.Name.Equals(this.Name) ) > 0) /* Unique */
                //{
                //    validationResult.Add(new ValidationResult("Name already exists", new List<string> { "Name" }));
                //}

                // Validasi unik Code
                if (!string.IsNullOrWhiteSpace(this.Code) &&
                    service.DbContext.Set<GarmentCategory>().Count(r => r._IsDeleted.Equals(false) && r.Id != this.Id && r.Code.Equals(this.Code)) > 0)
                {
                    validationResult.Add(new ValidationResult("kode sudah pernah dipakai, silahkan gunakan kode lain", new List<string> { "Code" }));
                }
            }

            return validationResult;
        }
    }
}
