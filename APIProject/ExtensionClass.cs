using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject
{
    public static class ExtensionClass
    {
        public static JsonResult ToJson<T>(this T obj)
        {
            var json = new JsonResult(obj, new JsonSerializerSettings());
            return json;
        }
    }
}
