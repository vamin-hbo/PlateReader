using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateReader.Model
{
    public class DropletInfoModel
    {
        public int Version { get ; set ; }
        public List<WellsModel> Wells { get ; set ; }

    }
}
