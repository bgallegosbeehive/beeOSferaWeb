using Newtonsoft.Json;

namespace beeOSferaWeb.Apis.Models
{
    public class Vivienda
    {
        [JsonProperty("idVivienda")]
        public int Id { get; set; }

        [JsonProperty("identificador")]
        public string Identificador { get; set; }

        [JsonProperty("descripcion")]
        public string descripcion { get; set; }

        [JsonProperty("IdCondominio")]
        public int IdCondominio { get; set; }

        [JsonProperty("Calle")]
        public string Calle { get; set; }

        [JsonProperty("numExt")]
        public int numExt { get; set; }

        [JsonProperty("numInt")]
        public string numInt { get; set; }

        [JsonProperty("registradaPor")]
        public int registradaPor { get; set; }

        [JsonProperty("fechaRegistro")]
        public DateTime? fechaRegistro { get; set; }

        [JsonProperty("IdTipoVivienda")]
        public int IdTipoVivienda { get; set; }

        [JsonProperty("solicitarAutorizacionIngresoVisitantes")]
        public string solicitarAutorizacionIngresoVisitantes { get; set; }

        [JsonProperty("aceptarVisitas")]
        public string aceptarVisitas { get; set; }

        [JsonProperty("referenciaPago")]
        public string referenciaPago { get; set; }

        [JsonProperty("superficie")]
        public float superficie { get; set; }

        [JsonProperty("moroso")]
        public string moroso { get; set; }

        [JsonProperty("fechaCambioMoroso")]
        public DateTime? fechaCambioMoroso { get; set; }

        [JsonProperty("IdZona")]
        public int IdZona { get; set; }

        [JsonProperty("buscador")]
        public string buscador { get; set; }

        [JsonProperty("LM")]
        public string LM { get; set; }

        [JsonProperty("RFC")]
        public string RFC { get; set; }

        [JsonProperty("razonSocial")]
        public string razonSocial { get; set; }

        [JsonProperty("codigoUsoCFDI")]
        public string codigoUsoCFDI { get; set; }

        [JsonProperty("convenioFinanciero")]
        public string convenioFinanciero { get; set; }

        [JsonProperty("IdEstadoFinanciero")]
        public string IdEstadoFinanciero { get; set; }

        [JsonProperty("codigoPostalFacturacion")]
        public string codigoPostalFacturacion { get; set; }

        [JsonProperty("regimenFiscal")]
        public string regimenFiscal { get; set; }

        [JsonIgnore]
        public object Response { get; set; }
    }
}