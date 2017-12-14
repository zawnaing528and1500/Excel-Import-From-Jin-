using System;
using System.Collections.Generic;

namespace Toyo.Core
{
    public class RepairedVehicleBUS
    {
        Base b = new Base();
        RepairedVehicleDAO dao = new RepairedVehicleDAO();
        public int Create(RepairedVehicleVO vo)
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
        public int CreateInfo_Detail(RepairedVehicleVO vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
        {
            int id = 0;
            try
            {
                id = dao.CreateInfo_Detail(vo, detalVoList, queryList, deleteList);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return id;

        }
        public int UpdateInfo_Detail(int infoId, RepairedVehicleVO vo, List<object> detalVoList, List<String> queryList, List<String> deleteList)
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
