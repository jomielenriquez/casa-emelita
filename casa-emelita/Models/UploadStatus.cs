using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casa_emelita.Models
{
    public class UploadStatus
    {
        public string fileName { get; set; }
        public bool IsSuccess { get; set; }
        public string message { get; set; }
    }
}