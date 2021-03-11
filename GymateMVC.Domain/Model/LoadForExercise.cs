using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Domain.Model
{
    public class LoadForExercise
    {
        public int Id { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public int LoadInKg { get; set; }
        public virtual Exercise Exercise { get; set; }
    }
}
