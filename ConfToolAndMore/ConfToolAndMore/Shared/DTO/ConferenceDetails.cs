﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ConfToolAndMore.Shared.DTO
{
    public class ConferenceDetails
    {
        public Guid ID { get; set; }
        [Required] 
        [StringLength(100, MinimumLength = 3)]
        public string Title { get; set; }
        [Required] 
        public DateTime DateFrom { get; set; }
        [Required] 
        public DateTime DateTo { get; set; }
        [Required] 
        public string Country { get; set; }
        [Required] 
        public string City { get; set; }
        [Required] 
        public string Url { get; set; }
    }
}
