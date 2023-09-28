namespace FacebookAppForDesktopLogic
{
    using System;
    using System.Collections.Generic;
    using FacebookWrapper.ObjectModel;

    public class FilterPostList
    {
        private readonly DateTime r_ChosenDateTimeOnDateTimePicker;

        public IPostFilter PostFilter { get; set; }

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