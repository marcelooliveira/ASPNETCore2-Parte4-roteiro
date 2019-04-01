## Exercícios

### Item01 - Criando o Projeto IdentityServer4

1) Quais afirmações abaixo são corretas sobre o ASP.NET Core Identity?

- (x) a. pode ser gerado facilmente por um novo "scaffolding" do projeto
- (x) b. é efetivo quando você só precisa de um sistema de login simples
- ( ) c. funciona como uma autoridade externa para validar identidades
- ( ) d. permite que múltiplos clientes possam fazer login
- ( ) e. é gerado a partir de um novo projeto exclusivo para serviço de usuários
- ( ) f. permite envolver e acessar várias APIs do seu sistema, de forma segura
- ( ) g. Autenticação como serviço
- ( ) h. Single Sign-on / Sign-out
- ( ) i. Controle de acesso para APIs

2) Quais afirmações abaixo são corretas sobre o IdentityServer?

- ( ) a. pode ser gerado facilmente por um novo "scaffolding" do projeto
- ( ) b. é efetivo quando você só precisa de um sistema de login simples
- (x) c. funciona como uma autoridade externa para validar identidades
- (x) d. permite que múltiplos clientes possam fazer login
- (x) e. é gerado a partir de um novo projeto exclusivo para serviço de usuários
- (x) f. permite envolver e acessar várias APIs do seu sistema, de forma segura
- (x) g. Autenticação como serviço
- (x) h. Single Sign-on / Sign-out
- (x) i. Controle de acesso para APIs

3) Como adicionar funcionalidades do ASP.NET Core Identity num projeto preexistente?

- (x) a. Clicar sobre o projeto > Add New Scaffolded Item > Identity > Identity
- (x) b. Selecionar a página de layout, views de Identity, classe de contexto, tipo de banco de dados e classe de usuário
- (x) c. Incluir uma partial view para o login do usuário
- (x) d. Add-Migration Usuarios -context CasaDoCodigoContext
- (x) e. rodar o comando: Update-Database -context CasaDoCodigoContext
- (x) f. app.UseAuthentication();

4) Como criar um projeto STS com IdentityServer?

- (x) a. Abrir Developer Command Prompt for VS 2017
- (x) b. No diretório da solução, criar um novo diretório para o projeto Iden
- (x) c. Instalar templates IdentityServer4 `dotnet new -i identityserver4.templates`
- (x) d. Criar novo projeto ASP.NET Identity for user management: `dotnet new is4aspid`
- (x) e. Fazer o "seeding" (alimentar) o banco de dados de usuário
- (x) f. Adicionar o novo projeto IdentityServer à solução
- (x) g. Definir os 2 projetos como iniciais (Startup Projects)


### Item02 - Autorizando o Cliente MVC

* O que acontece quando um usuário desconectado tenta acessar uma action protegida?
* Como as credenciais são trocadas entre o IdentityServer e o MVC?
* Qual a sequência de eventos logo após o usuário fazer login com sucesso?
* Quais actions devem ser protegidas?
 
### Item03 - Fluxo de Logout

* Como fazer logout pelo MVC?
* Quais passos necessários para exibir o nome do usuário nas views do MVC?
* Por que as claims do usuário logado não aparecem na aplicação MVC?
* O que acontece quando o usuário conectado faz logout na tela de carrinho?
 
### Item04 - Pedidos de Clientes

* Como obter o id do usuário autenticado?
* O que é JWT?
* O que são claims?
* A claim "sub" não está aparecendo. O que fazer?

### Item05 - Autorizando WebAPI

* Como envolver o Web API no processo de autorização?
* Qual configuração de Web API é correta?
* Qual a sequência de passos necessários para autorizar esta Web API?
* Como fazer chamadas HTTP Post autorizadas?

