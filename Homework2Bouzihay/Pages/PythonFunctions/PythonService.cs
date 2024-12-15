using System.Diagnostics;


namespace Homework2Bouzihay.Pages.PythonFunctions

{
    public class PythonService
    {
        public string RunPythonScript(string scriptPath)
        {
            try
            {
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = "C:\\Users\\theun\\miniconda3\\python.exe", // Path to the python.exe file make sure that you're getting it from Users
                    Arguments = "C:\\Users\\theun\\PycharmProjects\\Ryan_Dowd_CYBR493A_Fall24\\Training\\HelloWorld.py" //path to file we want to run
,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = new Process { StartInfo = processStartInfo })
                {
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();

                    return string.IsNullOrEmpty(error) ? output : $"Error: {error}";
                }
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }
    }
}
