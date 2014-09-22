using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame
{
    public interface IOutputDevice
    {
        void Render(string s);
    }

    public class ConsoleDevice
    {
        public void Render(string s)
        {
            Console.WriteLine(s);
        }
    }
}
