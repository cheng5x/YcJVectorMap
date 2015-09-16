using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace YcJVectorMap.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //json转换
            JavaScriptSerializer _ser = new JavaScriptSerializer();

            Dictionary<string, string> _mapDataDic = new Dictionary<string, string>();
            List<YcJVectorMap.Model.Map.data> _mapDataList = this.GetMapDefault(out _mapDataDic);
            decimal maxAreaCount = 0;

            //TODO:更改数值方法1
            _mapDataList.Find(_ => _.id == "HKG").value = "26";
            _mapDataList.Find(_ => _.id == "MAC").value = "6";
            _mapDataList.Find(_ => _.id == "GUD").value = "68";

            //TODO:更改数值方法2
            _mapDataList.Find(_ => _.name.Contains("北京")).value = "183";
            _mapDataList.Find(_ => _.name.Contains("海南")).value = "5";

            //TODO:获取标识最大值
            ViewData["maxAreaCount"] = maxAreaCount = _mapDataList.Max(_ => Convert.ToDecimal(_.value));

            //TODO:赋值透明度
            foreach (var item in _mapDataList)
            {
                item.opacity = (Convert.ToDecimal(item.value) / maxAreaCount).ToString();
            }

            //TODO:赋值Json
            ViewData["mapDataJson"] = _ser.Serialize(_mapDataList);

            return View();
        }

        /// <summary>
        /// 获取初始化地图分布
        /// </summary>
        /// <returns></returns>
        public List<YcJVectorMap.Model.Map.data> GetMapDefault(out Dictionary<string, string> mapDataDic)
        {
            List<YcJVectorMap.Model.Map.data> _mapDataList = new List<Model.Map.data>();

            mapDataDic = new Dictionary<string, string>();
            mapDataDic.Add("MAC", "澳门：");
            mapDataDic.Add("HKG", "香港：");
            mapDataDic.Add("HAI", "海南：");
            mapDataDic.Add("YUN", "云南：");
            mapDataDic.Add("BEJ", "北京：");
            mapDataDic.Add("TAJ", "天津：");
            mapDataDic.Add("XIN", "新疆：");
            mapDataDic.Add("TIB", "西藏：");
            mapDataDic.Add("QIH", "青海：");
            mapDataDic.Add("GAN", "甘肃：");
            mapDataDic.Add("NMG", "内蒙古：");
            mapDataDic.Add("NXA", "宁夏：");
            mapDataDic.Add("SHX", "山西：");
            mapDataDic.Add("LIA", "辽宁：");
            mapDataDic.Add("JIL", "吉林：");
            mapDataDic.Add("HLJ", "黑龙江：");
            mapDataDic.Add("HEB", "河北：");
            mapDataDic.Add("SHD", "山东：");
            mapDataDic.Add("HEN", "河南：");
            mapDataDic.Add("SHA", "陕西：");
            mapDataDic.Add("SCH", "四川：");
            mapDataDic.Add("CHQ", "重庆：");
            mapDataDic.Add("HUB", "湖北：");
            mapDataDic.Add("ANH", "安徽：");
            mapDataDic.Add("JSU", "江苏：");
            mapDataDic.Add("SHH", "上海：");
            mapDataDic.Add("ZHJ", "浙江：");
            mapDataDic.Add("FUJ", "福建：");
            mapDataDic.Add("TAI", "台湾：");
            mapDataDic.Add("JXI", "江西：");
            mapDataDic.Add("HUN", "湖南：");
            mapDataDic.Add("GUI", "贵州：");
            mapDataDic.Add("GXI", "广西：");
            mapDataDic.Add("GUD", "广东：");

            foreach (var item in mapDataDic)
            {
                _mapDataList.Add(new YcJVectorMap.Model.Map.data()
                {
                    id = item.Key,
                    name = item.Value,
                    value = "0",
                    url = "#"
                });
            }

            return _mapDataList;
        }
    }
}
