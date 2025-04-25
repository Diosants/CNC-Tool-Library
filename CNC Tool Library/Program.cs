
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.Json;

public class Tool
{
    public int ID { get; set; }
    public string Name { get; set; }
    public double Diameter { get; set; }
    public double Length { get; set; }
    public double HolderUpperDiam { get; set; }
    public double HolderLowerDiam { get; set; }
    public double HolderComponentLength { get; set; }
    public double OverhangLength { get; set; }
    public string Type { get; set; }
    public string Material { get; set; }

    public Tool(int id, string name, double diameter, double length, double holderUppDiam, double holderLowerDiam, double holderComponentLength, double overhangLength, string type, string material)
    {
        ID = id;
        Name = name;
        Diameter = diameter;
        Length = length;
        HolderUpperDiam = holderUppDiam;
        HolderLowerDiam = holderLowerDiam;
        HolderComponentLength = holderComponentLength;
        OverhangLength = overhangLength;
        Type = type;
        Material = material;
    }

    public override string ToString()
    {
        return $"ID: {ID}, Name: {Name}, Diameter: {Diameter}, Length: {Length},\n" +
               $"Holder Upper Diameter: {HolderUpperDiam}, Holder Lower Diameter: {HolderLowerDiam},\n" +
               $"Holder Component Length: {HolderComponentLength}, Overhang: {OverhangLength},\n" +
               $"Type: {Type}, Material: {Material}";
    }
}

public class ToolLibrary
{
    private readonly List<Tool> tools = new List<Tool>();

    public void AddTool(Tool tool)
    {
        if (tool == null)
        {
            throw new ArgumentNullException(nameof(tool), "Tool cannot be null.");
        }
        tools.Add(tool);
    }

    public bool RemoveTool(int id)
    {
        var tool = tools.FirstOrDefault(t => t.ID == id);
        if (tool != null)
        {
            tools.Remove(tool);
            return true;
        }
        return false;
    }

    public Tool? FindTool(int id)
    {
        return tools.FirstOrDefault(t => t.ID == id);
    }

    public bool UpdateTool(int id, Tool updatedTool)
    {
        if (updatedTool == null)
        {
            throw new ArgumentNullException(nameof(updatedTool), "Updated tool cannot be null.");
        }

        var tool = FindTool(id);
        if (tool != null)
        {
            tool.Name = updatedTool.Name;
            tool.Diameter = updatedTool.Diameter;
            tool.Length = updatedTool.Length;
            tool.Type = updatedTool.Type;
            tool.Material = updatedTool.Material;
            tool.HolderUpperDiam = updatedTool.HolderUpperDiam;
            tool.HolderLowerDiam = updatedTool.HolderLowerDiam;
            tool.HolderComponentLength = updatedTool.HolderComponentLength;
            tool.OverhangLength = updatedTool.OverhangLength;
            return true;
        }
        return false;
    }

    public void DisplayAllTools()
    {
        if (!tools.Any())
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("No tools available in the library.");
            Console.ResetColor();
            return;
        }

        foreach (var tool in tools)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(tool);
            Console.ResetColor();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var lib = new ToolLibrary();

        lib.AddTool(new Tool(1, "EndMill", 10.0, 50.0, 50.0, 50.0, 50.0, 30.0, "Cutting", "Steel"));
        lib.AddTool(new Tool(2, "Drill", 5.0, 30.0, 50.0, 50.0, 50.0, 30.0, "Drilling", "Steel"));
        lib.AddTool(new Tool(3, "BullNose", 15.0, 100.0, 50.0, 50.0, 50.0, 30.0, "Cutting", "Steel"));

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Displaying all tools:");
        Console.ResetColor();
        lib.DisplayAllTools();

        var tool = lib.FindTool(1);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nFound Tool:");
        Console.ResetColor();
        Console.WriteLine(tool);

        lib.UpdateTool(2, new Tool(2, "Drill", 5.0, 30.0, 50.0, 50.0, 50.0, 30.0, "Cutting", "Steel"));
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nAfter updating tool with ID 2:");
        Console.ResetColor();
        lib.DisplayAllTools();

        lib.RemoveTool(1);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nAfter removing tool with ID 1:");
        Console.ResetColor();
        lib.DisplayAllTools();
    }
}
