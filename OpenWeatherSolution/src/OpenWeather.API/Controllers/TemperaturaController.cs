using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OpenWeather.API.ViewModel;
using OpenWeather.Library.Services;
using System;
using System.Collections.Generic;

namespace OpenWeatherAPI.Controllers
{
    /// <summary>
    /// Ponto de consultade de dados referentes a temperatura de uma ou mais regiões em unidade métrica
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TemperaturaController : ControllerBase
    {
        private readonly ILogger<TemperaturaController> _logger;
        private readonly ITemperaturaService _temperaturaService;
        

        public TemperaturaController(ILogger<TemperaturaController> logger, ITemperaturaService temperaturaService)
        {
            _logger = logger;
            _temperaturaService = temperaturaService;
        }

        /// <summary>
        /// Consulta de dados de temperatura
        /// </summary>
        /// <param name="cidade">Cidades para consulta de temperatura (São Paulo, Florianópolis, Rio De janeiro)</param>
        /// <param name="dataInicio">Data inicial do histórico de pesquisa</param>
        /// <param name="dataFim">Data fim do histórico de pesquisa</param>
        /// <response code="200">Histórico de temperaturas das cidade/periodo informados</response>
        /// <response code="400">Dado de consulta inválido</response>
        /// <response code="500">Falha interna, favor tentar novamente mais tarde</response>
        [HttpGet("{cidade}")]
        [ProducesResponseType(typeof(List<TemperaturaViewModel>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(500)]
        public IActionResult Get(string cidade, DateTime dataInicio, DateTime dataFim)
        {
            if (string.IsNullOrWhiteSpace(cidade))
            {
                return BadRequest("A cidade deve ser informada para a consulta");
            }
            else if (dataInicio > dataFim)
            {
                return BadRequest("A data de inicio da pesquisa é maior que a data de fim");
            }

            var listaTemperatura = _temperaturaService.Listar(cidade, dataInicio, dataFim);

            return Ok(listaTemperatura);
        }
    }
}
