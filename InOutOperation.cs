using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.IO;


namespace Projekt
{
    public class InOutOperation
    {
        public ObservableCollection<Projekt.Waluty> WalutyList { get; set; }
        public ObservableCollection<Projekt.Surowce> SurowceList { get; set; }

        public InOutOperation()
        { }

        public InOutOperation(ObservableCollection<Projekt.Waluty> AddWaluty, ObservableCollection<Projekt.Surowce> AddSurowce)
        {
            this.WalutyList = AddWaluty;
            this.SurowceList = AddSurowce;
        }


        public virtual void OperationIO(InOutOperation Out) { }                   
    }
}
