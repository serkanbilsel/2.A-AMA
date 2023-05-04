﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P013KatmanliBlog.Core.Entities
{
    public class Slider : IEntity
    {
        public int Id { get; set; }


        [Display(Name = "Ad")]
        public string? Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Resim")]
        public string? Image { get; set; }

        public string? Link { get; set; }


    }
}
