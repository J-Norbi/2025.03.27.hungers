using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace _2_14fi_hunger_games
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        string name = "névtelen";
        public string Namee
        {
            get
            {
                return name;
            }
            set 
            {
                name = value;
                OnPropertyChanged("Namee");
            }
        }
        int ehsegSzazalek = 100;
        string kolbaszContent = "Kolbász";
        int money = 1000;
        public string KolbaszContent
        {
            get
            {
                return kolbaszContent;
            }
            set
            {
                if(value.ToLower() == "csokken")
                {
                    kolbaszContent = kolbaszContent.Substring(0, kolbaszContent.Length - 1);
                }
                else if(value.ToLower() == "ujratolt")
                {
                    kolbaszContent = "Kolbász";
                }
                OnPropertyChanged("KolbaszContent");
            }
        }
        public int EhsegSzazalek
        {
            get
            {
                return ehsegSzazalek;
            }
            set
            {
                ehsegSzazalek = value;

                if (ehsegSzazalek > 70)
                    ehseg.Background = new SolidColorBrush(Colors.Red);
                else if (ehsegSzazalek > 40)
                    ehseg.Background = new SolidColorBrush(Colors.Orange);
                else
                    ehseg.Background = new SolidColorBrush(Colors.Green);

                OnPropertyChanged("EhsegSzazalek");
            }
        }
        public int Money
        {
            get
            {
                return money;
            }
            set
            {
                money = value;

                OnPropertyChanged("Money");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;   //  ChatGPT

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        void NameChange(object s, EventArgs e)
        {
            Namee = "Aladár";
        }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;     // ez kapcsolja össze az xaml fájlunkat, az xaml.cs-sel, így az xaml-ben lévő Binding-ot ott fogja keresni
        }
        void KetchupClick(object s, EventArgs e)
        {
            if (money >= 10)
            {
                //string content = kolbasz.Content.ToString();
                if (KolbaszContent.Length > 0)
                {
                    //kolbasz.Content = content.Substring(0, content.Length - 1);
                    //int ehsegSzazalek = int.Parse(ehseg.Content.ToString().Trim('%'));
                    KolbaszContent = "csokken";
                    if (ehsegSzazalek >= 5)
                    {
                        EhsegSzazalek -= 5;
                        //ehseg.Content = (ehsegSzazalek - 5).ToString() + '%';
                    }
                    //EhsegBackground();
                    //money -= 10;
                    //moneyInput.Text = money.ToString();
                    Money -= 10;
                }
            }
        }
        void KolbaszClick(object s, EventArgs e)
        {
            MessageBox.Show($"{name} éhes, kolbászt szeretne enni");
        }
        void DisznoClick(object s, EventArgs e)
        {
            KolbaszContent = "ujratolt";
            //kolbasz.Content = "Kolbász";
            //int ehsegSzazalek = int.Parse(ehseg.Content.ToString().Trim('%'));
            //ehseg.Content = (ehsegSzazalek + 20) + "%";
            EhsegSzazalek += 20;
            if (EhsegSzazalek > 100)
            {
                MessageBox.Show("Éhen haltál!");
                this.Close();
            }
            //EhsegBackground();
        }
        //
        //  Ez a függvény feleslegessé válik, az EhsegSzazalek függvény miatt
        //
        /*void EhsegBackground()
        {
            int ehsegSzazalek = int.Parse(ehseg.Content.ToString().Trim('%'));
            if (ehsegSzazalek > 70)
                ehseg.Background = new SolidColorBrush(Colors.Red);
            else if (ehsegSzazalek > 40)
                ehseg.Background = new SolidColorBrush(Colors.Orange);
            else
                ehseg.Background = new SolidColorBrush(Colors.Green);
        }*/
        void ImHungryClick(object s, EventArgs e)
        {
            Namee = nevInput.Text;
        }
        void MoneyClick(object s, EventArgs e)
        {
            Money = int.Parse(moneyInput.Text.ToString());
            //money = int.Parse(moneyInput.Text.ToString());
            //moneyInput.IsEnabled = false;
            //moneyButton.Click -= MoneyClick;
        }
    }
}
