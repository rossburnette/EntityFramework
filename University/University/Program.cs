﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University
{
    class Program
    {
        static void Main(string[] args)
        {
            TpcUniversityContext context = new TpcUniversityContext();
            context.Database.Initialize(true);
        }
    }
}