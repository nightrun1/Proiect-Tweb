using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NextGenPC.Domain.Entities.Product
{

    public class ProdDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Product name must be between 3 and 100 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Image URL")]
        [StringLength(300, ErrorMessage = "Image URL must not exceed 300 characters.")]
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Processor (CPU)")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "CPU name must be between 2 and 50 characters.")]
        public string CPU { get; set; }

        [Required]
        [Display(Name = "Graphics Card (GPU)")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "GPU name must be between 2 and 50 characters.")]
        public string GPU { get; set; }

        [Required]
        [Display(Name = "Memory (RAM)")]
        [StringLength(30, ErrorMessage = "RAM description must not exceed 30 characters.")]
        public string RAM { get; set; }

        [Required]
        [Display(Name = "Storage")]
        [StringLength(50, ErrorMessage = "Storage description must not exceed 50 characters.")]
        public string Storage { get; set; }

        [Required]
        [Display(Name = "Stock Quantity")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be 0 or greater.")]
        public int StockQuantity { get; set; }

        [Required]
        [Display(Name = "Price (MDL)")]
        [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1,000,000.")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Display(Name = "Last Updated")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }

}
