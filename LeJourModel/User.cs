using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace LeJourModel
{
    public class User
    {
        [JsonPropertyName("ID")]
        public string idUser { get; set; }
        [JsonPropertyName("CREATED_AT")]
        public string dtCreated { get; set; }
    }
}
