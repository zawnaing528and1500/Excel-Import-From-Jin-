using System;
using System.Collections.Generic;

using System.Text;

namespace Toyo.Core
{
    public class LeaveRequestBUS
    {
        Base b = new Base();
        LeaveRequestDAO dao = new LeaveRequestDAO();
        public int Create(LeaveRequestVO vo)
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
        public int CreateInfo_Detail(LeaveRequestVO vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int id = 0;
            try
            {
               id = dao.InsertInfo_Detail(vo, detalVoList, queryList, deleteList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;

        }
        public int UpdateInfo_Detail(int infoId,LeaveRequestVO vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int id = 0;
            try
            {
                id = dao.UpdateInfo_Detail(infoId, vo, detalVoList, queryList, deleteList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;

        }
    }
}
