using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame
{
    public interface IOutputDevice
    {
        void Render(string format, params Object[] arguments);
    }

    public class ConsoleDevice : IOutputDevice
    {
        public void Render(string format, params object[] arguments)
        {
            Console.WriteLine(format,arguments);
        }
    }
}
