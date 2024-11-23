# EnergyAPI

**EnergyAPI** � uma API desenvolvida para gerenciar dispositivos, consumo de energia e gerar recomenda��es para otimiza��o do uso de energia. A API tamb�m inclui funcionalidades para prever o consumo de energia com base no uso anterior utilizando IA.

## Funcionalidades

- **Gerenciamento de Dispositivos**: Cria��o, leitura, atualiza��o e exclus�o de dispositivos de consumo de energia.
- **Monitoramento de Consumo de Energia**: Registro de consumo de energia dos dispositivos.
- **Recomenda��es**: Gera��o de recomenda��es baseadas no consumo de energia dos dispositivos.
- **Previs�o de Consumo de Energia**: Previs�o do consumo futuro de energia com base no hist�rico de consumo.

## Tecnologias Utilizadas

- **.NET 8.0**: Framework para desenvolvimento da API.
- **Entity Framework Core**: ORM para intera��o com o banco de dados Oracle.
- **Oracle Database**: Banco de dados para armazenar informa��es sobre dispositivos, consumo de energia e recomenda��es.
- **Swagger/OpenAPI**: Ferramenta para documenta��o e testes da API.
- **ML.NET**: Usado para a previs�o do consumo de energia com base no hist�rico.

## Endpoints da API

### Dispositivos

- **GET /api/Device/{id}**: Obt�m um dispositivo pelo ID.
- **GET /api/Device**: Obt�m todos os dispositivos.
- **POST /api/Device**: Adiciona um novo dispositivo.
- **PUT /api/Device/{id}**: Atualiza um dispositivo existente.
- **DELETE /api/Device/{id}**: Deleta um dispositivo pelo ID.

### Consumo de Energia

- **GET /api/EnergyUsage/{id}**: Obt�m o consumo de energia de um dispositivo pelo ID.
- **GET /api/EnergyUsage**: Obt�m todos os registros de consumo de energia.
- **POST /api/EnergyUsage**: Adiciona um novo registro de consumo de energia.
- **PUT /api/EnergyUsage/{id}**: Atualiza um registro de consumo de energia.
- **DELETE /api/EnergyUsage/{id}**: Deleta um registro de consumo de energia pelo ID.

### Recomenda��es

- **GET /api/Recommendation/{id}**: Obt�m uma recomenda��o pelo ID.
- **GET /api/Recommendation**: Obt�m todas as recomenda��es.
- **POST /api/Recommendation**: Adiciona uma nova recomenda��o.
- **PUT /api/Recommendation/{id}**: Atualiza uma recomenda��o existente.
- **DELETE /api/Recommendation/{id}**: Deleta uma recomenda��o pelo ID.

### Previs�o de Consumo de Energia

- **POST /api/EnergyUsage/predictEnergyUsage**: Faz a previs�o do consumo de energia com base no consumo anterior.

  **Par�metros**:
  - `previousUsage`: O consumo anterior de energia (valor do tipo `double`).

  **Resposta**:
  - Retorna o valor da previs�o de consumo de energia.

## Estrutura de Pastas

