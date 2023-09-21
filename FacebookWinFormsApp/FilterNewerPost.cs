using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppForDesktopLogic
{
    internal class FilterNewerPost : IPostFilter
    {
        public bool ShouldAddPostToList(Post i_Post, DateTime i_ChosenDateTimeOnDateTimePicker)
        {
            return i_Post.CreatedTime > i_ChosenDateTimeOnDateTimePicker;
        }
    }
}
