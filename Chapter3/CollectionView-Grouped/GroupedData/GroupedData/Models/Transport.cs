namespace GroupedData.Models
{
    public class Transport : List<CollectionModel>
    {
        public string Name { get; private set; }

        public Transport(string name, List<CollectionModel> collection) : base(collection)
        {
            Name = name;
        }

        public override string ToString() => Name;
    }
}
