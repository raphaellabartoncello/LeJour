﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace LeJourModel
{
   public class Invoice
    {
        [JsonPropertyName("ID")]
        public string idInvoice { get; set; }
        [JsonPropertyName("WEDDING_ID")]
        public string idWedding { get; set; }
        [JsonPropertyName("VENDOR_ID")]
        public string idVendor { get; set; }
        [JsonPropertyName("AMOUNT")]
        public string vlAmount { get; set; }
        [JsonPropertyName("VENDOR_AMOUNT")]
        public string vlAmountVendor { get; set; }
        [JsonPropertyName("CREATED_AT")]
        public string dtCreated { get; set; }
        [JsonPropertyName("ACCEPTED")]
        public string dsAccepted { get; set; }
        [JsonPropertyName("VENDOR_CATEGORY")]
        public string dsCategoryVendor { get; set; }
    }
}
