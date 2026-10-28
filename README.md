<div align="center">

# Sistema de Monitoramento de Temperatura

**Aplicação de console em C# que simula sensores industriais, grava as leituras no MySQL
e dispara alerta quando a temperatura passa do limite.**

![C#](https://img.shields.io/badge/C%23-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![.NET 9](https://img.shields.io/badge/.NET_9-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![MySQL](https://img.shields.io/badge/MySQL-4479A1?style=flat-square&logo=mysql&logoColor=white)

</div>

## Sobre

Pensado para uma linha de produção: os sensores
mandam leituras o tempo todo e o operador precisa ser avisado na hora em que algo
esquenta demais. Aqui os sensores são simulados com valores aleatórios.

## Funcionalidades

- Login com limite de 3 tentativas e senha mascarada no terminal
- Leitura contínua de temperatura
- Cada leitura salva no MySQL com data e hora
- Alerta sonoro e visual a partir de **80 °C**, que pode ser silenciado com a tecla `U`
- Consulta do histórico de leituras direto pelo menu

## Rodando

Precisa do [.NET 9 SDK](https://dotnet.microsoft.com/download) e de um MySQL local.

Crie o banco e a tabela:

```sql
CREATE DATABASE Monitoramento;
USE Monitoramento;

CREATE TABLE Monitoramento (
    id      INT AUTO_INCREMENT PRIMARY KEY,
    Leitura VARCHAR(255),
    Data    TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
```

Ajuste usuário e senha do banco na `connStr` em `Program.cs` e rode:

```bash
dotnet run
```

Login de demonstração: usuário `Pablin`, senha `306090`.

| Opção | Ação |
| :---: | --- |
| `1` | Inicia os sensores |
| `2` | Mostra as leituras salvas |
| `3` | Sai do programa |
| `U` | Silencia o alerta |

## Estrutura

```
├── Program.cs                  login, menu, simulação, alerta e acesso ao banco
└── SensorTemperatura.csproj    projeto .NET 9 (MySql.Data)
```

---

<div align="center">
<sub>Feito por <a href="https://github.com/pablinrlq">Pablo Moises</a></sub>
</div>
