#  CNC Tool Library

A simple C# console application to manage a library of CNC machining tools, including support for adding, removing, finding, updating, and displaying tools. This can be a starting point for integrating with CAM automation or CNC software like PowerMill or Fusion 360.

---

##  Features

- Add new tools to the library
- Update existing tools
- Remove tools by ID
- Find tools by ID
- Display all tools in the library
- Console color-coded output for better readability

---

##  Tool Attributes

Each tool contains the following attributes:

- `ID`: Unique identifier
- `Name`: Tool name (e.g., EndMill, Drill)
- `Diameter`: Tool diameter
- `Length`: Tool total length
- `HolderUpperDiam`: Upper diameter of the holder
- `HolderLowerDiam`: Lower diameter of the holder
- `HolderComponentLength`: Length of the holder component
- `OverhangLength`: Tool overhang
- `Type`: Tool type (e.g., Cutting, Drilling)
- `Material`: Suitable material for the tool

---

##  Getting Started

### Prerequisites

- [.NET 6 SDK or later](https://dotnet.microsoft.com/en-us/download)

### Clone the repository

```bash
git clone https://github.com/your-username/CNC-Tool-Library.git
cd CNC-Tool-Library

