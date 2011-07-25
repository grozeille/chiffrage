using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace Chiffrage.App
{
    public static class MapperUtils
    {
        public static void CreateDefaultMap()
        {
            Mapper.CreateMap<string, double>().ConvertUsing(s => Convert.ToDouble(s));
            Mapper.CreateMap<string, double?>().ConvertUsing(s => s == null ? null : new Nullable<double>(Convert.ToDouble(s)));
            Mapper.CreateMap<string, int>().ConvertUsing(s => Convert.ToInt32(s));
            Mapper.CreateMap<string, int?>().ConvertUsing(s =>  s == null ? null : new Nullable<int>(Convert.ToInt32(s)));
            Mapper.CreateMap<string, decimal?>().ConvertUsing(s => s == null ? null : new Nullable<Decimal>(Convert.ToDecimal(s)));
            Mapper.CreateMap<string, decimal>().ConvertUsing(s => Convert.ToDecimal(s));
            Mapper.CreateMap<string, bool?>().ConvertUsing(s => s == null ? null : new Nullable<bool>(Convert.ToBoolean(s)));
            Mapper.CreateMap<string, bool>().ConvertUsing(s => Convert.ToBoolean(s));
            Mapper.CreateMap<string, Int64?>().ConvertUsing(s => s == null ? null : new Nullable<Int64>(Convert.ToInt64(s)));
            Mapper.CreateMap<string, Int64>().ConvertUsing(s => Convert.ToInt64(s));
            Mapper.CreateMap<string, DateTime?>().ConvertUsing(s => s == null ? null : new Nullable<DateTime>(Convert.ToDateTime(s)));
            Mapper.CreateMap<string, DateTime>().ConvertUsing(s => Convert.ToDateTime(s));
        }
    }
}
