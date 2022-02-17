using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client_App
{
    public partial class Client : Form
    {
        private TcpClient tcpClient;
        private NetworkStream networkStream;

        public Client()
        {
            InitializeComponent();

            /**
             * Initialize some components with specific values:
             * - Submit button disabled
             * - Leave button hidden
             **/
            submitButton.Enabled = false;
            leaveButton.Visible = false;

            // Set minimum screen width & height
            MinimumSize = new Size(550, 325);
        }

        // Connects client to server
        private async void joinButton_Click(object sender, EventArgs e) { 
            try
            {
                // Checks if all inputs are valid
                if (parseInputs(usernameValue.Text, ipValue.Text, portValue.Text, buffersizeValue.Text))
                {
                    tcpClient = new TcpClient();
                    await tcpClient.ConnectAsync(ipValue.Text, parseInt(portValue.Text));
                    networkStream = tcpClient.GetStream();

                    joinButton.Visible = false;
                    leaveButton.Visible = true;
                    submitButton.Enabled = true;
                    usernameValue.Enabled = false;
                    ipValue.Enabled = false;
                    portValue.Enabled = false;
                    buffersizeValue.Enabled = false;

                    byte[] message = Encoding.ASCII.GetBytes("[Server] " + usernameValue.Text + " has connected to the server");
                    await networkStream.WriteAsync(message, 0, message.Length);

                    messageListener();
                }
                else
                {
                    chatValue.Items.Add("[Client] Incorrect input(s)");
                }
            } catch (SocketException)
            {
                chatValue.Items.Add("[Server] Destination Unreachable " + ipValue.Text + ":" + portValue.Text);
            }
        }

        // Disconnects client from server
        private async void leaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                chatValue.Items.Add("[Server] Disconnecting from " + ipValue.Text + ":" + portValue.Text);
                byte[] message = Encoding.ASCII.GetBytes(usernameValue.Text + " has disconnected from the server");
                await networkStream.WriteAsync(message, 0, message.Length);

                joinButton.Visible = true;
                leaveButton.Visible = false;
                submitButton.Enabled = false;
                usernameValue.Enabled = true;
                ipValue.Enabled = true;
                portValue.Enabled = true;
                buffersizeValue.Enabled = true;

                tcpClient.Close();
            }
            catch (SocketException)
            {
                byte[] message = Encoding.ASCII.GetBytes("[Server] An error has occurred when trying to disconnect");
                await networkStream.WriteAsync(message, 0, message.Length); ;
            }
        }

        // Submit messages
        private async void submitButton_Click(object sender, EventArgs e)
        {
            if(messageValue.Text.Length > 0){
                byte[] message = Encoding.ASCII.GetBytes("[" + usernameValue.Text + "]: "+ messageValue.Text);
                await networkStream.WriteAsync(message, 0, message.Length);
                messageValue.Clear();
                messageValue.Focus();
            }
        }

        // Receives new messages from others
        private async Task messageListener()
        {
            byte[] buffer = new byte[parseInt(buffersizeValue.Text)];
            NetworkStream networkStream = tcpClient.GetStream();
            int numberOfBytesRead;

            if (networkStream.CanRead)
            {
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
                                    joinButton.Visible = true;
                                    leaveButton.Visible = false;
                                    submitButton.Enabled = false;
                                    usernameValue.Enabled = true;
                                    ipValue.Enabled = true;
                                    portValue.Enabled = true;
                                    buffersizeValue.Enabled = true;
                                }

                            } while (networkStream.DataAvailable);

                            chatValue.Items.Add(buildMessage);
                        }
                    }
                }
                catch
                {
                    tcpClient.Close();
                    joinButton.Visible = true;
                    leaveButton.Visible = false;
                    submitButton.Enabled = false;
                    usernameValue.Enabled = true;
                    ipValue.Enabled = true;
                    portValue.Enabled = true;
                    buffersizeValue.Enabled = true;
                }
            }
        }

        // Parses input (string) to output (int)
        public static int parseInt(string input)
        {
            int.TryParse(input, out int output);
            return output;
        }

        // Parses inputs username (string), ip adress (string), port (string) and buffersize (string)
        // And checks if everything is valid
        public static bool parseInputs(string username, string ip, string port, string bufferSize)
        {
            bool checkUsername = username.All(char.IsLetterOrDigit) && username.Length > 0 && username.Length < 20;
            bool checkIP = IPAddress.TryParse(ip, out IPAddress iPAddress);
            bool checkPort = port.All(char.IsDigit) && parseInt(port) <= 65535 && parseInt(port) > 0;
            bool checkBufferSize = bufferSize.All(char.IsDigit) && parseInt(bufferSize) <= 1024 && parseInt(bufferSize) > 0;

            if (checkUsername && checkIP && checkPort && checkBufferSize) return true;
            else return false;
        }

        // In case the user closes the form directly it will still disconnect the client
        private async void Client_FormClosing(object sender, FormClosingEventArgs e)
        {
            leaveButton.PerformClick();
        }
    }
}