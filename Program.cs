Console.Write("Сколько задач добавить сначала: ");
int count = Convert.ToInt32(Console.ReadLine());

List<string> tasks = new List<string>();

for (int i = 0; i < count; i++)
{
    Console.Write($"Задача {i + 1}: ");
    string title = Console.ReadLine() ?? "";
    tasks.Add(title);
}

Console.WriteLine("Исходный список:");
PrintTasks(tasks);


Console.Write("Введите новую задачу для добавления в конец: ");
string newTask = Console.ReadLine() ?? "";
tasks.Add(newTask);
Console.WriteLine("Задача добавлена");

Console.Write("Введите задачу для вставки: ");
string insertTask = Console.ReadLine() ?? "";
Console.Write("Введите индекс для вставки: ");
int insertIndex = Convert.ToInt32(Console.ReadLine());

if (InsertTaskSafe(tasks, insertIndex, insertTask))
    Console.WriteLine("Задача вставлена");
else
    Console.WriteLine("Недопустимый индекс вставки");


Console.Write("Введите название задачи для удаления: ");
string removeTitle = Console.ReadLine() ?? "";
if (tasks.Remove(removeTitle))
    Console.WriteLine("Первое совпадение удалено");
else 
    Console.WriteLine("Задача не найдена");


Console.Write("Введите индекс задачи для удаления: ");
int removeIndex = Convert.ToInt32(Console.ReadLine());

if (RemoveTaskAtSafe(tasks, removeIndex))
    Console.WriteLine("Задача по индексу удалена");
else
    Console.WriteLine("Недопустимый индекс удаления");

Console.Write("Введите название для поиска: ");
string searchTitle = Console.ReadLine() ?? "";
int foundIndex = tasks.IndexOf(searchTitle);

if (foundIndex != -1)
    Console.WriteLine($"Первый индекс: {foundIndex}");
else
    Console.WriteLine("Задача не найдена");

void PrintTasks(List<string> tasks)
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Список пуст");
        return;
    }
    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i}: {tasks[i]}");
    }
}

bool InsertTaskSafe(List<string> tasks, int index, string title)
{
    if (index < 0 || index > tasks.Count) return false;
    tasks.Insert(index, title);
    return true;
}

bool RemoveTaskAtSafe(List<string> tasks, int index)
{
    if (index < 0 || index >= tasks.Count) return false;
    tasks.RemoveAt(index);
    return true;
}