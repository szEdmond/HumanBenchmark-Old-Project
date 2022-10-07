using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormUI_Test
{
    class Scores
    {
        public string Nev { get; set; }
        public double Speed { get; set; }
        public int Flick { get; set; }
        public double Precision { get; set; }
        public double Reaction { get; set; }
        public int NumberMemory { get; set; }
        public int SequenceMemory { get; set; }
        public int Chimp { get; set; }

        public Scores()
        {
            Nev = Login.nick;
            Speed = 9999;
            Flick = 0;
            Precision = 0;
            Reaction = 9999;
            NumberMemory = 0;
            SequenceMemory = 0;
            Chimp = 0;
        }
    }

}
