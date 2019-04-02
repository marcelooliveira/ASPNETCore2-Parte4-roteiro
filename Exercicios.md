## Exerc�cios

### Item01 - Criando o Projeto IdentityServer4

##### Exerc�cio 1)
   
Quais afirma��es abaixo s�o corretas sobre o ASP.NET Core Identity?

- (x) a. pode ser gerado facilmente por um novo "scaffolding" do projeto
Correto. O ASP.NET Core 2.1 e posterior permite realizar um "scaffolding", que fornece ASP.NET Core Identity como um biblioteca de classes Razor.
- (x) b. � efetivo quando voc� s� precisa de um sistema de login simples
Correto. Se voc� s� precisa de um controle de autentica��o/autoriza��o de usu�rios para uma aplica��o, usar ASP.NET Core Identity � o mais adequado.
- ( ) c. funciona como uma autoridade externa para validar identidades
Incorreto. ASP.NET Core Identity n�o funciona como um projeto externo.
- ( ) d. permite que m�ltiplos clientes possam fazer login
Incorreto. O uso do ASP.NET Core Identity se limita � aplica��o que a utiliza.
- ( ) e. � gerado a partir de um novo projeto exclusivo para servi�o de usu�rios
Incorreto. Voc� utilizar� o ASP.NET Core Identity no pr�prio projeto MVC.
- ( ) f. permite envolver e acessar v�rias Web APIs do seu sistema, de forma segura
Incorreto. As  Web APIs n�o ter�o como reconhecer o usu�rio autenticado.
- ( ) g. Autentica��o como servi�o
Incorreto. Com ASP.NET Core Identity, voc� n�o ter� autentica��o como servi�o.
- ( ) h. Single Sign-on / Sign-out
Incorreto. ASP.NET Core Identity n�o permite autentica��o centralizada de v�rios servi�os, necess�ria para realizar Single Sign-on


##### Exerc�cio 2)
   
Quais afirma��es abaixo s�o corretas sobre o IdentityServer?

- ( ) a. pode ser gerado facilmente por um novo "scaffolding" de projeto cliente MVC
Incorreto. IdentityServer precisa ser gerado como um projeto separado do seu projeto cliente MVC.
- ( ) b. � efetivo quando voc� s� precisa de um sistema de login simples
Incorreto. A configura��o do IdentityServer � mais complexa, e precisa de modifica��es tanto no projeto IdentityServer, cliente MVC como tamb�m nas Web APIs envolvidas.
- (x) c. funciona como uma autoridade externa para validar identidades
Correto. IdentityServer d� suporte para provedores de identidade externos, como o Azure Active Directory, o Google, o Facebook, etc. Isso protege seus aplicativos dos detalhes de como conectar-se a esses provedores externos.
- (x) d. permite que m�ltiplos clientes possam fazer login
Correto. IdentityServer permite que v�rios clientes possam utilizar o servi�o do IdentityServer para se autenticarem e compartilharem credenciais do usu�rio conectado.
- (x) e. � gerado a partir de um novo projeto exclusivo para servi�o de usu�rios
Correto. Voc� introduz o IdentityServer na sua solu��o criando um novo projeto com template IdentityServer.
- (x) f. permite envolver e acessar v�rias APIs do seu sistema, de forma segura
Correto. O IdentityServer emite tokens de acesso para APIs para v�rios tipos de clientes, por exemplo servidor para servidor, aplicativos da Web, SPAs e aplicativos nativos / m�veis.
- (x) g. Autentica��o como servi�o
Correto. IdentityServer fornece l�gica de login e fluxo de trabalho centralizados para todos os seus aplicativos (web, nativo, m�vel, servi�os). O IdentityServer � uma implementa��o oficialmente certificada do OpenID Connect.
- (x) h. Single Sign-on / Sign-out
Correto. IdentityServer fornece um ponto central para que um usu�rio possa usar diversas aplica��es e fazer login e logout apenas uma vez.

##### Exerc�cio 3)
   
Como adicionar funcionalidades do ASP.NET Core Identity num projeto preexistente?

1. Clicar sobre o projeto e selecionar `Add New Scaffolded Item > Identity > Identity`
2. Selecionar a p�gina de layout, views de Identity, classe de contexto, tipo de banco de dados e classe de usu�rio
3. Incluir uma partial view para o login do usu�rio
4. `Add-Migration Usuarios -context CasaDoCodigoContext`
5. rodar o comando: `Update-Database -context CasaDoCodigoContext`
6. `app.UseAuthentication();`

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
Correto. A propriedade `GetClaimsFromUserInfoEndpoint` define se o manipulador 
deve ir at� o endpoint de informa��es do usu�rio para recuperar declara��es 
adicionais ou n�o ap�s criar uma identidade a partir do id_token recebido do 
endpoint do token. O padr�o � falso'.

b. 
Adicionar esta op��o na configura��o do servidor IdentityServer:
```csharp
options.GetClaimsFromUserInfoEndpoint = true;
```
Incorreto. Essa configura��o n�o deve ser feita no servidor IdentityServer.

c. 
Adicionar esta op��o na configura��o do cliente MVC:
```csharp
options.SaveTokens = true;
```
Incorreto. `SaveTokens` apenas define se os tokens de acesso devem ser armazenados nas propriedades de autentica��o ap�s uma autoriza��o bem-sucedida.

d. 
Adicionar esta op��o na configura��o do servidor IdentityServer:
```csharp
options.SaveTokens = true;
```
Incorreto. `SaveTokens` apenas define se os tokens de acesso devem ser armazenados nas propriedades de autentica��o ap�s uma autoriza��o bem-sucedida.

##### Exerc�cio 2)
   
Voc� precisa programar uma action em um controller para desconectar o usu�rio logado numa aplica��o cliente que trabalha com IdentityServer.

Escolha o c�digo adequado para implementar essa action:

a. 
```csharp
[Authorize]
public async Task Logout()
{
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
}
```
Correto. O m�todo `HttpContext.SignOutAsync` nessas duas linhas exclui os cookies usadosna autentica��o.  Isso efetivamente desconecta o usu�rio, for�ando-o a um novo login da pr�xima vez que ele tentar acessar um recurso protegido.

b. 
```csharp
[Authorize]
public IActionResult Logout()
{
    return View("LoggedOut", vm);
}
```
Incorreto. Esse c�digo apenas ir� redirecionar o usu�rio para uma outra view, sem efetivamente desconect�-lo.

c. 
```csharp
[Authorize]
public async Task Logout()
{
    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme);
}
```
Incorreto. Precisamos fazer um sign-out, n�o um sign-in.


### Item04 - Pedidos de Clientes

##### Exerc�cio 1)
  
O que � JWT?

- (x) a. Os JSON Web Tokens s�o um padr�o aberto da ind�stria para representar declara��es do usu�rio (claims) com seguran�a entre duas partes.
Correto. Usamos esse padr�o nos projetos ASP.NET Core para transmitir claims entre aplica��es MVC, IdentityServer e Web API.
- ( ) b. Os JSON Web Tokens s�o um padr�o propriet�rio criado pela Microsoft para representar declara��es do usu�rio (claims) com seguran�a entre duas partes.
Incorreto. JWTs n�o s�o padr�o propriet�rio.
- ( ) c. Os JSON Web Tokens s�o um padr�o aberto da ind�stria para realizar chamadas AJAX com seguran�a entre duas partes.
Incorreto. � poss�vel utilizar tokens JWT com AJAX, mas eles n�o limitados a requisi��es AJAX.
- ( ) d. Os JSON Web Tokens s�o um padr�o propriet�rio criado pela Microsoft para realizar chamadas AJAX com seguran�a entre duas partes.
Incorreto. JWTs n�o s�o padr�o propriet�rio, e al�m disso � poss�vel utilizar tokens JWT com AJAX, mas eles n�o limitados a requisi��es AJAX.

##### Exerc�cio 2)
   
Selecione abaixo quais s�o exemplos de claims existentes em um JWT (Jason Web Token):

- (x) a. Nome do cliente
Correto. O nome do cliente � um atributo do cliente que poderia ser transmitido atrav�s de um token JWT.
- (x) b. CPF do cliente
Correto. O CPF do cliente � um atributo do cliente que poderia ser transmitido atrav�s de um token JWT.
- (x) c. Data de nascimento do cliente
Correto. A data de nascimento do cliente � um atributo do cliente que poderia ser transmitido atrav�s de um token JWT.
- ( ) d. Cookies
Incorreto. Cookies n�o s�o claims (declara��es do usu�rio). Eles s�o arquivos transmitidos junto com requisi��es web e nas respostas a essas requisi��es.
- ( ) e. Jason Web Tokens
Incorreto. Jason Web Tokens n�o s�o claims (declara��es do usu�rio), mas sim um padr�o de transmiss�o de claims.
- ( ) f. Endere�o do servidor IdentityServer
Incorreto. O endere�o do servidor IdentityServer n�o � uma informa��o do usu�rio.

##### Exerc�cio 3)
   
Voc� est� usando uma aplica��o ASP.NET Core em conjunto com autentica��o via IdentityServer.
Voc� verifica que o usu�rio est� devidamente autenticado, por�m a claim "sub" n�o est� aparecendo na lista de claims do usu�rio na aplica��o cliente MVC.
O que fazer?

- (x) a. Eliminar o mapeamento de claims na aplica��o MVC, com a linha de c�digo: `JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();`
Correto. O ASP.NET Core converte por padr�o a claim "sub" para outro nome: "nameidentifier". � necess�rio eliminar esse mapeamento para se obter o claim "sub".
- ( ) b. Criar uma nova claim "sub" na aplica��o IdentityServer, com a linha de c�digo: `var Sub = System.Guid.NewGuid();`
Incorreto. N�o se deve criar uma nova claim "sub" na aplica��o IdentityServer, pois ela j� est� criada.
- ( ) c. Criar uma nova claim "sub" na aplica��o cliente MVC, com a linha de c�digo: `var Sub = System.Guid.NewGuid();`
Incorreto. N�o se deve criar uma nova claim "sub" na aplica��o IdentityServer, pois ela j� est� criada.

### Item05 - Autorizando WebAPI

##### Exerc�cio 1)
   
Como envolver um novo projeto Web API no processo de autoriza��o?

- (x) a. Proteger uma ou mais actions do novo projeto Web API com o atributo `[Authorize]`
Correto. O atributo `[Authorize]` especifica que o acesso a um controlador ou m�todo de a��o � restrito a usu�rios que atendem ao requisito de autoriza��o.
- (x) b. Instalar no projeto Web API o pacote `IdentityServer4.AccessTokenValidation`
Correto. Esse pacote permite adicionar autentica��o com o m�todo de extens�o `AddIdentityServerAuthentication`.
- (x) c. Configurar autentica��o na classe Startup do projeto Web API 
Correto. A autentica��o da Web API precisa ser configurada, passando c�digo da API, segredo e url da autoridade (servidor IdentityServer).
- (x) d. Configurar o novo projeto Web API como ApiResource e escopo no projeto IdentityServer
Correto. O projeto IdentityServer deve ser configurado para que ele reconhe�a e permita acesso � Web API.
- ( ) e. Proteger uma ou mais actions do novo projeto Web API com o atributo `[Authenticate]`
Incorreto. N�o existe um atributo `AuthenticateAttribute` para permitir ou restringir acesso a m�todos da aplica��po.
- ( ) f. Instalar no projeto MVC o pacote `IdentityServer4.AccessTokenValidation`
Incorreto. Esse pacote n�o deve ser instalado na aplica��o cliente MVC.
- ( ) g. Configurar autentica��o na classe Startup do projeto IdentityServer
Incorreto. N�o se deve modificar a autentica��o no projeto Startup apenas para acomodar uma nova Web API.
- ( ) h. Configurar o novo projeto Web API como Client no projeto IdentityServer
Incorreto. Um Web API n�o deve ser configurado como cliente.

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
Correto. Voc� precisa configurar a autentica��o usando IdentityServer, passando como dados o id e nome da Web API, e tamb�m a Url do servidor IdentityServer, que � a autoridade da autentica��o.

- ( ) b.
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
Incorreto. Voc� n�o pode configurar dados do cliente, pois est� configurando uma Web API.

- ( ) c.
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
Incorreto. Essa configura��o � criada pelo template do projeto IdentityServer, e n�o deve ser usada na sua Web API.

##### Exerc�cio 3)
   
Como fazer chamadas autorizadas HTTP Post ao servi�o Web API a partir da aplica��o cliente MVC?

- (x) a.
1. Criar uma nova inst�ncia de `HttpClient` com o `HttpClientFactory`
2. Solicitar o access token � aplica��o IdentityServer
3. Definir o header de autoriza��o do `HttpClient` com o access token
4. Fazer uma requisi��o POST usando o `HttpClient`
Correto. � necess�rio requisitar o access token ao servi�o IdentityServer e pass�-lo no cabe�alho da requisi��o feita ao servi�o Web API.

- ( ) b.
1. Criar uma nova inst�ncia de `HttpClient` com o `HttpClientFactory`
2. Enviar o login e senha do usu�rio � aplica��o IdentityServer
3. Definir o header de autoriza��o do `HttpClient` com o login e senha do usu�rio
4. Fazer uma requisi��o POST usando o `HttpClient`
Incorreto. Com IdentityServer voc� n�o envia login e senha da aplica��o cliente para o IdentityServer, nem envia login e senha para o servi�o Web API.

- ( ) c.
1. Criar uma nova inst�ncia de `HttpClient` com o `HttpClientFactory`
2. Enviar o login e senha do usu�rio � aplica��o IdentityServer e receber de volta um access token
3. Definir o header de autoriza��o do `HttpClient` com o access token
4. Fazer uma requisi��o POST usando o `HttpClient`
Incorreto. Com IdentityServer voc� n�o envia usu�rio e senha da aplica��o cliente para o IdentityServer.

- ( ) d.
1. Criar uma nova inst�ncia de `HttpClient` com o `HttpClientFactory`
2. Enviar o access token � aplica��o IdentityServer e receber de volta o login e a senha do usu�rio
3. Definir o header de autoriza��o do `HttpClient` com o login e senha do usu�rio
4. Fazer uma requisi��o POST usando o `HttpClient`
Incorreto. Com IdentityServer voc� n�o envia login e senha para o servi�o Web API.




