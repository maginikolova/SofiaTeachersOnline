using System;
using System.Collections.Generic;
using System.Text;

namespace SofiaTeachersOnline.Database.Models.Contracts
{
    interface ICourse
    {
        public Teacher Teacher { get; set; }
    }
}
