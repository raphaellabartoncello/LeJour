using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace LeJour.DataModel
{
    public partial class TbUser
    {
        [JsonPropertyName("ID")]
        public string idUser { get; set; }
        [JsonPropertyName("CREATED_AT")]
        public string dtCreated { get; set; }

    }
}
