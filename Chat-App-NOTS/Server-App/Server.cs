using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server_App
{
    public partial class Server : Form
    {
        private TcpClient tcpClient;
        private TcpListener tcpListener;
        private List<TcpClient> tcpClientList = new();

        public Server()
        {
            InitializeComponent();
            stopButton.Visible = false;

            MinimumSize = new Size(550, 275);
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (parseInputs(ipValue.Text, portValue.Text, buffersizeValue.Text))
                {
                    tcpListener = new TcpListener(IPAddress.Parse(ipValue.Text), parseInt(portValue.Text));
                    tcpListener.Start();

                    startButton.Visible = false;
                    stopButton.Visible = true;
                    ipValue.Enabled = false;
                    portValue.Enabled = false;
                    buffersizeValue.Enabled = false;

                    chatValue.Items.Add("[Server] Opening connection @" + ipValue.Text + ":" + portValue.Text);

                    while (true)
                    {
                        tcpClient = await tcpListener.AcceptTcpClientAsync();
                        tcpClientList.Add(tcpClient);
                        messageListener(tcpClient);
                    }
                }
                else
                {
                    chatValue.Items.Add("[Server] Incorrect setting(s)");
                }
            } catch (SocketException)
            {
                chatValue.Items.Add("[Server] Connection closed");
            }
        }

        private async void stopButton_Click(object sender, EventArgs e)
        {
            await messageAllClients("[Server] Host has shut down the server");

            foreach (TcpClient tcpClient in tcpClientList)
            {
                tcpClient.Close();
            }

            tcpClientList.Clear();

            try
            {
                tcpListener.Stop();
                startButton.Visible = true;
                stopButton.Visible = false;
                ipValue.Enabled = true;
                portValue.Enabled = true;
                buffersizeValue.Enabled = true;
            } catch (SocketException)
            {
                chatValue.Items.Add("[Server] Couldn't stop the server");
            }

        }

        private async Task messageListener(TcpClient tcpClient)
        {
            byte[] buffer = new byte[parseInt(buffersizeValue.Text)];
            NetworkStream networkStream = tcpClient.GetStream();
            int numberOfBytesRead;
            try
            {
                while (true)
                {
                    StringBuilder buildMessage = new StringBuilder();

                    if (networkStream.CanRead)
                    {
                        do
                        {
                            numberOfBytesRead = await networkStream.ReadAsync(buffer, 0, buffer.Length);
                            if (numberOfBytesRead > 0)
                            {
                                buildMessage.Append(Encoding.ASCII.GetString(buffer, 0, numberOfBytesRead));
                            }
                            else
                            {
                                tcpClient.Close();
                                tcpClientList.Remove(tcpClient);
                            }
                        } while (networkStream.DataAvailable);

                        chatValue.Items.Add(buildMessage);
                        await messageAllClients(buildMessage.ToString());
                    }
                }
            } catch
            {
                tcpClient.Close();
                tcpClientList.Remove(tcpClient);
            }
        }
        private async Task messageAllClients(string msg)
        {
            if (tcpClientList.Count > 0)
            {
                foreach (TcpClient tcpClient in tcpClientList)
                {
                    NetworkStream networkStream = tcpClient.GetStream();

                    if (networkStream.CanRead)
                    {
                        byte[] serverMessageByteArray = Encoding.ASCII.GetBytes(msg);
                        await networkStream.WriteAsync(serverMessageByteArray, 0, serverMessageByteArray.Length);
                    }
                }
            }
        }
        public static int parseInt(string input)
        {
            int.TryParse(input, out int output);
            return output;
        }
        public static bool parseInputs(string ip, string port, string bufferSize)
        {
            bool checkIP = IPAddress.TryParse(ip, out IPAddress iPAddress);
            bool checkPort = port.All(char.IsDigit) && parseInt(port) <= 65535 && parseInt(port) > 0;
            bool checkBufferSize = bufferSize.All(char.IsDigit) && parseInt(bufferSize) <= 1024 && parseInt(bufferSize) > 0;

            if (checkIP && checkPort && checkBufferSize)
            {
                return true;
            } else
            {
                return false;
            }
        }

        private async void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopButton.PerformClick();
            Environment.Exit(0);
        }
    }
}