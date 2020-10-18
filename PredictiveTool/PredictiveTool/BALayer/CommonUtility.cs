using PredictiveTool.DALayer;
using PredictiveTool.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PredictiveTool.BALayer
{
    
    public class CommonUtility
    {
        PredAnalysisModel predAnalysisModel;
        public static List<ddnmodel> GetDDList(PredAnalysisModel predAnalysisModel)
        {
            predAnalysisModel.ID = "1";
            predAnalysisModel.Type = "SectorDDN";
            DataManager dataManager = new DataManager();
            List<ddnmodel> lstdropDownModels = new List<ddnmodel>();
            DataSet ds = dataManager.GetData(predAnalysisModel);
            if (ds.Tables.Count > 0)
            {
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                {
                    ddnmodel obj = new ddnmodel();
                    obj.ID = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"]);
                    obj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    lstdropDownModels.Add(obj);
                }

            }
            return lstdropDownModels;
        }
        public static IEnumerable<SelectListItem> GetSelectListItemsstr(IEnumerable<ddnmodel> elements)
        {
            var selectList = new List<SelectListItem>();
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {

                    Value = element.ID.ToString(),
                    Text = element.Name
                });
            }
            return selectList;
        }
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }
    }

}
