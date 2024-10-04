namespace API.DTOs
{
    public class SinhVien
    {
        public string MASV { get; set; }
        public string TENSV { get; set; }

        public int namSinh { get; set; }
        public virtual Lop Lop {get;set;}
        public ICollection<KetQua> KetQua { get; set; }
    }
}
