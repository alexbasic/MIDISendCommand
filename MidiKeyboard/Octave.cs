using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidiKeyboard
{
    public class Octave
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<Octave> GetOctaves()
        {
            return new List<Octave> 
            {
                new Octave {Id=-2, Name="Субконтроктава"},
                new Octave {Id=-1, Name="Контроктава"},
                new Octave {Id=0, Name="Большая октава"},
                new Octave {Id=1, Name="Малая октава"},
                new Octave {Id=2, Name="1 октава"},
                new Octave {Id=3, Name="2 октава"},
                new Octave {Id=4, Name="3 октава"},
                new Octave {Id=5, Name="4 октава"},
                new Octave {Id=6, Name="5 октава"},
                new Octave {Id=7, Name="6 октава"},
                new Octave {Id=8, Name="7 октава"}
            };
        }
    }
}
