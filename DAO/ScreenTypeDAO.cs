using QuanLyRapChieuPhim.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class ScreenTypeDAO
    {
        public static List<ScreenType> GetListScreenType()
        {
            List<ScreenType> screenTypeList = new List<ScreenType>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM MANHINH");
            foreach (DataRow item in data.Rows)
            {
                ScreenType screenType = new ScreenType(item);
                screenTypeList.Add(screenType);
            }
            return screenTypeList;
        }

        public static DataTable GetScreenType()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT MaMH AS [Mã màn hình], LoaiMH as [Loại màn hình] FROM MANHINH");
        }
        public static ScreenType GetScreenTypeByName(string screenName)
        {
            ScreenType screenType = null;
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM MANHINH WHERE LoaiMH = N'" + screenName + "'");
            foreach (DataRow item in data.Rows)
            {
                screenType = new ScreenType(item);
                return screenType;
            }
            return screenType;
        }
        public static List<ScreenType> GetScreenTypeById(string screenId)
        {
            List<ScreenType> screenType = new List<ScreenType>();
            DataTable data = DataProvider.Instance.ExcuteQuery("SELECT * FROM MANHINH WHERE MaMH = '" + screenId + "'");
            foreach (DataRow item in data.Rows)
            {
                ScreenType screen = new ScreenType(item);
                screenType.Add(screen);
            }
            return screenType;
        }

    }
}
