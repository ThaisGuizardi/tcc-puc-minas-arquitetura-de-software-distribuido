# Menu Facile

- Protótipo funcional do projeto integrado Menu Facile.
- PUC Minas Virtual.
- Pós Gradução em Arquitetura de Software Distribuído (2021).
- Disciplina: 16 - Projeto Integrado – Arquitetura de Software Distribuído (2021).
- Nota do Projeto: 99,00.

## Download do projeto

- Módulo A - Vídeo de Apresentação.
- Módulo B - Código da Aplicação.
- Módulo C - Vídeo de Apresentação Final.
- Donwload: https://drive.google.com/drive/folders/1oJAm8lt_1vWJGOLGDjNCR4pnIvuFLbqO?usp=sharing

## Pré-requisitos

- Visual Studio 2022 Community: https://visualstudio.microsoft.com/pt-br/vs/community/
- SQL Server Management Studio v18: https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
- SQL Server Express: https://www.microsoft.com/pt-br/sql-server/sql-server-downloads

## Funcionamento do projeto

- SQL Server Management Studio: Restaurar os bancos de dados MenuFacileMvc.bak, MenuFacileServiceManager.bak e MenuFacileServiceOrder.bak.
- Visual Studio 2022 Community: Abrir a solução MenuFacile.sln.
  - Projeto MenuFacile.Manager.Api, arquivo appsettings.json e propriedade sqlServerConnectionString, adicionar string de conexão com o banco de dados.
  - Projeto MenuFacile.Order.Api, arquivo appsettings.json e propriedade sqlServerConnectionString, adicionar string de conexão com o banco de dados.
  - Projeto MenuFacile.Mvc, arquivo appsettings.json, propriedades DefaultConnection e MenuFacileMvcContextConnection, adicionar string de conexão com o banco de dados.
  - Para que a funcionalidade abra com sucesso será necessário iniciar os três projetos juntos na solução. Para isso será necessário fazer a configuração abaixo:
    - Clicar com botão direito do mouse na solução MenuFacile e clicar em Properties.
    ![image](https://user-images.githubusercontent.com/3730961/183534418-beae3d6a-7bcc-4619-973e-af5050f4a396.png)
   
    - Na caixa de dialogo selecionar a opção "Multiple startup projects" e selecionar na coluna Action a opção Start para os projetos MenuFacile.Manager.Api, MenuFacile.Order.Api e MenuFacile.Mvc.
    ![image](https://user-images.githubusercontent.com/3730961/183534130-f77379b9-7965-4d8e-8d23-b9f75c1b3107.png)


## Usuários e senha de acesso à aplicação

- adm@menufacile.com.br
- entrega@menufacile.com.br
- cozinha@manufacile.com.br
- Todos os usuários senha 123Mudar_

## Contato Linked-in

- www.linkedin.com/in/thaisguizardi
