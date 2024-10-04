namespace API.DTOs
{
    public class MonHoc
    {
        public string MAMH { get; set; }
        public string TENMH { get; set; }
        public int SOTC { get; set; }
        public ICollection<KetQua> KetQuas { get; set; }
    }
}
