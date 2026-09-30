# Part G — Short Answer Questions

### 1. `.csproj` Contents & Part A Verification
Below is the `.csproj` file configuration for the project:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>



Confirmation of Part A Properties:

OutputType: Present (Configures the project as a runnable console application).

TargetFramework: Present (Specifies the target .NET runtime version).

ImplicitUsings: Present (Automatically imports common System namespaces).

Nullable: Present (Enables C# static null-safety checks and warnings).

2. #region / #endregion Impact & Purpose
Do they change compiled output? No. The C# compiler completely strips out #region and #endregion directives during compilation, so they have zero impact on the compiled IL bytecode or performance.

Why use them? They are IDE-only organizational tools used to collapse or expand logical sections of code in editors like Visual Studio.

3. /// XML Doc Comments vs. Plain //
Plain // comments are internal developer notes meant only for anyone reading the raw source code file.

/// XML doc comments are used for public APIs and methods because Visual Studio extracts them to display rich IntelliSense tooltips and descriptions when calling the method elsewhere.

4. Absence of True Global Variables in C# & Closest Equivalent
Why C# has no true global variables: C# is an Object-Oriented language designed around encapsulation to prevent naming collisions and unstructured state mutation.

Closest Equivalent: A public static field defined inside a class (e.g., public static int GlobalCounter; inside Program).