using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace FacebookAppForDesktopLogic
{
    public interface IPostFilter
    {
        bool ShouldAddPostToList(Post i_Post, DateTime i_ChosenDateTimeOnDateTimePicker);
    }
}
