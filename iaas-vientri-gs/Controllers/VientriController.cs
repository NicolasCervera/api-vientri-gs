using iaas.vientri.gs.Application.Implementation;
using iaas.vientri.gs.Application.Implementation.Interfaces;
using iaas.vientri.gs.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace iaas_vientri_gs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VientriController : ControllerBase
    {
        private readonly IVientriServices _vientriServices;

        public VientriController(IVientriServices vientriServices)
        {
           _vientriServices = vientriServices;
        }

        [SwaggerResponse(StatusCodes.Status200OK, "Devolver lista de polizas por CUIT", Type = typeof(ListaPorCuitResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpGet]
        [Route("V1/Vientri/ListaPorCuit")]
        public async Task<IActionResult> ListaPorCuit(string cuit, long userId)
        {
            try
            {
                var response = await _vientriServices.ListaPorCuit(cuit, userId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    codeError = 1,
                    messageError = ex.Message
                });
            }
        }

        [SwaggerResponse(StatusCodes.Status200OK, "Devolver lista de polizas por CUIT", Type = typeof(ListaNominaResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpGet]
        [Route("V1/Vientri/ListaNominaPorPoliza")]
        public async Task<IActionResult> ListaNominaPorPoliza(long nroPoliza, long userId)
        {
            try
            {
                var response = await _vientriServices.ListaNominaPorPoliza(nroPoliza, userId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    codeError = 1,
                    messageError = ex.Message
                });
            }
        }

        [SwaggerResponse(StatusCodes.Status200OK, "Devolver lista de certificados por DNI", Type = typeof(ListaCertificadosResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpGet]
        [Route("V1/Vientri/ListaCertificados")]
        public async Task<IActionResult> ListaCertificados(long nroDocumento, long userId)
        {
            try
            {
                var response = await _vientriServices.ListaCertificados(nroDocumento, userId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    codeError = 1,
                    messageError = ex.Message
                });
            }
        }

        [SwaggerResponse(StatusCodes.Status200OK, "Devolver descarga de certificado.", Type = typeof(DescargaCertificadoResponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpGet]
        [Route("V1/Vientri/DescargaCertificado")]
        public async Task<IActionResult> DescargaCertificado(long idNomina, long userId)
        {
            try
            {
                var response = await _vientriServices.DescargaCertificado(idNomina, userId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    codeError = 1,
                    messageError = ex.Message
                });
            }
        }

        [SwaggerResponse(StatusCodes.Status200OK, "Generar PDF de póliza.", Type = typeof(Reponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpGet]
        [Route("V1/Vientri/GeneraPdfPoliza")]
        public async Task<IActionResult> GeneraPdfPoliza(string idNomina, long userId)
        {
            try
            {
                var response = await _vientriServices.GeneraPdfPoliza(idNomina, userId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    codeError = 1,
                    messageError = ex.Message
                });
            }
        }

        [SwaggerResponse(StatusCodes.Status200OK, "Generar PDF de nómina.", Type = typeof(Reponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpGet]
        [Route("V1/Vientri/GeneraPdfNomina")]
        public async Task<IActionResult> GeneraPdfNomina(long nroPoliza, long userId)
        {
            try
            {
                var response = await _vientriServices.GeneraPdfNomina(nroPoliza, userId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    codeError = 1,
                    messageError = ex.Message
                });
            }
        }

        [SwaggerResponse(StatusCodes.Status200OK, "Lee PDF.", Type = typeof(LeerPdfReponse))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, Type = typeof(ErrorResponse))]
        [HttpGet]
        [Route("V1/Vientri/LeePdf")]
        public async Task<IActionResult> LeerPdf(long nroPoliza)
        {
            try
            {
                var response = await _vientriServices.LeerPdf(nroPoliza);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse()
                {
                    codeError = 1,
                    messageError = ex.Message
                });
            }
        }
    }
}