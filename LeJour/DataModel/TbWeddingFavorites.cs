using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace LeJour.DataModel
{
    public class TbWeddingFavorites
    {
        [JsonPropertyName("wedding_id")]
        public string idWedding { get; set; }
        [JsonPropertyName("vendor_id")]
        public string idVendor { get; set; }
    }
}
