//interface for inventory
public interface IItemContainer
{
    bool ContainsItem(Item item);
    bool Remove(Item item);
    bool Add(Item item);
    bool IsFull();
    int ItemCount(Item item);
}
