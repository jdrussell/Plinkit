using System;
using System.Collections.Generic;
using Plinkit.Domain.Models.Links;

namespace Plinkit.Domain.Configuration
{
    interface I
    {
        DateTime GetDate(DateTime t);
    }

    class Time : I
    {
        public DateTime GetDate(DateTime t)
        {
            return t.Date;
        }
    }

    static class p
    {
        public static IEnumerable<DailyLink> Link(I t)
        {
            return new List<DailyLink>();
        }
    }

    class Context
    {
        public void LogoCode()
        {            
            var it = new Time();
            var res = p.Link(it);
        }
    }
}
