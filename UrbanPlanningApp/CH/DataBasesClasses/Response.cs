﻿using System;

namespace UrbanPlanningApp.DataBasesClasses
{
    public partial  class Response
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get { return DateTime.Now; } set { } }
    }
}
