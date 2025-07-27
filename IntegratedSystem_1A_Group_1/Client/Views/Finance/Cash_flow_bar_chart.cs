using Client.Controllers;
using ScottPlot;
using ScottPlot.TickGenerators;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Client.Views.Finance
{
    public partial class Cash_flow_bar_chart : Form
    {
        private DataTable paymentTable;
        private double warningThreshold = 200; // default set to 200

        public Cash_flow_bar_chart()
        {
            InitializeComponent();

            // set the title
            txtWarningValue.Text = warningThreshold.ToString();
            this.Load += Cash_flow_bar_chart_Load;
        }

        private async void Cash_flow_bar_chart_Load(object sender, EventArgs e)
        {
            try
            {
                string response = await APIController.ApiRequest("POST", "/Common/GetData/payment/true", null);
                paymentTable = Newtonsoft.Json.JsonConvert.DeserializeObject<DataTable>(response);
                PlotCashFlow(paymentTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"load data fail : {ex.Message}");
            }
        }

        private void PlotCashFlow(DataTable table)
        {
            if (table == null)
            {
                MessageBox.Show("no data load");
                return;
            }

            // monthlyData will hold the total payment amount for each month
            var monthlyData = table.AsEnumerable()
                .Where(row => row["paymentDate"] != DBNull.Value &&
                              row["paymentAmount"] != DBNull.Value)
                .Select(row => new
                {
                    Date = Convert.ToDateTime(row["paymentDate"]),
                    Amount = Convert.ToDouble(row["paymentAmount"])
                })
                .GroupBy(p => new { Year = p.Date.Year, Month = p.Date.Month })
                .Select(g => new
                {
                    YearMonth = $"{g.Key.Year}-{g.Key.Month:D2}",
                    TotalAmount = g.Sum(x => x.Amount)
                })
                .OrderBy(g => g.YearMonth)
                .ToList();

            if (!monthlyData.Any())
            {
                MessageBox.Show("No data");
                return;
            }

            // preppulate the x-axis labels and values
            string[] monthLabels = monthlyData.Select(m => m.YearMonth).ToArray();
            double[] values = monthlyData.Select(m => m.TotalAmount).ToArray();

            formsPlot1.Plot.Clear();

            // 1. create warning line
            var warningLine = formsPlot1.Plot.Add.HorizontalLine(warningThreshold);
            warningLine.LineColor = ScottPlot.Colors.Red;
            warningLine.LineWidth = 2;
            warningLine.LinePattern = ScottPlot.LinePattern.DenselyDashed;
            warningLine.Label.Text = $"Warning Line ({warningThreshold} HKD)";

            // 2. create legend
            formsPlot1.Plot.ShowLegend();

            // 3. Create bar chart
            var bars = new List<ScottPlot.Bar>();
            for (int i = 0; i < values.Length; i++)
            {
                bars.Add(new ScottPlot.Bar
                {
                    Position = i,
                    Value = values[i],
                    Size = 0.8,
                    FillColor = ScottPlot.Colors.CornflowerBlue
                });
            }
            formsPlot1.Plot.Add.Bars(bars);

            // set the x-axis labels
            var tickGen = new ScottPlot.TickGenerators.NumericManual();
            for (int i = 0; i < monthLabels.Length; i++)
            {
                tickGen.AddMajor(i, monthLabels[i]);
            }
            formsPlot1.Plot.Axes.Bottom.TickGenerator = tickGen;

            // set the title and labels
            formsPlot1.Plot.Title("Income per month");
            formsPlot1.Plot.YLabel("Amount (HKD)");
            formsPlot1.Plot.XLabel("Months");
            formsPlot1.Plot.Axes.Bottom.TickLabelStyle.Rotation = 45;
            formsPlot1.Plot.Axes.AutoScale();

            // refresh the plot
            formsPlot1.Refresh();
        }

 
        private void BtnSet_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtWarningValue.Text, out double newThreshold))
            {
                warningThreshold = newThreshold;
                if (paymentTable != null)
                {
                    PlotCashFlow(paymentTable);
                }
                else
                {
                    MessageBox.Show("Data can't load");
                }
            }
            else
            {
                MessageBox.Show("Please input vaild value");
            }
        }
    }
}
