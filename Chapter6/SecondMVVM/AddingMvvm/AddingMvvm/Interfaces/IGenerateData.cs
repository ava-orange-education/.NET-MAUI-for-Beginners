using System.Collections.ObjectModel;
using AddingMvvm.Models;

namespace AddingMvvm.Interfaces;

public interface IGenerateData
{
    ObservableCollection<CollectionModel> CreateBackingData();
}