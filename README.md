# Sistema de gestão de planos por assinatura

Este sistema é uma aplicação web desenvolvida para controle interno onde é possível gerenciar os planos oferecidos, cadastrar os clientes e ter um controle sobre suas mensalidades.

## Funcionalidades

### Visão geral

Para facilitar a gestão, o sistema possui um painel para exibir informações relevantes para gestão, como:

- Quantidade total de clientes
- Quantidade de mensalidades atrasadas, pendentes e pagas
- Valor total em aberto para receber

### Cadastro de Planos

O sistema permite o cadastro de diferentes planos de assinatura com as seguintes informações:

- Título do Plano
- Duração em Meses
- Valor Mensal

Além do cadastro, o sistema garante a integridade dos dados só permitindo a edição e exclusão de planos que não tenham mensalidades pendentes.

### Cadastro de Clientes

Para cada cliente, podem ser registradas informações gerais além da associação a um plano específico. As informações gerais do cliente incluem dados como nome, endereço, e-mail, telefone, entre outros.

### Lançamento de Mensalidades

- O administrador pode lançar manualmente as mensalidades para os clientes. Além disso, o sistema gera automaticamente as mensalidades no momento do cadastro do cliente, de acordo com o plano escolhido.
- Caso seja necessário editar o plano de algum cliente, as mensalidades são geradas novamente, de acordo com o plano escolhido.

### Status das Mensalidades

O sistema possui uma atualização automática, indicando o status de cada mensalidade, sendo:

- **Pendente**: Mensalidade que ainda não foi paga e está dentro do prazo.
- **Atrasada**: Mensalidade que não foi paga dentro do prazo estipulado.
- **Paga**: Mensalidade que foi devidamente quitada pelo cliente.

### Renovação Automática de Clientes

Quando o Sistema identifica que o cliente só possui uma mensalidade em aberto, é exibido ao administrador, um ícone indicando que aquele cliente precisa ser renovado. Quando renovado, as mensalidades são geradas novamente, de acordo com o plano escolhido.
## Screenshots

![App Screenshot](https://i.imgur.com/p3hqZ7S.png)
![App Screenshot](https://i.imgur.com/9Utt8rg.png)
![App Screenshot](https://i.imgur.com/Rzbq1aw.png)
![App Screenshot](https://i.imgur.com/7LdSFet.png)
![App Screenshot](https://i.imgur.com/fKin8LH.png)

## Tecnologias Utilizadas

O sistema é desenvolvido utilizando as seguintes tecnologias:
- Estrutura MVC
- .NET Core para o desenvolvimento back-end
- SQL Server como banco de dados para armazenamento dos dados
- Entity Framework Core para mapeamento objeto-relacional
- HTML, CSS e JavaScript para o frontend, utilizando Razor Pages.
Também foram utilizadas as seguintes tecnlogias externas:
- Bootstrap e Jquery para criação do front-end;
- Hangfire para execução de tarefas assícronas, por exemplo: Uma vez ao dia, o Hangfire dispara a execução de um comando no banco de dados, para verificar se existem mensalidades atrasadas.

## Instalação

```bash
1. Clone este repositório para sua máquina local.
2. Certifique-se de ter o .NET SDK instalado.
3. Configure a string de conexão com o banco de dados SQL Server no arquivo `appsettings.json`.
4. Execute as migrações do Entity Framework Core para criar a estrutura do banco de dados.
5. Inicie a aplicação e navegue para a URL local para acessar o sistema.
```
    
## Contribuições

Contribuições são bem-vindas! Se você encontrar um problema ou tiver alguma melhoria para sugerir, sinta-se à vontade para abrir uma issue ou enviar um pull request.
## Licença
[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://github.com/ruan-almeidaa/BanzaiTV/blob/main/LICENSE)

