using System;
using System.Collections.Generic;
using System.Text;

namespace SofiaTeachersOnline.Models.Contracts
{
    interface ICourse
    {
        public Teacher Teacher { get; set; }
    }
}
