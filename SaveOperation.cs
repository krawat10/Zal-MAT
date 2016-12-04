using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Projekt
{
    class SaveOperation : InOutOperation
    {
        public SaveOperation() : base()
        { }


        public override void OperationIO(InOutOperation Out)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Lista";
            dlg.DefaultExt = ".xml";
            dlg.Filter = "XML documents (.xml)|*.xml";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                using (var sw = new StreamWriter(dlg.FileName))
                {
                var serializer = new XmlSerializer(typeof(InOutOperation));
                serializer.Serialize(sw, Out);
                }
            }

        }
    }
}
