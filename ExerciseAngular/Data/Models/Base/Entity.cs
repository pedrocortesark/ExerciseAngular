﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExerciseAngular.Data.Models.Base
{
    public abstract class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifyOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
    }
}
