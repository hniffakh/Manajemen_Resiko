using System.ComponentModel.DataAnnotations;

namespace Manajemen_Resiko.Models
{
    public class MatriksModel
    {
        public int mat_nilai { get; set; }
        public string mat_jenis { get; set; }
        public string mat_tingkat { get; set; }
        public string mat_kategori { get; set; }
        public string mat_status { get; set; }
        public string createdby { get; set; }
        public DateTime createdon { get; set; }
        public string updatedby { get; set; }
        public DateTime updatedon { get; set; }
    }
}
