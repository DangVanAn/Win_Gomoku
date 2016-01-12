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

namespace _1312001
{
    /// <summary>
    /// Interaction logic for Cot.xaml
    /// </summary>
    public partial class Cot : UserControl
    {
        int X, Y;
        String Color_Start, Color_End; // màu bắt đầu, kết thúc
        String Color;
        bool _agreeSetImage = false;
        public bool AgreeSetImage
        {
            get { return _agreeSetImage; }
            set { _agreeSetImage = value; }
        }

        public bool stop { get; set; } // dừng khi đã có người win
        public int x
        {
            get { return X; }
            set { X = value; }
        }
        public int y
        {
            get { return Y; }
            set { Y = value; }
        }
        public String EndColor
        {
            get { return Color_End; }
            set { Color_End = value; }
        }
        public String StartColor
        {
            get { return Color_Start; }
            set { Color_Start = value; }
        }
        public String COLOR
        {
            get { return Color; }
            set { Color = value; }
        }

        public Cot()
        {
            InitializeComponent();
        }
        public delegate void Cot_ClickHandler(Point p);
        public event Cot_ClickHandler Cot_Click;

        void setImage(String imageName, Button bt)
        {
            String name = @"Images/" + imageName;
            BitmapImage bitimg = new BitmapImage();
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(name, UriKind.RelativeOrAbsolute);
            bitimg.EndInit();

            Image img = new Image();
            img.Stretch = Stretch.Fill;
            img.Source = bitimg;

            bt.Content = img;
            bt.Background = new ImageBrush(bitimg);
        }
        public void setImageofWinner(String imageName, int index)
        {
            String name = @"Images/" + imageName;
            BitmapImage bitimg = new BitmapImage();
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(name, UriKind.RelativeOrAbsolute);
            bitimg.EndInit();

            Image img = new Image();
            img.Stretch = Stretch.Fill;
            img.Source = bitimg;

            getButton(index).Content = img;
            getButton(index).Background = new ImageBrush(bitimg);
        }
        Button getButton(int index)
        {
            if (index == 0)
                return x0_y0;
            if (index == 1)
                return x1_y0;
            if (index == 2)
                return x2_y0;
            if (index == 3)
                return x3_y0;
            if (index == 4)
                return x4_y0;
            if (index == 5)
                return x5_y0;
            if (index == 6)
                return x6_y0;
            if (index == 7)
                return x7_y0;
            if (index == 8)
                return x8_y0;
            if (index == 9)
                return x9_y0;
            if (index == 10)
                return x10_y0;
            if (index == 11)
                return x11_y0;
            return null;
        }
        void setClick(Button bt)
        {
            if (stop == false)
            {
                int index;
                if (bt.Name[2] != '_')
                    index = Int32.Parse(bt.Name.Substring(1, 2));
                else
                    index = Int32.Parse(bt.Name.Substring(1, 1));

                String cl;
                if (index % 2 == 0)
                {
                    cl = Color_Start.Substring(0, 5);
                }
                else
                {
                    cl = Color_End.Substring(0, 5);
                }
                ///kiểm tra nhấn lần 2
                Image k1 = (Image)bt.Content;
                String k2 = k1.Source.ToString();
                int k3 = k2.LastIndexOf("black_black.png");
                if (k3 == -1)
                    k3 = k2.LastIndexOf("black_white.png");
                if (k3 == -1)
                    k3 = k2.LastIndexOf("white_white.png");
                if (k3 == -1)
                    k3 = k2.LastIndexOf("white_black.png");

                if (k3 == -1)
                    setImage(cl + "_" + Color.ToLower() + ".png", bt);
            }
        }
        #region
        private void x0_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 0;
            if (Cot_Click != null)
            {

                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x0_y0);
        }
        private void x1_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 1;
            if (Cot_Click != null)
            {
                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x1_y0);

        }
        private void x2_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 2;
            if (Cot_Click != null)
            {
                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x2_y0);

        }
        private void x3_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 3;
            if (Cot_Click != null)
            {
                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x3_y0);

        }
        private void x4_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 4;
            if (Cot_Click != null)
            {
                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x4_y0);

        }
        private void x5_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 5;
            if (Cot_Click != null)
            {
                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x5_y0);

        }
        private void x6_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 6;
            if (Cot_Click != null)
            {
                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x6_y0);

        }
        private void x7_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 7;
            if (Cot_Click != null)
            {
                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x7_y0);

        }
        private void x8_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 8;
            if (this._agreeSetImage == true)
                if (Cot_Click != null)
                {
                    Cot_Click(new Point(X, Y));
                }
            if (this._agreeSetImage == true)
                setClick(x8_y0);

        }
        private void x9_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 9;
            if (Cot_Click != null)
            {
                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x9_y0);

        }
        private void x10_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 10;
            if (Cot_Click != null)
            {
                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x10_y0);

        }
        private void x11_y0_Click(object sender, RoutedEventArgs e)
        {
            X = x;
            Y = 11;
            if (Cot_Click != null)
            {
                Cot_Click(new Point(X, Y));
            }
            if (this._agreeSetImage == true)
                setClick(x11_y0);

        }
        #endregion
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (Color_Start != null && Color_End != null)
            {
                setImage(Color_Start, x0_y0);
                setImage(Color_End, x1_y0);
                setImage(Color_Start, x2_y0);
                setImage(Color_End, x3_y0);
                setImage(Color_Start, x4_y0);
                setImage(Color_End, x5_y0);
                setImage(Color_Start, x6_y0);
                setImage(Color_End, x7_y0);
                setImage(Color_Start, x8_y0);
                setImage(Color_End, x9_y0);
                setImage(Color_Start, x10_y0);
                setImage(Color_End, x11_y0);
            }
        }

        public void Clear()
        {
            if (Color_Start != null && Color_End != null)
            {
                setImage(Color_Start, x0_y0);
                setImage(Color_End, x1_y0);
                setImage(Color_Start, x2_y0);
                setImage(Color_End, x3_y0);
                setImage(Color_Start, x4_y0);
                setImage(Color_End, x5_y0);
                setImage(Color_Start, x6_y0);
                setImage(Color_End, x7_y0);
                setImage(Color_Start, x8_y0);
                setImage(Color_End, x9_y0);
                setImage(Color_Start, x10_y0);
                setImage(Color_End, x11_y0);
            }
            stop = false;
        }
        ///
        public void setImageAutoGoOff(int _index)
        {
            // dùng cho hàm auto đi second, do đó là màu trắng
            Button bt = getButton(_index);
            if (stop == false)
            {
                int index;
                if (bt.Name[2] != '_')
                    index = Int32.Parse(bt.Name.Substring(1, 2));
                else
                    index = Int32.Parse(bt.Name.Substring(1, 1));

                String cl;
                if (index % 2 == 0)
                {
                    cl = Color_Start.Substring(0, 5);
                }
                else
                {
                    cl = Color_End.Substring(0, 5);
                }
                ///kiểm tra nhấn lần 2
                Image k1 = (Image)bt.Content;
                String k2 = k1.Source.ToString();
                int k3 = k2.LastIndexOf("black_black.png");
                if (k3 == -1)
                    k3 = k2.LastIndexOf("black_white.png");
                if (k3 == -1)
                    k3 = k2.LastIndexOf("white_white.png");
                if (k3 == -1)
                    k3 = k2.LastIndexOf("white_black.png");

                if (k3 == -1)
                    setImage(cl + "_" + "white" + ".png", bt);
            }
        }
        public void setImageAutoGoOnl(int _index)
        {
            // dùng cho hàm auto đi second, do đó là màu đen
            Button bt = getButton(_index);
            if (stop == false)
            {
                int index;
                if (bt.Name[2] != '_')
                    index = Int32.Parse(bt.Name.Substring(1, 2));
                else
                    index = Int32.Parse(bt.Name.Substring(1, 1));

                String cl;
                if (index % 2 == 0)
                {
                    cl = Color_Start.Substring(0, 5);
                }
                else
                {
                    cl = Color_End.Substring(0, 5);
                }
                ///kiểm tra nhấn lần 2
                Image k1 = (Image)bt.Content;
                String k2 = k1.Source.ToString();
                int k3 = k2.LastIndexOf("black_black.png");
                if (k3 == -1)
                    k3 = k2.LastIndexOf("black_white.png");
                if (k3 == -1)
                    k3 = k2.LastIndexOf("white_white.png");
                if (k3 == -1)
                    k3 = k2.LastIndexOf("white_black.png");

                if (k3 == -1)
                    setImage(cl + "_" + "black" + ".png", bt);
            }
        }
    }
}
