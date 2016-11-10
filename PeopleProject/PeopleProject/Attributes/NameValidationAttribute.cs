﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]

    class NameValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string stringValue = (string)value;
            if(stringValue == null)
            {
                throw new ArgumentException("Property with attached attribute must be of type string and not null");

            }

            if(stringValue.Substring(0,1) != stringValue.Substring(0, 1).ToUpper())
            {
                return false;
            }

            return true;
        }
    }
}
