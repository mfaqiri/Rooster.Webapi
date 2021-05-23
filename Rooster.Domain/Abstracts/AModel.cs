

//This abstract model provides primary keys for the Entity Framework ORM.
namespace Rooster.Domain.Abstracts
{
  public abstract class AModel
  {
    public int EntityId { get; set; }
  }
}