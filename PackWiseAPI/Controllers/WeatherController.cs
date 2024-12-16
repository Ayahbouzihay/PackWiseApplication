using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{

  
    // Define WeatherRequest class inside the controller
    public class WeatherRequest
    {
        public string City { get; set; }
        public string Date { get; set; }
        public string State { get; set; }
    }

    [HttpPost("getWeather")]
    public IActionResult GetWeather([FromBody] WeatherRequest request)
    {
        try
        {
            // Call the Python script and get the result
            string result = CallPythonScript(request.City, request.Date, request.State);

            // Check if the result is empty or null
            if (string.IsNullOrEmpty(result))
            {
                return BadRequest("No data returned from the weather service.");
            }

            // Deserialize the result (assuming the result is a JSON string)
            var weatherData = JsonConvert.DeserializeObject<object>(result);  // Use the appropriate type instead of object if possible

            return Ok(weatherData);  // Return the deserialized JSON response
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }

    private string CallPythonScript(string city, string date, string state)
    {
        // Define path to Python executable and the script
        string pythonExePath = @"C:\Users\ayahb\miniconda3\python.exe";  // Path to your Python executable
        string scriptPath = @"C:\Users\ayahb\Source\Repos\Ayahbouzihay\Homework2Bouzihay\PackWiseAPI\pythonScripts\PackWiseWeatherIntegration.py";  // Path to your Python script

        // Set up the arguments for the script (city, date, state)
        string arguments = $"{city} {state} {date}";  // Pass only city, state, date to the script

        // Set up the ProcessStartInfo
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = pythonExePath,
            Arguments = arguments,  // This is where you pass the arguments to the Python script
            RedirectStandardOutput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        // Execute the Python script
        try
        {
            using (Process process = Process.Start(startInfo))
            using (StreamReader reader = process.StandardOutput)
            {
                string output = reader.ReadToEnd();
                return output; // Return the output from the Python script
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error executing Python script: " + ex.Message);
        }
    }
}