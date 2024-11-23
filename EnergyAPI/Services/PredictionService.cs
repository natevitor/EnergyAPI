using Microsoft.ML;
using Microsoft.ML.Data;
using EnergyAPI.Models; // Seu modelo de entrada, ModelInput
using EnergyAPI.Services.Interfaces; // Corrigido para o namespace correto

namespace EnergyAPI.Services.IA {
    public class PredictionService : IPredictionService {
        private readonly MLContext _mlContext;
        private ITransformer _trainedModel;
        private readonly string _modelPath = "model.zip"; // Caminho do modelo treinado

        public PredictionService() {
            _mlContext = new MLContext();
            _trainedModel = LoadModel(); // Carregar o modelo ao iniciar
        }

        // Método para carregar o modelo treinado
        private ITransformer LoadModel() {
            return _mlContext.Model.Load(_modelPath, out var modelInputSchema);
        }

        // Método para fazer previsões
        public float PredictEnergyUsage(double previousUsage) {
            // Cria o modelo de entrada (ModelInput)
            var input = new ModelInput {
                PreviousUsage = (float)previousUsage // Converte o valor de entrada para o formato esperado
            };

            // Cria o IDataView a partir dos dados de entrada
            var inputDataView = _mlContext.Data.LoadFromEnumerable(new[] { input });

            // Faz a previsão
            var prediction = _trainedModel.Transform(inputDataView);

            // Extrai o valor da previsão (Assumindo que a previsão está na coluna "PredictedEnergyUsage")
            var predictionResult = _mlContext.Data.CreateEnumerable<PredictionResult>(prediction, reuseRowObject: false).FirstOrDefault();

            return predictionResult?.PredictedEnergyUsage ?? 0;
        }

        // Classe de entrada para o modelo (modelo de entrada do ML.NET)
        public class ModelInput {
            [ColumnName("PreviousUsage")]
            public float PreviousUsage { get; set; }
        }

        // Classe de saída para a previsão (definindo o formato da saída do modelo)
        public class PredictionResult {
            [ColumnName("PredictedEnergyUsage")]
            public float PredictedEnergyUsage { get; set; }
        }
    }
}
