using System;
using System.Collections.Generic;
using System.Text;

namespace SofiaTeachersOnline.Database.Models.Contracts
{
    public interface IExercise
    {
        Course Course { get; set; }
        string Content { get; set; }
        ICollection<Grade> Grades { get; set; }
    }
}
