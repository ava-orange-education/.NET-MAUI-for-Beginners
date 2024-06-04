using System.Collections.ObjectModel;
using AddingSQLiteToExistingApp.Models;

namespace AddingSQLiteToExistingApp.Interfaces;

public interface IGenerateData
{
    ObservableCollection<CollectionModelDTO> CreateBackingData();
}