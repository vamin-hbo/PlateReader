using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateReader.Model
{
    public class WellsModel : IComparable<WellsModel>
    {
        public string WellName { get ; set ; }
        public int WellIndex { get ; set ; }
        public int DropletCount { get ; set ; }

        public int CompareTo(WellsModel obj)
        {
            return WellIndex.CompareTo(obj.WellIndex);
        }
    }
}
