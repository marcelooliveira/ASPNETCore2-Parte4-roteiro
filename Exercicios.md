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
   
Como as declara��es do usu�rio (claims) s�o trocadas entre o IdentityServer e a aplica��o MVC?

- (x) a. A aplica��o MVC faz um redirecionamento para a uma view de login da aplica��o IdentityServer, onde o usu�rio realiza o login. Ap�s a autentica��o, o usu�rio � redirecionado de volta para a aplica��o MVC com os cookies contendo o token JWT com as declara��es do usu�rio (claims).
- ( ) b. A aplica��o MVC faz uma chamada HTTP via AJAX (JavaScript), enviando login e senha para a aplica��o IdentityServer, onde o usu�rio � autenticado. A chamada AJAX retorna o token JWT com as declara��es do usu�rio (claims). 
- ( ) c. A aplica��o MVC faz uma chamada POST usando um objeto HttpClient, passando login e senha para uma action da aplica��o IdentityServer, onde o usu�rio � autenticado. A chamada ass�ncrona retorna o token JWT com as declara��es do usu�rio (claims).
- ( ) d. A aplica��o MVC faz uma chamada GET usando um objeto HttpClient, passando login e senha para uma action da aplica��o IdentityServer, onde o usu�rio � autenticado. A chamada ass�ncrona retorna o token JWT com as declara��es do usu�rio (claims). 

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
   
Voc� est� tentando exibir o nome do usu�rio conectado nas views da aplica��o cliente MVC.
Para isso, voc� adiciona as seguintes linhas ao arquivo `_layout.cshtml`:

```csharp
@using System.Linq;
@using System.Security.Claims;
@{
    string name = null;
    if (!true.Equals(ViewData["signed-out"]))
    {
        name = @User.FindFirst("name")?.Value;
    }
}
```
```html
<div class="navbar-collapse collapse">
    @if (!string.IsNullOrWhiteSpace(name))
    {
        <ul class="nav navbar-nav pull-right">
            <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown">@name <b class="caret"></b></a>
                <ul class="dropdown-menu">
                    <li><a asp-action="Logout" asp-controller="Pedido">Logout</a></li>
                </ul>
            </li>
        </ul>
    }
</div>
```

Entretanto, ao consultar as declara��es do usu�rio (claims), voc� nota que est� faltando a declara��o (claim) com o nome do usu�rio:

```csharp
Context.User.Claims.ToList()
Count = 4
    [0]: {sid: a7a7a086af6a1ae87c682638a80824c1}
    [1]: {http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier: 5f1aaf2e-3f22-467b-bd96-60a5cd4ec095}
    [2]: {http://schemas.microsoft.com/identity/claims/identityprovider: local}
    [3]: {http://schemas.microsoft.com/claims/authnmethodsreferences: pwd}
```

O que voc� precisa fazer para que a claim com o nome do usu�rio esteja presente nessa lista?

a. 
Adicionar esta op��o na configura��o do cliente MVC:
```csharp
options.GetClaimsFromUserInfoEndpoint = true;
```

b. 
Adicionar esta op��o na configura��o do servidor IdentityServer:
```csharp
options.GetClaimsFromUserInfoEndpoint = true;
```

c. 
Adicionar esta op��o na configura��o do cliente MVC:
```csharp
options.SaveTokens = true;
```

d. 
Adicionar esta op��o na configura��o do servidor IdentityServer:
```csharp
options.SaveTokens = true;
```

##### Exerc�cio 2)
   
Por que as claims (declara��es) do usu�rio logado n�o aparecem na aplica��o MVC?

##### Exerc�cio 3)
   
O que acontece quando o usu�rio conectado faz logout na tela de carrinho?
 
### Item04 - Pedidos de Clientes

##### Exerc�cio 1)
   
Como obter o id do usu�rio autenticado?

##### Exerc�cio 2)
   
O que � JWT?

- (x) a. Os JSON Web Tokens s�o um padr�o aberto da ind�stria para representar declara��es do usu�rio (claims) com seguran�a entre duas partes.
- ( ) b. Os JSON Web Tokens s�o um padr�o propriet�rio criado pela Microsoft para representar declara��es do usu�rio (claims) com seguran�a entre duas partes.
- ( ) c. Os JSON Web Tokens s�o um padr�o aberto da ind�stria para realizar chamadas AJAX com seguran�a entre duas partes.
- ( ) d. Os JSON Web Tokens s�o um padr�o propriet�rio criado pela Microsoft para realizar chamadas AJAX com seguran�a entre duas partes.

##### Exerc�cio 3)
   
Selecione abaixo quais s�o exemplos de claims existentes em um JWT (Jason Web Token):

- (x) a. Nome do cliente
- (x) b. CPF do cliente
- (x) c. Data de nascimento do cliente
- ( ) d. Cookies
- ( ) e. Jason Web Tokens
- ( ) f. Endere�o do servidor IdentityServer

##### Exerc�cio 4)
   
Voc� est� usando uma aplica��o ASP.NET Core em conjunto com autentica��o via IdentityServer.
Voc� verifica que o usu�rio est� devidamente autenticado, por�m a claim "sub" n�o est� aparecendo na lista de claims do usu�rio na aplica��o cliente MVC.
O que fazer?

- (x) a. Eliminar o mapeamento de claims na aplica��o MVC, com a linha de c�digo: `JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();`
- ( ) b. Criar uma nova claim "sub" na aplica��o IdentityServer, com a linha de c�digo: `var Sub = System.Guid.NewGuid();`
- ( ) c. Criar uma nova claim "sub" na aplica��o cliente MVC, com a linha de c�digo: `var Sub = System.Guid.NewGuid();`
- ( ) d. Eliminar o mapeamento de claims na aplica��o IdentityServer, com a linha de c�digo: `JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();`

### Item05 - Autorizando WebAPI

##### Exerc�cio 1)
   
Como envolver um novo projeto Web API no processo de autoriza��o?

- (x) a. Proteger uma ou mais actions do novo projeto Web API com o atributo `[Authorize]`
- (x) b. Instalar no projeto Web API o pacote `IdentityServer4.AccessTokenValidation`
- (x) c. Configurar autentica��o na classe Startup do projeto Web API 
- (x) d. Configurar o novo projeto Web API como ApiResource e escopo no projeto IdentityServer
- ( ) e. Proteger uma ou mais actions do novo projeto Web API com o atributo `[Authenticate]`
- ( ) f. Instalar no projeto MVC o pacote `IdentityServer4.AccessTokenValidation`
- ( ) g. Configurar autentica��o na classe Startup do projeto IdentityServer
- ( ) h. Configurar o novo projeto Web API como Client no projeto IdentityServer


##### Exerc�cio 2)
   
Qual configura��o de autentica��o da Web API � correta?

- (x) a.
```csharp
services
.AddAuthentication("Bearer")
.AddIdentityServerAuthentication(options =>
{
    options.ApiName = "Codigo_da_API";
    options.ApiSecret = "segredo_da_api";
    options.Authority = Configuration["IdentityUrl"];
});
```

- (x) b.
```csharp   
services
.AddAuthentication()
.AddOpenIdConnect(options =>
{
    options.ClientId = "Codigo_da_API";
    options.ClientSecret = "segredo_da_api";
    options.Authority = Configuration["IdentityUrl"];
});
```

- (x) c.
```csharp
var builder = services.AddIdentityServer(options =>
{
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
})
.AddInMemoryIdentityResources(Config.GetIdentityResources())
.AddInMemoryApiResources(Config.GetApis())
.AddInMemoryClients(Config.GetClients(Configuration["CallbackUrl"]))
.AddAspNetIdentity<ApplicationUser>();
```

##### Exerc�cio 3)
   
Como fazer chamadas autorizadas HTTP Post ao servi�o Web API a partir da aplica��o cliente MVC?

- (x) a.
1. Criar uma nova inst�ncia de `HttpClient` com o `HttpClientFactory`
2. Solicitar o access token � aplica��o IdentityServer
3. Definir o header de autoriza��o do `HttpClient` com o access token
4. Fazer uma requisi��o POST usando o `HttpClient`

- ( ) b.
1. Criar uma nova inst�ncia de `HttpClient` com o `HttpClientFactory`
2. Enviar o login e senha do usu�rio � aplica��o IdentityServer
3. Definir o header de autoriza��o do `HttpClient` com o login e senha do usu�rio
4. Fazer uma requisi��o POST usando o `HttpClient`

- ( ) c.
1. Criar uma nova inst�ncia de `HttpClient` com o `HttpClientFactory`
2. Enviar o login e senha do usu�rio � aplica��o IdentityServer e receber de volta um access token
3. Definir o header de autoriza��o do `HttpClient` com o access token
4. Fazer uma requisi��o POST usando o `HttpClient`

- ( ) d.
1. Criar uma nova inst�ncia de `HttpClient` com o `HttpClientFactory`
2. Enviar o access token � aplica��o IdentityServer e receber de volta o login e a senha do usu�rio
3. Definir o header de autoriza��o do `HttpClient` com o login e senha do usu�rio
4. Fazer uma requisi��o POST usando o `HttpClient`


