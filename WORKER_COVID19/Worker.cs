using DATASET;
using MAIL;
using Microsoft.Extensions.Configuration;
using MODEL.MODEL;
using PDF;

namespace WORKER_COVID19
{
    public class Worker : BackgroundService
    {
        private readonly TimerWorker _timer;
        private readonly string _sectionTimer = "TimerWorker";
        private readonly IReadDataset _readDataset;
        private readonly IGeneratePDF _generatePDF;
        private readonly ISendMail _sendMail;
        public Worker(IConfiguration configuration,IReadDataset _readDataset, IGeneratePDF generatePDF, ISendMail sendMail)
        {
            _timer = new TimerWorker();
            configuration.GetSection(_sectionTimer).Bind(_timer);
            this._readDataset = _readDataset;
            this._generatePDF = generatePDF;
            this._sendMail = sendMail;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    DateTime date = DateTime.Now;
                    int hourInit = Convert.ToInt32(_timer.HoraInicio);
                    int HourEnd = Convert.ToInt32(_timer.HoraFin);
                    int intervalo = Convert.ToInt32(_timer.IntervaloMinutos);
                    int intervaloOffLine = Convert.ToInt32(_timer.IntervaloMinutosOffLine);

                    if (date.Hour >= hourInit && date.Hour < HourEnd)
                    {
                        List<Report> listReport = _readDataset.ReadList_UsingFileHelpers();
                        string FilePath = Path.Combine(Environment.CurrentDirectory, "Pdfs", $"Report_{date.Hour}_{date.Minute}.pdf");
                        _generatePDF.ExportListToPdf(listReport, FilePath);
                        _sendMail.SendEmail(FilePath);

                        #region TIMER
                        await Task.Delay(TimeSpan.FromMinutes(intervalo), stoppingToken);
                        #endregion
                    }
                    else
                    {
                        await Task.Delay(TimeSpan.FromMinutes(intervaloOffLine), stoppingToken);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
