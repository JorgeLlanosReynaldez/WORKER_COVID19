using MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATASET
{
    public interface IReadDataset
    {
        List<Report> ReadList_UsingFileHelpers();
    }
}
