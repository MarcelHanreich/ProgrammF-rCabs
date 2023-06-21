using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammFürCabs
{
    internal class ZITATE
    {
        public string _zitat;
        public string _ergebnis;
        public string _answer1;
        public string _answer2;

        public string GetZitat()
        {
            return _zitat;
        }
        public string GetErgebnis()
        {
            return _ergebnis;
        }
        public void SetZitat(string zitat)
        {
            _zitat = zitat;
        }
        public void SetErgebnis(string ergbenis)
        {
            _ergebnis = ergbenis;
        }
        public string GetAnswer1()
        {
            return _answer1;
        }
        public string GetAnswer2()
        {
            return _answer2;
        }
        public void SetAnswer1(string answer1)
        {
            _answer1 = answer1;
        }
        public void SetAnswer2(string answer2)
        {
            _answer2 = answer2;
        }
    }
}
