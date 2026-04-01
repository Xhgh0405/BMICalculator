using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace BMI計算機
{
    public partial class frmHistory : Form
    {
        private string username;
        private string recordFilePath = "records.txt";

        public frmHistory(string user)
        {
            InitializeComponent();
            username = user;
        }



        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void frmHistory_Load(object sender, EventArgs e)
        {
            this.Text = username + " 的 BMI 歷史紀錄";

            chartBMI.Series.Clear();
            chartBMI.ChartAreas.Clear();

            ChartArea area = new ChartArea("MainArea");
            area.AxisX.Title = "次數";
            area.AxisY.Title = "BMI";
            chartBMI.ChartAreas.Add(area);

            Series series = new Series("BMI");
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 3;
            series.MarkerStyle = MarkerStyle.Circle;
            series.MarkerSize = 8;

            chartBMI.Series.Add(series);

            if (!File.Exists(recordFilePath))
            {
                MessageBox.Show("找不到紀錄檔。");
                return;
            }

            string[] lines = File.ReadAllLines(recordFilePath);
            int x = 1;

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 3 && parts[0] == username)
                {
                    double bmi;
                    if (double.TryParse(parts[2], out bmi))
                    {
                        series.Points.AddXY(x, bmi);
                        x++;
                    }
                }
            }

            if (series.Points.Count == 0)
            {
                MessageBox.Show("這個帳號目前沒有歷史紀錄。");
            }

        }
    }
}
