using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Text.Json;
namespace DataAccess
{
    public class IMemberRepository
    {
        private static IMemberRepository? instance = null;
        private static readonly object instanceLock = new object();
        private IMemberRepository() { }
        public static IMemberRepository Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new IMemberRepository();
                    }
                    return instance;
                }
            }
        }
        public IEnumerable<Member> GetMemberList()
        {
            List<Member> members;
            try
            {
                var myStockDB = new MemberDAO();
                members = myStockDB.Member.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return members;
        }

        public Member GetMemberByID(int memberId)
        {
            Member? member = null;
            try
            {
                var myStockDB = new MemberDAO();
                member = myStockDB.Member.SingleOrDefault(x => x.MemberId == memberId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public Member Login(string email, string password)
        {
            Member? member = null;
            try
            {
                var myStockDB = new MemberDAO();
                member = myStockDB.Member.SingleOrDefault(x => x.Email == email &&  x.Password == password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return member;
        }
        public void AddNew(Member member)
        {
            try
            {
                Member _member = GetMemberByID(member.MemberId);
                if (_member == null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.Member.Add(member);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member is already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Member member)
        {
            try
            {
                Member c = GetMemberByID(member.MemberId);
                if (c != null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.Entry<Member>(member).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Member member)
        {
            try
            {
                Member _Member = GetMemberByID(member.MemberId);
                if (_Member != null)
                {
                    var myStockDB = new MemberDAO();
                    myStockDB.Member.Remove(member);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("The member does not already exist.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        string fileName = "login.json";
        List<Member> members = new List<Member>();
        public void StoreToFile()
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(members,
                     new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void InsertToJson(string email, string password)
        {
            try
            {
                Member member = Login(email, password);
                members.Add(member);
                StoreToFile();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GetDataFromFile()
        {
            try
            {
                if(File.Exists(fileName)){
                    string jsonData = File.ReadAllText(fileName);
                    members = JsonSerializer.Deserialize<List<Member>>(jsonData);
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Member> GetAllMember()
        {
            GetDataFromFile();
            return members;
        }

    }
}
