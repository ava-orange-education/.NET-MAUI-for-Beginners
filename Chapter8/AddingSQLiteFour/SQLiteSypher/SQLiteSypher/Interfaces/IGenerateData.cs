using System.Collections.ObjectModel;
using SQLiteSypher.Models;

namespace SQLiteSypher.Interfaces;

public interface IGenerateData
{
    ObservableCollection<CollectionModelDTO> CreateBackingData();
}