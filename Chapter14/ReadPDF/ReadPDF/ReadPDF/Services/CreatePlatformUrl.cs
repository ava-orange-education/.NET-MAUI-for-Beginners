using System.Net;
using ReadPDF.Interfaces;

namespace ReadPDF.Services;

public class CreatePlatformUrl : IFormFilename
{
    #if ANDROID
    public string FormUrl(string filename) => $"file:///android_asset/pdfjs/web/viewer.html?file=file:///android_asset/{WebUtility.UrlEncode(filename)}";
    #else
    public string FormUrl(string filename) => filename;
    #endif
}