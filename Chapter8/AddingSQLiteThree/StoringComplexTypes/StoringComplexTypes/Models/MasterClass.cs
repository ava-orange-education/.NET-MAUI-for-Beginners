using Newtonsoft.Json;
using SQLite;
using StoringComplexTypes.Helpers;
using StoringComplexTypes.Interfaces;
using System.Collections.ObjectModel;

namespace StoringComplexTypes.Models
{
    public class MasterClass
    {
#nullable enable
        IRepository? repository => Startup.ServiceProvider.GetService<IRepository>();
#nullable disable

        [PrimaryKey]
        public int Id { get; set; }

#nullable enable
        public string? CollectionSerialised { get; set; }
        public string? ComplexCollectionSerialised { get; set; }
#nullable disable

        [Ignore]
        public ObservableCollection<CollectionModel> CollectionModel => 
            JsonConvert.DeserializeObject<ObservableCollection<CollectionModel>>(CollectionSerialised);

        [Ignore]
        public ObservableCollection<ComplexCollectionModel> ComplexCollectionModel =>
            JsonConvert.DeserializeObject<ObservableCollection<ComplexCollectionModel>>(ComplexCollectionSerialised);
    }
}
