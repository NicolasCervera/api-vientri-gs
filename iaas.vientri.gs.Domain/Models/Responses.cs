using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iaas.vientri.gs.Domain.Models
{
    public class Responses
    {

    }

    public class ErrorResponse
    {
        public long codeError { get; set; }
        public string messageError { get; set; }
    }


    public class ListaPorCuitResponse
    {
        public string Cuit { get; set; }
        public string RazonSocial { get; set; }
        public string CantidadPolizas { get; set; }
        public string Polizas { get; set; }
    }

    public class ListaNominaResponse
    {
        public List<NominaResponse> ListNomina { get; set; }
    }

    public class NominaResponse
    {
        public string NroPoliza { get; set; }
        public string Producto { get; set; }
        public string Id { get; set; }
        public string NroCertificado { get; set; }
        public string ApeNomTitutlar { get; set; }
        public string NroDocTitular { get; set; }
        public string VigAltaTitular { get; set; }
        public string VigBajaTitular { get; set; }
        public string ApeNomConyuge { get; set; }
        public string NroDocConyuge { get; set; }
        public string VigAltaConyuge { get; set; }
        public string VigBajaConyuge { get; set; }
    }

    public class ListaCertificadosResponse
    {
        public string IdentificadorUnico { get; set; }
        public string NroPoliza { get; set; }
        public string NroCertificado { get; set; }
        public string Legajo { get; set; }
        public string VigenciaAlta { get; set; }
        public string VigenciaBaja { get; set; }
        public string SumaAsegurada { get; set; }
        public string ApellidoNombre { get; set; }
    }

    public class DescargaCertificadoResponse
    {
        public string Pdf { get; set; }
    }

    public class Reponse
    {
        public string respuesta { get; set; }
    }

    public class LeerPdfReponse
    {
        public string respuesta { get; set; }
    }
}
