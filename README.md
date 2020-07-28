# API_Central_de_Erros
#### *ErrorMonitoring*

![68747470733a2f2f7777772e696d6167656d686f73742e636f6d2e62722f696d616765732f323031392f31322f31332f6c6f676f2e706e67](https://user-images.githubusercontent.com/37166588/88711265-4f553700-d0ee-11ea-8cbe-e822fd452230.png)

## Índice
- [Objetivo](#objetivo)
- [Arquitetura](#arquitetura)
- [Tecnologias e Ferramentas Utilizadas](#tecnologias)
- [Banco de Dados](#bd)
- [Deploy da aplicação](#deploy)
- [Rotas](#rotas)
- [Mais informações](#more)
- [Squad desenvolvedora](#squad)
- [Agradecimentos](#objetivo)

### Objetivo <a name="objetivo"></a>
Em projetos modernos é cada vez mais comum o uso de arquiteturas baseadas em serviços ou microsserviços. 
Nestes ambientes complexos, erros podem surgir em diferentes camadas da aplicação (backend, frontend, mobile, desktop) e mesmo em serviços distintos. 
Desta forma, é muito importante que os desenvolvedores possam centralizar todos os registros de erros em um local, de onde podem monitorar e tomar decisões mais acertadas. 
Neste projeto vamos implementar um sistema para centralizar registros de erros de aplicações.

### A arquitetura do projeto é formada por: <a name="arquitetura"></a>

*Backend - API*
- criar endpoints para serem usados pelo frontend da aplicação
- criar um endpoint que será usado para gravar os logs de erro em um banco de dados relacional
- a API deve ser segura, permitindo acesso apenas com um token de autenticação válido

### Tecnologias Utilizadas: <a name="tecnologias"></a>
- C# .NET
- Entity Framework
- Clean Code
- Swagger

### Ferramentas Utilizadas: <a name="ferramentas"></a>
- Visual Studio
- Postman
- Trello
- WhatsApp

## Banco de Dados: <a name="bd"></a>
- SqlServer via Codefirst

## Deploy da aplicação: <a name="deploy"></a>
- Deploy automático Azure [Clique aqui](https://errormonitoring.azurewebsites.net/swagger/index.html)

## Rotas: <a name="rotas"></a>

-AuthController
`POST /api/v1/Auth/cadastrar` - Cadastra um novo usuário<br/>
`POST /api/v1/Auth/login` - Realiza login do usuário cadastrado<br/>
`POST /api/v1/Auth/logout` - Realiza o logout do usuário<br/>
`POST /api/v1/Auth/forgotPassword` - Envia um codigo para que o usuário possa resetar a senha<br/>
`POST /api/v1/Auth/resetPassword` -<br/>

-EnvironmentController
`GET api/environments` - Retorna todos os ambientes da ErrorMonitoring<br/>
`GET api/environments/{id}` - Retorna o ambiente do ID<br/>
`POST api/environments` - Cadastra um novo ambiente<br/>
`PUT api/environments/{id}` - Atualiza o ambiente do ID<br/>
`DELETE api/environments/{id}` - Deleta o ambiente do ID<br/>

-ProjectController
`GET 	api/project` - Retorna todos os projetos da ErrorMonitoring<br/>
`GET 	api/project/{id}` - Retorna o projeto do ID<br/>
`POST 	api/project` - Cadastra um novo projeto<br/>
`PUT 	api/project/{id}` - Atualiza o projeto do ID<br/>
`DELETE	api/project/{id}` - Deleta o projeto do ID<br/>

-EventsController
`GET 	/api/Events` - Retorna todos os eventos da ErrorMonitoring<br/>
`GET 	/api/Events/{id}` - Retorna o evento do ID<br/>
`POST 	/api/Events` - Cadastra um novo evento<br/>
`PUT 	/api/Events/{id}` - Atualiza o evento<br/>
`DELETE	/api/Events/{id}` - Deleta o evento do ID<br/>

-LogController
`GET 	api/log`	- Retorna todos os logs da ErrorMonitoring<br/>
`GET 	api/log/{id}` - Retorna o log do ID<br/>
`POST 	api/log` - Cadastra um novo log<br/> 
`PUT 	api/log/{id}` - Atualiza o log do ID<br/>
`DELETE	api/log/{id}` - Deleta o log do ID<br/>

-ProjectsEnvironments
`GET 	api/projects_environments` - Retorna todos os ambientes e projetos relacionados da ErrorMonitoring<br/>
`GET 	api/projects_environments/{id}`	- Retorna o ambiente e projeto relacionados do ID<br/>
`POST 	api/projects_environments` - Cadastra um novo ambiente e projeto relacionados<br/>
`PUT 	api/projects_environments` - Atualiza o ambiente e projeto relacionados do ID<br/>
`DELETE	api/projects_environments/{id}`	- Deleta o ambiente e projeto relacionados do ID<br/>

### Maiores informações: <a name="more"></a>
- Esta API é um projeto desenvolvido para o AceleraDev C# Woman ClearSale, um projeto da Codenation.

#### Squad desenvolvedora: <a name="squad"></a>

- [Aline Saouda](https://www.linkedin.com/in/aline-saouda-42242856/)

- [Bruna Stefani Marques](https://www.linkedin.com/in/bruna-stefani-marques-736a58b1/)	

- [Juliana Onofrio Marques](https://www.linkedin.com/in/julianaonofrio/)

- [Thalita Mariano](https://www.linkedin.com/in/thalita-mariano-971b48172/)

### Agradecimentos: <a name="agradecimentos"></a>
