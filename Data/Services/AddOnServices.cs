using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using BisleriumCafe.Data.Model;
using BisleriumCafe.Data.Utils;

namespace BisleriumCafe.Data.Services
{
    public class AddOnServices
    {
        public static void SaveAddOnsToJson(List<AddOns> addOn)
        {
            // Gets the file path where form data will be stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.AddOnsFilePath();

            // Serialize the list of hobbies to JSON format with formatting Indented and store it in Variable jsonData
            string jsonData = JsonConvert.SerializeObject(addOn, Formatting.Indented);

            // Write the JSON data to the file given from filePath variable and data from jsonData variable.
            File.WriteAllText(filePath, jsonData);
        }

        //This method Injects the data Into the Json File Manually by creating the multiple objects and Passing it to the list only if the data inside the file is empty.
        public static void InjectSampleAddOnsData()
        {
            // Gets the file path where hobby data will be stored from HobbiesFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.AddOnsFilePath();

            // Read existing data from the file and store it in variable existingData
            var existingData = File.ReadAllText(filePath);

            // If the file is empty, injects a list of sample hobby data in a object of List<Hobby> called sampleHobbies first and saves it in a Json File by calling method SaveHobbiesToJson.
            if (string.IsNullOrEmpty(existingData))
            {
                List<AddOns> sampleAddOns = new List<AddOns>
            {
                new AddOns { Name = "Caramel" },
                new AddOns { Name = "Chocolate" },
                new AddOns { Name = "Honey" },
                new AddOns { Name = "Hazelnut" },
                new AddOns { Name = "WhipCream"},
                new AddOns { Name = "Butter"},
                new AddOns { Name = "Espresso"},
            };
                SaveAddOnsToJson(sampleAddOns); // Save the sample hobby data to the JSON file by calling SaveHobbiesToJson Method and passing sampleHobbies as it Argument.
            }
        }

        // Retrieves hobby data from the JSON file.
        public static List<AddOns> RetrieveAddOnsData()
        {
            // Gets the file path where hobby data is stored from HobbiesFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.AddOnsFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); // Read existing JSON data from the file.

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of Hobby objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<AddOns>();
                }
                return JsonConvert.DeserializeObject<List<AddOns>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                return new List<AddOns>();
            }
        }

        public static List<CoffeeModel> RetrieveCoffeeData()
        {
            // Gets the file path where hobby data is stored from HobbiesFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.CoffeeDataFilePath();
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

        // Retrieves a specific hobby by its Id.
        public static AddOns GetAddOnById(int id)
        {
            List<AddOns> addOns = RetrieveAddOnsData(); // Retrieves the list of hobbies and stores it in hobbies object
            
            // Return the first hobby with the specified Id.
            return addOns.FirstOrDefault(x => x.Id == id); //creating arrow function and checking whether the Id of Hobbies is equal to the id of parameter that recieves value later on.
        }

        // Edits the name of a specific hobby.
        public static List<AddOns> EditNewPrice(string id, string newPrice)
        {
            int addInId = Convert.ToInt32(id);
            //Retrieve the list of hobbies.
            List<AddOns> addOns = RetrieveAddOnsData();
             //Find the hobby with the specified Id.
            AddOns editAddOns = addOns.FirstOrDefault(x => x.Id == addInId);
            // If the hobby is not found, throw an exception.
            if (editAddOns == null)
            {
                throw new Exception("AddOns not found");
            }
            // Update the name of the hobby.
            editAddOns.Price = newPrice;
            SaveAddOnsToJson(addOns); // Save the updated list of hobbies to the JSON file by calling method SaveHobbiesToJson
            return addOns;  // Return the updated list of hobbies.
        }
    }
}
