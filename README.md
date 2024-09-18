# Sistema de Gerenciamento de Contas Bancárias

## Descrição

Este projeto implementa um sistema de gerenciamento de contas bancárias para uma cooperativa de crédito. O sistema permite o cadastro de correntistas e a gestão de contas bancárias, incluindo operações de depósito, saque, aplicação de juros e rendimento. O sistema suporta dois tipos de contas: Conta Corrente e Conta Poupança.

## Funcionalidades

- **Cadastro de Correntistas**: Inclui CPF, nome, endereço e profissão.
- **Criação de Contas**: Suporte para Conta Corrente e Conta Poupança.
- **Operações Bancárias**:
  - Depósito
  - Saque
  - Aplicação de rendimento (para Conta Poupança)
  - Aplicação de juros (para Conta Corrente)
- **Cálculo de Juros**:
  - Juros aplicados ao saldo negativo (Conta Corrente)
  - Rendimento aplicado ao saldo da Conta Poupança

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET Core
- **Banco de Dados**: Banco de Dados em Memória para desenvolvimento e testes
- **ORM**: Entity Framework
- **Bibliotecas**: FluentValidation para validação
- **Extras**: Docker

## Estrutura do Projeto

- **Application**: Contém a lógica de aplicação e serviços.
- **Domain**: Define as entidades e enums do domínio.
- **Infrastructure**: Implementações de acesso a dados e repositórios.
- **WebApi**: Implementação da API para interação com o sistema.




