using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonUpdater_Application
{
    internal class InputKeysChecker
    {
        

        public bool IsKeyAllowed(string input)
        {
            string[] keys = { "-add", "-update ", "-get ", "-delete", "-getall" };
            bool result = keys.Contains<string>(input);
            return result;
        }
        public bool IsInputKey(string input)
        {
            return input[0] == '-';
        }
        
    }
}
