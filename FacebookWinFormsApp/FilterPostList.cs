using FacebookWrapper.ObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookAppForDesktopLogic
{
    public class FilterPostList
    {
        public IPostFilter PostFilter { get; set; }
        private readonly DateTime r_ChosenDateTimeOnDateTimePicker;

        public FilterPostList(IPostFilter i_Filter, DateTime i_ChosenDateTimeOnDateTimePicker)
        {
            PostFilter = i_Filter;
            r_ChosenDateTimeOnDateTimePicker = i_ChosenDateTimeOnDateTimePicker;
        }

        public List<Post> GetFilteredPostList(List<Post> i_PostList)
        {
            List<Post> filteredPostList = new List<Post>();

            foreach (Post post in i_PostList)
            {
                if (!string.IsNullOrEmpty(post.Message) && PostFilter.ShouldAddPostToList(post, r_ChosenDateTimeOnDateTimePicker))
                {
                    filteredPostList.Add(post);
                }
            }

            return filteredPostList;
        }
       
    }

    

}