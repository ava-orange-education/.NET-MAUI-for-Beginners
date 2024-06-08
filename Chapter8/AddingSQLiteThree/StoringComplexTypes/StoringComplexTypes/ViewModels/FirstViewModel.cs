using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using StoringComplexTypes.Interfaces;
using StoringComplexTypes.Models;
using System.Collections.ObjectModel;
using System.Globalization;

namespace StoringComplexTypes.ViewModels
{
    public partial class FirstViewModel : ObservableObject
    {
#nullable enable
        IRepository? repository => Startup.ServiceProvider.GetService<IRepository>();
        IGenerateData? generateData => Startup.ServiceProvider.GetService<IGenerateData>();
#nullable disable

        [ObservableProperty]
        ObservableCollection<CollectionModel> collection;

        [ObservableProperty]
        ObservableCollection<ComplexCollectionModel> complexCollection;

        [ObservableProperty]
        bool collectionSame;

        [ObservableProperty]
        bool complexCollectionSame;

        [ObservableProperty]
        bool showCollections;

        [ObservableProperty]
        bool showRandomDta;

        [ObservableProperty]
        Guid internalId;

        [ObservableProperty]
        string internalRect;

        [ObservableProperty]
        string internalLabelText;

        MasterClass DataMasterClass { get; set; } = new MasterClass();

        [RelayCommand]
        async Task ShowData()
        {
            DataMasterClass = await repository.GetData<MasterClass, int>("Id", 1);
            Collection = DataMasterClass.CollectionModel;
            ComplexCollection = DataMasterClass.ComplexCollectionModel;

            var serialCollection = JsonConvert.SerializeObject(Collection);
            var serialComplex = JsonConvert.SerializeObject(ComplexCollection);

            CollectionSame = serialCollection.Equals(DataMasterClass.CollectionSerialised);
            ComplexCollectionSame = serialComplex.Equals(DataMasterClass.ComplexCollectionSerialised);

            ShowCollections = true;
        }

        [RelayCommand]
        void ShowRandomData()
        {
            var value = new Random().Next(0, ComplexCollection.Count);
            InternalId = ComplexCollection[value].Id;
            InternalRect = ComplexCollection[value].Bounds.ToString();
            InternalLabelText = $"{ComplexCollection[value].DictionaryLabels.First()} {ComplexCollection[value].DictionaryLabels.Last()}";
            ShowRandomDta = true;
        }

        public async Task SetupDatabase()
        {
            if ((await repository.Count<MasterClass>()) != 0)
            {
                var _ = await repository.GetList<MasterClass>();
                await repository.DeleteList(_);
            }

            var collect = generateData.CreateBackingData();
            var complexCollect = generateData.CreateComplexData();

            for (var i = 0; i < complexCollect.Count; i++)
            {
                complexCollect[i].CollectionModel = collect[i];
            }

            var serialCollect = JsonConvert.SerializeObject(collect);

            var settings = new JsonSerializerSettings()
            {
                Culture = CultureInfo.InvariantCulture,
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                MaxDepth = 8,
                Error = delegate (object o, Newtonsoft.Json.Serialization.ErrorEventArgs e)
                {
                    e.ErrorContext.Error.Message.Trim();
                }
            };

            var serialComplexCollect = JsonConvert.SerializeObject(complexCollect, Formatting.Indented, settings);


            await repository.SaveData(new MasterClass
            {
                Id = 1,
                CollectionSerialised = JsonConvert.SerializeObject(collect),
                ComplexCollectionSerialised = JsonConvert.SerializeObject(complexCollect)
            });
        }


    }
}
