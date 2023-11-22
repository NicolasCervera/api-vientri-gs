using iaas.vientri.gs.Application.Implementation.Interfaces;
using iaas.vientri.gs.Domain.Models;
using iaas.vientri.gs.Domain.Repositories;
using iaas.vientri.gs.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iaas.vientri.gs.Application.Implementation
{
    public class VientriServices : IVientriServices
    {
        private readonly IConfiguration _configuration;
        private readonly IVientriRepositories _vientriRepositories;
        private bool autorizado = true;

        public VientriServices(IConfiguration configuration, IVientriRepositories vientriRepositories) 
        { 
            _configuration = configuration;
            _vientriRepositories = vientriRepositories;
        }

        public async Task<ListaPorCuitResponse> ListaPorCuit(string cuit, long userId)
        {
            try
            {
                ListaPorCuitResponse response = new ListaPorCuitResponse();

                if (userId <= 0)
                {
                    autorizado = false;
                }

                if (cuit == "")
                {
                    throw new Exception("Debe de indicar un CUIT");
                }
                else
                {
                    response = _vientriRepositories.ObtenerListaPorCuit(cuit);

                    if(response.Cuit != "")
                    {

                    }    
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el proceso de obtener la lista por cuits.");
            }
        }

        public async Task<ListaNominaResponse> ListaNominaPorPoliza(long nroPoliza, long userId)
        {
            try
            {
                ListaNominaResponse response = new ListaNominaResponse();
                
                if (userId <= 0)
                {
                    autorizado = false;
                }

                if (nroPoliza == 0)
                {
                    throw new Exception("Debe de indicar un número de póliza");
                }
                else
                {
                    response = _vientriRepositories.ObtenerListaNomina(nroPoliza);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el proceso de obtener la lista de nominas por número de póliza.", ex);
            }
        }

        public async Task<ListaCertificadosResponse> ListaCertificados(long nroDocumento, long userId)
        {
            try
            {
                ListaCertificadosResponse response = new ListaCertificadosResponse();

                if (userId <= 0)
                {
                    autorizado = false;
                }

                if (nroDocumento == 0)
                {
                    throw new Exception("Debe de indicar un número de documento.");
                }
                else
                {
                    response = _vientriRepositories.ObtenerCertificado(nroDocumento);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el proceso de obtener la lista de certificados por número de documento.", ex);
            }
        }

        public async Task<DescargaCertificadoResponse> DescargaCertificado(long idNomina, long userId)
        {
            try
            {
                DescargaCertificadoResponse response = new DescargaCertificadoResponse();

                if (userId <= 0)
                {
                    autorizado = false;
                }

                if (idNomina == 0)
                {
                    throw new Exception("Debe de indicar un número de nómina");
                }
                else
                {
                    response = _vientriRepositories.DescargarCertificado(idNomina);
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el proceso de obtener la lista de certificados por número de nómina.", ex);
            }
        }

        public async Task<Reponse> GeneraPdfPoliza(string idNomina, long userId)
        {
            try
            {
                Reponse response = new Reponse();

                if (userId <= 0)
                {
                    autorizado = false;
                }

                if (idNomina == "")
                {
                    throw new Exception("Debe de indicar un número de nómina");
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el proceso de obtener un archivo pdf de póliza por número de nómina.", ex);
            }
        }

        public async Task<Reponse> GeneraPdfNomina(long nroPoliza, long userId)
        {
            try
            {
                Reponse response = new Reponse();

                if (userId <= 0)
                {
                    autorizado = false;
                }

                if (nroPoliza == 0)
                {
                    throw new Exception("Debe de indicar un número de póliza");
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el proceso de obtener un archivo pdf de nóminas por número de póliza.", ex);
            }
        }

        public async Task<LeerPdfReponse> LeerPdf(long nroPoliza)
        {
            try
            {
                LeerPdfReponse response = new LeerPdfReponse();

                if (nroPoliza == 0)
                {
                    throw new Exception("Debe de indicar un número de póliza");
                }

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error en el proceso de lectura de un archivo pdf.", ex);
            }
        }
    }

    
}
