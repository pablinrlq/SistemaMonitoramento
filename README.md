# Sistema de Monitoramento com Alerta de Temperatura

## 📌 Sobre o Projeto
Este projeto é um sistema de monitoramento de temperatura que simula leituras de sensores e gera alertas quando a temperatura atinge valores críticos. Se a temperatura ultrapassar 80°C, um alerta sonoro é ativado, e os dados são armazenados em um banco de dados MySQL.

## 🚀 Funcionalidades
- Tela de login segura com limite de tentativas.
- Monitoramento contínuo de temperatura com valores gerados aleatoriamente.
- Registro de temperaturas no banco de dados.
- Alerta sonoro e visual quando a temperatura atingir 80°C ou mais.
- Opção de desativar o alerta pressionando a tecla 'U'.

## 🛠️ Tecnologias Utilizadas
- **C#** (linguagem principal)
- **MySQL** (banco de dados para armazenar as leituras)
- **.NET Framework**

## 🎮 Como Usar
1. **Instale os pré-requisitos**:
   - .NET SDK
   - MySQL Server
   - MySQL Connector para .NET
2. **Configure o Banco de Dados**:
   - Crie um banco de dados chamado `Monitoramento`.
   - Crie a tabela com o seguinte comando:
     ```sql
     CREATE TABLE Monitoramento (
         id INT AUTO_INCREMENT PRIMARY KEY,
         Leitura VARCHAR(255),
         Data TIMESTAMP DEFAULT CURRENT_TIMESTAMP
     );
     ```
3. **Execute o Programa**
   - Compile e rode o programa no terminal ou no Visual Studio.
   - Faça login usando:
     - **Usuário:** `Pablin`
     - **Senha:** `306090`
   - Escolha a opção `1` para iniciar os sensores.
   - Escolha a opção `2` para visualizar os dados no banco.
   - Pressione `U` para desativar o alerta.
   - Escolha a opção `3` para sair do programa.

## 📂 Estrutura do Código
```
📂 SistemaMonitoramento
 ├── Program.cs  # Código principal
 ├── SistemaMonitoramento.cs  # Lógica do monitoramento e alertas
```

## 📜 Licença
Este projeto é de uso livre para aprendizado e melhorias. 🚀

