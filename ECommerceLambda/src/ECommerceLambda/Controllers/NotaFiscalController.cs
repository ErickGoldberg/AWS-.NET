using ECommerceLambda.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceLambda.Controllers
{
    [Route("api/nota-fiscal")]
    [ApiController]
    public class NotaFiscalController : ControllerBase
    {
        private readonly IStorageService storageService;

        public NotaFiscalController(IStorageService storageService)
        {
            this.storageService = storageService;
        }

        [HttpGet("download/{documento}/{ano}/{mes}/{dia}/{idNotaFiscal}")]
        public async Task<IActionResult> DownloadNotaFiscal(string documento, string ano, string mes, string dia, string idNotaFiscal)
        {
            var chaveArquivo = $"{documento}/{ano}/{mes}/{dia}/{idNotaFiscal}.json";
            var nomeArquivo = chaveArquivo.Replace("/", "-");

            var objeto = await this.storageService.DownloadArquivo("notas-emitidas-bucket", chaveArquivo);

            return File(objeto, "application/octet-stream", nomeArquivo);
        }

    }
}
