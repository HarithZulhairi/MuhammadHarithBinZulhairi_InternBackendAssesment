class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Item Manager!");

        ItemManager manager = new ItemManager();
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

        // Part Four (Bonus): Implement an interface IItemManager and make ItemManager implement it.
        // TODO: Implement this part four.
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

public class ItemManager
{
    private List<string> items;

    // Constructor to initialize the items list (fixes the NullReferenceException)
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


    // Part Two: Implement the RemoveItem method
    // TODO: Implement this method
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
        items = [];
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