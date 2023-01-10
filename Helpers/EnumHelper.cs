﻿using System;
using System.ComponentModel;
using System.Reflection;

namespace Marinel_ui.Helpers
{
	public static class EnumHelper
	{
        public static string GetEnumDescription(Enum? value)
        {
            if (value == null) return null;

            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            return attributes?.SingleOrDefault()?.Description;
        }
    }
}

