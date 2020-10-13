using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantRaterAPI.Models
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Range(0,10)]
        public double FoodScore { get; set; }
        [Required]
        [Range(0,10)]
        public double CleanlinessScore { get; set; }
        [Required]
        [Range(0, 10)]
        public double EnviromentScore { get; set; }
        public double AverageRating
        {
            get
            {
                return (FoodScore + EnviromentScore + CleanlinessScore) / 3;
            }
        }

        [ForeignKey(nameof(Restaurant))]
        public int RestaurantID { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}