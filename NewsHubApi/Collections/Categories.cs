﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsHubApi.Collections
{
    public class Categories
    {
        public ObjectId Id { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}