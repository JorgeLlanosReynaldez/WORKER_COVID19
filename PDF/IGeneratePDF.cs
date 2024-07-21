using MODEL.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDF
{
    public interface IGeneratePDF
    {
        void ExportListToPdf(List<Report> listReport, string outputFilePath);
    }
}
