#if ANDROID
using Android.Content.Res;
#endif
#if IOS || MACCATALYST
using Foundation;
#endif
#if WINDOWS
using Windows.Storage;
#endif

using ReadPDF.Interfaces;

namespace ReadPDF.Services;

public class ListResAssets : IListAssets
{
    public List<string> ListAssets(string path)
    {
        var fileslist = new List<string>();
        
        #if ANDROID
        AssetManager assets = Platform.AppContext.Assets;
        string[] files = assets.List(path);
        fileslist = files.ToList();
#elif IOS || MACCATALYST
        NSBundle mainBundle = NSBundle.MainBundle;
        string resourcesPath = mainBundle.ResourcePath;
        string subfolderPath = Path.Combine(resourcesPath, path);

        if (Directory.Exists(subfolderPath))
        {
            string[] files = Directory.GetFiles(subfolderPath);
            fileslist = files.Select(Path.GetFileName).ToList();
        }
#elif WINDOWS
        StorageFolder installFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
        StorageFolder subfolder = installFolder.GetFolderAsync(path).GetAwaiter().GetResult();
        IReadOnlyList<StorageFile> files = subfolder.GetFilesAsync().GetAwaiter().GetResult();

        fileslist = files.Select(f => f.Name).ToList();
#endif
        return fileslist;
    }
}