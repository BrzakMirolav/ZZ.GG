namespace BusinessModel.GlobalModels
{
    public class LoadOptions
    {
        public int? Skip { get; set; }
        public int? Take { get; set; }
        public SortingOptions[]? Sort { get; set; }
    }


    public class LoadOptions<T> : LoadOptions
    {
        public T Filter { get; set; }
        public LoadOptions(T filter)
        {
            Filter = filter;
        }
    }

    public class SortingOptions
    {
        public string SortBy { get; set; }
        public bool? Desc { get; set; }

        public SortingOptions(string sortBy, bool? desc)
        {
            SortBy = sortBy;
            Desc = desc ?? false;
        }

    }
    

}
