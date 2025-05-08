using System;
using System.IO.Ports;
using System.Media;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameShow
{
    public partial class GameShowMain : Form
    {
        static SerialPort serialPort;
        static SoundPlayer soundPlayer;

        public GameShowMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadAvailablePorts();
            soundPlayer = new SoundPlayer("CompetenciaSound.wav");
            soundPlayer.Load();

        }

        private void LoadAvailablePorts()
        {
            CboPuertos.Items.Clear();
            string[] ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            CboPuertos.Items.AddRange(ports);

            if (ports.Length > 0)
                CboPuertos.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadAvailablePorts();

        }

        private void ListenToSerialPort()
        {
            try
            {
                // Set the COM port and settings here
                string portName = (string)CboPuertos.SelectedItem; // Change as needed
                int baudRate = 9600;
                                
                serialPort = new SerialPort(portName, baudRate);
                serialPort.DtrEnable = true;
                serialPort.DataReceived += SerialDataReceived;
                serialPort.Open();

                soundPlayer.Play();
                MessageBox.Show("Started");
            }
            catch (Exception ex)
            {
               MessageBox.Show(ex.Message);
            }
        }

        void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine().Trim();
                Console.WriteLine($"Received: {data}");

                if (Regex.IsMatch(data, @"^Player [1-4]$", RegexOptions.IgnoreCase))
                {
                    ShowPlayer(data);
                }
                else if (data == "Reset" || data == "Init")
                {
                    Reset();
                }
                else
                {
                    //wdf
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading from serial port: " + ex.Message);
            }
        }

        void ShowPlayer(string player)
        {
            int playerNumber = int.Parse(player.Split(' ')[1]);      

            Invoke(new Action(() =>
            {
                labelPlayer.Text = $"Jugador {playerNumber}";
                soundPlayer.Play();
            }));
        }

        void Reset()
        {
            Invoke(new Action(() =>
            {
                labelPlayer.Text = $"-";
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ListenToSerialPort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btnListen.Visible = !btnListen.Visible;
            CboPuertos.Visible = !CboPuertos.Visible;
            btnRefresh.Visible = !btnRefresh.Visible;

            if (btnListen.Visible)
            {
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.TopMost = false;
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.TopMost = true;
                this.WindowState = FormWindowState.Maximized;
            }
        }
    }
}
