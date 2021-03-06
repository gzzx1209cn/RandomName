﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandomName
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] s = new string[41] {"梁宿溪","高明萱","殷昕","黄永康","王文超","王长鑫","刘沁宜","徐一丹","毛美云","初宁","张瀚","荣昱","吕欣蓉","夏金泽","钱炜鸿","闫耕图","马鸣远","林子康","王子曰","张衡","邹淮扬","徐晗淏","张贺","邹子恺","孙逸夫","张越强","毕静颐","李汶洋","刘怡文","林乐赓","张瑞洁","宋若琦","唐圣林","王奕文","战洁","刘浩男","王浩宇","于心语","姜欣妤","李姝曈","王景仪"};

        public MainWindow()
        {
            InitializeComponent();
        }
        int number = 2;
        Boolean[] flag = new Boolean[41];

        private void buttonStart_Click(object sender, RoutedEventArgs e)
        {
            if (NeedReset(number))
            {
                for (int i = 0; i < 41; i++) flag[i] = false;
            }
                string[] r = new string[4];
                r = pickUpStu(number, r);
                nameBlock1.Text = r[0];
                nameBlock2.Text = r[1];
                nameBlock3.Text = r[2];
                nameBlock4.Text = r[3];
                buttonStart.Content = "Lucky you!";
        }

        public bool NeedReset(int n)
        {
            int a = 0;
            for (int i = 0; i < 41; i++) if (flag[i])a++;
            if (a + n > 41) return true;
            else return false;
        }

        public string[] pickUpStu(int n,string[] r)
        {
            if (n == 1)
            {
                start: int a = GetRandomNumber(0, 40);
                r[0] = s[a];
                if (flag[a]) goto start;
                    flag[a] = true;
                    return r;
            }
            else
            {
                pickUpStu(n - 1, r);
            mmm: int a = GetRandomNumber(0, 40);
                r[n - 1] = s[a];
                for (int i = 0; i < n - 1; i++)
                {
                    if (r[i] == r[n - 1]||flag[a]) goto mmm;
                }
                flag[a] = true;
                return r;
            }
        }

        public static int GetRandomNumber(int min, int max)
        {
            int rtn = 0;
            Random r = new Random();
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            r = new Random(iSeed);
            rtn = r.Next(min, max + 1);
            return rtn;
        }

        private void buttonReduce_Click(object sender, RoutedEventArgs e)
        {
            setNumber(-1);
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            setNumber(1);
        }

        public void setNumber(int n)
        {
            number += n;
            if (number >= 4)
            {
                number = 4;
                buttonAdd.IsEnabled = false;
            }
            if (number>1&&number<4)
            {
                buttonAdd.IsEnabled = true;
                buttonReduce.IsEnabled = true;
            }
            if (number<=1)
            {
                number = 1;
                buttonReduce.IsEnabled = false;
            }
            textbox1.Text = Convert.ToString(number);
        }

        private void buttonStart_MouseMove(object sender, MouseEventArgs e)
        {
            buttonStart.Content = "GO!";
        }


        private void buttonStart_MouseLeave(object sender, MouseEventArgs e)
        {
            buttonStart.Content = "Ready?";
        }

        private void buttonStart_MouseEnter(object sender, MouseEventArgs e)
        {
            buttonStart.Content = "GO!";
        }
    }
}
