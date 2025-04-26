
namespace PrubaTecnica.Service
{
    public class FileCopyTaskService : IHostedService, IDisposable
    {
        private Timer _timer;
        private readonly string _sourceFilePath = @"D:\Proyectos\PruebaTecnica\Origen\Documento.txt"; 
        private readonly string _destinationDirectory = @"D:\Proyectos\PruebaTecnica\Destino";  

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(PerformFileCopyTask, null, TimeSpan.Zero, TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private void PerformFileCopyTask(object state)
        {
            CopyFile();
        }

        private void CopyFile()
        {
            try
            {
                if (File.Exists(_sourceFilePath))
                {
                    string destinationFilePath = Path.Combine(_destinationDirectory, "DocumentoCopiado.txt");
                    File.Copy(_sourceFilePath, destinationFilePath, true); 
                    Console.WriteLine($"Archivo copiado exitosamente a: {destinationFilePath}");
                }
                else
                {
                    Console.WriteLine($"El archivo de origen no existe en la ruta: {_sourceFilePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al copiar el archivo: {ex.Message}");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0); 
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
