using FileHelpers;
using MODEL.MODEL;

namespace DATASET
{
    public class ReadDataset : IReadDataset
    {
        public List<Report> ReadList_UsingFileHelpers()
        {
            List<Report> listReport = new List<Report>();
            string filePath = Path.Combine(Environment.CurrentDirectory, "Dataset", "geografico_covid19_lapaz.csv");
            try
            {
                var engine = new FileHelperEngine<Report>();
                listReport = new List<Report>(engine.ReadFile(filePath));
                listReport.RemoveAt(0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading CSV file: {ex.Message}");
            }
            return listReport;
        }
    }
}
