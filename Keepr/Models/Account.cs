using Keepr.Interfaces;

namespace Keepr.Models;

public class Profile : IRepoItem<string>
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Picture { get; set; }
  public string ImgUrl { get; set; }
  public DateTime CreatedAt { get; set; }
  public DateTime UpdatedAt { get; set; }
}



public class Account : Profile
{
  public string Email { get; set; }


}