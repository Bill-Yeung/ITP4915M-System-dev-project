using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class DatabaseApicaller
    {

        public async Task<DataTable> GetAPIResponse(string endpoint)
        {
            try
            {
                using (HttpClient client = new HttpClient())// create a client and use http 
                {
                    // addresss = find in the app.config file find this (server address)//5112 port
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServerAddress"]); // Adjust ServerAddress as needed

                    // Make the GET request to the API endpoint, and return the HTTPResponseMessage
                    HttpResponseMessage response = await client.GetAsync(endpoint);

                    // Check response successful 
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a JSON string
                        string jsonString = await response.Content.ReadAsStringAsync();
                        if (jsonString != "0")

                        // Convert the JSON string to a DataTable
                        {
                            DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(jsonString);

                            return dataTable;
                        }
                        else return null;
                    }
                    else
                    {
                        // Handle unsuccessful responses
                        throw new Exception($"API Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (HttpRequestException e)
            {
                // Handle request-specific exceptions
                MessageBox.Show($"Request error: {e.Message}");
                throw;
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                MessageBox.Show($"Can't convert to datatable: {ex.Message}");
                throw;
            }
        }

        public async Task<string> PostAPIResponse(string endpoint, object data)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServerAddress"]);

                    // Serialize the data to JSON
                    string jsonString = JsonConvert.SerializeObject(data);
                    StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    //StringContent 将 JSON 字符串包装成 HTTP 请求的内容，以便通过 HttpClient 发送到服务器。

                    //自动设置正确的 HTTP 请求头（Content - Type: application / json; charset = utf - 8）。

                    //确保数据以 UTF-8 编码 传输（支持中文等特殊字符）。
                    //真正的发送操作是在后续调用 HttpClient 的请求方法（如 PostAsync）时才会发生

                    // Make the POST request
                    HttpResponseMessage response = await client.PostAsync(endpoint, content);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        MessageBox.Show($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return "0";
                    }
                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Request error: {e.Message}");
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                throw;
            }
        }

    }

}
