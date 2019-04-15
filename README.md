# Churras 
Sistema para administrar os churras da galera.

## Pré-Requisitos
Para utilizar o projeto você necessita ter instalado:
- .NET Core 2.0 (ou superior)
- SqlServer
- Nodejs (algum geranciador de pacotes, por exemplo, npm ou yarn)

## Como instalar
Navegue até a pasta em que deseja salvar o projeto e realize os seguintes comandos: 

```sh
$ git clone https://github.com/lukaspiccini/Churras.git
$ cd TrincaFrontEnd/trinca-front-end/
$ npm install
```

## Banco de Dados
Para a criação do banco de dados, será necessário acessar o projeto .NET (TrincaBackEnd), ir até a classe **ChurrasDbContext.cs** localizado na pasta **/TrincaBackEnd/Repositories/** e adicionar a string de conexão a base de dados no método **optionsBuilder.UseSqlServer** 

Após isso, basta ir ao **Console do Gerenciador de Pacotes** e rodar o comando **Update-Database**

## Inicializar o Projeto
Após seguir todos os passos anterior, ou seja, ter instalado as dependências do Front-end e a configuração do banco de dados no Back-end, basta ir até a pasta do projeto Front-end e realizar o seguinte comando:

```sh
$ npm run serve
```

## Observações
O projeto possui o swagger instalado no Back-end, logo que o projeto é rodado, ja é direcionado para a página do swagger
A porta configurada para o projeto Back-end é a **50878**, caso seja necessário muda-lá, será necessário alterar a variavel de ambiente VUE_APP_BASE_URL_API no arquivo .env do projeto Front-end
