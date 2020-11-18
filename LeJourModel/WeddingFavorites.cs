using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace LeJourModel
{
    public class WeddingFavorites
    {
        [JsonPropertyName("wedding_id")]
        public string idWedding { get; set; }
        [JsonPropertyName("vendor_id")]
        public string idVendor { get; set; }
    }
}
