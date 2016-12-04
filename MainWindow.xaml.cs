using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;


namespace Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Waluty> WalutyList { get; set; }
        public ObservableCollection<Surowce> SurowceList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            WalutyList = new ObservableCollection<Waluty>();
            SurowceList = new ObservableCollection<Surowce>();
            Waluty example = new Waluty(2.0, Waluty.EnumWaluty.Dollar, Waluty.Skrot.USD);
            WalutyList.Add(example);

            this.KategorieComboBox.ItemsSource = Enum.GetValues(typeof(Przedmioty.EnumPrzedmioty));
            this.KategorieComboBox.SelectedIndex = 0;
        }


        private void KategorieComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Pętla odpowiedzialna za zmiane Comboboxu z wyborem rodzaju przedmiotu
            //np. Wybiore Surowce w KategorieComboBox to automatycznie w ObjectComboBox generuje sie lista Surowców
            switch (KategorieComboBox.SelectedIndex)
            {
                case (int)Przedmioty.EnumPrzedmioty.Surowiec:
                    this.ObjectComboBox.ItemsSource = Enum.GetValues(typeof(Surowce.EnumSurowce));
                    this.ObjectComboBox.SelectedIndex = 0; break;

                case (int)Przedmioty.EnumPrzedmioty.Waluta:
                    this.ObjectComboBox.ItemsSource = Enum.GetValues(typeof(Waluty.EnumWaluty));
                    this.ObjectComboBox.SelectedIndex = 0; break;
            }
        }


        private void ObjectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Pętla odpowiedzialna za zmiane Jednostki przy Boksie Tekstowym(MeasureTextBox) 
            // np. wybiorę Ropę to zamienia automatycznie jednostkę na metry sześcienne
            //W głównej pętli (Sprawdza Kategorie, czyli czy Surowiec lub Waluta), umieszczone są 2 pętle(Dla surowców i walut) 
            //które odpowiednio zmieniają Jednostkę (czyli w Surowcach kg, metry^3, w Walutach EUR, USD, CHF)                                
            switch (KategorieComboBox.SelectedIndex)
            {
                case (int)Przedmioty.EnumPrzedmioty.Surowiec:
                    switch (ObjectComboBox.SelectedIndex)
                    {
                        case (int)Surowce.EnumSurowce.Gaz:
                            MeasureTextBox.Text = Surowce.MetrSzescienny; break;

                        case (int)Surowce.EnumSurowce.Ropa:
                            MeasureTextBox.Text = Surowce.MetrSzescienny; break;

                        case (int)Surowce.EnumSurowce.Koks:
                            MeasureTextBox.Text = Surowce.Kilogram; break;
                    }
                    break;

                case (int)Przedmioty.EnumPrzedmioty.Waluta:
                    switch (ObjectComboBox.SelectedIndex)
                    {
                        case (int)Waluty.EnumWaluty.Dollar:
                            MeasureTextBox.Text = Waluty.Skrot.USD.ToString(); break;

                        case (int)Waluty.EnumWaluty.Euro:
                            MeasureTextBox.Text = Waluty.Skrot.EUR.ToString(); break;

                        case (int)Waluty.EnumWaluty.Frank:
                            MeasureTextBox.Text = Waluty.Skrot.CHF.ToString(); break;
                    }
                    break;
            }
        }
        

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            switch (KategorieComboBox.SelectedIndex)
            {
                //Dodawanie danego przedmiotu do listy 
                //Pętla ze względów 2 kategorii, czyli program musi wiedzieć czy dodać to do listy WalutyList, czy do SurowceList
                case (int)Przedmioty.EnumPrzedmioty.Waluta:
                    double IloscWaluta;
                    try
                        {
                             double IloscWalutaTry = double.Parse(this.AmountTextBox.Text);
                             IloscWaluta = IloscWalutaTry;
                        }
                    catch (FormatException)
                        {
                            this.AmountTextBox.Text = "";
                            MessageBox.Show(@"Zły format");
                            break;
                        }
                    Waluty.EnumWaluty Waluta = (Waluty.EnumWaluty)this.ObjectComboBox.SelectedIndex;
                    Waluty.Skrot Skrot = (Waluty.Skrot)Enum.Parse(typeof(Waluty.Skrot), MeasureTextBox.Text);
                    Waluty AddWaluta = new Waluty(IloscWaluta, Waluta, Skrot);
                    WalutyList.Add(AddWaluta);
                    break;

                case (int)Przedmioty.EnumPrzedmioty.Surowiec:
                    double IloscSurowce;
                    try
                    {
                        double IloscSurowceTry = double.Parse(this.AmountTextBox.Text);
                        IloscSurowce = IloscSurowceTry;
                    }
                    catch (FormatException)
                    {
                        this.AmountTextBox.Text = "";
                        MessageBox.Show(@"Zły format");
                        break;
                    }
                    Surowce.EnumSurowce Surowce = (Surowce.EnumSurowce)this.ObjectComboBox.SelectedIndex;
                    string Jednostka = MeasureTextBox.Text;
                    Surowce AddSurowce = new Surowce(IloscSurowce, Surowce, Jednostka);
                    SurowceList.Add(AddSurowce);
                    break;
            }
        }


        private void DeleteWalutyButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.WalutyList.RemoveAt(this.Waluty_ListView.SelectedIndex);
            }
            catch { }
        }


        private void DeleteSurowceButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.SurowceList.RemoveAt(this.Surowce_ListView.SelectedIndex);
            }
            catch { }
        }


        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            InOutOperation CombinedList = new InOutOperation(WalutyList, SurowceList);            
            SaveOperation save = new SaveOperation();
            save.OperationIO(CombinedList);
        }
        

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            LoadOperation load = new LoadOperation();
            load.OperationIO(WalutyList, SurowceList);
        }


    }
}