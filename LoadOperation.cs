using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Xml.Serialization;

namespace Projekt
{
    class LoadOperation : InOutOperation
    {
        public LoadOperation() : base()
        { }


        public void OperationIO(ObservableCollection<Projekt.Waluty> AddWaluty, ObservableCollection<Projekt.Surowce> AddSurowce)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();
            string filename = "";

            if (result == true)
            {
            filename = dlg.FileName;
            }

            if (!(File.Exists(filename)))
            {
            MessageBox.Show(@"Such file doesn't exist");
            }
                   
            using (var sr = new StreamReader(filename))
            {
                var deserializer = new XmlSerializer(typeof(InOutOperation));
                InOutOperation tmpList = (InOutOperation)deserializer.Deserialize(sr);

                foreach (var item in tmpList.WalutyList)
                {
                AddWaluty.Add(item);
                }

                foreach (var item in tmpList.SurowceList)
                {
                AddSurowce.Add(item);
                }
            }           
        }


    }
}
