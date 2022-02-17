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

            /**
             * Initialize some components with specific values:
             * - Stop server button hidden
             **/
            stopButton.Visible = false;

            // Set minimum screen width & height 
            MinimumSize = new Size(550, 275);
        }

        // Starts the server
        private async void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Checks if all inputs are valid
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

                    // Accepts clients trying to connect
                    // Will also start seperate messageListener Task
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

        // Stops the server
        private async void stopButton_Click(object sender, EventArgs e)
        {
            await messageAllClients("[Server] Host has shut down the server");

            // Loops all connected clients and closes them
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

        // Listens for new messages from clients
        // Also uses StringBuilder to build messages with smaller buffer sizes
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

        // Sends the received message to all the clients
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

        // Parses input (string) to output (int)
        public static int parseInt(string input)
        {
            int.TryParse(input, out int output);
            return output;
        }

        // Parses input ip adress (string), port (string) and buffersize (string) 
        // And checks if everything valid 
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

        // In case the host closes the form directly it will still stop the server
        private async void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopButton.PerformClick();
        }
    }
}