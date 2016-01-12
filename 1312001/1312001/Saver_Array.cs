using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace _1312001
{
    class Saver_Array
    {
        public enum COLOR { Black = 0, white = 1 };
        public class Square
        {
            public int x;
            public int y;
            public bool exist = false;
            public int color;
            public Square(int _x, int _y, int _color)
            {
                x = _x;
                y = _y;
                exist = true; color = _color;
            }
            public Square()
            {
            }
            public Square( int _color)
            {
                color = _color;
            }
        }
        Square[,] _board = new Square[12, 12];
        public List<Point> cellOfWinner = new List<Point>();
        public int step = 0;
        bool hadWinner = false;

        public Saver_Array()
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                {
                    _board[i, j] = new Square(-1, -1, -1);
                    _board[i, j].exist = false;
                }
        }


        public int addToaDo(Point p, int _color)
        {

            /// thêm tọa độ mới vào bàn cờ
            /// 
            if ((int)p.X != -1 && (int)p.Y != -1) //nguyên nhân khi chuyển từ offline sang online datawoker vẫn còn hoạt động.
            if (_board[(int)p.X, (int)p.Y].exist == false) //Xuất hiện lỗi p = {-1,-1}
            {
                step++;
                if (step == 1)
                {
                    FirstPoint.X = p.X;
                    FirstPoint.Y = p.Y;
                }

                    // thêm tọa độ mới vào và kiểm tra có thắng không
                    //Thêm mới
                    _board[(int)p.X, (int)p.Y] = new Square();
                    _board[(int)p.X, (int)p.Y].x = (int)p.X;
                    _board[(int)p.X, (int)p.Y].y = (int)p.Y;
                    _board[(int)p.X, (int)p.Y].exist = true;
                    _board[(int)p.X, (int)p.Y].color = _color;
                    Square s = new Square((int)p.X, (int)p.Y, _color);
                    int winner = isWinner(s);
                    if (winner == 0 && hadWinner == false)
                    {
                        hadWinner = true;
                        return 0;
                    }
                    if (winner == 1 && hadWinner == false)
                    {
                        hadWinner = true;
                        return 1;
                    }
                    //Thêm mới

                }


            return -1;
        }

        bool compareSquare(Square s1, Square s2)
        {
            if (s1.color == s2.color && s1.exist == s2.exist && s1.exist == true)
                return true;
            else
                return false;
        }
        public int isWinner(Square s)
        {
            cellOfWinner.Add(new Point(s.x, s.y));
            int x = s.x, y = s.y - 1;
            int n = 0;
            ///////////////////////////// Dọc
            while (y >= 0 && compareSquare(_board[x, y], s)) // theo chiều dọc đi lên
            {
                cellOfWinner.Add(new Point(x, y));
                y--; n++;
            }
            y = s.y + 1;
            while (y < 12 && compareSquare(_board[x, y], s)) // theo chiều dọc đi xuống
            {
                cellOfWinner.Add(new Point(x, y));
                y++; n++;
            }
            if (n > 3)
                return s.color;
            cellOfWinner.Clear();
            //////////////////////////////// Ngang
            cellOfWinner.Add(new Point(s.x, s.y));
            x = s.x - 1; y = s.y;
            n = 0;
            while (x >= 0 && compareSquare(_board[x, y], s)) // theo chiều ngang qua trái
            {
                cellOfWinner.Add(new Point(x, y));
                x--; n++;
            }
            x = s.x + 1;
            while (x < 12 && compareSquare(_board[x, y], s)) // theo chiều ngang qua phải
            {
                cellOfWinner.Add(new Point(x, y));
                x++; n++;
            }
            if (n > 3)
                return s.color;
            cellOfWinner.Clear();
            //////////////////////////////// Chéo trên xuống
            cellOfWinner.Add(new Point(s.x, s.y));
            x = s.x - 1; y = s.y + 1;
            n = 0;
            while (x >= 0 && y < 12 && compareSquare(_board[x, y], s)) // theo chiều ngang qua trái
            {
                cellOfWinner.Add(new Point(x, y));
                x--; y++; n++;
            }
            x = s.x + 1; y = s.y - 1;
            while (x < 12 && y >= 0 && compareSquare(_board[x, y], s)) // theo chiều ngang qua phải
            {
                cellOfWinner.Add(new Point(x, y));
                x++; y--; n++;
            }
            if (n > 3)
                return s.color;
            cellOfWinner.Clear();
            //////////////////////////////// Chéo dưới lên
            cellOfWinner.Add(new Point(s.x, s.y));
            x = s.x - 1; y = s.y - 1;
            n = 0;
            while (x >= 0 && y >= 0 && compareSquare(_board[x, y], s)) // theo chiều ngang qua trái
            {
                cellOfWinner.Add(new Point(x, y));
                x--; y--; n++;
            }
            x = s.x + 1; y = s.y + 1;
            while (x < 12 && y < 12 && compareSquare(_board[x, y], s)) // theo chiều ngang qua phải
            {
                cellOfWinner.Add(new Point(x, y));
                x++; y++; n++;
            }
            if (n > 3)
                return s.color;
            cellOfWinner.Clear();
            return -1;
        }

        Point FirstPoint = new Point(); // điểm cuối cùng được đi

        
        Stack<Point> listPoint = new Stack<Point>(); // list các điểm đã đi
        void setImage_AutoGoOff(int x, int y, Cot c)
        {
            if (x != -1 && y != -1)
                c.setImageAutoGoOff(y);
        }
        void setImage_AutoGoOnl(int x, int y, Cot c)
        {
            c.setImageAutoGoOnl(y);
        }

        // tách hàm AutoGo thành 2 hàm nhỏ
        // Viết hàm máy chơi auto++ code tham khảo mạng
        public long[] aScore = new long[7] { 0, 3, 24, 192, 1536, 12288, 98304 };
        public long[] dScore = new long[7] { 0, 1, 9, 81, 729, 6561, 59849 };
        Saver_Array S_temp;
        private Point ai_FindWay()
        {
            Point res = new Point();
            long max_Mark = 0; //di?m d? xác d?nh nu?c di

            for (int i = 1; i < 12; i++)
            {
                for (int j = 1; j < 12; j++)
                {
                    if (S_temp._board[i, j].exist == false)
                    {
                        long Attackscore = DiemTC_DuyetDoc(i, j) + DiemTC_DuyetNgang(i, j) + DiemTC_DuyetCheoNguoc(i, j) + DiemTC_DuyetCheoXuoi(i, j);
                        long Defensescore = DiemPN_DuyetDoc(i, j) + DiemPN_DuyetNgang(i, j) + DiemPN_DuyetCheoNguoc(i, j) + DiemPN_DuyetCheoXuoi(i, j); ;
                        long tempMark = Attackscore > Defensescore ? Attackscore : Defensescore;
                        if (max_Mark < tempMark)
                        {
                            max_Mark = tempMark;
                            res.X = i;
                            res.Y = j;
                        }
                    }
                }
            }
            return res;
        }

        private long DiemTC_DuyetDoc(int currRow, int currCol)
        {
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            long Sum = 0;

            //duy?t t? du?i lên 
            for (int count = 1; count < 6 && currRow - count >= 0; count++)
            {
                if (S_temp._board[currRow - count, currCol].color == 0)
                    SoQuanTa++;
                else if (S_temp._board[currRow - count, currCol].color == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }

            //duyet t? trên xu?ng
            for (int count = 1; count < 6 && currRow + count < 12; count++)
            {
                if (S_temp._board[currRow + count, currCol].color == 0)
                    SoQuanTa++;
                else if (S_temp._board[currRow + count, currCol].color == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            Sum -= dScore[SoQuanDich + 1];
            Sum += aScore[SoQuanTa];
            return Sum;
        }
        private long DiemTC_DuyetNgang(int currRow, int currCol)
        {
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            long Sum = 0;

            //duy?t t? ph?i sang trái
            for (int count = 1; count < 6 && currCol - count >= 0; count++)
            {
                if (S_temp._board[currRow, currCol - count].color == 0)
                    SoQuanTa++;
                else if (S_temp._board[currRow, currCol - count].color == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }

            //duyet t? trái sang ph?i
            for (int count = 1; count < 6 && currCol + count < 12; count++)
            {
                if (S_temp._board[currRow, currCol + count].color == 0)
                    SoQuanTa++;
                else if (S_temp._board[currRow, currCol + count].color == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            Sum -= dScore[SoQuanDich + 1];
            Sum += aScore[SoQuanTa];
            return Sum;
        }
        private long DiemTC_DuyetCheoXuoi(int currRow, int currCol)
        {
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            long Sum = 0;

            //duy?t góc ph?i trên
            for (int count = 1; count < 6 && currRow - count >= 0 && currCol + count < 12; count++)
            {
                if (S_temp._board[currRow - count, currCol + count].color == 0)
                    SoQuanTa++;
                else if (S_temp._board[currRow - count, currCol + count].color == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }

            //duyet goc trái du?i
            for (int count = 1; count < 6 && currRow + count < 12 && currCol - count >= 0; count++)
            {
                if (S_temp._board[currRow + count, currCol - count].color == 0)
                    SoQuanTa++;
                else if (S_temp._board[currRow + count, currCol - count].color == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            Sum -= dScore[SoQuanDich + 1];
            Sum += aScore[SoQuanTa];
            return Sum;
        }
        private long DiemTC_DuyetCheoNguoc(int currRow, int currCol)
        {
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            long Sum = 0;

            //duy?t góc trái trên
            for (int count = 1; count < 6 && currRow - count >= 0 && currCol - count >= 0; count++)
            {
                if (S_temp._board[currRow - count, currCol - count].color == 0)
                    SoQuanTa++;
                else if (S_temp._board[currRow - count, currCol - count].color == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }

            //duyet goc ph?i du?i
            for (int count = 1; count < 6 && currRow + count < 12 && currCol + count < 12; count++)
            {
                if (S_temp._board[currRow + count, currCol + count].color == 0)
                    SoQuanTa++;
                else if (S_temp._board[currRow + count, currCol + count].color == 1)
                {
                    SoQuanDich++;
                    break;
                }
                else
                    break;
            }
            if (SoQuanDich == 2)
                return 0;
            Sum -= dScore[SoQuanDich + 1];
            Sum += aScore[SoQuanTa];
            return Sum;
        }
        private long DiemPN_DuyetDoc(int currRow, int currCol)
        {
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            long Sum = 0;

            //duy?t t? du?i lên 
            for (int count = 1; count < 6 && currRow - count >= 0; count++)
            {
                if (S_temp._board[currRow - count, currCol].color == 0)
                {
                    SoQuanTa++;
                    break;
                }
                else if (S_temp._board[currRow - count, currCol].color == 1)
                    SoQuanDich++;
                else
                    break;
            }

            //duyet t? trên xu?ng
            for (int count = 1; count < 6 && currRow + count < 12; count++)
            {
                if (S_temp._board[currRow + count, currCol].color == 0)
                {
                    SoQuanTa++;
                    break;
                }
                else if (S_temp._board[currRow + count, currCol].color == 1)
                    SoQuanDich++;
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            Sum += dScore[SoQuanDich];
            return Sum;
        }
        private long DiemPN_DuyetNgang(int currRow, int currCol)
        {
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            long Sum = 0;

            //duy?t t? ph?i sang trái
            for (int count = 1; count < 6 && currCol - count >= 0; count++)
            {
                if (S_temp._board[currRow, currCol - count].color == 0)
                {
                    SoQuanTa++;
                    break;
                }
                else if (S_temp._board[currRow, currCol - count].color == 1)
                    SoQuanDich++;
                else
                    break;
            }

            //duyet t? trái sang ph?i
            for (int count = 1; count < 6 && currCol + count < 12; count++)
            {
                if (S_temp._board[currRow, currCol + count].color == 0)
                {
                    SoQuanTa++;
                    break;
                }
                else if (S_temp._board[currRow, currCol + count].color == 1)
                    SoQuanDich++;
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            Sum += dScore[SoQuanDich];
            return Sum;
        }
        private long DiemPN_DuyetCheoXuoi(int currRow, int currCol)
        {
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            long Sum = 0;

            //duyet góc ph?i trên
            for (int count = 1; count < 6 && currRow - count >= 0 && currCol + count < 12; count++)
            {
                if (S_temp._board[currRow - count, currCol + count].color == 0)
                {
                    SoQuanTa++;
                    break;
                }
                else if (S_temp._board[currRow - count, currCol + count].color == 1)
                    SoQuanDich++;
                else
                    break;
            }

            //duyet góc trái du?i
            for (int count = 1; count < 6 && currRow + count < 12 && currCol - count >= 0; count++)
            {
                if (S_temp._board[currRow + count, currCol - count].color == 0)
                {
                    SoQuanTa++;
                    break;
                }
                else if (S_temp._board[currRow + count, currCol - count].color == 1)
                    SoQuanDich++;
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            Sum += dScore[SoQuanDich];
            return Sum;
        }
        private long DiemPN_DuyetCheoNguoc(int currRow, int currCol)
        {
            int SoQuanTa = 0;
            int SoQuanDich = 0;
            long Sum = 0;

            //duyet góc trái trên
            for (int count = 1; count < 6 && currRow - count >= 0 && currCol - count >= 0; count++)
            {
                if (S_temp._board[currRow - count, currCol - count].color == 0)
                {
                    SoQuanTa++;
                    break;
                }
                else if (S_temp._board[currRow - count, currCol - count].color == 1)
                    SoQuanDich++;
                else
                    break;
            }

            //duyet góc ph?i du?i
            for (int count = 1; count < 6 && currRow + count < 12 && currCol + count < 12; count++)
            {
                if (S_temp._board[currRow + count, currCol + count].color == 0)
                {
                    SoQuanTa++;
                    break;
                }
                else if (S_temp._board[currRow + count, currCol + count].color == 1)
                    SoQuanDich++;
                else
                    break;
            }
            if (SoQuanTa == 2)
                return 0;
            Sum += dScore[SoQuanDich];
            return Sum;
        }
        public Point takePointtoGo(Saver_Array S)
        {
            S_temp = new Saver_Array();
            S_temp = S;

            return ai_FindWay();
        }
        public int setImageOff(Point p, Cot c)
        {
            setImage_AutoGoOff((int)p.X, (int)p.Y, c);
            return addToaDo(p, 1);
        }
        public int setImageOnl(Point p, Cot c)
        {
            setImage_AutoGoOnl((int)p.X, (int)p.Y, c);
            return addToaDo(p, 0);
        }
        ///////////

        Point RandomToGo()
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                    if (_board[i, j].exist == false)
                        return new Point(i, j);
            return new Point(-1, -1);
        }

        public void Clear()
        {
            for (int i = 0; i < 12; i++)
                for (int j = 0; j < 12; j++)
                {
                    _board[i, j] = new Square(-1);
                }
            this.step = 0;
            hadWinner = false;
        }

    }
}
