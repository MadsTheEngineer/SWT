using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame
{
    public interface IOutputDevice
    {
        void Render(params string[] s);
    }

    public class ConsoleDevice
    {
        public void Render(string s)
        {
            foreach (char t in s)
            {
                Console.WriteLine(t);
            }
        }
    }
}
