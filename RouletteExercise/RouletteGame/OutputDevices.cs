using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame
{
    public interface IOutputDevice
    {
        void Render(params Object[] s);
    }

    public class ConsoleDevice : IOutputDevice
    {
        public void Render(params Object[] s)
        {
            Console.WriteLine(s);
            
        }
    }
}
