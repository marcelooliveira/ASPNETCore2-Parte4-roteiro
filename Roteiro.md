# Instala��o

- Visual Studio Community
https://visualstudio.microsoft.com/pt-br/vs/community/

- DB Browser for SQLite
https://sqlitebrowser.org/blog/version-3-11-1-released

- Postman
https://www.getpostman.com/downloads/


# Da Parte 2 para a Parte 3: diferen�as

PROBLEMA PR�TICO : fazer uma "pr�-introdu��o", para orientar estudantes vindos do �ltimo curso (Parte 2)
SOLU��O PR�TICA : Mostrar as altera��es feitas no projeto inicial da Parte 3
ABSTRA��O DO PROBLEMA PR�TICO EM TEORIA : introduzir assincronia, busca de produtos, refatora��o no modelo simplifica��o nos reposit�rios. Atualiza��o do framework.
ABSTRA��O DA SOLU��O EM TEORIA : 

Come�amos a parte 3 deste curso com o c�digo que usamos no final �ltimo curso,
**ASP.NET Core parte 2: Um e-Commerce com MVC e EF Core** 
(https://cursos.alura.com.br/course/aspnet-core-2-validacoes-seguranca)

Por�m, algumas altera��es e atualiza��es foram necess�rias.

**Melhorias**:
1. Todos os m�todos de bancos de dados ou E/S agora s�o ass�ncronos
2. Nova view de busca de produtos
3. O modelo agora tem categorias de Produtos
4. Arquivo `models.cs` foi quebrado em v�rios arquivos, um para cada entidade
5. Reposit�rios foram simplificados: `CategoriaRepository` foi para `ProdutoRepository` e `ItemPedidoRepository` foi para `PedidoRepository`.
6. Os dados iniciais agora s�o carregados no `Program.cs`
7. Projeto atualizado para ASP.NET Core 2.2

# Item01 - Criando o Projeto IdentityServer4

## Introdu��o

Nesta parte 3 do curso, iremos utilizar um sistema de login e garantir que nossa aplica��o seja acessada apenas por usu�rios autenticados.

Tamb�m vamos utilizar nossa web app em conjunto com um novo projeto web api simples.

Se voc� s� precisa de uma tabela de usu�rios com recursos de login de senha e um perfil de usu�rio, ent�o **ASP.NET Identity** � a melhor op��o para voc�.

A Alura j� possui os cursos abaixo, que utilizam ASP.NET Identity para deixar suas aplica��es seguras:

**PARA SABER MAIS (INCLUIR COMO SLIDES E COMO ATIVIDADE NA PLATAFORMA):**

![Curso Identity1](CursoIdentity1.png)

* **ASP.NET Identity parte 1: Gerencie contas de usu�rios**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt1)

![Curso Identity2](CursoIdentity2.png)

* **ASP.NET Identity parte 2: Autentica��o, seguran�a com lockout**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt2)

![Curso Identity3](CursoIdentity3.png)

* **ASP.NET Identity parte 3: Autoriza��o, autentica��o externa com redes sociais**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt3)

![Curso Identity4](CursoIdentity4.png)

* **ASP.NET Identity parte 4: Autentica��o mais segura com 2 fatores**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt4)

Entretanto, se voc� tiver m�ltiplos clientes, que precisam acessar diferentes web APIs, voc� poder� utilizar um **servidor de token de seguran�a (STS)** para proteger e validar tokens de identidade e acesso entre os servi�os.

Por esse motivo, iremos utilizar IdentityServer4 como uma **autoridade externa de login**. Dessa forma, a mesma autentica��o e autoriza��o funcionar�o tanto para a web app quanto para as web apis.

![](https://openid.net/wordpress-content/uploads/2014/09/openid-r-logo-900x360.png)

Algumas caracter�sticas do **IdentityServer4** s�o:


![Topologia](topologia.png)


- **Autentica��o como servi�o**:
L�gica de login e fluxo de trabalho centralizados para todos os seus aplicativos (web, nativo, m�vel, servi�os). O IdentityServer � uma implementa��o oficialmente certificada do OpenID Connect.

![Singlesignon](singlesignon.png)

- **Single Sign-on / Sign-out**:
Logon e logout �nico em v�rios tipos de aplicativos.

![Controledeacessoapis](controledeacessoapis.png)
- **Controle de acesso para APIs**:
Emitir tokens de acesso para APIs para v�rios tipos de clientes, por exemplo servidor para servidor, aplicativos da Web, SPAs e aplicativos nativos / m�veis.

![Gatewayfederacao](gatewayfederacao.png)

- **Gateway de Federa��o**:
Suporte para provedores de identidade externos, como o Azure Active Directory, o Google, o Facebook, etc. Isso protege seus aplicativos dos detalhes de como conectar-se a esses provedores externos.

![Personalizacao](personalizacao.png)

- **Foco na personaliza��o**:
A parte mais importante - muitos aspectos do IdentityServer podem ser personalizados para atender �s suas necessidades. Como o IdentityServer � uma estrutura e n�o um produto em caixa ou um SaaS, voc� pode escrever c�digo para adaptar o sistema da maneira que fizer sentido para seus cen�rios.

![Opensource](opensource.png)

- **Open Source Maduro**:
O IdentityServer usa a licen�a permissiva do Apache 2, que permite criar produtos comerciais sobre ela. Tamb�m faz parte da Funda��o .NET, que fornece governan�a e suporte legal.

## O Novo Projeto CasaDoCodigo.Identity

Os passos abaixo s�o necess�rios para criar um novo projeto **IdentityServer4**:

- Copiar o projeto "CasaDoCodigo" da pasta **antes** para **Item01**

- Abrir Developer Command Prompt for VS 2017

- Ir para a pasta Item01:

```
cd **ASPNETCore2-Parte3\Item01**
```

- Criar a pasta **CasaDoCodigo.Identity**

```
md CasaDoCodigo.Identity
```

- Mudar para a pasta **CasaDoCodigo.Identity**

```
cd CasaDoCodigo.Identity
```

- Instalar templates IdentityServer4

```
dotnet new -i identityserver4.templates
```

- Criar novo projeto ASP.NET Identity for user management:


```
\ASPNETCore2-Parte3\Item01\CasaDoCodigo.Identity>dotnet new is4aspid
```

> O modelo "IdentityServer4 with ASP.NET Core Identity" foi criado com �xito.
>
> Processando a��es de p�s-cria��o...
O modelo est� configurado para executar a seguinte a��o:
Descri��o:
Instru��es manuais: Seeds the initial user database
Comando real: dotnet run /seed
Deseja executar esta a��o (S|N)?
Y
Executando o comando 'dotnet run /seed'...
O comando foi bem-sucedido.

- Adicionar o novo projeto � solu��o, na pasta Item01

- Mudar o endere�o do projeto Identity para http://localhost:5000

- Mudar o endere�o do projeto MVC para http://localhost:5001

- Mudar o nome do projeto MVC para CasaDoCodigo.MVC

- Definir 2 projetos iniciais: \Item01\CasaDoCodigo e \Item01\CasaDoCodigo.Identity.

- Executar os 2 projetos

- Fazer login como **Alice Smith** e **Bob Smith**

![Formulariologin](formulariologin.png)

Uma vez logado, o usu�rio visualiza seu nome no topo da p�gina.

![Username](username.png)

Aqui, ele pode fazer o logout, como podemos ver:

![Logoutmenu](logoutmenu.png)


# Item02 - Autorizando o Cliente MVC

## Protegendo recursos

Agora que temos o projeto Identity, come�aremos a proteger nosso projeto MVC contra acesso n�o-autenticado.
Com isso, garantiremos que somente usu�rios que entraram com login e senha v�lidos possam ter acesso a recursos protegidos do sistema.

Mas quais recursos dever�o ser protegidos?

|Action|Protegido?|
|--|--|
|Carrossel|N�O|
|BuscaProdutos|N�O|
|Carrinho|SIM|
|Cadastro|SIM|
|Resumo|SIM|
|UpdateQuantidade|SIM|

Note que tanto a Carrossel e BuscaProdutos ficar�o desprotegidos.
Por qu�? Queremos permitir que usu�rios possam navegar pela busca de produtos do site livremente, sem obrig�-los a fazer login com a senha.
J� os outros actions s�o todas protegidas, pois envolvem a manipula��o de pedidos, que s� podem ser feito por clientes.

Como protegeremos esses recursos? Devemos marcar cada action com um atributo de autoriza��o:

```csharp
[Authorize]
public async Task<IActionResult> Carrinho(string codigo)
```

> O atributo `[Authorize]` especifica que o acesso a um controlador ou m�todo de a��o � restrito a usu�rios que atendem ao requisito de autoriza��o.

Agora que marcamos a autoriza��o, rodamos a solu��o...

A p�gina inicial da aplica��o � a busca de produtos, como podemos ver,
que � acessada pela action `BuscaProdutos`. Note que n�o exigimos autoriza��o nessa action.

![Buscaprodutos](buscaprodutos.png)

Agora vamos clicar para adicionar um produto qualquer...

> An unhandled exception occurred while processing the request.
InvalidOperationException: No authenticationScheme was specified, and there was no DefaultChallengeScheme found.
Microsoft.AspNetCore.Authentication.AuthenticationService+<ChallengeAsync>d__11.MoveNext()

Por que recebemos esse erro? 

At� agora, s� dissemos quais actions s�o autorizadas, por�m n�o definimos o **esquema de autentica��o**. 

Lembre-se de que a action que estamos tentando acessar, `Carrinho`, � protegida pelo atributo `[Authorize]`.

Vamos fazer isso agora. Mas antes, precisamos entender os pap�is desempenhados por cada
componente nesta arquitetura.

Como vemos na imagem abaixo, o projeto com **IdentityServer4**
pode ser usado pelos clientes e outros servi�os, para garantir a seguran�a 
de um sistema.

**Clientes**: app m�vel, web app, single page application, etc.
que exige que o usu�rio seja autenticado para acessar determinados recursos.
**IdentityServer4**: servidor de token de seguran�a. Possui a view para login do usu�rio. 
**Relat�rio Web API**: servi�o restrito, que s� pode ser acessado por usu�rios autenticados.

![Client S T S Web A P I](Client_STS_WebAPI.png)

O projeto **IdentityServer4** possui um arquivo `Config.cs`, onde podemos configurar os **clientes**, **apis** e **recursos** usados no fluxo de autentica��o/autoriza��o.

Vamos modificar somente o **cliente ** para definir o id e nome do cliente (projeto CasaDoC�digo.MVC)

**arquivo Config.cs (CasaDoCodigo.Identity)**
```csharp
// MVC client using hybrid flow
new Client
{
    ClientId = "CasaDoCodigo.MVC",
    ClientName = "Casa do C�digo MVC",
```

Essa �rea define quais s�o os clientes autorizados pelo projeto IdentityServer4.

Agora precisamos modificar o projeto MVC para habilitar autentica��o.

Podemos dizer que o servi�o de autentica��o � um **middleware**.

> O middleware � um software que fornece servi�os para aplica��es al�m das j� s�o oferecidas pelo sistema operacional.

**arquivo Startup.cs (CasaDoCodigo.MVC)**
```csharp
public void ConfigureServices(IServiceCollection services)
{
    //...
    services.AddAuthorization();
    //...
}
public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
{
    //...
    app.UseAuthentication();
    //...
}
```

Os m�todos `AddAuthorization` e `UseAuthentication` acrescentam o **middleware** de autoriza��o e autentica��o no **pipeline** da aplica��o web.

Agora tamb�m precisamos adicionar o **esquema de autentica��o**. 

Esse esquema necessita de 2 informa��es:

- O esquema **default**: vamos usar cookies
- O esquema de **"desafio" default**: vamos usar OpenId 

```csharp
services
.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
});
```

Para utilizar esses defaults, instale o pacote no projeto MVC:
```
PM>Install-Package Microsoft.AspNetCore.Authentication.Cookies
```

Agora precisamos dizer ao ASP.NET Core para utilizar **cookies** durante a autentica��o:

```csharp
.AddCookie();
```

A seguir, vamos configurar o sistema de identifica��o **OpenId** :

- **SignInScheme**: o esquema para fazer o login (por cookies)
- **Authority**: a "autoridade", ou seja, o endere�o do servi�o do IdentityServer
- **ClientId**: o Id do cliente (CasaDoCodigo.MVC)
- **ClientSecret**: o segredo da autentica��o (usamos o mesmo do servi�o identity)
- **ResponseType**: precisa requisitar um c�digo de autoriza��o e um token de identidade
- **RequireHttpsMetadata**: vamos dispensar a necessidade de HTTPS, pois estamos em modo de desenvolvimento

```csharp
.AddOpenIdConnect(options =>
{
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Authority = "http://localhost:5000";
    options.ClientId = "CasaDoCodigo.MVC";
    options.ClientSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
    options.ResponseType = "code id_token";
    options.RequireHttpsMetadata = false;
});
```

Agora que fizemos a configura��o do cliente de autentica��o, rodamos a solu��o novamente...

![Buscaprodutos](buscaprodutos.png)

Como sabemos, a action `BuscaProdutos` n�o � protegida por autoriza��o.

Agora tentaremos adicionar um produto ao carrinho.

Isso nos levar� para o endere�o do servi�o STS (IdentityServer4):

![Formulariologin](formulariologin.png)

Neste momento, podemos fazer login com 2 usu�rios predeterminados:

- **login**: alice, **senha**: Pass123$
- **login**: bob, **senha**: Pass123$

Ao aceitarmos o login, a aplica��o IdentityServer nos leva para uma 
outra view, onde o usu�rio pode visualizar as informa��es 
que s�o solicitadas pela aplica��o CasaDoCodigo.MVC.

Aqui, ele tem a oportunidade de negar permiss�o a esse acesso.

![Requestingpermission](requestingpermission.png)

Ao conceder a permimiss�o, voc� � redirecionado de volta para
a aplica��o cliente (CasaDoCodigo.MVC):

![Actionautorizada](actionautorizada.png)

Vamos dar uma olhada na aba "network" da aplica��o cliente ap�s o login:

![Cookies1](cookies1.png)
![Cookies2](cookies2.png)

Note como a aplica��o est� utilizando v�rios cookies.
Esses cookies s�o necess�rios para v�rias finalidades, como:

- token anti-falsifica��o
- "lembrar" quem � o usu�rio logado,
- quais s�o suas informa��es,
- data/hora de expira��o, 
- sess�o do IdentityServer, etc.

Na outra p�gina, vamos dar uma olhada neste link, que exibir� os "grants", isto �,
as "concess�es" que foram dadas � aplica��o cliente:

![Linkgerenciargrants](linkgerenciargrants.png)

![Gerenciargrants](gerenciargrants.png)


Voc� pode facilmente interromper o uso dos seus dados pela aplica��o, deslogando
na aplica��o IdentityServer:

![Logoutbutton](logoutbutton.png)

![Deslogado](deslogado.png)

Agora vamos abrir novamente a aba "network" do navegador, para ver quais cookies est�o sendo usados
pela aplica��o cliente:

![Cookiesdeslogado](cookiesdeslogado.png)

Podemos notar que "sumiram" 3 cookies desde nossa �ltima visita a essa aba:

- .AspNetCore.Cookies
- .AspNetCore.Identity.Application
- idsrv.session

Sem esses cookies, o mecanismo de autentica��o considera que o usu�rio est� "deslogado", portanto
da pr�xima vez que ele tentar acessar o carrinho, ser� solicitado um novo login.

Vamos dar uma olhada no caminho desde a p�gina inicial a at� a aplica��o ser autenticada:

![Carrinhoautenticado](carrinhoautenticado.png)

# Item03 - Fluxo de Logout

## CasaDoCodigo.Identity

Neste ponto, o endere�o do nosso cliente (CasaDoCodigo.MVC) est� fixo
na configura��o de clientes do projeto Identity:

```csharp
RedirectUris = { "http://localhost:5001/signin-oidc" },
FrontChannelLogoutUri = "http://localhost:5001/signout-oidc",
PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },
```

E voc� quiser, ou precisar mudar o endere�o desse cliente? Voc� teria que alterar e recompilar o c�digo.

Ent�o � melhor deixar essa informa��o configur�vel.

Vamos adicionar uma configura��o nova para o "endere�o de retorno":

(arquivo appsettings.json)
```
"CallbackUrl": "http://localhost:5001"
```

Esse "CallbackUrl" � o endere�o-base para o cliente MVC do IdentityServer

Agora � necess�rio modificar o c�digo para injetar o parametro de url de callback:

(arquivo Startup.cs)
```csharp
.AddInMemoryClients(Config.GetClients(Configuration["CallbackUrl"]))
```

```csharp
RedirectUris = { callbackUrl + "/signin-oidc" },
FrontChannelLogoutUri = callbackUrl + "/signout-oidc",
PostLogoutRedirectUris = { callbackUrl + "/signout-callback-oidc" },
```

## CasaDoCodigo.MVC

- Instalar IdentityModel

(arquivo appsettings.json)
```
  "IdentityUrl": "http://localhost:5000",
  "CallbackUrl": "http://localhost:5001"
```

(arquivo PedidoController.cs)
```csharp
[Authorize]
public async Task Logout()
{
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
}
```

(arquivo _Layout.cshtml)
```csharp
@using IdentityServer4.Extensions
@{
    string name = null;
    if (!true.Equals(ViewData["signed-out"]))
    {
        name = Context.User?.GetDisplayName();
    }
}
```

```html
@if (!string.IsNullOrWhiteSpace(name))
{
    <ul class="nav navbar-nav">
        <li class="dropdown">
            <a href="#" class="dropdown-toggle" data-toggle="dropdown">@name <b class="caret"></b></a>
            <ul class="dropdown-menu">
                <li><a asp-action="Logout" asp-controller="Account">Logout</a></li>
            </ul>
        </li>
    </ul>
}
```

Por�m, quando rodamos a solu��o, n�o estamos vendo a informa��o do usu�rio logado:

![Usuariologadonaoaparece](usuariologadonaoaparece.png)

Por qu�?

Primeiro, vamos fazer logout com a aplica��o Identity.

Agora, vamos modificar o arquivo de layout do nosso site.

(arquivo _Layout.cshtml)
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

```csharp
Context.User.Claims.ToList()
Count = 4
    [0]: {sid: a7a7a086af6a1ae87c682638a80824c1}
    [1]: {http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier: 5f1aaf2e-3f22-467b-bd96-60a5cd4ec095}
    [2]: {http://schemas.microsoft.com/identity/claims/identityprovider: local}
    [3]: {http://schemas.microsoft.com/claims/authnmethodsreferences: pwd}
```

Precisamos marcar esta op��o na configura��o do cliente:
```csharp
options.GetClaimsFromUserInfoEndpoint = true;
```

A propriedade `GetClaimsFromUserInfoEndpoint` define se o manipulador 
deve ir at� o endpoint de informa��es do usu�rio para recuperar declara��es 
adicionais ou n�o ap�s criar uma identidade a partir do id_token recebido do 
endpoint do token. O padr�o � falso'.

Consultando novamente os claims do usu�rio, obtemos uma nova lista:

```csharp
Context.User.Claims.ToList()
Count = 6
    [0]: {sid: 7005c6b234f0e3db4f829e6e5631e35b}
    [1]: {sub: 5f1aaf2e-3f22-467b-bd96-60a5cd4ec095}
    [2]: {idp: local}
    [3]: {name: Bob Smith}
    [4]: {given_name: Bob}
    [5]: {family_name: Smith}
```



# Item04 - Pedidos de Clientes

Lembra dos usu�rios alice e bob? Vamos abrir o banco de dados que est� no projeto Identity, chamado AspIdUsers.db.

Esse arquivo � o banco de dados do SQLite.Vamos fazer um duplo clique, que nos levar� para o programa DB Browser for SQLite:

Aqui, vamos navegar pelas tabelas de usu�rios e de dados pessoais de usu�rios (claims)

![Asp Net Users](AspNetUsers.png)

![Asp Net User Claims](AspNetUserClaims.png)

Como essas informa��es s�o criadas?

Isso � feito com a ajuda da classe SeedData do projeto IdentityServer.

Note como o `ApplicationUser` � criado e como os claims (dados pessoais) s�o adicionados ao usu�rio "Alice": 

(arquivo SeedData.cs do projeto Identity)
```csharp
var userMgr = scope.ServiceProvider
    .GetRequiredService<UserManager<ApplicationUser>>();
var alice = userMgr.FindByNameAsync("alice").Result;
if (alice == null)
{
    alice = new ApplicationUser
    {
        UserName = "alice"
    };
    var result = userMgr.CreateAsync(alice, "Pass123$").Result;
    if (!result.Succeeded)
    {
        throw new Exception(result.Errors.First().Description);
    }

    result = userMgr.AddClaimsAsync(alice, new Claim[]{
    new Claim(JwtClaimTypes.Name, "Alice Smith"),
    new Claim(JwtClaimTypes.GivenName, "Alice"),
    new Claim(JwtClaimTypes.FamilyName, "Smith"),
    new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
    new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
    new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
    new Claim(JwtClaimTypes.Address, 
        @"{ 'street_address': 'One Hacker Way', 
        'locality': 'Heidelberg', 
        'postal_code': 69118, 'country': 'Germany' }", 
        IdentityServer4.IdentityServerConstants.ClaimValueTypes.Json)
}).Result;
```


(arquivo PedidoController.cs)
```csharp
await pedidoRepository.AddItemAsync(codigo, GetUserId());
```

```csharp
var pedido = await pedidoRepository.GetPedidoAsync(GetUserId());
```

```csharp
var pedido = await pedidoRepository.GetPedidoAsync(GetUserId());
```

```csharp
return View(await pedidoRepository.UpdateCadastroAsync(cadastro, GetUserId()));
```

```csharp
return await pedidoRepository.UpdateQuantidadeAsync(itemPedido, GetUserId());
```

```csharp
public class Pedido : BaseModel
{
    public Pedido()
    {
        Cadastro = new Cadastro();
    }

    public Pedido(string clienteId, Cadastro cadastro)
    {
        ClienteId = clienteId;
        Cadastro = cadastro;
    }

    public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();

    [Required]
    public string ClienteId { get; private set; }

    [ForeignKey("CadastroId")]
    [Required]
    public virtual Cadastro Cadastro { get; private set; }
}
```

(arquivo HttpHelper.cs)
```csharp
public int? GetPedidoId(string clienteId)
{
    return contextAccessor.HttpContext.Session.GetInt32($"pedidoId_{clienteId}");
}

public void SetPedidoId(string clienteId, int pedidoId)
{
    contextAccessor.HttpContext.Session.SetInt32($"pedidoId_{clienteId}", pedidoId);
}

public void ResetPedidoId(string clienteId)
{
    contextAccessor.HttpContext.Session.Remove($"pedidoId_{clienteId}");
}
```

(arquivo IHttpHelper.cs)
```csharp
int? GetPedidoId(string clienteId);
void SetPedidoId(string clienteId, int pedidoId);
void ResetPedidoId(string clienteId);
```

(arquivo IPedidoRepository)
```csharp
Task<Pedido> GetPedidoAsync(string clienteId);
Task AddItemAsync(string codigo, string clienteId);
Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido, string clienteId);
Task<Pedido> UpdateCadastroAsync(Cadastro cadastro, string clienteId);
```

(arquivo PedidoRepository)
```csharp
public async Task AddItemAsync(string codigo, string clienteId)
```

```csharp
var pedido = await GetPedidoAsync(clienteId);
```

```csharp
public async Task<Pedido> GetPedidoAsync(string clienteId)
{
    var pedidoId = httpHelper.GetPedidoId(clienteId);
```

```csharp
pedido = new Pedido(clienteId, new Cadastro());
```

```csharp
httpHelper.SetPedidoId(clienteId, pedido.Id);
```

```csharp
private void ResetPedidoId(string clienteId)
{
    contextAccessor.HttpContext.Session.Remove($"pedidoId_{clienteId}");
}
```

```csharp
public async Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido, string clienteId)
```

```csharp
var pedido = await GetPedidoAsync(clienteId);
```

```csharp
public async Task<Pedido> UpdateCadastroAsync(Cadastro cadastro, string clienteId)
{
    var pedido = await GetPedidoAsync(clienteId);
    await cadastroRepository.UpdateAsync(pedido.Cadastro.Id, cadastro);
    httpHelper.ResetPedidoId(clienteId);
    await GerarRelatorio(pedido);
    return pedido;
}
```

# Item05 - Autorizando WebAPI

(arquivo appsettings.json)
```json
"RelatorioUrl": "http://localhost:5002"
```

(arquivo IHttpHelper.cs)
```csharp
Task<string> GetAccessToken(string scope);
void SetAccessToken(string accessToken);
```

(arquivo HttpHelper.cs)
```csharp
public async Task<string> GetAccessToken(string scope)
{
    Uri baseUri = new Uri(Configuration["IdentityUrl"]);
    var tokenClient = new TokenClient(new Uri(baseUri, "connect/token").ToString(), "CasaDoCodigo.MVC", "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0");

    var tokenResponse = await tokenClient.RequestClientCredentialsAsync(scope);
    return tokenResponse.AccessToken;
}

public void SetAccessToken(string accessToken)
{
    contextAccessor.HttpContext.Session.SetString("accessToken", accessToken);
}
```

(arquivo PedidoRepository.cs)
```csharp
Uri uriBase = new Uri(configuration["RelatorioUrl"]);
```

trocar:
```csharp
await System.IO.File.AppendAllLinesAsync("Relatorio.txt", new string[] { sb.ToString() });
```

por:
```csharp
var accessToken = await httpHelper.GetAccessToken("CasaDoCodigo.Relatorio");
httpClient.SetBearerToken(accessToken);
var httpResponseMessage = await httpClient.PostAsync(new Uri(uriBase, "api/values"), content);
```

