using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
namespace DataAccess
{
    public class MemberRepository : IntefaceMemberRepository
    {
        public Member GetMemberById(int memberId) => IMemberRepository.Instance.GetMemberByID(memberId);
        public Member Login(string email,string password) => IMemberRepository.Instance.Login(email,password);
        public IEnumerable<Member> GetMembers() => IMemberRepository.Instance.GetMemberList();
        public void InsertMember(Member member) => IMemberRepository.Instance.AddNew(member);
        public void DeleteMember(Member member) => IMemberRepository.Instance.Remove(member);
        public void UpdateMember(Member member) => IMemberRepository.Instance.Update(member);

        public void InsertToJson(string email, string password) => IMemberRepository.Instance.InsertToJson(email, password);
        public IEnumerable<Member> GetAllMember() => IMemberRepository.Instance.GetAllMember();

    }

    public interface IntefaceMemberRepository
    {
        IEnumerable<Member> GetMembers();
        Member GetMemberById(int memberId);
        Member Login (string email,string password);
        void InsertMember(Member member);
        void DeleteMember(Member member);
        void UpdateMember(Member member);
        void InsertToJson(string email, string password);
        IEnumerable<Member> GetAllMember();
    }
}
