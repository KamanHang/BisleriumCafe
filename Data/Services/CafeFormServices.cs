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
    public class CafeFormServices
    {
        public static void SaveFormDataInJson(PlaceOrderModel form)
        {
            // Gets the file path where form data will be stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.ApplicationFilePath();
            try // Deserialize existing JSON data from the file into a list of AddForm objects called formList.
            {
                List<PlaceOrderModel> formList; // object of List of AddForm i.e. formList
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existingJSONData variable is empty, initialize a new list; otherwise, deserialize the data.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    formList = new List<PlaceOrderModel>();
                }
                else
                {
                    formList = JsonConvert.DeserializeObject<List<PlaceOrderModel>>(existingJsonData);
                }
                // Add the current form to the list.
                formList.Add(form);

                // Serialize the updated list of form data to JSON format with formatting Indented and store it in a variable formJsonData
                string formJsonData = JsonConvert.SerializeObject(formList, Formatting.Indented);

                // Write the JSON data back to the file.
                File.WriteAllText(filePath, formJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", $"Error Saving Data", "OK");
            }
        }


        // Retrieves form data from the JSON file.
        public static List<PlaceOrderModel> RetrieveFormData()
        {
            // Gets the file path where form data is stored from ApplicationFilePath method
            // in FormUtils class in Utils Folder and stores it in the variable filePath.
            string filePath = FormUtils.ApplicationFilePath();
            try
            {
                string existingJsonData = File.ReadAllText(filePath); //ReadAllText reads the datas inside the file from filePath Variable and Stores in variable called existingJsonData

                // If the existing JSON data is empty, return an empty list;
                // otherwise, deserialize the data into a list of AddForm objects.
                if (string.IsNullOrEmpty(existingJsonData))
                {
                    return new List<PlaceOrderModel>();
                }
                return JsonConvert.DeserializeObject<List<PlaceOrderModel>>(existingJsonData);
            }
            catch (Exception ex)
            {
                // Handle exceptions by displaying an alert with the error message.
                Console.WriteLine($"Error reading JSON file: {ex.Message}");
                App.Current.MainPage.DisplayAlert("Error", "Error Retrieving Data from Json", "OK");
                return new List<PlaceOrderModel>();
            }
        }

        

        
    }
}
