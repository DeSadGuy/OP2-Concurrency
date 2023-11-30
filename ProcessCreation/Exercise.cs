using System;
using System.Diagnostics;

/// This example shows how to define a process and start it.
/// Check here: https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process?view=netcore-3.1


namespace Exercise
{
    public class ProcessCreation
    {
        public virtual void createProcess()
        {
            // Todo: Create an object from ProcessStartInfo
            // Implement your code here ...
            Console.WriteLine("This method is going to create a process ... ");
            Process process = new Process();
            process.StartInfo.FileName = "C:\\Program Files (x86)\\Microsoft\\Edge\\Application\\msedge.exe";
            process.StartInfo.CreateNoWindow = true;



            // Todo: Provide the path and the name of your executable file
            // Implement your code here


            //prInfo.CreateNoWindow = false; // This means start the process in a new window
            //prInfo.UseShellExecute = false;

            try
            {
                // Todo: Start your process and then wait for its exit
                // Implement your code here
                process.Start();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }

        }
    }
}
