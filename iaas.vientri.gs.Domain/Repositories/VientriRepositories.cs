using iaas.vientri.gs.Domain.Models;
using iaas.vientri.gs.Domain.Repositories.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace iaas.vientri.gs.Domain.Repositories
{
    public class VientriRepositories : IVientriRepositories
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString = "";

        public VientriRepositories(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public ListaPorCuitResponse ObtenerListaPorCuit(string cuit)
        {
            try
            {
                ListaPorCuitResponse response = new ListaPorCuitResponse();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"Select 
                                PR.CUIT,rtrim(PR.RAZON_SOCIAL) razonSocial,isnull(PLS.cantidad,0) POLIZAS,PR.id
                                From
                                SGA_GALICIA..PER PR 
                                left join (Select idper_tomador,count(1) cantidad from SGA_GALICIA..POLIZA group     by IDPER_TOMADOR) PLS on PR.id=PLS.IDPER_TOMADOR
                                Where
                                PR.CUIT=@cuit and PR.utransac='V' and PR.idtipper>0";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@cuit", cuit);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                while (reader.Read())
                                {
                                    response.Cuit = reader["CUIT"].ToString();
                                    response.Polizas = reader["POLIZAS"].ToString();
                                    response.RazonSocial = reader["RAZONSOCIAL"].ToString();
                                }
                            }
                        }
                    }
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ListaPorCuitResponse ObtenerListaPorIdTomador(string cuit)
        {
            try
            {
                ListaPorCuitResponse response = new ListaPorCuitResponse();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"Select 
                PR.CUIT,rtrim(PR.RAZON_SOCIAL) razonSocial,isnull(PLS.cantidad,0) POLIZAS,PR.id
                From
                SGA_GALICIA..PER PR 
                left join (Select idper_tomador,count(1) cantidad from SGA_GALICIA..POLIZA group by IDPER_TOMADOR) PLS on PR.id=PLS.IDPER_TOMADOR
                Where
                PR.CUIT=@cuit and PR.utransac='V' and PR.idtipper>0";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@cuit", cuit);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                response.Cuit = reader["CUIT"].ToString();
                                response.Polizas = reader["POLIZAS"].ToString();
                                response.RazonSocial = reader["RAZONSOCIAL"].ToString();
                            }
                        }
                    }
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ListaNominaResponse ObtenerListaNomina(long nroPoliza)
        {
            try
            {
                ListaNominaResponse response = new ListaNominaResponse();
                NominaResponse nomina = new NominaResponse();
                response.ListNomina = new List<NominaResponse>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"Select 
                                 PL.numero nroPoliza,
                                 rtrim(PR.des) producto,
                                 NM.id,NM.nCertificado nroCertificado,
                                 rtrim(TIT.des) apeNomTitular,TIT.nrodoc nroDocTitular,
                                 NM.VIGALT vigAltaTitular,NM.VIGBAJ vigBajaTitular,
                                 isnull(rtrim(CNY.des),'') apeNomConyuge,isnull(CNY.nrodoc,0) nroDocConyuge,
                                 NM.VIGALTC vigAltaConyuge,NM.VIGBAJC vigBajaConyuge
                                From
                                 SGA_GALICIA..NOMINA NM
                                 inner join SGA_GALICIA..POLIZA PL on NM.idpoliza=PL.id and PL.numero=@nroPoliza
                                 inner join SGA_GALICIA..PRODUCTO PR on PL.idproducto=PR.id
                                 inner join SGA_GALICIA..PER TIT on NM.idper_titular = TIT.id
                                 inner join SGA_GALICIA..PER CNY on NM.idper_conyuge = CNY.id
                                Where
                                 NM.utransac='V'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nroPoliza", nroPoliza);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                nomina.NroPoliza = reader["NROPOLIZA"].ToString();
                                nomina.Producto = reader["PRODUCTO"].ToString();
                                nomina.NroCertificado = reader["NROCERTIFICADO"].ToString();
                                nomina.ApeNomTitutlar = reader["APENOMTITULAR"].ToString();
                                nomina.NroDocTitular = reader["NRODOCTITULAR"].ToString();
                                nomina.VigAltaTitular = reader["VIGALTATITULAR"].ToString();
                                nomina.VigBajaTitular = reader["VIGBAJATITULAR"].ToString();
                                nomina.ApeNomConyuge = reader["APENOMCONYUGE"].ToString();
                                nomina.NroDocConyuge = reader["NRODOCCONYUGE"].ToString();
                                nomina.VigAltaConyuge = reader["VIGALTACONYUGE"].ToString();
                                nomina.VigBajaConyuge = reader["VIGBAJACONYUGE"].ToString();

                                response.ListNomina.Add(nomina);
                                nomina = new NominaResponse();
                            }
                        }
                    }
                }

                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ListaCertificadosResponse ObtenerCertificado(long nroDocumento)
        {
            try
            {
                ListaCertificadosResponse response = new ListaCertificadosResponse();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"Select 
                                NM.id identificadorUnico
                                ,PL.numero nroPoliza 
                                ,NM.nCertificado nroCertificado
                                ,NM.legajo
                                ,isnull(NM.vigAlt,NM.vigAltC) vigenciaAlta
                                ,isnull(NM.vigBaj,NM.vigBajC) vigenciaBaja
                                ,isnull(NM.sum_t,NM.sum_c) sumaAsegurada
                                ,isnull(TIT.DES,CON.DES) apellidoNombre
                             From
                                SGA_GALICIA..NOMINA NM
                                inner join SGA_GALICIA..POLIZA PL on NM.idpoliza=PL.id
                                left join SGA_GALICIA..PER TIT on NM.IDPER_TITULAR=TIT.ID
                                left join SGA_GALICIA..PER CON on NM.IDPER_CONYUGE=CON.ID
                             Where
                                (Tit.nrodoc=@nroDocumento or Con.nrodoc=@nroDocumento )
                                and NM.utransac='V'";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@nroDocumento", nroDocumento);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                response.IdentificadorUnico = reader["IDENTIFICADORUNICO"].ToString();
                                response.NroPoliza = reader["NROPOLIZA"].ToString(); ;
                                response.NroCertificado = reader["NROCERTIFICADO"].ToString(); ;
                                response.Legajo = reader["LEGAJO"].ToString(); ;
                                response.VigenciaAlta = reader["VIGENCIAALTA"].ToString(); ;
                                response.VigenciaBaja = reader["VIGENCIABAJA"].ToString(); ;
                                response.SumaAsegurada = reader["SUMAASEGURADA"].ToString(); ;
                                response.ApellidoNombre = reader["APELLIDONOMBRE"].ToString(); ;
                            }
                        }
                    }
                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DescargaCertificadoResponse DescargarCertificado(long idNomina)
        {
            try
            {
                DescargaCertificadoResponse response = new DescargaCertificadoResponse();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"Select pdf from sga_pdf..pdf where idnomina=@idnomina and utransac='V' and idbasesdedatos=116";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@idnomina", idNomina);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            foreach (DataRow item in reader)
                            {

                            }
                        }
                    }
                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LeerPdfReponse> LeerPdf()
        {
            try
            {
                LeerPdfReponse response = new LeerPdfReponse();

                await using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql = @"select pdf from sga_pdf..pdf where idcmp in (Select id from sga_galicia..poliza where numero=${nroPoliza.toString()}) and utransac='V' and idbasesdedatos=116";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            foreach (DataRow item in reader)
                            {

                            }
                        }
                    }
                }

                return response;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
