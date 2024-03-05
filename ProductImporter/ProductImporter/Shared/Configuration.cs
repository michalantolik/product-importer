using System.Reflection;

namespace ProductImporterApp.Shared;

public class Configuration
{
    public string SourceCsvPath => Path.Combine(ProjectPath, InputFilename);
    public string TargetCsvPath => Path.Combine(ProjectPath, OutputFilename);

    internal string InputFilename => "product-input.csv";
    internal string OutputFilename => "product-output.csv";
    internal string ProjectPath
    {
        get
        {
            // Get the location of the currently executing assembly (which could be in a bin\Debug or bin\Release folder).
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            string projectPath = Path.GetDirectoryName(assemblyLocation);

            // Check if the assembly location contains "\bin", which indicates it's inside a bin folder.
            // If it is, navigate up until reaching the folder that contains the .csproj file.
            while (!Directory.GetFiles(projectPath, "*.csproj").Any() && Directory.GetParent(projectPath) != null)
            {
                projectPath = Directory.GetParent(projectPath).FullName;
            }

            return projectPath;
        }
    }
}
