<p align="center">
  <img src="https://github.com/user-attachments/assets/b7479aa1-dcb1-4c9f-a202-64018a010c66" alt="Assistente Virtual de Auditoria Energética - Logo" width="200"/>
</p>

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

---

## Integrantes do Projeto

| Nome                         | Matrícula | Turma  |
|------------------------------|-------------|--------|
| Enzo Oliveira                | RM551356    | 2TDSPF |
| Igor Ribeiro Anccilotto      | RM550415    | 2TDSPF |
| João Vitor Souza Nunes      | RM550381    | 2TDSPF |
| Matheus Colossal             | RM99572     | 2TDSPF |
| Pedro Henrique Endo de Oliveira | RM551446 | 2TDSPF |

---

# Projeto Web API .NET Core [ C# ]

## Sistema

A API desenvolvida em .NET atenderá à nossa aplicação mobile Assistente Virtual de Auditoria Energética.

## Arquitetura do Sistema

O projeto foi iniciado com uma **arquitetura monolítica** para acelerar o desenvolvimento e validar o produto de forma rápida. No futuro, está planejada uma **migração para microserviços**, garantindo maior escalabilidade e flexibilidade para o crescimento da plataforma.

---

## Padrões de Design Utilizados

### Repository Pattern
Utilizamos o **Repository Pattern** para isolar a lógica de acesso aos dados, facilitando a manutenção e permitindo a troca de fontes de dados (como bancos de dados ou APIs externas) sem afetar as demais camadas da aplicação.

Exemplo: `AppDbContext.cs` gerencia a interação com o banco de dados, enquanto repositórios específicos encapsulam as operações CRUD.

### Vantagens dos Padrões Utilizados

- **Manutenibilidade**: A separação clara das responsabilidades facilita a manutenção e a expansão de funcionalidades.
- **Testabilidade**: A lógica de negócios isolada permite a criação de testes unitários e de integração de forma mais eficiente.
- **Escalabilidade**: A estrutura modular possibilita a expansão do sistema com baixo impacto no código existente.

## Princípios Utilizados

### Clean Code

- **Legibilidade**: Utilizamos nomes descritivos, como `ListarDispositivos`, `BuscarDispositivo`, e `CadastrarDispositivo`, para tornar o código mais intuitivo.
- **Facilidade de Manutenção**: Métodos com responsabilidade única permitem alterações localizadas.
- **Redução de Erros**: Práticas como verificação de nulos evitam exceções indesejadas.
- **Produtividade**: Estruturas claras e organizadas facilitam o desenvolvimento.

### SOLID

- **Single Responsibility Principle**: Cada método no controller e nos serviços tem uma única responsabilidade.
- **Open/Closed Principle**: O código é aberto para extensões e fechado para modificações, permitindo novas funcionalidades sem impactar o existente.
- **Liskov Substitution Principle**: O uso de interfaces permite a troca de implementações sem afetar a lógica do sistema.
- **Interface Segregation Principle**: Interfaces pequenas e focadas garantem que o código seja modular e fácil de entender.
- **Dependency Inversion Principle**: Controllers dependem de abstrações, facilitando a troca de implementações e reduzindo o acoplamento.

## Benefícios

- **Facilidade de Extensão**: Novas funcionalidades podem ser adicionadas sem modificar o código existente.
- **Reutilização de Código**: O padrão de repositório permite a reutilização da lógica de acesso a dados em diferentes partes da aplicação.
- **Flexibilidade e Manutenção**: A separação clara entre camadas promove uma arquitetura que é fácil de modificar.
- **Melhor Testabilidade**: A estrutura modular facilita a criação de testes unitários, aumentando a confiabilidade do sistema.

---

## Guia para Testar a API com Swagger

### Passo 1: Abrir a Interface do Swagger
Após iniciar a API, acesse o **Swagger UI** pelo navegador. A URL será algo como:

https://localhost:7036/swagger/index.html

(O número da porta pode variar conforme o ambiente de execução).

### Passo 2: Explorar os Endpoints
Na interface do **Swagger**, visualize todos os endpoints disponíveis organizados por controladores. Expanda cada endpoint para ver detalhes como método HTTP, parâmetros e respostas.

### Passo 3: Testar um Endpoint
1. Selecione um endpoint e clique para expandir.
2. Preencha os parâmetros necessários.
3. Clique em **Try it out** para enviar uma requisição.
4. O Swagger retorna a resposta, incluindo:
   - **Código de status** (ex.: 200 OK, 404 Not Found).
   - **Corpo da resposta** no formato JSON.
   - **Cabeçalhos da requisição**.

### Passo 4: Revisar a Resposta
- Verifique a resposta retornada e, se necessário, ajuste os parâmetros e tente novamente.
- O **tipo de dados** (string, int, bool, double, etc.) deve ser conferido ao preencher os parâmetros.

---

## Machine Learning com ML NET

Com o pacote **ML.NET**, desenvolvemos um modelo de Machine Learning para prever o valor da conta de energia elétrica com base em fatores como histórico de consumo, uso diário de energia, impostos aplicáveis e quantidade de dias no mês. Para realizar essa previsão, utilizamos o algoritmo **SDCA (Stochastic Dual Coordinate Ascent)**, que é eficiente e escalável para problemas de regressão linear.

## Testes Unitários

O projeto de testes foi desenvolvido utilizando **xUnit** e **Moq** para validar todos os endpoints da API de forma eficiente e confiável. A combinação dessas ferramentas permite testar as funcionalidades sem depender de serviços ou bancos de dados reais, garantindo isolamento e rapidez nos testes.

### Estrutura do Projeto de Testes
- **xUnit**: Utilizado como framework de testes por ser simples, modular e suportar testes parametrizados e de integração.
- **Moq**: Utilizado para criar objetos simulados (mocks), permitindo testar os endpoints de maneira isolada e simular cenários reais e controlados.

