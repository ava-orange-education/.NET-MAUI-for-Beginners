using SQLite;

namespace AddingSQLite.Models;

public class AddingSQLiteDataModel
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    #nullable  enable
    public string? DataName { get; set; }
    public string? DataInformation { get; set; }
    #nullable  disable
}