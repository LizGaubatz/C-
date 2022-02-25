using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsNDishes.Models
{
    public class Dish
    {
        [Key]
        public int DishID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, 6)]
        public int Tastiness { get; set; }

        [Required]
        [GTZero]
        public int Calories { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int ChefID { get; set; }

        public Chef Creator { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}