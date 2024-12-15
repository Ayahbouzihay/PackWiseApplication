using Homework2Bouzihay.Pages.PythonFunctions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Homework2Bouzihay.Pages
{
    public class PythonOutputModel : PageModel
    {
        private readonly PythonService _pythonService;

        public PythonOutputModel(PythonService pythonService)
        {
            _pythonService = pythonService;
        }

        public string Output { get; private set; }

        public void OnGet()
        {
            string scriptPath = "C:\\Users\\theun\\PycharmProjects\\Ryan_Dowd_CYBR493A_Fall24\\Training\\HelloWorld.py"; // Full path to file we want to run
            Output = _pythonService.RunPythonScript(scriptPath);
            Console.WriteLine(Output);
        }
    }
}

