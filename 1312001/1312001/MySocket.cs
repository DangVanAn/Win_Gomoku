using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Threading;
using System.Configuration;

namespace _1312001
{
    class MySocket
    {
        Socket socket; 
        //String _message = "";
        public bool startPlay = false; // báo khi nào đủ 2 người mới thực hiện chơi
        public Point myPoint { get; set; }
        public int IStartFirst { get; set; }// 1 là đi dầu tiên, 2 là đi thứ 2, -1 là chưa gán
        Point _yourPoint = new Point(-1, -1);
        public Point yourPoint { get { return _yourPoint; } set { _yourPoint = value; } }
        String _namePlayer = "GUEST";
        public String NamePlayer
        {
            get { return _namePlayer; }
            set
            {
                _namePlayer = value;
            }
        }
        String _message = "";
        public String MyMessage
        {
            get { return _message; }
            set
            {
                _message = value;
            }
        }
        public MySocket()
        {

            string Constr = null;
            Constr = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

            //socket = IO.Socket("ws://gomoku-lajosveres.rhcloud.com:8000");
            socket = IO.Socket(Constr);
            socket.On(Socket.EVENT_CONNECT, () =>
            {
            });
            socket.On(Socket.EVENT_MESSAGE, (data) =>
            {
            });
            socket.On(Socket.EVENT_CONNECT_ERROR, (data) =>
            {
            });
            socket.On("ChatMessage", (data) =>
            {
                var jobject = data as JToken;
                int n = jobject.Children().Count(); // số lượng trong gói tin
                if (jobject.Value<String>("message").IndexOf("started") > 0)
                    this.startPlay = true;
                if (jobject.Value<String>("message").IndexOf("first") > 0)
                    IStartFirst = 1;

                String temp = _message; // kiểm tra message thay đổi không
                _message = this.getMessageFromSever(data, "message");
                if (n == 1 && message_changed != null)
                {
                    //String k = this.getMessageFromSever(data, "message");
                    message_changed(_message);
                }

                if (n > 1 && getMessageFromSever(data, "from").Length > 0)
                {
                    String hashcode = "";
                    if (temp.CompareTo(_message) == 0)
                        hashcode = "5714517219";
                    else
                        hashcode = "5714517545";
                    String k1 = this.getMessageFromSever(data, "message");
                    String k2 = this.getMessageFromSever(data, "from") + hashcode; // mã nhận biết là tin nhắn từ bên kia
                    k2 += k1;
                    if (message_changed != null)
                        message_changed((String)k2);
                }
                //if (((Newtonsoft.Json.Linq.JObject)data)["message"].ToString().CompareTo("Welcome!") == 0)
                //{
                //    socket.Emit("MyNameIs", _namePlayer);
                //    socket.Emit("ConnectToOtherPlayer");
                //}

            });
            socket.On("EndGame", (data) =>
            {
                _message = this.getMessageFromSever(data, "message");
                if (message_changed != null)
                {
                    String k = this.getMessageFromSever(data, "message");
                    message_changed((String)k);
                }
            });
            socket.On(Socket.EVENT_ERROR, (data) =>
            {
            });

        }

        public void emitName()
        {
            socket.Emit("MyNameIs", _namePlayer);
            socket.Emit("ConnectToOtherPlayer");
        }
        public void setNamePlayer(String nameplayer)
        {
            _namePlayer = nameplayer;
            socket.Emit("MyNameIs", _namePlayer);
        }
        public void chatting(String message)
        {
            socket.Emit("ChatMessage", message);
        }
        public void addOn()
        {
            socket.On("NextStepIs", (data) =>
            {
                String Player = getMessageFromSever(data, "player");
                String Row = getMessageFromSever(data, "row");
                String Column = getMessageFromSever(data, "col");
                if (Int32.Parse(Player) == 1)
                {
                    _yourPoint = new Point(Int32.Parse(Column), Int32.Parse(Row));
                    if (playerOnlineGo != null)
                        playerOnlineGo(yourPoint);
                }
            });
        }
        public void Disconnected()
        {
            socket.Off(Socket.EVENT_CONNECT);
            socket.Off(Socket.EVENT_MESSAGE);
            socket.Off(Socket.EVENT_CONNECT_ERROR);
            socket.Off("ChatMessage");
            socket.Off("EndGame");
            socket.Off(Socket.EVENT_ERROR);
            socket.Off(Socket.EVENT_CONNECT);
            socket.Disconnect();

        }
        String getMessageFromSever(object data, String eventString)
        {
            var jobject = data as JToken;
            return jobject.Value<String>(eventString);

        }

        public void IGo(Point p)
        {
            socket.Emit("MyStepIs", JObject.FromObject(new { row = p.X, col = p.Y }));
            myPoint = p;
        }

        public Point UGo()
        {
            return _yourPoint;
        }
        int getFirtOrSecond(String content)
        {
            // chuẩn hóa message để đưa vào khung chat
            if (content.Length > 6 && content.IndexOf("first") > 0)
                return 1;
            if (content.Length > 6 && content.IndexOf("second") > 0)
                return 2;
            return -1;
        }

        public delegate void Message_ChangedHandler(String mesage);
        public event Message_ChangedHandler message_changed;


        public delegate void UGoHandler(Point p);
        public event UGoHandler playerOnlineGo;
    }
}
