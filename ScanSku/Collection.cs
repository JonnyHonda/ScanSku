﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using DespatchBayExpress;
//
//    var collectionObject = CollectionObject.FromJson(jsonString);

namespace DespatchBayExpress
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Collection
    {
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("gps")]
        public Gps Gps { get; set; }

        [JsonProperty("scans")]
        public List<Scan> Scans { get; set; }
    }

    public partial class Gps
    {
        [JsonProperty("latitude")]
        public double? Latitude { get; set; }

        [JsonProperty("longitude")]
        public double? Longitude { get; set; }
    }

    public partial class Scan
    {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("gps")]
        public Gps Gps { get; set; }
    }

    public partial class Collection
    {
        public static Collection FromJson(string json) => JsonConvert.DeserializeObject<Collection>(json, DespatchBayExpress.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Collection self) => JsonConvert.SerializeObject(self, DespatchBayExpress.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}