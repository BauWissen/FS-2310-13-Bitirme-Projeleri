using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TeamTask.Shared.Types
{
    public enum UserNotePriorityType
    {
        [Description("00bb99")]
        Low = 0,

        [Description("0099cc")]
        Medium = 1,

        [Description("ff6666")]
        High = 2,




    }
    public static class EnumExtension 
    {
        public static string GetDescription(this UserNotePriorityType pType)
        {
            var description = pType.GetType().GetField(pType.ToString())?
                .GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            return description != null && description.Length > 0 ? description[0].Description : pType.ToString();
        }
    }

}
