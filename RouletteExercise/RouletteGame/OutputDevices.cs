using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame
{
    public interface IOutputDevice
    {
        void Render(Object s);
    }

    public class ConsoleDevice : IOutputDevice
    {
        public void Render(Object s)
        {
            Console.WriteLine(s);
        }
    }
}
