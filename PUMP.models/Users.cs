using System.ComponentModel.DataAnnotations;

namespace PUMP.models;

public class Users
{
    [Key]
    public string Username { get; set; }
    public string Password { get; set; }   
}