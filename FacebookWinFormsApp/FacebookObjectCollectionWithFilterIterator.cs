using FacebookWrapper.ObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookAppForDesktopLogic
{
    internal class FacebookObjectCollectionWithFilterIterator<T> : IEnumerable
        where T : FacebookObject
    {
        private readonly IEnumerable<T> r_FacebookObjects;
        private readonly Func<T, bool> r_Test;

        public FacebookObjectCollectionWithFilterIterator(IEnumerable<T> i_FacebookObjects, Func<T, bool> i_Test = null)
        {
            r_FacebookObjects = i_FacebookObjects;
            r_Test = i_Test;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (T item in r_FacebookObjects)
            {
                if (r_Test == null || r_Test.Invoke(item))
                {
                    yield return item;
                }
            }
        }
    }
}