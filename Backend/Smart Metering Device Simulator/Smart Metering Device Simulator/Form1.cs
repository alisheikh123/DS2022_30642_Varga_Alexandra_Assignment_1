using CsvHelper;
using Newtonsoft.Json;
using OfficeOpenXml;
using RabbitMQ.Client;
using Smart_Metering_Device_Simulator.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Smart_Metering_Device_Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
             var connection = factory.CreateConnection();
             var channel = connection.CreateModel();
            try
            {
                var path = @"D:\upwork\Alexandra Varga\DS2022_Group_LastName_FirstName_Assignment_Number\Backend\Smart Metering Device Simulator\Smart Metering Device Simulator\File\sensor2.csv";
                channel.QueueDeclare(queue: "letterbox", durable: false, exclusive: false, autoDelete: false, arguments: null);
                using (var reader = new StreamReader(path, Encoding.Default))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    AddEngergyConsumptionDto obj = new AddEngergyConsumptionDto();
                    var records = csv.GetRecords<EnergyConsumptionDto>().ToList();
                    for (int i = 0; i < records.Count; i++)
                    {
                        obj.UserId = "4B62EF58-6E0F-4678-BF99-AF486D4CFA00";
                        obj.EnergyConsumption = records[i].Name.ToString();
                        obj.DeviceId = "3";
                        obj.CurrentDate= DateTime.Now;
                        obj.Hours = "0.16";
                        var jsonmessage = new AddEngergyConsumptionDto
                        {
                                UserId=obj.UserId,
                                DeviceId=obj.DeviceId,
                                EnergyConsumption=obj.EnergyConsumption,
                                Hours = obj.Hours,
                                CurrentDate = obj.CurrentDate,
                                Count = records.Count()

                        };
                        var message = JsonConvert.SerializeObject(jsonmessage);
                        var encodeMessage = Encoding.Default.GetBytes(JsonConvert.SerializeObject(Regex.Replace(message, @"\s+", "")));
                        await Task.Delay(12000);
                        channel.BasicPublish("", "letterbox", null, encodeMessage);
                        Console.WriteLine($"Published Message:{obj}");
                       
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
