﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Models
{
   public class ReviewRequestModel
    {
        public int UserId { get; set; }
        public int movieId { get; set; }
        public decimal Rating { get; set; }
        public string ReviewText { get; set; }
    }
}
