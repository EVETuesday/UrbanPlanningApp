using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using UrbanPlanningApp.DataBasesClasses;
using static UrbanPlanningApp.CH.Context;

namespace UrbanPlanningApp.CH
{
    public class ClassHelper
    {
        public static Employee ActiveEmployee { get; set; }
    }
}
