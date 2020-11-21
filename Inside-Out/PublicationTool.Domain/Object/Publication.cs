﻿using System;

namespace PublicationTool.Domain.Object
{
    public class Publication
    {
        public string Title { get; set; }
        public DateTime? Date { get; set; }

        public Publication()
        {
        }

        public Publication(string title, DateTime? date)
        {
            Title = title;
            Date = date;
        }
    }
}