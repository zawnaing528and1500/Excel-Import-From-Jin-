
namespace Toyo.Core
{
    public class EmployeeBankInfoBUS
    {
        Base b = new Base();
        EmployeeBankInfoDAO dao = new EmployeeBankInfoDAO();
        public int Create(EmployeeBankInfoVO vo)
        {
            int id;
            if (!dao.isExist(vo.Id.ToString()))
            {
                id = dao.Insert(vo);
            }
            else
            {
                id = dao.Update(vo);
            }
            return id;
        }
    }
}
