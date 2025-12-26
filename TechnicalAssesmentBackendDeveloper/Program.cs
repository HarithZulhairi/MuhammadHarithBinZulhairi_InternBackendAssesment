// (Part 4)
public interface IItemManager
{
    void AddItem(string item);
    void RemoveItem(string item);
    void PrintAllItems();
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        // Using the interface in the declaration is a good way to test it
        IItemManager manager = new ItemManager();
        manager.AddItem("Apple");
        manager.AddItem("Banana");
        manager.PrintAllItems();
        manager.RemoveItem("Apple");

        // Part Three: Generic Implementation
        Console.WriteLine("\n--- Fruit Manager ---");
        ItemManager<Fruit> fruitManager = new ItemManager<Fruit>();
        fruitManager.AddItem(new Fruit { Name = "Mango", Color = "Yellow" });
        fruitManager.AddItem(new Fruit { Name = "Strawberry", Color = "Red" });
        fruitManager.AddItem(new Fruit { Name = "Grape", Color = "Purple" });

        fruitManager.PrintAllItems();
    }
}

public class Fruit
{
    public string Name { get; set; }
    public string Color { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Color})";
    }
}

// 2. Implement the Interface here (Part 4)
public class ItemManager : IItemManager
{
    private List<string> items;

    public ItemManager()
    {
        items = new List<string>();
    }

    public void AddItem(string item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"Removed: {item}");
        }
        else
        {
            Console.WriteLine($"Item not found: {item}");
        }
    }

    public void ClearAllItems()
    {
        items.Clear();
    }
}

public class ItemManager<T>
{
    private List<T> items;

    public ItemManager()
    {
        items = new List<T>();
    }

    public void AddItem(T item)
    {
        items.Add(item);
    }

    public void PrintAllItems()
    {
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
    
    public void RemoveItem(T item)
    {
        items.Remove(item);
    }
}