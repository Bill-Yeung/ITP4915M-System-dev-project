using Client.Controllers;
using EntityModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel.DataAnnotations.Schema;


namespace Client.Common
{
    public static class Helper
    {

        public static async Task<string?> GenerateNextId(string tableName, string primaryKey)
        {

            string lastId = await APIController.ApiRequest("GET", $"/Common/GetLastId?tableName={tableName}&primaryKey={primaryKey}", null);

            if (string.IsNullOrEmpty(lastId))
            {
                return null;
            }

            var isMatched = Regex.Match(lastId, @"^(?<prefix>[A-Za-z]+)(?<number>\d+)$");
            if (!isMatched.Success)
            {
                throw new ArgumentException("Invalid ID format. Expected format: Letters followed by numbers.");
            }

            string prefixString = isMatched.Groups["prefix"].Value;
            string numberString = isMatched.Groups["number"].Value;
            int number = int.Parse(numberString) + 1;
            string newNumberString = number.ToString().PadLeft(numberString.Length, '0');

            return prefixString + newNumberString;

        }

        public static void FillComboBoxByDatabase<T>(string jsonString, ComboBox[] cbList, string primaryKey, string columnKey)
        {

            List<T> list = JsonConvert.DeserializeObject<List<T>>(jsonString);

            foreach (ComboBox cb in cbList)
            {
                cb.BindingContext = new BindingContext();
                cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.DataSource = list;
                cb.DisplayMember = columnKey;
                cb.ValueMember = primaryKey;
                cb.SelectedIndex = -1;
                cb.Text = "Please select";
                cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb.AutoCompleteSource = AutoCompleteSource.ListItems;
                cb.Leave += ComboBox_Leave;
            }

        }

        public static void FillComboBoxByArray(ComboBox[] cbList, string[] items)
        {

            foreach(ComboBox cb in cbList)
            {
                cb.BindingContext = new BindingContext();
                cb.DropDownStyle = ComboBoxStyle.DropDown;
                cb.Items.AddRange(items);
                cb.SelectedIndex = -1;
                cb.Text = "Please select";
                cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cb.AutoCompleteSource = AutoCompleteSource.ListItems;
                cb.Leave += ComboBox_Leave;
            }
            
        }

        public static void ComboBox_Leave(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            if (!cb.Items.Contains(cb.SelectedItem))
            {
                MessageBox.Show("Please select from the list!");
                cb.SelectedIndex = -1;
                cb.Text = "Please select";
            }
        }

        public static async Task<List<ProductMaterialVersion>> GetLatestMaterialVersion(string productID)
        {

            var productKey = new
            {
                productID = productID
            };

            string result3 = await APIController.ApiRequest("POST", "/Common/GetData/ProductMaterialVersion/false", Helper.ToDictionary(productKey));
            List<ProductMaterialVersion>productMaterialList = (JsonConvert.DeserializeObject<List<ProductMaterialVersion>>(result3)).OrderByDescending(p => p.versionID).ToList() ?? new List<ProductMaterialVersion>();

            var relevantMaterials = productMaterialList.Select(m => m.materialID).Distinct().OrderBy(m => m).ToList();
            var sortedList = new List<ProductMaterialVersion>();

            foreach (var m in relevantMaterials)
            {

                foreach (var p in productMaterialList)
                {

                    if (p.materialID != m || p.versionStatus != "Approved")
                    {
                        continue;
                    }

                    sortedList.Add(p);
                    break;

                }

            }

            return sortedList;

        }

        public static List<Dictionary<string, object>> ToDictionaryList<T>(List<T> list)
        {
            return list.Select(item => ToDictionary(item)).ToList();
        }

        public static Dictionary<string, object> ToDictionary(Object data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "Data cannot be null.");
            }

            var dictionary = new Dictionary<string, object>();
            var properties = data.GetType().GetProperties().Where(p => !Attribute.IsDefined(p, typeof(NotMappedAttribute)));

            foreach (var prop in properties)
            {
                var value = prop.GetValue(data);
                if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
                {
                    dictionary.Add(prop.Name, value);
                }
            }

            return dictionary;
        }

        public static void SaveControlAsPdf(Control ctrl, string pdfPath)
        {
            
            using (var bmp = new Bitmap(ctrl.Width, ctrl.Height))
            {
                ctrl.DrawToBitmap(bmp, new Rectangle(0, 0, bmp.Width, bmp.Height));

                using (var ms = new MemoryStream())
                {

                    bmp.Save(ms, ImageFormat.Png);
                    ms.Position = 0;

                    var document = new PdfDocument();
                    var page = document.AddPage();

                    using (var img = XImage.FromStream(ms))
                    {
                        page.Width = XUnit.FromPoint(img.PointWidth);
                        page.Height = XUnit.FromPoint(img.PointHeight);

                        using (var gfx = XGraphics.FromPdfPage(page))
                        {
                            gfx.DrawImage(img, 0, 0, img.PointWidth, img.PointHeight);
                        }
                    }

                    document.Save(pdfPath);

                }
            }

        }

    }

}
