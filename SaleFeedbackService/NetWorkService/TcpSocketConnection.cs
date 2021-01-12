using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace SaleFeedbackService.NetWorkService
{
    public class TcpSocketConnection
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="socket">维护的Socket对象</param>
        /// <param name="socketServer">维护此连接的服务对象</param>
        /// <param name="recLength">接收缓冲区大小</param>
        public TcpSocketConnection(Socket socket, TcpSocketServer socketServer, Int32 recLength)
        {
            _socket = socket;
            _tcpServer = socketServer;
            _recLength = recLength;
        }
        #region 内部成员
        Socket _socket { get; }
        Boolean _isRec { get; set; } = true;
        TcpSocketServer _tcpServer { get; set; } = null;
        Boolean _isClose { get; set; } = false;
        String _connectionId { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 接收区大小
        /// </summary>
        Int32 _recLength { get; set; }
        #endregion
        #region 外部接口
        public void StartRecMsg()
        {
            try
            {
                Byte[] container = new Byte[_recLength];
                _socket.BeginReceive(container, 0, container.Length, SocketFlags.None, asyncResult =>
                {
                    try
                    {
                        Int32 length = _socket.EndReceive(asyncResult);
                        if (length > 0 && _isRec && IsSocketConnected())
                        {
                            StartRecMsg();
                        }
                        if (length > 0)
                        {
                            Byte[] recBytes = new Byte[length];
                            Array.Copy(container, 0, recBytes, 0, length);//这一步能减少带宽消耗，发送实际大小
                            HandleRecMsg?.Invoke(_tcpServer, this, recBytes);
                        }
                        else
                            Close();
                    }
                    catch (ObjectDisposedException)
                    {

                    }
                    catch (Exception ex)
                    {
                        HandleException?.Invoke(ex);
                        Close();
                    }
                }, null);
            }
            catch (Exception ex)
            {
                HandleException?.Invoke(ex);
                Close();
            }
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="bytes">数据字节</param>
        public void Send(Byte[] bytes)
        {
            try
            {
                _socket.BeginSend(bytes, 0, bytes.Length, SocketFlags.None, asyncResult =>
                {
                    try
                    {
                        Int32 length = _socket.EndSend(asyncResult);
                        HandleSendMsg?.Invoke(_tcpServer, this, bytes);
                    }
                    catch (Exception ex)
                    {
                        HandleException?.Invoke(ex);
                    }
                }, null);
            }
            catch (Exception ex)
            {
                HandleException?.Invoke(ex);
            }
        }
        /// <summary>
        /// 发送字符串（默认使用UTF-8编码）
        /// </summary>
        /// <param name="msgStr">字符串</param>
        public void Send(String msgStr)
        {
            Send(Encoding.UTF8.GetBytes(msgStr));
        }
        /// <summary>
        /// 发送字符串（使用自定义编码）
        /// </summary>
        /// <param name="msgStr">字符串消息</param>
        /// <param name="encoding">使用的编码</param>
        public void Send(String msgStr, Encoding encoding)
        {
            Send(encoding.GetBytes(msgStr));
        }
        /// <summary>
        /// 连接标识
        /// </summary>
        public String ConnectionId
        {
            get
            {
                return _connectionId;
            }
            set
            {
                String oldConnectionId = _connectionId;
                _connectionId = value;
                _tcpServer?.SetConnectionId(this, oldConnectionId, value);
            }
        }
        public String IP
        {
            get
            {
                return _socket.RemoteEndPoint.ToString();
            }
        }
        public void Close()
        {
            if (_isClose) return;
            try
            {
                _isClose = true;
                _tcpServer.RemoveConnection(this);

                _isRec = false;
                _socket.BeginDisconnect(false, asyncCallback =>
                 {
                     try
                     {
                         _socket.EndDisconnect(asyncCallback);
                     }
                     catch (Exception ex)
                     {
                         HandleException?.Invoke(ex);
                     }
                     finally
                     {
                         _socket.Dispose();
                     }
                 }, null);
            }
            catch (Exception ex)
            {
                HandleException?.Invoke(ex);
            }
            finally
            {
                try
                {
                    HandleClientClose?.Invoke(_tcpServer, this);
                }
                catch (Exception ex)
                {
                    HandleException?.Invoke(ex);
                }
            }
        }
        /// <summary>
        /// 判断是否处于已连接状态
        /// </summary>
        /// <returns></returns>
        public Boolean IsSocketConnected()
        {
            return !((_socket.Poll(1000, SelectMode.SelectRead) && (_socket.Available == 0)) || !_socket.Connected);
        }
        #endregion
        #region 事件处理
        /// <summary>
        /// 客户端连接接受新的消息后回调
        /// </summary>
        public Action<TcpSocketServer, TcpSocketConnection, Byte[]> HandleRecMsg { get; set; }
        /// <summary>
        /// 发送消息回调
        /// </summary>
        public Action<TcpSocketServer, TcpSocketConnection, Byte[]> HandleSendMsg { get; set; }
        /// <summary>
        /// 关闭连接回调
        /// </summary>
        public Action<TcpSocketServer, TcpSocketConnection> HandleClientClose { get; set; }
        /// <summary>
        /// 异常处理
        /// </summary>
        public Action<Exception> HandleException { get; set; }
        #endregion
    }
}
