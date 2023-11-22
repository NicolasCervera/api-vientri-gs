using iaas.vientri.gs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iaas.vientri.gs.Application.Implementation.Interfaces
{
    public interface IVientriServices
    {
        Task<ListaNominaResponse> ListaNominaPorPoliza(long nroPoliza, long userId);
        Task<ListaPorCuitResponse> ListaPorCuit(string cuit, long userId);
        Task<ListaCertificadosResponse> ListaCertificados(long nroDocumento, long userId);
        Task<DescargaCertificadoResponse> DescargaCertificado(long idNomina, long userId);
        Task<Reponse> GeneraPdfPoliza(string idNomina, long userId);
        Task<Reponse> GeneraPdfNomina(long nroPoliza, long userId);
        Task<LeerPdfReponse> LeerPdf(long nroPoliza);
    }
}
