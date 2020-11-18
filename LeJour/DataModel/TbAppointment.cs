using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace LeJour.DataModel
{
    public class TbAppointment
    {
        [JsonPropertyName("ID")]
        public string idAppointment { get; set; }
        [JsonPropertyName("WEDDING_ID")]
        public string idWedding { get; set; }
        [JsonPropertyName("VENDOR_ID")]
        public string idVendor { get; set; }
        [JsonPropertyName("STATUS")]
        public string idStatus { get; set; }
        [JsonPropertyName("VENDOR_CATEGORY")]
        public string dsCategoryVendor { get; set; }
        [JsonPropertyName("BEGINS_AT")]
        public string dtAppointment { get; set; }
    }
}
