﻿using System.Collections.ObjectModel;

namespace GroupedData.Helpers
{
    public static class ToObservableCollection
    {
        public static ObservableCollection<T> ToObservable<T>(this List<T> collection) => 
            new ObservableCollection<T>(collection as IEnumerable<T>);
    }
}
