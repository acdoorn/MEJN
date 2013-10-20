﻿using MensErgerJeNiet.ModelView;
using MensErgerJeNiet.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

namespace MensErgerJeNiet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ModelView.Game theGame;
        private PreGameScreen pgs;
        private Model.Spawn[] spawns;

        public MainWindow()
        {
            InitializeComponent();
            pgs = new PreGameScreen(this);
            theGame = new Game(this);
            dice.MouseLeftButtonUp += Button_Click;
            startingDice();
        }

        private void colorEllipses()
        {

            //color all the spawns
            int i = 0;
            Console.WriteLine("i =" + spawns.Length);
            while (i < spawns.Length)
            {
                if (spawns[i].fieldCode.StartsWith("p1") && spawns[i].pawn != null)
                {
                    getFieldEllipse(spawns[i].fieldCode).Fill = new SolidColorBrush(Colors.LawnGreen);
                    Console.WriteLine("Green");
                }
                else if(spawns[i].fieldCode.StartsWith("p1") && spawns[i].pawn == null) 
                {
                    getFieldEllipse(spawns[i].fieldCode).Fill = new SolidColorBrush(Colors.DarkGreen);
                    Console.WriteLine("DarkGreen");
                }
                else if (spawns[i].fieldCode.StartsWith("p2") && spawns[i].pawn != null)
                {
                    getFieldEllipse(spawns[i].fieldCode).Fill = new SolidColorBrush(Colors.Red);
                    Console.WriteLine("Red");
                }
                else if (spawns[i].fieldCode.StartsWith("p2") && spawns[i].pawn == null)
                {
                    getFieldEllipse(spawns[i].fieldCode).Fill = new SolidColorBrush(Colors.DarkRed);
                    Console.WriteLine("DarkRed");
                }
                else if (spawns[i].fieldCode.StartsWith("p3") && spawns[i].pawn != null)
                {
                    getFieldEllipse(spawns[i].fieldCode).Fill = new SolidColorBrush(Colors.Blue);
                    Console.WriteLine("Blue");
                }
                else if (spawns[i].fieldCode.StartsWith("p3") && spawns[i].pawn == null)
                {
                    getFieldEllipse(spawns[i].fieldCode).Fill = new SolidColorBrush(Colors.DarkBlue);
                    Console.WriteLine("DarkBlue");
                }
                else if (spawns[i].fieldCode.StartsWith("p4") && spawns[i].pawn != null)
                {
                    getFieldEllipse(spawns[i].fieldCode).Fill = new SolidColorBrush(Colors.Yellow);
                    Console.WriteLine("Yellow");
                }
                else if (spawns[i].fieldCode.StartsWith("p4") && spawns[i].pawn == null)
                {
                    getFieldEllipse(spawns[i].fieldCode).Fill = new SolidColorBrush(Colors.Goldenrod);
                    Console.WriteLine("LightGoldenrodYellow");
                }
                i++;
            }
        }

        public void refreshField(String fieldCode)
        {
            if (fieldCode.StartsWith("p1") && spawns[i].pawn != null)
            {
                getFieldEllipse(fieldCode).Fill = new SolidColorBrush(Colors.LawnGreen);
                Console.WriteLine("Green");
            }
            else if (fieldCode.StartsWith("p1") && spawns[i].pawn == null)
            {
                getFieldEllipse(fieldCode).Fill = new SolidColorBrush(Colors.DarkGreen);
                Console.WriteLine("DarkGreen");
            }
            else if (fieldCode.StartsWith("p2") && spawns[i].pawn != null)
            {
                getFieldEllipse(fieldCode).Fill = new SolidColorBrush(Colors.Red);
                Console.WriteLine("Red");
            }
            else if (fieldCode.StartsWith("p2") && spawns[i].pawn == null)
            {
                getFieldEllipse(fieldCode).Fill = new SolidColorBrush(Colors.DarkRed);
                Console.WriteLine("DarkRed");
            }
            else if (fieldCode.StartsWith("p3") && spawns[i].pawn != null)
            {
                getFieldEllipse(fieldCode).Fill = new SolidColorBrush(Colors.Blue);
                Console.WriteLine("Blue");
            }
            else if (fieldCode.StartsWith("p3") && spawns[i].pawn == null)
            {
                getFieldEllipse(fieldCode).Fill = new SolidColorBrush(Colors.DarkBlue);
                Console.WriteLine("DarkBlue");
            }
            else if (fieldCode.StartsWith("p4") && spawns[i].pawn != null)
            {
                getFieldEllipse(fieldCode).Fill = new SolidColorBrush(Colors.Yellow);
                Console.WriteLine("Yellow");
            }
            else if (fieldCode.StartsWith("p4") && spawns[i].pawn == null)
            {
                getFieldEllipse(fieldCode).Fill = new SolidColorBrush(Colors.Goldenrod);
                Console.WriteLine("LightGoldenrodYellow");
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }

        public void startGame(int players, int humans)
        {
            theGame.startGame(players, humans);
            spawns = theGame.board.Spawns;
            colorEllipses();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void startingDice()
        {
            changeDice(1);
        }

        public void changeDice(int value)
        {
            System.Reflection.Assembly thisExe = System.Reflection.Assembly.GetExecutingAssembly();
            string path = thisExe.Location;
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            string folderName = dirInfo.Parent.FullName;
            Uri uri = new Uri(folderName + "/Image" + value + ".jpg");
            BitmapImage img = new BitmapImage(uri);
            dice.Source = img;
            SoundPlayer player = new SoundPlayer(Properties.Resources.dice_throw);
            player.Play();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            changeDice(theGame.rollDice());
        }

        private Ellipse getFieldEllipse(String field)
        {
            switch (field)
            {
                case "p1spawn1":
                    return p1_base1;
                case "p1spawn2":
                    return p1_base2;
                case "p1spawn3":
                    return p1_base3;
                case "p1spawn4":
                    return p1_base4;
                case "p2spawn1":
                    return p2_base1;
                case "p2spawn2":
                    return p2_base2;
                case "p2spawn3":
                    return p2_base3;
                case "p2spawn4":
                    return p2_base4;
                case "p3spawn1":
                    return p3_base1;
                case "p3spawn2":
                    return p3_base2;
                case "p3spawn3":
                    return p3_base3;
                case "p3spawn4":
                    return p3_base4;
                case "p4spawn1":
                    return p4_base1;
                case "p4spawn2":
                    return p4_base2;
                case "p4spawn3":
                    return p4_base3;
                case "p4spawn4":
                    return p4_base4;
                case "f1":
                    return field1;
                case "f2":
                    return field2;
                case "f3":
                    return field3;
                case "f4":
                    return field4;
                case "f5":
                    return field5;
                case "f6":
                    return field6;
                case "f7":
                    return field7;
                case "f8":
                    return field8;
                case "f9":
                    return field9;
                case "f10":
                    return field10;
                case "f11":
                    return field11;
                case "f12":
                    return field12;
                case "f13":
                    return field13;
                case "f14":
                    return field14;
                case "f15":
                    return field15;
                case "f16":
                    return field16;
                case "f17":
                    return field17;
                case "f18":
                    return field18;
                case "f19":
                    return field19;
                case "f20":
                    return field20;
                case "f21":
                    return field21;
                case "f22":
                    return field22;
                case "f23":
                    return field23;
                case "f24":
                    return field24;
                case "f25":
                    return field25;
                case "f26":
                    return field26;
                case "f27":
                    return field27;
                case "f28":
                    return field28;
                case "f29":
                    return field29;
                case "f30":
                    return field30;
                case "f31":
                    return field31;
                case "f32":
                    return field32;
                case "p1end1":
                    return p1_end1;
                case "p1end2":
                    return p1_end2;
                case "p1end3":
                    return p1_end3;
                case "p1end4":
                    return p1_end4;
                case "p2end1":
                    return p2_end1;
                case "p2end2":
                    return p2_end2;
                case "p2end3":
                    return p2_end3;
                case "p2end4":
                    return p2_end4;
                case "p3end1":
                    return p3_end1;
                case "p3end2":
                    return p3_end2;
                case "p3end3":
                    return p3_end3;
                case "p3end4":
                    return p3_end4;
                case "p4end1":
                    return p4_end1;
                case "p4end2":
                    return p4_end2;
                case "p4end3":
                    return p4_end3;
                case "p4end4":
                    return p4_end4;
                default:
                    return new Ellipse();
            }
        }

        public void showEndMessage()
        {
            MessageBox.Show("The game has ended!");//to be edited
        }
    }
}
