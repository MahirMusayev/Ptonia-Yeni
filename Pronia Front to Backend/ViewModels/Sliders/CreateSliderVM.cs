﻿using System.ComponentModel.DataAnnotations;

namespace Pronia_Front_to_Backend.ViewModels.Sliders
{
    public class CreateSliderVM
    {
        [MaxLength(32,ErrorMessage="basliq 32 simvoldan cox ola bilmez"), Required]
        public string Title { get; set; }
        [Range(0, 100)]
        public int Discount { get; set; }
        [MaxLength(64), Required]
        public string Subtitle { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}
