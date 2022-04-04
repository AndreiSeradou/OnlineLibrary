using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineLibraryPresentationLayer.DTOs.Requests
{
    public class FilterByRequest
    {
        [Required]
        public string Text { get; set; }
    }
}
