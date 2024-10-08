using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json.Linq;
using System.Linq;
using TrainModule2_New.DTOs;
using TrainModule2_New.Models;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore.Query.Internal;
namespace TrainModule2_New.Services
{
    public interface IGiaoVienService
    {
        Task<bool> loggin(string ma,string pass);
        Task<bool> Register(GiaoVienDTO dto);
    }

    public class GiaoVienService:IGiaoVienService
    {
        public readonly IGiaoVienModel _model;
        public GiaoVienService(IGiaoVienModel model)
        {
            _model = model;
        }

        public async Task<bool> loggin(string ma,string pass)
        {
            //var Jobject=JObject.FromObject(doc);
            //string ma = string.Empty;
            //string pass = string.Empty;
            //if (Jobject["magv"] != null)
            //{
            //   ma = Jobject["magv"].ToString();
            //}

            //if (Jobject["pass"] != null)
            //{
            //   pass = Jobject["pass"].ToString();
            //}
            if (verifyPassword(pass,await _model.loggin(ma))) {
                return true;
            }
            return false; 
        }
       public async Task<bool> Register(GiaoVienDTO dto)
        {
            if (dto.Pass == null)
            {
                return false;
            }
            dto.Pass=hashPassWord(dto.Pass);
            bool kq= await _model.Register(dto);
       
            return kq;
          
        }
        public string hashPassWord(string password)
        {
            using (var rg = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[16];
                rg.GetBytes(salt);
                using (var rfc = new Rfc2898DeriveBytes(password, salt, 10000))
                {
                    byte[] hashByte = rfc.GetBytes(20);

                    byte[] hashPass = new byte[36];
                    Array.Copy(salt, 0, hashPass, 0, 16);
                    Array.Copy(hashByte, 0, hashPass, 16, 20);
                    return Convert.ToBase64String(hashPass);
                }

            }
        }
        public bool verifyPassword(string password, string hashedPassword)
        {
            List<bool> compare= new List<bool>(); 
            byte[] hashpass = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashpass, 0, salt, 0, 16);
            using (var rfc = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                byte[] bytes = rfc.GetBytes(20);
                for (int i = 0; i < 20; i++)
                {
                    string k = bytes[i].ToString();
                    string h= hashpass[i + 16].ToString();
                    if (bytes[i] != hashpass[i + 16])
                    {

                        return false;
                    }
                    compare.Add(bytes[i] != hashpass[i + 16]);
                }
                return true;
                //int a =compare.Where(x => x==true).Count();
                //int b = a;
                //return bytes.SequenceEqual(hashpass.Take(20).Skip(16));
            }
        }
    }
}
