namespace API.DTOs
{
    public class Lop
    {
        public string MALOP { get; set; }
        public string TENLOP { get; set; }
        public int SISO { get; set; }
        public ICollection<SinhVien> sinhViens { get; set; }
    }
}
