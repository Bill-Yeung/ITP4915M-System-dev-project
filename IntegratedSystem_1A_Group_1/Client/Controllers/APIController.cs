using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public static class APIController
    {

        public static async Task<string> ApiRequest(string type, string endpoint, Object? data)
        {

            try
            {

                using (HttpClient client = new HttpClient())
                {
                    
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServerAddress"]);
                    HttpResponseMessage response;

                    if (type == "GET")
                    {
                        response = await client.GetAsync(endpoint);
                    }
                    else if (type == "POST")
                    {
                        string jsonString = JsonConvert.SerializeObject(data);
                        StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                        response = await client.PostAsync(endpoint, content);
                    }
                    else
                    {
                        throw new Exception();
                    }

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        // Log the status code and reason
                        string error = $"Error: {response.StatusCode} - {response.ReasonPhrase}";
                        MessageBox.Show(error);
                        return error;
                    }

                }
            }
            catch (HttpRequestException e)
            {
                MessageBox.Show($"Request error: {e.Message}");
                return $"Request error: {e.Message}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return $"An error occurred: {ex.Message}";
            }

        }

        public static async Task<string> UploadFile(string filePath, string nextFileID)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    using (MultipartFormDataContent form = new MultipartFormDataContent())
                    {

                        using (var fileStream = File.OpenRead(filePath))
                        {

                            var streamContent = new StreamContent(fileStream);
                            streamContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                            form.Add(streamContent, "file", Path.GetFileName(filePath));
                            form.Add(new StringContent(nextFileID), "nextFileID");

                            var fullUrl = ConfigurationManager.AppSettings["ServerAddress"] + ConfigurationManager.AppSettings["UploadLink"];
                            HttpResponseMessage response = await client.PostAsync(fullUrl, form);

                            if (response.IsSuccessStatusCode)
                            {
                                return await response.Content.ReadAsStringAsync();
                            }
                            else
                            {
                                return $"Error: {response.ReasonPhrase}";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return "Exception: " + ex.Message;
            }

        }

        public static async Task DownloadFile(string filePath, string fileName)
        {

            string localPath = Path.Combine(Path.GetTempPath(), fileName);

            try
            {

                using (HttpClient client = new HttpClient())
                {
                    byte[] fileBytes = await client.GetByteArrayAsync(filePath);
                    await File.WriteAllBytesAsync(localPath, fileBytes);
                }

                ProcessStartInfo psi = new ProcessStartInfo
                {
                    FileName = localPath,
                    UseShellExecute = true
                };
                Process.Start(psi);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error downloading or opening the document: " + ex.Message);
            }

        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }

}
