using iaas.vientri.gs.Domain;
using iaas.vientri.gs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iaas.vientri.gs.Domain.Repositories.Interfaces
{
    public interface IVientriRepositories
    {
        ListaPorCuitResponse ObtenerListaPorCuit(string cuit);
        ListaNominaResponse ObtenerListaNomina(long nroPoliza);
        ListaCertificadosResponse ObtenerCertificado(long nroDocumento);
        DescargaCertificadoResponse DescargarCertificado(long idNomina);
    }
}
