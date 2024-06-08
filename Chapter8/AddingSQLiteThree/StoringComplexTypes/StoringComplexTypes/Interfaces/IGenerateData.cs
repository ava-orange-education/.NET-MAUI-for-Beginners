using System.Collections.ObjectModel;
using StoringComplexTypes.Models;

namespace StoringComplexTypes.Interfaces;

public interface IGenerateData
{
    ObservableCollection<CollectionModel> CreateBackingData();
    ObservableCollection<ComplexCollectionModel> CreateComplexData();
}