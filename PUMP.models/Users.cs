using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PUMP.models;

public class Users
{
    [Key]
    public string Username { get; set; }
    public string Password { get; set; }
    
    [JsonIgnore] 
    public byte[]? Salt { get; set; }

    [JsonIgnore]
    public bool Admin { get; set; }
}