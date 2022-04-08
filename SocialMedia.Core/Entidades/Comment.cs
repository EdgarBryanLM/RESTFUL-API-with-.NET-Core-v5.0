﻿using SocialMedia.Core.Entidades;
using System;
using System.Collections.Generic;

#nullable disable

namespace SocialMedia.Core.Entidades
{
    public partial class Comment: BaseEntity
    {
  
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }

        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
