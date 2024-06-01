using SQLite;

namespace AddingSQLite.Models;

public class AddingSQLiteDataModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    #nullable  enable
    public string? UserName { get; set; }
    public string? SomeInformation { get; set; }
    #nullable  disable
}