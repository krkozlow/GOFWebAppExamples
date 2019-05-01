using System;
using System.Collections.Generic;
using System.Text;

namespace QueryBuilder
{
    public class QueryConfiguration
    {
        public bool IsDescending { get; set; }
        public bool IsAscending { get; set; }
        public bool IsDistinct { get; set; }
        public int Top { get; set; }
        public string[] Columns { get; set; }
        public string Table { get; set; }
        public string OrderBy { get; set; }
    }
}