using API.EntityModel;
namespace API.DTOs
{
    public class KetQua
    {
        public string MASV { get; set; }
        public string MAMH { get; set; }
        public double DIEMSO { get; set; }
        public string XEPLOAI { get; set; }
        public virtual SinhVien SinhVien { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}
