namespace Ion.Domain.Common;

public abstract class BaseEntity<TKey>
{
    public TKey Key { get; set; }
}