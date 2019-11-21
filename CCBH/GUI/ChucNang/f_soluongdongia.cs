using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DevExpress.XtraEditors;
using System.IO.Ports;
using ControlLocalizer;

namespace GUI.ChucNang
{
    public partial class f_soluongdongia : DevExpress.XtraEditors.XtraForm
    {
        private int sec;
        private SerialPort _serialPort;
        private SerialPort _checkPort;//<-- declares a SerialPort Variable to be used throughout the form
        private const int BaudRate = 9600;

        public f_soluongdongia()
        {
            InitializeComponent();

            if (Biencucbo.banhang == true)
            {
                txtdongia.Text = Biencucbo.dongia.ToString();
                txtdongia.ReadOnly = true;

            }

            try
            {
                string port;
                string[] portNames = SerialPort.GetPortNames(); //<-- Reads all available comPorts
                foreach (var portName in portNames)
                {
                    
                   

                    if (_serialPort != null && _serialPort.IsOpen)
                        _serialPort.Close();
                    if (_serialPort != null)
                        _serialPort.Dispose();
                    //<-- End of Block

                    _serialPort = new SerialPort(portName, BaudRate, Parity.None, 8, StopBits.One);
                    //<-- Creates new SerialPort using the name selected in the combobox
                    _serialPort.DataReceived += SerialPortOnDataReceived;
                    //<-- this event happens everytime when new data is received by the ComPort
                    _serialPort.Open(); //<-- make the comport listen
                    lblinfo.Text = "Listening on " + _serialPort.PortName + "...\r\n";

                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void f_soluongdongia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (double.Parse(txtsoluong.Text) > 0 && double.Parse(txtdongia.Text) > 0)
                {
                    Biencucbo.soluong = double.Parse(txtsoluong.Text);
                    Biencucbo.dongia = double.Parse(txtdongia.Text);
                    DialogResult = DialogResult.OK;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void f_soluongdongia_Load(object sender, EventArgs e)
        {
            LanguageHelper.Translate(this);
            changeFont.Translate(this);
        }







     

        private delegate void Closure();

        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {

            try
            {
                if (InvokeRequired) //<-- Makes sure the function is invoked to work properly in the UI-Thread
                {
                    BeginInvoke(new Closure(() => { SerialPortOnDataReceived(sender, serialDataReceivedEventArgs); }));

                }
                //<-- Function invokes itself

                else
                {
                    int dataLength = _serialPort.BytesToRead;

                    byte[] data = new byte[dataLength];
                    int nbrDataRead = _serialPort.Read(data, 0, dataLength);
                    if (nbrDataRead == 0)
                        return;
                    string str = Encoding.UTF8.GetString(data);

                    int dd = str.Length - 4;
                    lblinfo.Text = str;
                    txtsoluong.Text = str.Substring(0, dd);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void f_soluongdongia_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _serialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }

}