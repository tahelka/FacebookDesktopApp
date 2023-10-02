namespace FacebookAppForDesktopLogic
{
    using System;
    using FacebookWrapper.ObjectModel;

    internal class FilterOlderPost : IPostFilter
    {
        public bool ShouldAddPostToList(Post i_Post, DateTime i_ChosenDateTimeOnDateTimePicker)
        {
            return i_Post.CreatedTime <= i_ChosenDateTimeOnDateTimePicker;
        }
    }
}