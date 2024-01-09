using System;
using System.Collections.Generic;
using System.IO;  // Add this for File.ReadAllText
using BisleriumCafe.Data.Model;
using BisleriumCafe.Data.Utils;
using Newtonsoft.Json;


namespace BisleriumCafe.Data.Services
{
    public class CoffeeServices
    {
        public static List<CoffeeModel> RetrieveCoffeeData()
        {
            // Gets the file path where hobby data is stored from HobbiesFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.CoffeeDataFilePath();

            System.Diagnostics.Debug.WriteLine(filePath);

            try
            {
                string existingJsonData = File.ReadAllText(filePath); // Read existing JSON data from the file.

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of Hobby objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<CoffeeModel>();
                }
                return JsonConvert.DeserializeObject<List<CoffeeModel>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return new List<CoffeeModel>();
            }
        }
    }
}
