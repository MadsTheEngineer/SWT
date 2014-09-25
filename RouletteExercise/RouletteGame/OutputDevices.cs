using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteGame
{
    public interface IOutputDevice
    {
<<<<<<< HEAD
        void Render(params Object[] s);
=======
        void Render(string s);
>>>>>>> 334d8f43b2b84c5896635a437148137f5e5ee76c
    }

    public class ConsoleDevice : IOutputDevice
    {
<<<<<<< HEAD
        public void Render(params Object[] s)
=======
        public void Render(string s)
>>>>>>> 334d8f43b2b84c5896635a437148137f5e5ee76c
        {
            Console.WriteLine(s);
            
        }
    }
}
