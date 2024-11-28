using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class UnknownAPI
    {
        public static string getCategory()
        {
            return "SQL_STRING_TRYING_TO_INJECT_CUSTOM_QUERY_INTO_A_LEGITIMATE_ONE";
        }
    }
}
