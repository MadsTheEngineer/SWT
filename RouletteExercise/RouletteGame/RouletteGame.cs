using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RouletteGame
{
    public class RouletteGame
    {
        private IOutputDevice _outputDevice;
        private IRoulette _roulette;
        private bool _roundIsOpen;
        private List<IBet> _bets;

        public RouletteGame(IRoulette roulette, IOutputDevice outputDevice)
        {
            _bets = new List<IBet>();
            _roulette = roulette;
            _outputDevice = outputDevice;
        }

        public void OpenBets()
        {
            _outputDevice.Render("Round is open for bets");
            _roundIsOpen = true;
        }

        public void CloseBets()
        {
            _outputDevice.Render("Round is closed for bets");
            _roundIsOpen = false;
        }

        public void PlaceBet(IBet bet)
        {
            if (_roundIsOpen) _bets.Add(bet);
            else throw new RouletteGameException("Bet placed while round closed");
        }

        public void SpinRoulette()
        {
            _outputDevice.Render("Spinning...");
            _roulette.Spin();
            _outputDevice.Render("Result: {0}", _roulette.GetResult());
        }

        public void PayUp()
        {
            var result = _roulette.GetResult();

            foreach (var bet in _bets)
            {
                var won = bet.WonAmount(result);
                if(won > 0)
                    _outputDevice.Render("{0} just won {1}$ on a {2}", bet.PlayerName, won, bet);
            }
        }

    }

    public class RouletteGameException : Exception
    {
        public RouletteGameException(string s) : base(s)
        {
        }
    }
}
