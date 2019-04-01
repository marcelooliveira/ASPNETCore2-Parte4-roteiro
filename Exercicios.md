## Exerc�cios

### Item01 - Criando o Projeto IdentityServer4

1) Quais afirma��es abaixo s�o corretas sobre o ASP.NET Core Identity?

- (x) a. pode ser gerado facilmente por um novo "scaffolding" do projeto
- (x) b. � efetivo quando voc� s� precisa de um sistema de login simples
- ( ) c. funciona como uma autoridade externa para validar identidades
- ( ) d. permite que m�ltiplos clientes possam fazer login
- ( ) e. � gerado a partir de um novo projeto exclusivo para servi�o de usu�rios
- ( ) f. permite envolver e acessar v�rias APIs do seu sistema, de forma segura
- ( ) g. Autentica��o como servi�o
- ( ) h. Single Sign-on / Sign-out
- ( ) i. Controle de acesso para APIs

2) Quais afirma��es abaixo s�o corretas sobre o IdentityServer?

- ( ) a. pode ser gerado facilmente por um novo "scaffolding" do projeto
- ( ) b. � efetivo quando voc� s� precisa de um sistema de login simples
- (x) c. funciona como uma autoridade externa para validar identidades
- (x) d. permite que m�ltiplos clientes possam fazer login
- (x) e. � gerado a partir de um novo projeto exclusivo para servi�o de usu�rios
- (x) f. permite envolver e acessar v�rias APIs do seu sistema, de forma segura
- (x) g. Autentica��o como servi�o
- (x) h. Single Sign-on / Sign-out
- (x) i. Controle de acesso para APIs

3) Como adicionar funcionalidades do ASP.NET Core Identity num projeto preexistente?

- (x) a. Clicar sobre o projeto > Add New Scaffolded Item > Identity > Identity
- (x) b. Selecionar a p�gina de layout, views de Identity, classe de contexto, tipo de banco de dados e classe de usu�rio
- (x) c. Incluir uma partial view para o login do usu�rio
- (x) d. Add-Migration Usuarios -context CasaDoCodigoContext
- (x) e. rodar o comando: Update-Database -context CasaDoCodigoContext
- (x) f. app.UseAuthentication();

4) Como criar um projeto STS com IdentityServer?

- (x) a. Abrir Developer Command Prompt for VS 2017
- (x) b. No diret�rio da solu��o, criar um novo diret�rio para o projeto Iden
- (x) c. Instalar templates IdentityServer4 `dotnet new -i identityserver4.templates`
- (x) d. Criar novo projeto ASP.NET Identity for user management: `dotnet new is4aspid`
- (x) e. Fazer o "seeding" (alimentar) o banco de dados de usu�rio
- (x) f. Adicionar o novo projeto IdentityServer � solu��o
- (x) g. Definir os 2 projetos como iniciais (Startup Projects)


### Item02 - Autorizando o Cliente MVC

* O que acontece quando um usu�rio desconectado tenta acessar uma action protegida?
* Como as credenciais s�o trocadas entre o IdentityServer e o MVC?
* Qual a sequ�ncia de eventos logo ap�s o usu�rio fazer login com sucesso?
* Quais actions devem ser protegidas?
 
### Item03 - Fluxo de Logout

* Como fazer logout pelo MVC?
* Quais passos necess�rios para exibir o nome do usu�rio nas views do MVC?
* Por que as claims do usu�rio logado n�o aparecem na aplica��o MVC?
* O que acontece quando o usu�rio conectado faz logout na tela de carrinho?
 
### Item04 - Pedidos de Clientes

* Como obter o id do usu�rio autenticado?
* O que � JWT?
* O que s�o claims?
* A claim "sub" n�o est� aparecendo. O que fazer?

### Item05 - Autorizando WebAPI

* Como envolver o Web API no processo de autoriza��o?
* Qual configura��o de Web API � correta?
* Qual a sequ�ncia de passos necess�rios para autorizar esta Web API?
* Como fazer chamadas HTTP Post autorizadas?

