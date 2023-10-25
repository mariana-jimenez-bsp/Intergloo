using SegmentacionDeAsientos.Connection.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SegmentacionDeAsientos.Connection.DataSet1;
using static SegmentacionDeAsientos.Data.dtasientos;

namespace SegmentacionDeAsientos.Connection
{
    class connection
    {
        public List<dtasiento> ViewAsientosSeparado()
        {
                List<dtasiento> listasientos = new List<dtasiento>();

                ObtenerPaquetesSeparadosTableAdapter Adapter = new ObtenerPaquetesSeparadosTableAdapter();
                ObtenerPaquetesSeparadosDataTable data = Adapter.GetData();

                foreach (ObtenerPaquetesSeparadosRow row in data)
                {
                    dtasiento _clAsiento = new dtasiento();
                    _clAsiento.Asiento = row.ASIENTO;
                    listasientos.Add(_clAsiento);
                }
                return listasientos;

        }

        public List<dtasiento> ViewAsientosSN()
        {
            List<dtasiento> listasientos = new List<dtasiento>();

            ObtenerPaquetesSNTableAdapter Adapter = new ObtenerPaquetesSNTableAdapter();
            ObtenerPaquetesSNDataTable data = Adapter.GetData();

            foreach (ObtenerPaquetesSNRow row in data)
            {
                dtasiento _clAsiento = new dtasiento();
                _clAsiento.Asiento = row.ASIENTO;
                listasientos.Add(_clAsiento);
            }
            return listasientos;

        }


        public string PasoUno()
        {
            string resultCode = "-1";

            Paso_AsientoTableAdapter Adapter = new Paso_AsientoTableAdapter();
            Paso_AsientoDataTable data = Adapter.GetData();

            foreach (Paso_AsientoRow row in data)
            {
                resultCode = row.ResultCode;
            }

            return resultCode;

        }

        public string PasoDos(string asientoNuevo, string aseintoanterior)
        {
            string resultCode = "-1";
            try
            {
                SEGMENTAR_ASIENTOTableAdapter Adapter = new SEGMENTAR_ASIENTOTableAdapter();
                SEGMENTAR_ASIENTODataTable data = Adapter.GetData(asientoNuevo, aseintoanterior);
                resultCode = "1";
                return resultCode;
            }
            catch
            {
                return resultCode;
            }
        }

    }
}
