namespace AdventOfCode2022;

public class Day07
{
    // 2h 04min
    public int PartOne()
    {
        var folders = GetInput();
        var folderSizes = folders.Select(f => new { f.Name, Size = f.GetSize()});
        return folderSizes.Select(x => x.Size).Where(x => x <= 100000).Sum();
    }

    public int PartTwo()
    {
        var folders = GetInput();
        var folderSizes = folders.Select(f => new { f.Name, Size = f.GetSize()}).OrderByDescending(x => x.Size);
        var spaceNeeded = 30000000 - (70000000 - folderSizes.Single(x => x.Name == "/").Size);
        return folderSizes.Select(x => x.Size).Where(x => x >= spaceNeeded).OrderBy(x => x).First();
    }

    private List<Folder> GetInput()
    {
        var input = Input;

        var folders = new List<Folder>();
        var currentFolder = new Folder("/");
        folders.Add(currentFolder);
        foreach (var line in input)
        {
            if (!IsCommand(line))
            {
                var newFolder = currentFolder.AddFileOrFolder(line);
                if (newFolder != null)
                {
                    folders.Add(newFolder);
                }
            }

            if (TryGetChangeDirectory(line, out var dir))
            {
                currentFolder = dir == ".." ? folders.Single(f => f.Id == currentFolder.ParentFolder) : currentFolder.Folders.Single(f => f.Name == dir);
            }
        }

        return folders;
    }

    private bool TryGetChangeDirectory(string line, out string dir)
    {
        if (line.StartsWith("$ cd") && !line.EndsWith("/"))
        {
            dir = line.Split(" ")[2];
            return true;
        }

        dir = null;
        return false;
    }


    public virtual string[] Input => new Input().ReadLines(7).Result;

    public static bool IsCommand(string line)
    {
        return line.StartsWith("$");
    }


}

public class Folder
{
    public Folder(string line, Folder parentFolder)
    {
        Id = Guid.NewGuid();
        Name = line.Split(" ")[1];
        ParentFolder = parentFolder.Id;
    }

    public Folder(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
    }

    public Guid Id { get; }
    public List<Folder> Folders { get; } = new();
    public List<File> Files { get; } = new();
    public string? Name { get; }
    public Guid? ParentFolder { get; }

    public Folder? AddFileOrFolder(string line)
    {
        Folder? folder = null;
        if (line.StartsWith("dir"))
        {
            folder = new Folder(line, this);
            Folders.Add(folder);
        }
        else
        {
            Files.Add(new File(line));
        }

        return folder;
    }

    public int GetSize()
    {
        var filesizes = Files.Select(x => x.Size).Sum();
        var subFolderSizes = Folders.Select(f => f.GetSize()).Sum();
        return filesizes + subFolderSizes;
    }
}

public class File
{
    public File(string line)
    {
        Name = line.Split(" ")[1];
        Size = int.Parse(line.Split(" ")[0]);
    }

    public string Name { get; }
    public int Size { get; }
}