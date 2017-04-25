using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace BaseApp
{
    class Server
    {
        private TextBox callerTextBox;
        private BaseForm callerBaseForm;

        private IPAddress hostIP;
        private string hostname;
        private Thread loopThread;
        
        /// <summary>
        /// Constructor of the Server class instance.
        /// </summary>
        /// <param name="caller">A BaseForm that instantiates this Server.</param>
        /// <param name="infobox">A multiline TextBox control to show info text or null.</param>
        public Server(BaseForm caller, TextBox infobox)
        {
            callerTextBox = infobox;
            callerBaseForm = caller;
        }

        /// <summary>
        /// Appends text given by <paramref name="info"/> to the TextBox control given in the constructor, or does nothing 
        /// if it is null.
        /// </summary>
        /// <param name="info">The text to be appended to the TextBox control.</param>
        private void UpdateServerInfoBox(string info)
        {
            if (callerTextBox != null)
            {
                callerTextBox.Invoke(new Action(() => callerTextBox.AppendText(info)));
            }
        }

        /// <summary>
        /// This is a helper wrapper method that calls static Log(string path, string text) method of the Logger class.
        /// </summary>
        /// <param name="text">The text to be logged by the Logger class.</param>
        private void Log(string text)
        {
            Logger.Log(callerBaseForm.LogPath + @"\SrvLog_" + DateTime.Today.ToString("yyyyMMdd") + ".txt", text);
        }

        /// <summary>
        /// This is a helper wrapper method that calls static Log(string path, byte[] data) method of the Logger class.
        /// </summary>
        /// <param name="data">An array of bytes to be logged by the Logger class.</param>
        private void Log(byte[] data)
        {
            Logger.Log(callerBaseForm.LogPath + @"\ClDat_" + DateTime.Today.ToString("yyyyMMdd") + ".bin", data);
        }

        /// <summary>
        /// TcpListener initialization & start listening for connections
        /// at port 8266
        /// </summary>
        public void Start()
        {
            try
            {
                if (CheckNetwork())
                {
                    TcpListener listener = new TcpListener(hostIP, 8266);
                    listener.Start();
                    Log("Server started: " + hostname + ", IP: " + hostIP + ", port: 8266");
                    
                    loopThread = new Thread(() =>
                    {

                        while (true)
                        {
                            if (listener.Pending())
                            {
                                ClientHandler(listener);
                            }
                            else
                            {
                                Thread.Sleep(500);
                            }
                        }
                    });
                    loopThread.Start();
                    loopThread.Join();
                }
                else
                {
                    throw new Exception("Network error! Server not started.");
                }
            }
            catch (ThreadAbortException tae)
            {
                Log("Server ThreadAbortException: " + tae.Message);
                loopThread.Abort();

                Thread.Yield();
            }
            catch (Exception e)
            {
                Log("Server Exception: " + e.Message + "\n" + e.StackTrace);
                MessageBox.Show(e.Message + e.StackTrace, "Server Exception!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Client connection handler procedure.
        /// </summary>
        private void ClientHandler(TcpListener listener)
        {
            try
            {
                using (TcpClient client = listener.AcceptTcpClient())
                {
                    string clientIPAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
                    Log("Client connection: " + clientIPAddress);
                    UpdateServerInfoBox("\nClient connection: " + clientIPAddress + "\n");

                    using (StreamReader stream = new StreamReader(client.GetStream()))
                    {
                        byte[] data = new byte[6];
                        int x = 0;

                        while (stream.Peek() != -1)
                        {
                            data[x++] = Convert.ToByte(stream.Read());
                        }

                        if (data[0] == 204)
                        {
                            if (data[5] == 185)
                            {
                                Log(data);
                                Log("DATA:\t" + data[1] + "\t" + data[2] + "\t" + data[3] + "\t" + data[4]);
                                UpdateServerInfoBox("DATA:\t" + data[1] + "\t" + data[2] + "\t" + data[3] + "\t" + data[4] + "\n");
                            }
                        }
                        UpdateServerInfoBox("W_DATA:\t" + data[0] + "+" + data[1] + "+" + data[2] + "+" + data[3] + "+" + data[4] + "+" + data[5] + "\n");
                        client.Client.Disconnect(true);
                    }
                    Log("Client disconnected: " + clientIPAddress);
                    UpdateServerInfoBox("Client disconnected: " + clientIPAddress + "\n");
                }
            }
            catch (ThreadAbortException tae)
            {
                Log("Client Handler Exception: " + tae.Message + "\n" + tae.StackTrace);
                MessageBox.Show(tae.Message + tae.StackTrace, "Client Handler Exception!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Thread.Yield();
            }
            catch (Exception e)
            {
                Log("Client Handler Exception: " + e.Message + "\n" + e.StackTrace);
                MessageBox.Show(e.Message + e.StackTrace, "Client Handler Exception!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Network check & IP address setter procedure.
        /// </summary>
        /// <returns><strong>true</strong> if got IP, <strong>false</strong> otherwise.</returns>
        private bool CheckNetwork()
        {
            Log("Checking network...");
            if (System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                UpdateServerInfoBox("Network is available.\n");

                hostname = Dns.GetHostName();
                UpdateServerInfoBox("Hostname: " + hostname + "\n");

                foreach (IPAddress ip in (Dns.GetHostEntry(hostname).AddressList))
                {
                    UpdateServerInfoBox("Found local IP: " + ip + "\n");
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        hostIP = ip;
                        UpdateServerInfoBox("Local IP: " + hostIP + "\n");
                        Log("Hostname: " + hostname);
                        Log("IP: " + hostIP);
                        return true;
                    }
                }
            }
            UpdateServerInfoBox("Network is unavailable.\n");
            Log("Network is unavailable.");
            return false;
        }
    }
}
