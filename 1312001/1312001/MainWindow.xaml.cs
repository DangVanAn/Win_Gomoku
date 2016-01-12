using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.ComponentModel;

namespace _1312001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();

            column_0.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_1.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_2.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_3.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_4.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_5.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_6.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_7.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_8.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_9.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_10.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            column_11.Cot_Click += new Cot.Cot_ClickHandler(setToaDo);
            loadCOLOR();

            MyWorker.DoWork += MyWorker_DoWork;
            MyWorker.RunWorkerCompleted += MyWorker_RunWorkerCompleted;

            /////////

            InitSocket("GUEST");
            _socket.playerOnlineGo += _socket_playerOnlineGo;
            _socket.message_changed += _socket_message_changed;
        }


        String name = "GUEST";   //Tên của người chơi.
        /// </summary>
        String para = "";
        DispatcherTimer Timer = new DispatcherTimer();
        //String space = "";
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            chatting(input_chat.Text);
            //chatBox.Text = para;
            input_chat.Text = null;
        }
        private void Change_Click(object sender, RoutedEventArgs e)
        {
            String temp = name;
            name = YourName.Text;
            if (name.Length > 13)
            {
                para += "SERVER" + "                                                              "
                   + DateTime.Now.ToString("HH:mm:ss") + "\n" + "Tên bạn nhập quá dài!!!" + "\n";
                para += "-------------------------------------------------------------------------------------\n";
                chatBox.Text = para;
                name = temp;
            }
            else
            {
                setNamePlayer(YourName.Text);
            }
        }

        #region //Thao tác chọn kiểu chơi

        private void rbt_Machine_Checked(object sender, RoutedEventArgs e)
        {
            TypePlay = 0; // chơi với máy
            disconnected();
            if (chatBox != null)
                chatBox.Text = "";
        }

        private void rbt_2Player_Checked(object sender, RoutedEventArgs e)
        {
            TypePlay = 1; // chơi với người chơi khác
            disconnected();
            if (chatBox != null)
                chatBox.Text = "";
        }

        private void online_Checked(object sender, RoutedEventArgs e)
        {
            TypePlay = 2; // người chơi onl
            newGame(name);
            setStartPlayer(false);
            if (chatBox != null)
                chatBox.Text = "";
        }

        private void onlineMachine_Checked(object sender, RoutedEventArgs e)
        {
            TypePlay = 3; // máy chơi onl
            newGame(name);
            setStartPlayer(false);
            if (chatBox != null)
                chatBox.Text = "";
        }
        private void btn_Newgame_Click(object sender, RoutedEventArgs e)
        {
            int k = TypePlay;
            setStartPlayer(false);
            ClearAll();
            if (k == 0)
            {
                rbt_Machine_Checked(sender, e);
                rbt_Machine.IsChecked = true;
                disconnected();
            }
            else
            {
                if (k == 1)
                {
                    rbt_2Player_Checked(sender, e);
                    rbt_2Player.IsChecked = true;
                    disconnected();
                }
                else
                {
                    if (k == 2)
                    {
                        online_Checked(sender, e);
                        online.IsChecked = true;
                        newGame(name);
                    }
                    else
                    {
                        onlineMachine_Checked(sender, e);
                        onlineMachine.IsChecked = true;
                        newGame(name);
                    }
                }
            }
        }

        #endregion

        private void container_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (TypePlay == 2 || TypePlay == 3)
            {
                String nameTalker = "SERVER";
                String content = container.Text;
                if (content.IndexOf("game.") > 0) // nhận tin bắt đầu game
                {
                    int index = content.IndexOf("game.");
                    int len = content.Length;
                    content = content.Substring(0, index + 5) + "\n" + content.Substring(index + 11, len - index - 11);
                }
                if (content.IndexOf("5714517219") > 0) // nhận tin nhắn chat
                {
                    int index = content.IndexOf("5714517219");
                    int len = content.Length;
                    String name1 = content.Substring(0, index);
                    String con = content.Substring(index + 10, len - (index + 10)); // nội dung lời nói người chơi 
                    content = con;
                    nameTalker = name1;
                }
                if (content.IndexOf("5714517545") > 0)
                {
                    int index = content.IndexOf("5714517545");
                    int len = content.Length;
                    String name1 = content.Substring(0, index);
                    String con = content.Substring(index + 10, len - (index + 10)); // nội dung lời nói người chơi 
                    content = con;
                    nameTalker = name1;
                }

                para += nameTalker + "                                                              "
                   + DateTime.Now.ToString("HH:mm:ss") + "\n" + content + "\n";
                para += "-------------------------------------------------------------------------------------\n";
                chatBox.Text = para;
            }

        }


        // Code Board Change to Main .../////////////////////////////////...//////////////////////////////...///////////////////////////////

        void _socket_message_changed(String mesage)
        {
            MyMessage = mesage;
        }

        void _socket_playerOnlineGo(Point p)
        {
            yourpoint = p;
        }

        BackgroundWorker MyWorker = new BackgroundWorker();
        Point ToaDo;
        String COLOR = "BLACK"; // nước đi trước là đen
        Saver_Array _board = new Saver_Array();
        Point pointToGo = new Point(); // chứa điểm máy đi tự động
        int n = 1;
        private MySocket _socket;
        int winner_typemachine = -1;
        Point yourpoint = new Point(-1, -1);
        String _message = "";
        public String MyMessage
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged("MyMessage");
            }
        }
        #region // thread machine
        private void MyWorker_RunWorkerCompleted(object Sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            winner_typemachine = _board.setImageOff(pointToGo, getColumn((int)pointToGo.X)); // kiểm tra lại hàm set winner cho máy này lại
            if (winner_typemachine != -1)
            {
                setImageofWinner(_board.cellOfWinner, winner_typemachine);
                winner_typemachine = -1;
            }

        }
        private void MyWorker_DoWork(object Sender, System.ComponentModel.DoWorkEventArgs e)
        {
            pointToGo = _board.takePointtoGo(_board);
            if (MyWorker.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
        }

        #endregion
        public void setToaDo(Point p)
        {
            ToaDo = p;
            int winner = -1;
            n++;
            if (_board.step % 2 == 0)
                COLOR = "BLACK";
            else
                COLOR = "WHITE";
            loadCOLOR();
            #region // chơi với người chơi khác
            if (typePlay == 1) // chơi với người chơi khác
            {
                getColumn((int)p.X).AgreeSetImage = true;
                if (COLOR.CompareTo("BLACK") == 0)
                    winner = _board.addToaDo(p, 0);
                else
                    winner = _board.addToaDo(p, 1);
                if (winner != -1)
                {
                    setImageofWinner(_board.cellOfWinner, winner);
                }
            }
            #endregion
            #region// chơi với máy
            if (typePlay == 0) // chơi với máy
            {
                getColumn((int)p.X).AgreeSetImage = true;

                int k = _board.step;

                winner = _board.addToaDo(p, 0);

                if (winner != -1)
                {
                    setImageofWinner(_board.cellOfWinner, winner);
                }

                if (k != _board.step) // nếu k đi bước cũ
                {
                    MyWorker.RunWorkerAsync();
                    winner = winner_typemachine;
                }
                if (winner != -1)
                {
                    setImageofWinner(_board.cellOfWinner, winner);
                    winner_typemachine = -1;
                }

            }
            #endregion
            if (typePlay == 2) // chơi online
            {

                if (_socket.startPlay == true)
                {
                    for (int i = 0; i < 12; i++)
                        getColumn(i).AgreeSetImage = true;


                    if (_socket.IStartFirst == 1) // local đi đầu tiên
                    {
                        int step_temp = _board.step;
                        while (_board.step % 2 == 0)
                        {
                            winner = _board.addToaDo(p, 0);   // Lỗi add bị p = {-1; -1} khi chơi bước đầu tiên.
                            p = new Point(p.Y, p.X);
                            _socket.IGo(p);
                            if (winner != -1)
                            {
                                setImageofWinner(_board.cellOfWinner, winner);
                                break;
                            }
                        }
                        if (_board.step % 2 != 0 && yourpoint.X != -1)
                        {
                            _board.setImageOff(yourpoint, getColumn((int)yourpoint.X));
                        }
                        if (_board.step == step_temp)
                        {
                            getColumn((int)p.X).AgreeSetImage = false;
                        }


                    }
                    else
                    {
                        int step_temp = _board.step;
                        while (_board.step % 2 != 0)
                        {
                            winner = _board.addToaDo(p, 0);
                            p = new Point(p.Y, p.X);
                            _socket.IGo(p);
                            if (winner != -1)
                            {
                                setImageofWinner(_board.cellOfWinner, winner);
                                break;
                            }
                            getColumn((int)p.Y).COLOR = "black";
                        }
                        if (_board.step % 2 == 0 && yourpoint.X != -1)
                        {
                            _board.setImageOff(yourpoint, getColumn((int)yourpoint.X));
                        }
                        if (_board.step == step_temp)
                        {
                            getColumn((int)p.X).AgreeSetImage = false;
                        }

                    }
                }
                else
                {
                    getColumn((int)p.X).AgreeSetImage = false; // k cho ấn
                }
            } // end chơi onl
            if (typePlay == 3) // machine chơi onl
            {
                getColumn((int)p.X).AgreeSetImage = false;
            }// end typeplayer
        }
        void setImageofWinner(List<Point> list, int color)
        {
            String namefile = "";
            if (color == 0)
                namefile = "black_winner.png";
            else
                namefile = "white_winner.png";
            foreach (Point i in list)
            {
                Cot c = getColumn((int)i.X);
                c.setImageofWinner(namefile, (int)i.Y);
            }
            for (int j = 0; j < 12; j++)
                getColumn(j).stop = true;
            if(TypePlay != 2 && TypePlay != 3)
            {
                if (color == 0)
                {
                    para += "SERVER" + "                                                              "
                     + DateTime.Now.ToString("HH:mm:ss") + "\n" + "Player1 is winner!!!" + "\n";
                    para += "-------------------------------------------------------------------------------------\n";
                    chatBox.Text = para;
                }
                if (color == 1)
                {
                    para += "SERVER" + "                                                              "
                     + DateTime.Now.ToString("HH:mm:ss") + "\n" + "Player2 is winner!!!" + "\n";
                    para += "-------------------------------------------------------------------------------------\n";
                    chatBox.Text = para;
                }
            }   
        }
        void loadCOLOR()
        {
            //  load màu nước đi ĐEN HOẶC TRẮNG
            column_0.COLOR = COLOR;
            column_1.COLOR = COLOR;
            column_2.COLOR = COLOR;
            column_3.COLOR = COLOR;
            column_4.COLOR = COLOR;
            column_5.COLOR = COLOR;
            column_6.COLOR = COLOR;
            column_7.COLOR = COLOR;
            column_8.COLOR = COLOR;
            column_9.COLOR = COLOR;
            column_10.COLOR = COLOR;
            column_11.COLOR = COLOR;

        }
        public Cot getColumn(int index)
        {
            if (index == 0)
                return column_0;
            if (index == 1)
                return column_1;
            if (index == 2)
                return column_2;
            if (index == 3)
                return column_3;
            if (index == 4)
                return column_4;
            if (index == 5)
                return column_5;
            if (index == 6)
                return column_6;
            if (index == 7)
                return column_7;
            if (index == 8)
                return column_8;
            if (index == 9)
                return column_9;
            if (index == 10)
                return column_10;
            if (index == 11)
                return column_11;
            return null;
        }

        int typePlay = 0;
        public int TypePlay
        {
            get { return typePlay; }
            set { typePlay = value; }
        }
        public void ClearAll()
        {
            column_0.Clear();
            column_1.Clear();
            column_2.Clear();
            column_3.Clear();
            column_4.Clear();
            column_5.Clear();
            column_6.Clear();
            column_7.Clear();
            column_8.Clear();
            column_9.Clear();
            column_10.Clear();
            column_11.Clear();
            _board.Clear();
            yourpoint = new Point(-1, -1);
        }
        public void setNamePlayer(String namePlayer)
        {
            _socket.setNamePlayer(namePlayer);
        }
        public void newGame(String namePlayer)
        {
            _socket.Disconnected();

            InitSocket(namePlayer);
            _socket.playerOnlineGo += _socket_playerOnlineGo;
            _socket.message_changed += _socket_message_changed;
        }
        public void disconnected()
        {
            if (_socket != null)
                _socket.Disconnected();
        }
        public void chatting(String message)
        {
            _socket.chatting(message);
        }
        public void setStartPlayer(bool value)
        {
            _socket.startPlay = value;
        }
        public void InitSocket(String namePlayer)
        {
            _socket = new MySocket();
            _socket.setNamePlayer(namePlayer);
            _socket.addOn();
            _socket.emitName();
        }
        private void B_MouseMove(object sender, MouseEventArgs e)
        {
            if (_socket.startPlay == true)
            {
                int winner = -1;
                if (_socket != null && yourpoint.X != -1 && typePlay == 2)
                {
                    yourpoint = _socket.UGo();
                    winner = _board.setImageOff(yourpoint, getColumn((int)yourpoint.X));
                    if (winner != -1)
                    {
                        setImageofWinner(_board.cellOfWinner, winner);
                    }
                }
                //////////////////////
                if (_socket != null && typePlay == 3) // machine online
                {
                    if (_board.step == 0)
                        for (int i = 0; i < 12; i++)
                            getColumn(i).AgreeSetImage = true;

                    if (_socket.IStartFirst == 1) // machine đi đầu tiên
                    {
                        if (_board.step % 2 == 0 && _socket != null && typePlay == 3)
                        {
                            pointToGo = _board.takePointtoGo(_board);
                            Point temp = new Point(pointToGo.Y, pointToGo.X);
                            winner = _board.setImageOnl(pointToGo, getColumn((int)pointToGo.X));
                            _socket.IGo(temp);
                            if (winner != -1)
                            {
                                setImageofWinner(_board.cellOfWinner, winner);
                                _socket.startPlay = false;
                                winner = -1;
                            }
                        }

                        if (_board.step % 2 != 0 && _socket != null && yourpoint.X != -1 && typePlay == 3)
                        {
                            yourpoint = _socket.UGo();
                            winner = _board.setImageOff(yourpoint, getColumn((int)yourpoint.X));
                            if (winner != -1)
                            {
                                setImageofWinner(_board.cellOfWinner, winner);
                                _socket.startPlay = false;
                                winner = -1;
                            }
                        }
                    }
                    else
                    {
                        if (_board.step % 2 != 0 && _socket != null && typePlay == 3)
                        {
                            pointToGo = _board.takePointtoGo(_board);
                            Point temp = new Point(pointToGo.Y, pointToGo.X);
                            winner = _board.setImageOnl(pointToGo, getColumn((int)pointToGo.X));
                            _socket.IGo(temp);
                            if (winner != -1)
                            {
                                setImageofWinner(_board.cellOfWinner, winner);
                                _socket.startPlay = false;
                                winner = -1;
                            }
                        }

                        if (_board.step % 2 == 0 && _socket != null && yourpoint.X != -1 && typePlay == 3)
                        {
                            yourpoint = _socket.UGo();
                            winner = _board.setImageOff(yourpoint, getColumn((int)yourpoint.X));
                            if (winner != -1)
                            {
                                setImageofWinner(_board.cellOfWinner, winner);
                                _socket.startPlay = false;
                                winner = -1;
                            }
                        }
                    }
                }
            }
            else
            {
                getColumn((int)pointToGo.X).AgreeSetImage = false; // k cho ấn
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {

                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
