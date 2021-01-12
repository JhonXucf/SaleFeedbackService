using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SalesFeedbackSetting
{
    public partial class AutoSolderItemShowControl : UserControl
    {
        Socket _Listeners;
        private IPEndPoint _IP;
        private volatile bool IsInit = false;
        private List<Socket> sockets = new List<Socket>();
        Thread threadSend;
        Thread threadRecive;
        public AutoSolderItemShowControl(string[] result, MathineType mathineType)
        {
            InitializeComponent();
            label5.Text = "36.5";
            label6.Text = "54";
            label7.Text = "20";
            label9.Text = "63.7%";
            label11.Text = "2";
            this.label13.Text = "";
            this.label15.Text = "";
            IsInit = true;
            _IP = new IPEndPoint(IPAddress.Parse(result[4]), int.Parse(result[5]));
            _Result = result;
            _MathineType = mathineType;
            if (mathineType == MathineType.DW800)
            {
                this.label2.Text = "DW800";

            }
            else
            {
                this.label2.Text = "ID900";
            }
            _Listeners = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _Listeners.Bind(_IP);
            _Listeners.Listen(20);
            SocketAsyncEventArgs sea = new SocketAsyncEventArgs();
            sea.Completed += new EventHandler<SocketAsyncEventArgs>(this.AcceptAsync_Async);
            this.AcceptAsync(sea);
        }
        private void AcceptAsync(SocketAsyncEventArgs sae)
        {
            if (IsInit)
            {
                if (!this._Listeners.AcceptAsync(sae))
                {
                    AcceptAsync_Async(this, sae);
                }
            }
            else
            {
                if (sae != null)
                {
                    sae.Dispose();
                }
            }
        }

        private void AcceptAsync_Async(object sender, SocketAsyncEventArgs sae)
        {
            if (sae.SocketError == SocketError.Success)
            {
                sockets.Add(sae.AcceptSocket);
                string[] ip = sae.AcceptSocket.RemoteEndPoint.ToString().Split(':');
                this.Invoke(new Action(() =>
                {
                    this.label13.Text = ip[0].ToString();
                    this.label15.Text = ip[1].ToString();
                }));
                Console.WriteLine("Remote Socket LocalEndPoint：" + sae.AcceptSocket.LocalEndPoint + " RemoteEndPoint：" +
                                  sae.AcceptSocket.RemoteEndPoint.ToString());
                if (sockets.Count == 1)
                {
                    if (_MathineType == MathineType.DW800)
                    {
                        threadSend = new Thread(SendMsg);
                        threadSend.IsBackground = true;
                        threadSend.Start();
                    }
                    else
                    {
                        threadRecive = new Thread(RevMsg);
                        threadRecive.IsBackground = true;
                        threadRecive.Start();
                    }
                }
            }
            sae.AcceptSocket = null;
            if (IsInit)
            {
                this._Listeners.AcceptAsync(sae);
            }
            else
            {
                sae.Dispose();
            }
        }
        void SendMsg()
        {
            // 定义一个100b的缓存区；
            byte[] arrMsgRec = new byte[100];
            arrMsgRec[0] = 0x6D;
            arrMsgRec[1] = 0x01;//温度36.5
            arrMsgRec[2] = 0x36;
            arrMsgRec[3] = 0x00;//湿度54
            arrMsgRec[4] = 0x7C;
            arrMsgRec[5] = 0x02;//剩余量63.7%
            arrMsgRec[6] = 0x02;
            arrMsgRec[7] = 0x00;//已使用瓶数
            arrMsgRec[8] = 0x04;
            arrMsgRec[9] = 0x00;//已使用次数            
            while (this.sockets != null && sockets.Count > 0)
            {
                for (int i = 0; i < sockets.Count; i++)
                {
                    if (sockets[i].Connected)
                    {
                        try
                        {
                            sockets[i].Send(arrMsgRec);
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action(() =>
                            {
                                this.label13.Text = "";
                                this.label15.Text = "";
                            }));
                            sockets.RemoveAt(i);
                            i--;
                        }
                    }
                    else
                    {
                        sockets.RemoveAt(i);
                        i--;
                    }
                }

                Thread.Sleep(500);
            }
        }
        int _recivedCount = 0;
        void RevMsg()
        {
            // 定义一个100b的缓存区；
            byte[] arrMsgRec = new byte[12];
            byte[] arrMsgSend = new byte[11];
            while (this.sockets != null && sockets.Count > 0)
            {
                for (int i = 0; i < sockets.Count; i++)
                {
                    if (sockets[i].Connected)
                    {
                        try
                        {
                            sockets[i].Receive(arrMsgRec);
                            arrMsgSend[0] = (Byte)((_recivedCount >> 8) & (0xFF));
                            arrMsgSend[1] = (Byte)((_recivedCount >> 0) & (0xFF));
                            arrMsgSend[2] = 0x00;
                            arrMsgSend[3] = 0x00;
                            arrMsgSend[4] = 0x00;
                            arrMsgSend[5] = 0x00;
                            arrMsgSend[6] = 0x00;
                            arrMsgSend[7] = 0x03;
                            arrMsgSend[8] = 0x00;
                            arrMsgSend[9] = 0x01;
                            arrMsgSend[10] = 0x6D;
                            //int AddrUp = arrMsgRec[8] << 8 + 1;
                            //int AddrLower = arrMsgRec[9] << 0 + 1;

                            //reciveType recive = (reciveType)(AddrUp + AddrLower);
                            //switch (recive)
                            //{
                            //    case reciveType.Temperture:
                            //    case reciveType.Humidity:
                            //    case reciveType.DeviceName:
                            //    case reciveType.LineName:
                            //    case reciveType.SingleSolderWeight:
                            //    case reciveType.SolderCycle:
                            //    case reciveType.ProductWidth:
                            //    case reciveType.ResidueSolder:
                            //    case reciveType.AddSolderNumber:
                            //    case reciveType.SolderProductNumber:
                            //    case reciveType.SolderCapacity:
                            //    case reciveType.StencilScraper:
                                   
                            //        break;
                                
                            //    default:
                            //        break;
                            //}
                            _recivedCount++;
                            if (_recivedCount >= 0xFFF0)
                                _recivedCount = 0;
                            sockets[i].Send(arrMsgSend);
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action(() =>
                            {
                                this.label13.Text = "";
                                this.label15.Text = "";
                            }));
                            sockets.RemoveAt(i);
                            i--;
                        }
                    }
                    else
                    {
                        sockets.RemoveAt(i);
                        i--;
                    }
                }

                Thread.Sleep(500);
            }
        }
        enum reciveType
        {
            Temperture = 0,
            Humidity,
            DeviceName,
            LineName,
            SingleSolderWeight,
            SolderCycle,
            ProductWidth,
            ResidueSolder,
            AddSolderNumber,//加息次数
            SolderProductNumber,//生产了多少板
            SolderCapacity,//产能
            StencilScraper,//刮刀
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            if (IsInit)
            {
                IsInit = false;
                this.Dispose(true);
                if (_Listeners != null)
                {
                    try
                    {
                        
                        for (int i = 0; i < sockets.Count; i++)
                        {
                            sockets[i].Disconnect(false);
                        }
                        sockets.Clear();
                        Console.WriteLine(string.Format("Stop Listener Tcp -> {0}:{1} ", this._IP.Address.ToString(),
                            this._IP.Port));
                        _Listeners.Close();
                        _Listeners.Dispose();
                    }
                    catch
                    {
                    }
                }
                GC.SuppressFinalize(this);
            }
        }

        public string[] _Result;
        public MathineType _MathineType;
        public event EventHandler ModifyEventClicked;
        public event EventHandler DeleteEventClicked;
        private void button1_Click(object sender, EventArgs e)
        {
            ModifyEventClicked?.Invoke(this, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除吗？此操作将断开连接！", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Dispose();
                DeleteEventClicked?.Invoke(this, e);
            }
        }
    }
}
