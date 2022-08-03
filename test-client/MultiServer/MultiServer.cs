using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Game.MultiServer
{
    internal class MultiServer
    {
        protected Socket _linstener;
        protected Socket stoped;
        public virtual bool Start()
        {
            if (this._linstener == null)
            {
                return false;
            }
            try
            {
                this._linstener.Listen(100);
                this.AcceptAsync();

            }
            catch (Exception e)
            {
                if (this._linstener != null)
                {
                    this._linstener.Close();
                }
                return false;
            }
            return true;
        }
        private void AcceptAsync()
        {
            try
            {
                if (this._linstener != null)
                {
                    SocketAsyncEventArgs e = new SocketAsyncEventArgs();
                    e.Completed += new EventHandler<SocketAsyncEventArgs>(this.AcceptAsyncCompleted);
                    this._linstener.AcceptAsync(e);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("AcceptAsync: " + ex);
            }
        }
        private void AcceptAsyncCompleted(object sender, SocketAsyncEventArgs e)
        {
            Socket sock = null;
            try
            {
                sock = e.AcceptSocket;
                try
                {
                    string ip = sock.Connected ? sock.RemoteEndPoint.ToString() : "socket disconnected";
                    Logger.Log("Incoming connection from " + ip);

                    while (true)
                    {
                        NetworkStream stream = new NetworkStream(sock);
                        StreamWriter writer = new StreamWriter(stream);
                        StreamReader reader = new StreamReader(stream);
                        try
                        {
                            string result = reader.ReadLine();
                            Logger.Log(sock.RemoteEndPoint + " socket get data reader: " + result);
                            MultiCommand.runCommand(result);
                            sock.Close();
                            writer.Flush();
                        }

                        catch(Exception ex)
                        {
                            Logger.Log("AcceptAsyncCompleted: " + ex.ToString());
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            }
            catch
            {
                if (sock != null)
                {
                    try
                    {
                        sock.Close();
                    }
                    catch
                    {
                    }
                }
            }
            finally
            {
                e.Dispose();
                this.AcceptAsync();
            }
        }

        public void InitSocket(IPAddress ip, int port)
        {
            try
            {
                Logger.Log("multi server listen...");
                this._linstener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                this._linstener.Bind(new IPEndPoint(ip, port));
            }
            catch (Exception e)
            {
                Logger.Log("InitSocket: " + e);
            }

        }
    }
}
