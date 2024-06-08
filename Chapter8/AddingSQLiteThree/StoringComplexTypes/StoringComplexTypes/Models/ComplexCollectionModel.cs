using SQLite;
using System.Drawing;

namespace StoringComplexTypes.Models
{
    public class ComplexCollectionModel
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        public int ParentKey { get; set; }

        public Rectangle Bounds { get; set; }

#nullable enable
        public List<string>? DictionaryLabels { get; set; }
        public CollectionModel? CollectionModel { get; set; }
#nullable disable
    }
}
