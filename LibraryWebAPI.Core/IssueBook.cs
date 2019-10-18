﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryWebAPI.Core
{
    public class IssueBook
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string BookBarCode { get; set; }
        public DateTime IssueDate { get; set; }
    }
}
