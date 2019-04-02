## Exerc�cios

### Item01 - Criando o Projeto IdentityServer4

##### Exerc�cio 1)
   
Quais afirma��es abaixo s�o corretas sobre o ASP.NET Core Identity?

- (x) a. pode ser gerado facilmente por um novo "scaffolding" do projeto
- (x) b. � efetivo quando voc� s� precisa de um sistema de login simples
- ( ) c. funciona como uma autoridade externa para validar identidades
- ( ) d. permite que m�ltiplos clientes possam fazer login
- ( ) e. � gerado a partir de um novo projeto exclusivo para servi�o de usu�rios
- ( ) f. permite envolver e acessar v�rias APIs do seu sistema, de forma segura
- ( ) g. Autentica��o como servi�o
- ( ) h. Single Sign-on / Sign-out
- ( ) i. Controle de acesso para APIs

##### Exerc�cio 2)
   
Quais afirma��es abaixo s�o corretas sobre o IdentityServer?

- ( ) a. pode ser gerado facilmente por um novo "scaffolding" do projeto
- ( ) b. � efetivo quando voc� s� precisa de um sistema de login simples
- (x) c. funciona como uma autoridade externa para validar identidades
- (x) d. permite que m�ltiplos clientes possam fazer login
- (x) e. � gerado a partir de um novo projeto exclusivo para servi�o de usu�rios
- (x) f. permite envolver e acessar v�rias APIs do seu sistema, de forma segura
- (x) g. Autentica��o como servi�o
- (x) h. Single Sign-on / Sign-out
- (x) i. Controle de acesso para APIs

##### Exerc�cio 3)
   
Como adicionar funcionalidades do ASP.NET Core Identity num projeto preexistente?

- (x) a. Clicar sobre o projeto > Add New Scaffolded Item > Identity > Identity
- (x) b. Selecionar a p�gina de layout, views de Identity, classe de contexto, tipo de banco de dados e classe de usu�rio
- (x) c. Incluir uma partial view para o login do usu�rio
- (x) d. Add-Migration Usuarios -context CasaDoCodigoContext
- (x) e. rodar o comando: Update-Database -context CasaDoCodigoContext
- (x) f. app.UseAuthentication();

##### Exerc�cio 4)
   
Como criar um projeto STS com IdentityServer?

- (x) a. Abrir Developer Command Prompt for VS 2017
- (x) b. No diret�rio da solu��o, criar um novo diret�rio para o projeto Iden
- (x) c. Instalar templates IdentityServer4 `dotnet new -i identityserver4.templates`
- (x) d. Criar novo projeto ASP.NET Identity for user management: `dotnet new is4aspid`
- (x) e. Fazer o "seeding" (alimentar) o banco de dados de usu�rio
- (x) f. Adicionar o novo projeto IdentityServer � solu��o
- (x) g. Definir os 2 projetos como iniciais (Startup Projects)

### Item02 - Autorizando o Cliente MVC

##### Exerc�cio 1)
   
Voc� est� desenvolvendo uma aplica��o que j� utiliza autentica��o/autoriza��o. O que acontece quando um usu�rio desconectado tenta acessar uma view atrav�s de uma action protegida num controller da sua aplica��o?

- (x) a. O usu�rio � redirecionado para a p�gina de login
- ( ) b. O usu�rio � redirecionado para a p�gina de logout
- ( ) c. O usu�rio consegue acessar a action normalmente
- ( ) d. Ocorre uma exce��o de AuthenticationException

##### Exerc�cio 2)
   
Como as credenciais (claims) s�o trocadas entre o IdentityServer e a aplica��o MVC?

- (x) a. A aplica��o MVC faz um redirecionamento para a uma view de login da aplica��o IdentityServer, onde o usu�rio realiza o login. Ap�s a autentica��o, o usu�rio � redirecionado de volta para a aplica��o MVC com os cookies contendo o token JWT com as credenciais (claims) do usu�rio. 
- ( ) b. A aplica��o MVC faz uma chamada HTTP via AJAX (JavaScript), enviando login e senha para a aplica��o IdentityServer, onde o usu�rio � autenticado. A chamada AJAX retorna o token JWT com as credenciais (claims) do usu�rio.. 
- ( ) c. A aplica��o MVC faz uma chamada POST usando um objeto HttpClient, passando login e senha para uma action da aplica��o IdentityServer, onde o usu�rio � autenticado. A chamada ass�ncrona retorna o token JWT com as credenciais (claims) do usu�rio.. 
- ( ) d. A aplica��o MVC faz uma chamada GET usando um objeto HttpClient, passando login e senha para uma action da aplica��o IdentityServer, onde o usu�rio � autenticado. A chamada ass�ncrona retorna o token JWT com as credenciais (claims) do usu�rio.. 

##### Exerc�cio 3)
   
Quais actions devem ser protegidas?

Voc� est� desenvolvendo uma aplica��o de com�rcio eletr�nico.

Voc� quer permitir que usu�rios possam pesquisar produtos do site livremente, sem obrig�-los a fazer autentica��o com login com a senha.
Por�m, a manipula��o de pedidos deve ser feita somente por usu�rios devidamente autorizados.

Quais actions de controller da aplica��o devem ser protegidos pelo atributo `[Authorize]`?

- (x) a. Carrinho
- (x) b. Cadastro
- (x) c. Resumo
- (x) d. UpdateQuantidade
- ( ) e. Carrossel
- ( ) f. BuscaProdutos

 
### Item03 - Fluxo de Logout

##### Exerc�cio 1)
   
Como fazer logout pelo MVC?

##### Exerc�cio 2)
   
Quais passos necess�rios para exibir o nome do usu�rio nas views do MVC?

##### Exerc�cio 3)
   
Por que as claims do usu�rio logado n�o aparecem na aplica��o MVC?

##### Exerc�cio 4)
   
O que acontece quando o usu�rio conectado faz logout na tela de carrinho?
 
### Item04 - Pedidos de Clientes

##### Exerc�cio 1)
   
Como obter o id do usu�rio autenticado?

##### Exerc�cio 2)
   
O que � JWT?

##### Exerc�cio 3)
   
O que s�o claims?

##### Exerc�cio 4)
   
A claim "sub" n�o est� aparecendo. O que fazer?

### Item05 - Autorizando WebAPI

##### Exerc�cio 1)
   
Como envolver o Web API no processo de autoriza��o?

##### Exerc�cio 2)
   
Qual configura��o de Web API � correta?

##### Exerc�cio 3)
   
Qual a sequ�ncia de passos necess�rios para autorizar esta Web API?

##### Exerc�cio 4)
   
Como fazer chamadas HTTP Post autorizadas?

