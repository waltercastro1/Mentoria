﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Mentoria.Library.ModelAttributeValidator
{
    public class TimeSpanAttribute : ValidationAttribute
    {
        private string _NameToShow;
        private string _Name;
        private TimeSpan _MinimumTimeSpan;
        private TimeSpan _MaximumTimeSpan;
        private bool _Required;

        public TimeSpanAttribute(string NameToShow, string Name, bool Required, string TimeSpanMin, string TimeSpanMax)
        {
            try
            {
                _NameToShow = NameToShow;
                _Name = Name;
                _MinimumTimeSpan = TimeSpan.Parse(TimeSpanMin);
                _MaximumTimeSpan = TimeSpan.Parse(TimeSpanMax);

                _Required = Required;
            }
            catch (Exception) { throw; }
        }

        protected override ValidationResult IsValid(object objTimeSpan, ValidationContext validationContext)
        {
            try
            {
                if (_Required)
                {
                    if (objTimeSpan == null) 
                    {
                        return new ValidationResult($"[{_Name}] La variable {_NameToShow} es requerida");
                    }
                    else
                    {
                        if ((TimeSpan)objTimeSpan < _MinimumTimeSpan || (TimeSpan)objTimeSpan > _MaximumTimeSpan)
                        {
                            return new ValidationResult($"[{_Name}] La variable {_NameToShow} debe estar entre {_MinimumTimeSpan} y {_MaximumTimeSpan}");
                        }
                        else
                        {
                            return ValidationResult.Success;
                        }
                    }
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            catch (Exception) { throw; }
        }
    }
}
