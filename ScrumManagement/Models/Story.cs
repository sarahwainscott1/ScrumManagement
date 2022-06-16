﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ScrumManagement.Models {
    public class Story {
        public int Id { get; set; }
        [StringLength(30)]
        public string User { get; set; } = string.Empty;
        [StringLength(100)]
        public string Feature { get; set; } = string.Empty;
        [StringLength(100)]
        public string Value { get; set; } = string.Empty;
        public int Importance { get; set; }
        public int EstimatedPoints { get; set; }
        public int ActualTime { get; set; }
        [JsonIgnore]
        public virtual Sprint? Sprint { get; set; }
        public int SprintId { get; set; }
        [JsonIgnore]
        public virtual TeamMember? TeamMember { get; set; }
        public int TeamMemberId { get; set; }
    }
}