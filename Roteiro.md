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

PROBLEMA PR�TICO : nosso projeto MVC n�o possui sistema de login
SOLU��O PR�TICA : criar um novo projeto para autenticar usu�rios
ABSTRA��O DO PROBLEMA PR�TICO EM TEORIA : o projeto MVC n�o possui sistema de autentica��o e autoriza��o para os pontos de acesso
ABSTRA��O DA SOLU��O EM TEORIA : criar um projeto STS (Security Token Server) utilizando IdentityServer4

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

PROBLEMA PR�TICO : Nosso projeto MVC n�o se comunica com o projeto Identity
SOLU��O PR�TICA : Fazer configura��o para integrar os dois projetos
ABSTRA��O DO PROBLEMA PR�TICO EM TEORIA : As duas aplica��es est�o isoladas. Precisamos fazer a troca de informa��es entre o projeto MVC e o Identity
ABSTRA��O DA SOLU��O EM TEORIA : Configurar tanto no MVC quanto no IdentityServer os pontos de acesso, tipos de tokens, grants, claims, etc. que v�o ser compartilhados

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

PROBLEMA PR�TICO : A aplica��o MVC faz login mas n�o faz logout
SOLU��O PR�TICA : Configurar o logout da plataforma
ABSTRA��O DO PROBLEMA PR�TICO EM TEORIA : Uma vez conectado o usu�rio, o projeto MVC n�o possui as informa��es necess�rias para desconectar o usu�rio e retornar para a p�gina inicial
ABSTRA��O DA SOLU��O EM TEORIA : definir os tokens com as informa��es de nome de usu�rio, id, etc., a action de logout e tamb�m as urls de retorno.

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

* A ideia aqui �: verificar se o usu�rio n�o est� deslogado
(`!true.Equals(ViewData["signed-out"])`)
* Obter o claim (dado de usu�rio) contendo o nome

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

Agora tamb�m temos que exibir o dropdown para exibir o nome do usu�rio e permitir o logout:

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

Agora rodamos a aplica��o e...

Percebemos que o nome do usu�rio logado ainda n�o aparece. Por qu�?

Vamos inspecionar os claims do usu�rio no momento:

```csharp
Context.User.Claims.ToList()
Count = 4
    [0]: {sid: a7a7a086af6a1ae87c682638a80824c1}
    [1]: {http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier: 5f1aaf2e-3f22-467b-bd96-60a5cd4ec095}
    [2]: {http://schemas.microsoft.com/identity/claims/identityprovider: local}
    [3]: {http://schemas.microsoft.com/claims/authnmethodsreferences: pwd}
```

Veja que nenhum dos claims cont�m o nome do usu�rio. Isso acontece porque a aplica��o
MVC precisa requisitar esses claims a partir do STS (Security Token Server) representado pelo nosso projeto IdentityServer.

Precisamos marcar esta op��o na configura��o do cliente:
```csharp
options.GetClaimsFromUserInfoEndpoint = true;
```

> Defini��o:
> A propriedade `GetClaimsFromUserInfoEndpoint` define se o manipulador 
deve ir at� o endpoint de informa��es do usu�rio para recuperar declara��es 
adicionais ou n�o ap�s criar uma identidade a partir do id_token recebido do 
endpoint do token. O padr�o � falso'.

IMPORTANTE: para essa altera��o surtir efeito, precisamos:

1. deslogar o usu�rio
2. fazer o login novamente

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

Agora sim, podemos ver como o nome do usu�rio aparece na barra superior

![Dropdownusuariologado](dropdownusuariologado.png)

Agora vamos clicar no bot�o logout:


![Logoutconfirmacao](logoutconfirmacao.png)

E assim nosso usu�rio � finalmente desconectado:

![Loggedout](loggedout.png)

Mas como voltamos para a aplica��o MVC?

Na verdade, o projeto IdentityServer n�o foi instru�do corretamente retornar para o cliente ap�s a desconex�o.

Vamos fazer essa configura��o com a propriedade `SignedOutRedirectUri` :

```csharp
options.SignedOutRedirectUri = Configuration["CallbackUrl"];
```

> Defini��o:
> SignedOutRedirectUri
> O uri para o qual o agente do usu�rio ser� redirecionado depois que o aplicativo for desconectado do provedor de identidade. O redirecionamento ocorrer� depois que o SignedOutCallbackPath for chamado.

Mas rodando a aplica��o novamente, n�o percebemos nenhuma mudan�a.

Na verdade, � necess�rio modificar mais uma propriedade:

```csharp
options.SaveTokens = true;
```

> Defini��o:
> Define se os tokens de acesso e atualiza��o 
> devem ser armazenados no 
> Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties ap�s uma autoriza��o 
> bem-sucedida. Essa propriedade � configurada como false por 
> padr�o para reduzir o tamanho do cookie de autentica��o final.

Agora percebemos que ap�s a desconex�o � sugerido um novo link para retorno � aplica��o MVC (CallbackUrl):

![Linkcallbackurl](linkcallbackurl.png)

Podemos ainda fazer uma �ltima configura��o, para dispensar a confirma��o do login, no momento de confirmar o usu�rio e senha:

![Requestingpermission](requestingpermission.png)

Basta modificar o arquivo Config.cs no projeto Identity:

```csharp
RequireConsent = false
```

# Item04 - Pedidos de Clientes

PROBLEMA PR�TICO : Os pedidos n�o identificam o cliente
SOLU��O PR�TICA : adaptar o modelo da aplica��o para acomodar o id do cliente que est� logado
ABSTRA��O DO PROBLEMA PR�TICO EM TEORIA : Os pedidos n�o possuem o id do cliente que est� logado e fazendo a compra
ABSTRA��O DA SOLU��O EM TEORIA : modificar o modelo, gerar a migra��o e adaptar reposit�rios e controllers

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

Note tamb�m que essas informa��es foram criadas automaticamente
pelo template do IdentityServer4. 


Agora ser� necess�rio modificar o modelo, para que o pedido tenha a informa��o do usu�rio que fez a compra.


(arquivo Pedido.cs)
```csharp
[Required]
public string ClienteId { get; private set; }
```

Esse mesmo clienteId agora ser� exigido tamb�m no construtor, juntamente com o cadastro

```csharp
public Pedido(string clienteId, Cadastro cadastro)
{
    ClienteId = clienteId;
    Cadastro = cadastro;
}
```

Mas s� modificar o modelo n�o � suficiente. Para aplicar as altera��es no banco, vamos
criar uma nova migra��o:

```
PM> Add-Migration "Pedido_ClienteId"
```

Em seguida, aplicamos as altera��es:

```
PM> Update-Database -verbose
```

Agora vamos modificar as assinaturas na interface IHttpHelper

(arquivo IHttpHelper.cs)
```csharp
int? GetPedidoId(string clienteId);
void SetPedidoId(string clienteId, int pedidoId);
void ResetPedidoId(string clienteId);
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

Agora vamos modificar nosso reposit�rio de pedidos

(arquivo IPedidoRepository)
```csharp
Task<Pedido> GetPedidoAsync(string clienteId);
Task AddItemAsync(string codigo, string clienteId);
Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido, string clienteId);
Task<Pedido> UpdateCadastroAsync(Cadastro cadastro, string clienteId);
```

(arquivo PedidoRepository)
```csharp
public async Task<Pedido> GetPedidoAsync(string clienteId)
{
    var pedidoId = httpHelper.GetPedidoId(clienteId);
```

```csharp
public async Task AddItemAsync(string codigo, string clienteId)
...
var pedido = await GetPedidoAsync(clienteId);
...
```

```csharp
pedido = new Pedido(clienteId, new Cadastro());
```

```csharp
httpHelper.SetPedidoId(clienteId, pedido.Id);
```

```csharp
public async Task<UpdateQuantidadeResponse> UpdateQuantidadeAsync(ItemPedido itemPedido, string clienteId)
.
.
.
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

E como esse clienteId ser� obtido?

Vamos mexer no PedidoController para criar um m�todo que procura essa informa��o nos claims do usu�rio:

(arquivo PedidoController.cs)
```csharp
private string GetUserId()
{
    return @User.FindFirst("sub")?.Value;
}
```

Agora o GetUserId() ser� acessado pelos outros m�todos do controller:

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

Depois de muitas altera��es, vamos agora rodar a solu��o e ver se conseguimos gravar os pedidos com os ids dos usu�rios

![Pedido Cliente Id](Pedido_ClienteId.png)

![Tabela Cadastro](Tabela_Cadastro.png)

Como vimos, agora o ID do cliente est� sendo gravado juntamente com os pedidos!

# Item05 - Autorizando WebAPI

PROBLEMA PR�TICO : Permitir acesso autorizado a uma web api externa ao MVC
SOLU��O PR�TICA : Compartilhar com a nova web api as informa��es do usu�rio logado
ABSTRA��O DO PROBLEMA PR�TICO EM TEORIA : Uma nova web api externa n�o consegue identificar se o usu�rio est� logado na aplica��o MVC
ABSTRA��O DA SOLU��O EM TEORIA : criar uma configura��o que inclua a web api na autoriza��o do IdentityServer

Vamos come�ar criando um novo projeto Web API dentro da nossa solu��o:

O projeto se chamar� CasaDoCodigo.Relatorio

![Newwebapi](newwebapi.png)

Agora vamos mudar o endere�o do projeto Web API para http://localhost:5002

Vamos definir como projeto inicial e rod�-lo:

![Values](values.png)

Vamos modificar o ValuesController desse novo projeto para ler/gravar dados do relat�rio

Nosso relat�rio ser� muito simples: apenas uma lista de strings est�tica, em mem�ria:

(arquivo ValuesController.cs)
```csharp
private static readonly List<string> Relatorio = new List<string>();
```

Agora modificamos a action Get() para retornar uma string, em vez de uma lista de strings.

```csharp
public ActionResult<string> Get()
```

A string retornada ser� constru�da com a ajuda de um `StringBuilder`

```csharp
StringBuilder sb = new StringBuilder();
foreach (var item in Relatorio)
{
    sb.AppendLine(item);
}
return sb.ToString();
```

Por outro lado, a grava��o do relat�rio s� exigir� a inclus�o de uma string na lista Relatorio,
na action Post():

```csharp
public void PostAsync([FromBody] string value)
{
    Relatorio.Add(value);
}
```

J� as outras actions (Put, Delete) podem ser exclu�das.

Vamos rodar novamente a web api

Para testar o relat�rio, precisamos rodar o programa Postman, para consumir a action Post:

![Primeiralinha](primeiralinha.png)

![Segundalinha](segundalinha.png)

![Relatorio2](relatorio2.png)

Cada linha do relat�rio representar� os dados de um pedido da aplica��o MVC.

Voc� deve aplicar as seguintes regras:

- Qualquer pessoa pode LER o relat�rio
- Somente os usu�rios autenticados poder�o GRAVAR linhas no relat�rio

Para isso, vamos proteger o m�todo `Post` com o atributo `[Authorize]`

```csharp
[HttpPost]
[Authorize]
public void Post([FromBody] string value)
```

Executando o POST no Postman novamente, pegamos um erro HTTP 500:

```
An unhandled exception occurred while processing the request.

InvalidOperationException: No authenticationScheme was specified, and there was no DefaultChallengeScheme found.
Microsoft.AspNetCore.Authentication.AuthenticationService.ChallengeAsync(HttpContext context, string scheme, AuthenticationProperties properties)
```

Claro, porque precisamos configurar a autentica��o da nossa web api.

Come�amos criando a configura��o da url do servi�o Identity:

(arquivo appsettings.json)
```json
"IdentityUrl": "http://localhost:5000"
```

Agora precisamos instalar no web api o pacote `IdentityServer4.AccessTokenValidation`


```
PM> Install-Package IdentityServer4.AccessTokenValidation
```

Isso permitir� adicionar o c�digo mais abaixo.

Na classe `Startup`, precisamos configurar a autentica��o

Esse c�digo precisa conter:


```csharp
services
    .AddAuthentication("Bearer")
    .AddIdentityServerAuthentication(options =>
    {
        options.ApiName = "CasaDoCodigo.Relatorio";
        options.ApiSecret = "49C1A7E1-0C79-4A89-A3D6-A37998FB86B0";
        options.Authority = Configuration["IdentityUrl"];
        options.RequireHttpsMetadata = false;
    });
```

```csharp
app.UseAuthentication();
```

J� na aplica��o MVC, vamos criar a configura��o com o endere�o do servi�o de relat�rio

(arquivo appsettings.json)
```json
"RelatorioUrl": "http://localhost:5002"
```

Esse servi�o vai ser acessado aom a ajuda de tokens de acesso, que precisam ser consultados no servi�o do IdentityServer.


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

Rodando a aplica��o web api, vamos testar novamente com o Postman, para tentar inserir uma linha no relat�rio.

![Postman401](postman401.png)

Vemos que desta vez o Postman falhou com o erro HTTP 401, indicando acesso n�o autorizado.

Vamos parar a aplica��o e definir os 2 projetos (MVC e Relatorio) como iniciais.



