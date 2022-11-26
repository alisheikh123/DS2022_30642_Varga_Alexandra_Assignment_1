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
        AddEngergyConsumptionDto obj = new AddEngergyConsumptionDto();
        private async void button1_Click(object sender, EventArgs e)
        {
            // Create List of Dropdown

            List<UserName> usersList = new List<UserName>();
            List<Device> devicesList = new List<Device>();

            usersList.Add(new UserName() { Id = "4b62ef58-6e0f-4678-bf99-af486d4cfa00", UserNm = "Alexendra Loana" });
            usersList.Add(new UserName() { Id = "0d238ff9-f48a-4152-a873-97db74b4996c", UserNm = "Ali" });


            devicesList.Add(new Device() { Id = "3", DeviceNm = "Register" });
            devicesList.Add(new Device() { Id = "4", DeviceNm = "Mobile" });
            devicesList.Add(new Device() { Id = "2", DeviceNm = "Song " });
            devicesList.Add(new Device() { Id = "1", DeviceNm = "Headphones" });

            // Assign to specific combobox
            cboDevice.Items.Clear();
            cboUserName.Items.Clear();


            cboUserName.DataSource = usersList;
            cboUserName.ValueMember = "Id";
            cboUserName.DisplayMember = "UserNm";


            cboDevice.DataSource = devicesList;
            cboDevice.ValueMember = "Id";
            cboDevice.DisplayMember = "DeviceNm";


           



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cboUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblValue.Text= cboUserName.Text;
            obj.UserId = cboUserName.SelectedValue.ToString();
        }

        private void cboDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDevice.Text = cboDevice.Text;
            obj.DeviceId = cboDevice.SelectedValue.ToString();
        }

        private async void genbtn_Click(object sender, EventArgs e)
        {
            // Create Consumer Connection
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
                    //AddEngergyConsumptionDto obj = new AddEngergyConsumptionDto();
                    var records = csv.GetRecords<EnergyConsumptionDto>().ToList();
                    for (int i = 0; i < records.Count; i++)
                    {
                        obj.EnergyConsumption = records[i].Name.ToString();
                        obj.CurrentDate = DateTime.Now;
                        obj.Hours = "0.16";
                        var jsonmessage = new AddEngergyConsumptionDto
                        {
                            UserId = obj.UserId,
                            DeviceId = obj.DeviceId,
                            EnergyConsumption = obj.EnergyConsumption,
                            Hours = obj.Hours,
                            CurrentDate = obj.CurrentDate,
                            Count = records.Count()

                        };
                        var message = JsonConvert.SerializeObject(jsonmessage);
                       var encodeMessage = Encoding.Default.GetBytes(JsonConvert.SerializeObject(Regex.Replace(message, @"\s+", "")));
                        channel.BasicPublish("", "letterbox", null, encodeMessage);
                        Console.WriteLine($"Published Message:{obj}");
                        await Task.Delay(10000);
                        //await Task.Delay(600000);

                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
