#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System.Collections.Generic;

#endregion

namespace Achilles.Acme.Models
{
    public enum DateFormat
    {
        ISO8601,
        DayFirst,
        MonthFirst,
    }

    public class DateFormats
    {
        public static readonly IDictionary<DateFormat, string> DateTimeFormat = new Dictionary<DateFormat, string>
        {
                { DateFormat.DayFirst, "dd/MM/yyyy" },
                { DateFormat.MonthFirst, "MM/dd/yyyy" },
                { DateFormat.ISO8601, "yyyy-MM-dd" }
        };

        public static readonly IDictionary<DateFormat, string> DatePickerFormat = new Dictionary<DateFormat, string>
        {
                { DateFormat.DayFirst, "dd/mm/yy" },
                { DateFormat.MonthFirst, "mm/dd/yy" },
                { DateFormat.ISO8601, "yy/mm/dd" }
        };
    }
}