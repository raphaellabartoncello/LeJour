using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace LeJourModel
{
   public class Wedding
    {
        [JsonPropertyName("ID")]
        public string idWedding { get; set; }
        [JsonPropertyName("OWNER_ID")]
        public string idUser { get; set; }
        [JsonPropertyName("BUDGET")]
        public string vlBudget { get; set; }
        [JsonPropertyName("WEDDING_DATE")]
        public string dtWedding { get; set; }
        [JsonPropertyName("NUMBER_OF_GUESTS")]
        public string nmGuests { get; set; }
        [JsonPropertyName("STYLE")]
        public string dsStyle { get; set; }
    }
}
