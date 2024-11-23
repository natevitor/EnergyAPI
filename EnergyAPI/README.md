# EnergyAPI

**EnergyAPI** é uma API desenvolvida para gerenciar dispositivos, consumo de energia e gerar recomendações para otimização do uso de energia. A API também inclui funcionalidades para prever o consumo de energia com base no uso anterior utilizando IA.

## Funcionalidades

- **Gerenciamento de Dispositivos**: Criação, leitura, atualização e exclusão de dispositivos de consumo de energia.
- **Monitoramento de Consumo de Energia**: Registro de consumo de energia dos dispositivos.
- **Recomendações**: Geração de recomendações baseadas no consumo de energia dos dispositivos.
- **Previsão de Consumo de Energia**: Previsão do consumo futuro de energia com base no histórico de consumo.

## Tecnologias Utilizadas

- **.NET 8.0**: Framework para desenvolvimento da API.
- **Entity Framework Core**: ORM para interação com o banco de dados Oracle.
- **Oracle Database**: Banco de dados para armazenar informações sobre dispositivos, consumo de energia e recomendações.
- **Swagger/OpenAPI**: Ferramenta para documentação e testes da API.
- **ML.NET**: Usado para a previsão do consumo de energia com base no histórico.

## Endpoints da API

### Dispositivos

- **GET /api/Device/{id}**: Obtém um dispositivo pelo ID.
- **GET /api/Device**: Obtém todos os dispositivos.
- **POST /api/Device**: Adiciona um novo dispositivo.
- **PUT /api/Device/{id}**: Atualiza um dispositivo existente.
- **DELETE /api/Device/{id}**: Deleta um dispositivo pelo ID.

### Consumo de Energia

- **GET /api/EnergyUsage/{id}**: Obtém o consumo de energia de um dispositivo pelo ID.
- **GET /api/EnergyUsage**: Obtém todos os registros de consumo de energia.
- **POST /api/EnergyUsage**: Adiciona um novo registro de consumo de energia.
- **PUT /api/EnergyUsage/{id}**: Atualiza um registro de consumo de energia.
- **DELETE /api/EnergyUsage/{id}**: Deleta um registro de consumo de energia pelo ID.

### Recomendações

- **GET /api/Recommendation/{id}**: Obtém uma recomendação pelo ID.
- **GET /api/Recommendation**: Obtém todas as recomendações.
- **POST /api/Recommendation**: Adiciona uma nova recomendação.
- **PUT /api/Recommendation/{id}**: Atualiza uma recomendação existente.
- **DELETE /api/Recommendation/{id}**: Deleta uma recomendação pelo ID.

### Previsão de Consumo de Energia

- **POST /api/EnergyUsage/predictEnergyUsage**: Faz a previsão do consumo de energia com base no consumo anterior.

  **Parâmetros**:
  - `previousUsage`: O consumo anterior de energia (valor do tipo `double`).

  **Resposta**:
  - Retorna o valor da previsão de consumo de energia.

## Estrutura de Pastas

