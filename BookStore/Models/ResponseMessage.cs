﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ResponseMessage
    {
        public object Data { get; set; }
        public string Message { get; set; } = "Success";
    }
}
