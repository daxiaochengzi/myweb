using service.Dto;
using service.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace service
{
    public class UserInfoDataBase
    {
        public string pageListstr(UserInfoPagedDto parm)
        {
            string sqls = string.Format(@"select a.Id,a.Address,a.UserName, a.Phone, a.Address,a.CreateTime ,a.MakeRoomTime ,a.SellingPoint,a.RoomNumber,a.Price,a.AllPrice,a.Areas,a.Apartment,a.Remark
                  ,(select  Url from img where UserInfoId = a.id order by CreateTime desc limit 1 offset 0) as url from UserInfo as a where a.Id is not null");
            string sqlCount = "select count(*) from UserInfo where Id  is not null";
            string sqlwhere = null;
            //if (strRegionIds != null)
            //{
            //    strsql = strRegionIds + strsql;
            //    sqlCount = strRegionIds + sqlCount;
            //    sqlwhere += " and exists(select RegionId from RegionIds where RegionId =c.RegionId)";
            //}
            if (!string.IsNullOrWhiteSpace(parm.Address))
            {
                sqlwhere += $" and Address like N'" + parm.Address + "%'";
            }
            if (!string.IsNullOrWhiteSpace(parm.UserName))
            {
                sqlwhere += $" and UserName like  N'" + parm.UserName + "%'";
            }
            if (!string.IsNullOrWhiteSpace(parm.Apartment))
            {
                sqlwhere += " and Apartment like  N'" + parm.Apartment + "%'";
            }
            if (!string.IsNullOrWhiteSpace(parm.Keywords))
            {
                sqlwhere += $" and (SellingPoint like N'" + parm.Keywords + "%' or Apartment like   N'" + parm.Keywords + "%' )";
            }
            string sqlsize = "";
            sqlCount += sqlwhere;
            sqls += sqlwhere;
            if (parm.limit != 0 && parm.offset > 0)
            {
                var skipCount = parm.limit * (parm.offset - 1);
                sqlsize = string.Format(" order by CreateTime asc limit {0} offset {1}", parm.limit, skipCount);
                sqls += sqlsize;
            }

            return sqls;
        }

        public Dictionary<int, List<UserInfoDto>> pageList(UserInfoPagedDto parm)
        {


            string sqls = string.Format(@"select a.Id,a.Address,a.UserName, a.Phone, a.Address,a.MakeRoomTime ,a.SellingPoint,a.RoomNumber,a.Price,a.AllPrice,a.Areas,a.Apartment,a.Remark
                  ,(select  Url from img where UserInfoId = a.id order by CreateTime desc limit 1 offset 0) as url from UserInfo as a where a.Id is not null");
            string sqlCount = "select count(*) from UserInfo where Id  is not null";
            string sqlwhere = null;
            //if (strRegionIds != null)
            //{
            //    strsql = strRegionIds + strsql;
            //    sqlCount = strRegionIds + sqlCount;
            //    sqlwhere += " and exists(select RegionId from RegionIds where RegionId =c.RegionId)";
            //}
            if (!string.IsNullOrWhiteSpace(parm.Address))
            {
                sqlwhere += $" and Address like N'" + parm.Address + "%'";
            }
            if (!string.IsNullOrWhiteSpace(parm.UserName))
            {
                sqlwhere += $" and UserName like  N'" + parm.UserName + "%'";
            }
            if (!string.IsNullOrWhiteSpace(parm.Apartment))
            {
                sqlwhere += " and Apartment like  N'" + parm.Apartment + "%'";
            }
            if (!string.IsNullOrWhiteSpace(parm.Keywords))
            {
                sqlwhere += $" and (SellingPoint like N'" + parm.Keywords + "%' or Apartment like   N'" + parm.Keywords + "%' )";
            }
            string sqlsize = "";
            sqlCount += sqlwhere;
            sqls += sqlwhere;
            if (parm.limit != 0 && parm.offset > 0)
            {
                var skipCount = parm.limit * (parm.offset - 1);
                sqlsize = string.Format(" order by CreateTime asc limit {0} offset {1}", parm.limit, skipCount);
                sqls += sqlsize;
            }
            var dt = SQLiteHelper.ExecuteDataTable(sqls);
            var userData = new List<UserInfoDto>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = new UserInfoDto
                    {
                        Id = Guid.Parse(dr["Id"].ToString()),
                        UserName = dr["UserName"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Address = dr["Address"].ToString(),
                        AllPrice = dr["AllPrice"].ToString(),
                        Price = dr["Price"].ToString(),
                        Areas = dr["Areas"].ToString(),
                        Apartment = dr["Apartment"].ToString(),
                        RoomNumber = dr["RoomNumber"].ToString(),
                        SellingPoint = dr["SellingPoint"].ToString(),
                        MakeRoomTime = dr["MakeRoomTime"].ToString(),
                        Url = dr["url"].ToString()
                    };
                    userData.Add(item);
                }
            }
            var count = SQLiteHelper.ExecuteScalar(sqlCount);
            Dictionary<int, List<UserInfoDto>> result = new Dictionary<int, List<UserInfoDto>>();
            result.Add(Convert.ToInt16(count), userData);
            return result;

        }

        public void AddImg(Img Param)
        {
            string sqlStr = $" insert into img values(N'{Param.Id}',N'{Param.UserInfoId}',N'{Param.Type}',N'{Param.Url}',N'{Param.CreateTime}','')";
            var dt = SQLiteHelper.ExecuteDataTable(sqlStr);
        }
        public List<string> GetImg(string UserInfoId)
        {
            var result = new List<string>();
            string strsql = $"select  url from  img where UserInfoId='{UserInfoId}' order by CreateTime desc limit 4 offset 0";
            var dt = SQLiteHelper.ExecuteDataTable(strsql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var Strurl = "/Files/Pictures/" + dr["url"].ToString();
                    result.Add(Strurl);
                }
            }
            if (dt.Rows.Count < 4)
            {
                for (int i = 0; i < 4- dt.Rows.Count; i++)
                {
                    if (dt.Rows.Count > 0)
                    {
                        result.Add("/Files/Pictures/"+dt.Rows[0]["url"].ToString());
                    }
                    else
                    {
                        result.Add("/lib/aifang/2017918517917504711.jpg");
                    }
                  
                }
            }
            return result;
        }

        public UserInfoDto GetUserInfo(string UserInfoId)
        {
            string strsql = string.Format(@"select a.Id,a.Address,a.UserName, a.Phone, a.Address ,a.MakeRoomTime ,a.SellingPoint,a.RoomNumber,a.Price,a.AllPrice,a.Areas,a.Apartment,a.Remark
          from UserInfo as a where  a.id='{0}'", UserInfoId);
            var dt = SQLiteHelper.ExecuteDataTable(strsql);
            var userData =new  UserInfoDto();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var item = new UserInfoDto
                    {
                        Id = Guid.Parse(dr["Id"].ToString()),
                        UserName = dr["UserName"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        Address = dr["Address"].ToString(),
                        AllPrice = dr["AllPrice"].ToString(),
                        Price = dr["Price"].ToString(),
                        Areas = dr["Areas"].ToString(),
                        Apartment = dr["Apartment"].ToString(),
                        RoomNumber = dr["RoomNumber"].ToString(),
                        SellingPoint = dr["SellingPoint"].ToString(),
                        MakeRoomTime = dr["MakeRoomTime"].ToString(),
                        Remark= dr["Remark"].ToString(),

                    };
                    userData = item;
                }
            }
            return userData;
        }
    }
}
