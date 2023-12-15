
namespace MyLibrary.Domain.Common;
public abstract class BaseEntity : IEquatable<BaseEntity>
{
    public long Id { get; private init; }
    public DateTime? DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }

    protected BaseEntity()
    {

    }
    protected BaseEntity(long id)
    {
        Id = id;
    }

    public static bool operator ==(BaseEntity? first, BaseEntity? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(BaseEntity? first, BaseEntity? second)
    {
        return !(first == second);
    }

    public bool Equals(BaseEntity? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }
        return other.Id == Id;
    }
    public override bool Equals(object? obj)
    {
        if (obj is null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not BaseEntity entity)
        {
            return false;
        }

        return entity.Id == Id;
    }


    public override int GetHashCode()
    {

        return Id.GetHashCode();
    }


}

