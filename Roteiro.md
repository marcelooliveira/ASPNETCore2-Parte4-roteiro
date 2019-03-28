# Instalação

- Visual Studio Community
https://visualstudio.microsoft.com/pt-br/vs/community/

- DB Browser for SQLite
https://sqlitebrowser.org/blog/version-3-11-1-released

- Postman
https://www.getpostman.com/downloads/


# Da Parte 2 para a Parte 3: diferenças

PROBLEMA PRÁTICO : fazer uma "pré-introdução", para orientar estudantes vindos do último curso (Parte 2)
SOLUÇÃO PRÁTICA : Mostrar as alterações feitas no projeto inicial da Parte 3
ABSTRAÇÃO DO PROBLEMA PRÁTICO EM TEORIA : introduzir assincronia, busca de produtos, refatoração no modelo simplificação nos repositórios. Atualização do framework.
ABSTRAÇÃO DA SOLUÇÃO EM TEORIA : 

Começamos a parte 3 deste curso com o código que usamos no final último curso,
**ASP.NET Core parte 2: Um e-Commerce com MVC e EF Core** 
(https://cursos.alura.com.br/course/aspnet-core-2-validacoes-seguranca)

Porém, algumas alterações e atualizações foram necessárias.

**Melhorias**:
1. Todos os métodos de bancos de dados ou E/S agora são assíncronos
2. Nova view de busca de produtos
3. O modelo agora tem categorias de Produtos
4. Arquivo `models.cs` foi quebrado em vários arquivos, um para cada entidade
5. Repositórios foram simplificados: `CategoriaRepository` foi para `ProdutoRepository` e `ItemPedidoRepository` foi para `PedidoRepository`.
6. Os dados iniciais agora são carregados no `Program.cs`
7. Projeto atualizado para ASP.NET Core 2.2

# Item01 - Criando o Projeto IdentityServer4

PROBLEMA PRÁTICO : nosso projeto MVC não possui sistema de login
SOLUÇÃO PRÁTICA : criar um novo projeto para autenticar usuários
ABSTRAÇÃO DO PROBLEMA PRÁTICO EM TEORIA : o projeto MVC não possui sistema de autenticação e autorização para os pontos de acesso
ABSTRAÇÃO DA SOLUÇÃO EM TEORIA : criar um projeto STS (Security Token Server) utilizando IdentityServer4

## Introdução

Nesta parte 3 do curso, iremos utilizar um sistema de login e garantir que nossa aplicação seja acessada apenas por usuários autenticados.

Também vamos utilizar nossa web app em conjunto com um novo projeto web api simples.

Se você só precisa de uma tabela de usuários com recursos de login de senha e um perfil de usuário, então **ASP.NET Identity** é a melhor opção para você.

A Alura já possui os cursos abaixo, que utilizam ASP.NET Identity para deixar suas aplicações seguras:

**PARA SABER MAIS (INCLUIR COMO SLIDES E COMO ATIVIDADE NA PLATAFORMA):**

![Curso Identity1](CursoIdentity1.png)

* **ASP.NET Identity parte 1: Gerencie contas de usuários**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt1)

![Curso Identity2](CursoIdentity2.png)

* **ASP.NET Identity parte 2: Autenticação, segurança com lockout**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt2)

![Curso Identity3](CursoIdentity3.png)

* **ASP.NET Identity parte 3: Autorização, autenticação externa com redes sociais**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt3)

![Curso Identity4](CursoIdentity4.png)

* **ASP.NET Identity parte 4: Autenticação mais segura com 2 fatores**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt4)

Entretanto, se você tiver múltiplos clientes, que precisam acessar diferentes web APIs, você poderá utilizar um **servidor de token de segurança (STS)** para proteger e validar tokens de identidade e acesso entre os serviços.

Por esse motivo, iremos utilizar IdentityServer4 como uma **autoridade externa de login**. Dessa forma, a mesma autenticação e autorização funcionarão tanto para a web app quanto para as web apis.

![](https://openid.net/wordpress-content/uploads/2014/09/openid-r-logo-900x360.png)

Algumas características do **IdentityServer4** são:


![Topologia](topologia.png)


- **Autenticação como serviço**:
Lógica de login e fluxo de trabalho centralizados para todos os seus aplicativos (web, nativo, móvel, serviços). O IdentityServer é uma implementação oficialmente certificada do OpenID Connect.

![Singlesignon](singlesignon.png)

- **Single Sign-on / Sign-out**:
Logon e logout único em vários tipos de aplicativos.

![Controledeacessoapis](controledeacessoapis.png)
- **Controle de acesso para APIs**:
Emitir tokens de acesso para APIs para vários tipos de clientes, por exemplo servidor para servidor, aplicativos da Web, SPAs e aplicativos nativos / móveis.

![Gatewayfederacao](gatewayfederacao.png)

- **Gateway de Federação**:
Suporte para provedores de identidade externos, como o Azure Active Directory, o Google, o Facebook, etc. Isso protege seus aplicativos dos detalhes de como conectar-se a esses provedores externos.

![Personalizacao](personalizacao.png)

- **Foco na personalização**:
A parte mais importante - muitos aspectos do IdentityServer podem ser personalizados para atender às suas necessidades. Como o IdentityServer é uma estrutura e não um produto em caixa ou um SaaS, você pode escrever código para adaptar o sistema da maneira que fizer sentido para seus cenários.

![Opensource](opensource.png)

- **Open Source Maduro**:
O IdentityServer usa a licença permissiva do Apache 2, que permite criar produtos comerciais sobre ela. Também faz parte da Fundação .NET, que fornece governança e suporte legal.

## O Novo Projeto CasaDoCodigo.Identity

Os passos abaixo são necessários para criar um novo projeto **IdentityServer4**:

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

> O modelo "IdentityServer4 with ASP.NET Core Identity" foi criado com êxito.
>
> Processando ações de pós-criação...
O modelo está configurado para executar a seguinte ação:
Descrição:
Instruções manuais: Seeds the initial user database
Comando real: dotnet run /seed
Deseja executar esta ação (S|N)?
Y
Executando o comando 'dotnet run /seed'...
O comando foi bem-sucedido.

- Adicionar o novo projeto à solução, na pasta Item01

- Mudar o endereço do projeto Identity para http://localhost:5000

- Mudar o endereço do projeto MVC para http://localhost:5001

- Mudar o nome do projeto MVC para CasaDoCodigo.MVC

- Definir 2 projetos iniciais: \Item01\CasaDoCodigo e \Item01\CasaDoCodigo.Identity.

- Executar os 2 projetos

- Fazer login como **Alice Smith** e **Bob Smith**

![Formulariologin](formulariologin.png)

Uma vez logado, o usuário visualiza seu nome no topo da página.

![Username](username.png)

Aqui, ele pode fazer o logout, como podemos ver:

![Logoutmenu](logoutmenu.png)


# Item02 - Autorizando o Cliente MVC

PROBLEMA PRÁTICO : Nosso projeto MVC não se comunica com o projeto Identity
SOLUÇÃO PRÁTICA : Fazer configuração para integrar os dois projetos
ABSTRAÇÃO DO PROBLEMA PRÁTICO EM TEORIA : As duas aplicações estão isoladas. Precisamos fazer a troca de informações entre o projeto MVC e o Identity
ABSTRAÇÃO DA SOLUÇÃO EM TEORIA : Configurar tanto no MVC quanto no IdentityServer os pontos de acesso, tipos de tokens, grants, claims, etc. que vão ser compartilhados

## Protegendo recursos

Agora que temos o projeto Identity, começaremos a proteger nosso projeto MVC contra acesso não-autenticado.
Com isso, garantiremos que somente usuários que entraram com login e senha válidos possam ter acesso a recursos protegidos do sistema.

Mas quais recursos deverão ser protegidos?

|Action|Protegido?|
|--|--|
|Carrossel|NÃO|
|BuscaProdutos|NÃO|
|Carrinho|SIM|
|Cadastro|SIM|
|Resumo|SIM|
|UpdateQuantidade|SIM|

Note que tanto a Carrossel e BuscaProdutos ficarão desprotegidos.
Por quê? Queremos permitir que usuários possam navegar pela busca de produtos do site livremente, sem obrigá-los a fazer login com a senha.
Já os outros actions são todas protegidas, pois envolvem a manipulação de pedidos, que só podem ser feito por clientes.

Como protegeremos esses recursos? Devemos marcar cada action com um atributo de autorização:

```csharp
[Authorize]
public async Task<IActionResult> Carrinho(string codigo)
```

> O atributo `[Authorize]` especifica que o acesso a um controlador ou método de ação é restrito a usuários que atendem ao requisito de autorização.

Agora que marcamos a autorização, rodamos a solução...

A página inicial da aplicação é a busca de produtos, como podemos ver,
que é acessada pela action `BuscaProdutos`. Note que não exigimos autorização nessa action.

![Buscaprodutos](buscaprodutos.png)

Agora vamos clicar para adicionar um produto qualquer...

> An unhandled exception occurred while processing the request.
InvalidOperationException: No authenticationScheme was specified, and there was no DefaultChallengeScheme found.
Microsoft.AspNetCore.Authentication.AuthenticationService+<ChallengeAsync>d__11.MoveNext()

Por que recebemos esse erro? 

Até agora, só dissemos quais actions são autorizadas, porém não definimos o **esquema de autenticação**. 

Lembre-se de que a action que estamos tentando acessar, `Carrinho`, é protegida pelo atributo `[Authorize]`.

Vamos fazer isso agora. Mas antes, precisamos entender os papéis desempenhados por cada
componente nesta arquitetura.

Como vemos na imagem abaixo, o projeto com **IdentityServer4**
pode ser usado pelos clientes e outros serviços, para garantir a segurança 
de um sistema.

**Clientes**: app móvel, web app, single page application, etc.
que exige que o usuário seja autenticado para acessar determinados recursos.
**IdentityServer4**: servidor de token de segurança. Possui a view para login do usuário. 
**Relatório Web API**: serviço restrito, que só pode ser acessado por usuários autenticados.

![Client S T S Web A P I](Client_STS_WebAPI.png)

O projeto **IdentityServer4** possui um arquivo `Config.cs`, onde podemos configurar os **clientes**, **apis** e **recursos** usados no fluxo de autenticação/autorização.

Vamos modificar somente o **cliente ** para definir o id e nome do cliente (projeto CasaDoCódigo.MVC)

**arquivo Config.cs (CasaDoCodigo.Identity)**
```csharp
// MVC client using hybrid flow
new Client
{
    ClientId = "CasaDoCodigo.MVC",
    ClientName = "Casa do Código MVC",
```

Essa área define quais são os clientes autorizados pelo projeto IdentityServer4.

Agora precisamos modificar o projeto MVC para habilitar autenticação.

Podemos dizer que o serviço de autenticação é um **middleware**.

> O middleware é um software que fornece serviços para aplicações além das já são oferecidas pelo sistema operacional.

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

Os métodos `AddAuthorization` e `UseAuthentication` acrescentam o **middleware** de autorização e autenticação no **pipeline** da aplicação web.

Agora também precisamos adicionar o **esquema de autenticação**. 

Esse esquema necessita de 2 informações:

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

Agora precisamos dizer ao ASP.NET Core para utilizar **cookies** durante a autenticação:

```csharp
.AddCookie();
```

A seguir, vamos configurar o sistema de identificação **OpenId** :

- **SignInScheme**: o esquema para fazer o login (por cookies)
- **Authority**: a "autoridade", ou seja, o endereço do serviço do IdentityServer
- **ClientId**: o Id do cliente (CasaDoCodigo.MVC)
- **ClientSecret**: o segredo da autenticação (usamos o mesmo do serviço identity)
- **ResponseType**: precisa requisitar um código de autorização e um token de identidade
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

Agora que fizemos a configuração do cliente de autenticação, rodamos a solução novamente...

![Buscaprodutos](buscaprodutos.png)

Como sabemos, a action `BuscaProdutos` não é protegida por autorização.

Agora tentaremos adicionar um produto ao carrinho.

Isso nos levará para o endereço do serviço STS (IdentityServer4):

![Formulariologin](formulariologin.png)

Neste momento, podemos fazer login com 2 usuários predeterminados:

- **login**: alice, **senha**: Pass123$
- **login**: bob, **senha**: Pass123$

Ao aceitarmos o login, a aplicação IdentityServer nos leva para uma 
outra view, onde o usuário pode visualizar as informações 
que são solicitadas pela aplicação CasaDoCodigo.MVC.

Aqui, ele tem a oportunidade de negar permissão a esse acesso.

![Requestingpermission](requestingpermission.png)

Ao conceder a permimissão, você é redirecionado de volta para
a aplicação cliente (CasaDoCodigo.MVC):

![Actionautorizada](actionautorizada.png)

Vamos dar uma olhada na aba "network" da aplicação cliente após o login:

![Cookies1](cookies1.png)
![Cookies2](cookies2.png)

Note como a aplicação está utilizando vários cookies.
Esses cookies são necessários para várias finalidades, como:

- token anti-falsificação
- "lembrar" quem é o usuário logado,
- quais são suas informações,
- data/hora de expiração, 
- sessão do IdentityServer, etc.

Na outra página, vamos dar uma olhada neste link, que exibirá os "grants", isto é,
as "concessões" que foram dadas à aplicação cliente:

![Linkgerenciargrants](linkgerenciargrants.png)

![Gerenciargrants](gerenciargrants.png)


Você pode facilmente interromper o uso dos seus dados pela aplicação, deslogando
na aplicação IdentityServer:

![Logoutbutton](logoutbutton.png)

![Deslogado](deslogado.png)

Agora vamos abrir novamente a aba "network" do navegador, para ver quais cookies estão sendo usados
pela aplicação cliente:

![Cookiesdeslogado](cookiesdeslogado.png)

Podemos notar que "sumiram" 3 cookies desde nossa última visita a essa aba:

- .AspNetCore.Cookies
- .AspNetCore.Identity.Application
- idsrv.session

Sem esses cookies, o mecanismo de autenticação considera que o usuário está "deslogado", portanto
da próxima vez que ele tentar acessar o carrinho, será solicitado um novo login.

Vamos dar uma olhada no caminho desde a página inicial a até a aplicação ser autenticada:

![Carrinhoautenticado](carrinhoautenticado.png)

# Item03 - Fluxo de Logout

PROBLEMA PRÁTICO : A aplicação MVC faz login mas não faz logout
SOLUÇÃO PRÁTICA : Configurar o logout da plataforma
ABSTRAÇÃO DO PROBLEMA PRÁTICO EM TEORIA : Uma vez conectado o usuário, o projeto MVC não possui as informações necessárias para desconectar o usuário e retornar para a página inicial
ABSTRAÇÃO DA SOLUÇÃO EM TEORIA : definir os tokens com as informações de nome de usuário, id, etc., a action de logout e também as urls de retorno.

## CasaDoCodigo.Identity

Neste ponto, o endereço do nosso cliente (CasaDoCodigo.MVC) está fixo
na configuração de clientes do projeto Identity:

```csharp
RedirectUris = { "http://localhost:5001/signin-oidc" },
FrontChannelLogoutUri = "http://localhost:5001/signout-oidc",
PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },
```

E você quiser, ou precisar mudar o endereço desse cliente? Você teria que alterar e recompilar o código.

Então é melhor deixar essa informação configurável.

Vamos adicionar uma configuração nova para o "endereço de retorno":

(arquivo appsettings.json)
```
"CallbackUrl": "http://localhost:5001"
```

Esse "CallbackUrl" é o endereço-base para o cliente MVC do IdentityServer

Agora é necessário modificar o código para injetar o parametro de url de callback:

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

Porém, quando rodamos a solução, não estamos vendo a informação do usuário logado:

![Usuariologadonaoaparece](usuariologadonaoaparece.png)

Por quê?

Primeiro, vamos fazer logout com a aplicação Identity.

Agora, vamos modificar o arquivo de layout do nosso site.

* A ideia aqui é: verificar se o usuário não está deslogado
(`!true.Equals(ViewData["signed-out"])`)
* Obter o claim (dado de usuário) contendo o nome

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

Agora também temos que exibir o dropdown para exibir o nome do usuário e permitir o logout:

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

Agora rodamos a aplicação e...

Percebemos que o nome do usuário logado ainda não aparece. Por quê?

Vamos inspecionar os claims do usuário no momento:

```csharp
Context.User.Claims.ToList()
Count = 4
    [0]: {sid: a7a7a086af6a1ae87c682638a80824c1}
    [1]: {http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier: 5f1aaf2e-3f22-467b-bd96-60a5cd4ec095}
    [2]: {http://schemas.microsoft.com/identity/claims/identityprovider: local}
    [3]: {http://schemas.microsoft.com/claims/authnmethodsreferences: pwd}
```

Veja que nenhum dos claims contém o nome do usuário. Isso acontece porque a aplicação
MVC precisa requisitar esses claims a partir do STS (Security Token Server) representado pelo nosso projeto IdentityServer.

Precisamos marcar esta opção na configuração do cliente:
```csharp
options.GetClaimsFromUserInfoEndpoint = true;
```

> Definição:
> A propriedade `GetClaimsFromUserInfoEndpoint` define se o manipulador 
deve ir até o endpoint de informações do usuário para recuperar declarações 
adicionais ou não após criar uma identidade a partir do id_token recebido do 
endpoint do token. O padrão é falso'.

IMPORTANTE: para essa alteração surtir efeito, precisamos:

1. deslogar o usuário
2. fazer o login novamente

Consultando novamente os claims do usuário, obtemos uma nova lista:

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

Agora sim, podemos ver como o nome do usuário aparece na barra superior

![Dropdownusuariologado](dropdownusuariologado.png)

Agora vamos clicar no botão logout:


![Logoutconfirmacao](logoutconfirmacao.png)

E assim nosso usuário é finalmente desconectado:

![Loggedout](loggedout.png)

Mas como voltamos para a aplicação MVC?

Na verdade, o projeto IdentityServer não foi instruído corretamente retornar para o cliente após a desconexão.

Vamos fazer essa configuração com a propriedade `SignedOutRedirectUri` :

```csharp
options.SignedOutRedirectUri = Configuration["CallbackUrl"];
```

> Definição:
> SignedOutRedirectUri
> O uri para o qual o agente do usuário será redirecionado depois que o aplicativo for desconectado do provedor de identidade. O redirecionamento ocorrerá depois que o SignedOutCallbackPath for chamado.

Mas rodando a aplicação novamente, não percebemos nenhuma mudança.

Na verdade, é necessário modificar mais uma propriedade:

```csharp
options.SaveTokens = true;
```

> Definição:
> Define se os tokens de acesso e atualização 
> devem ser armazenados no 
> Microsoft.AspNetCore.Http.Authentication.AuthenticationProperties após uma autorização 
> bem-sucedida. Essa propriedade é configurada como false por 
> padrão para reduzir o tamanho do cookie de autenticação final.

Agora percebemos que após a desconexão é sugerido um novo link para retorno à aplicação MVC (CallbackUrl):

![Linkcallbackurl](linkcallbackurl.png)

Podemos ainda fazer uma última configuração, para dispensar a confirmação do login, no momento de confirmar o usuário e senha:

![Requestingpermission](requestingpermission.png)

Basta modificar o arquivo Config.cs no projeto Identity:

```csharp
RequireConsent = false
```

# Item04 - Pedidos de Clientes

PROBLEMA PRÁTICO : Os pedidos não identificam o cliente
SOLUÇÃO PRÁTICA : adaptar o modelo da aplicação para acomodar o id do cliente que está logado
ABSTRAÇÃO DO PROBLEMA PRÁTICO EM TEORIA : Os pedidos não possuem o id do cliente que está logado e fazendo a compra
ABSTRAÇÃO DA SOLUÇÃO EM TEORIA : modificar o modelo, gerar a migração e adaptar repositórios e controllers

Lembra dos usuários alice e bob? Vamos abrir o banco de dados que está no projeto Identity, chamado AspIdUsers.db.

Esse arquivo é o banco de dados do SQLite.Vamos fazer um duplo clique, que nos levará para o programa DB Browser for SQLite:

Aqui, vamos navegar pelas tabelas de usuários e de dados pessoais de usuários (claims)

![Asp Net Users](AspNetUsers.png)

![Asp Net User Claims](AspNetUserClaims.png)

Como essas informações são criadas?

Isso é feito com a ajuda da classe SeedData do projeto IdentityServer.

Note como o `ApplicationUser` é criado e como os claims (dados pessoais) são adicionados ao usuário "Alice": 

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

Note também que essas informações foram criadas automaticamente
pelo template do IdentityServer4. 


Agora será necessário modificar o modelo, para que o pedido tenha a informação do usuário que fez a compra.


(arquivo Pedido.cs)
```csharp
[Required]
public string ClienteId { get; private set; }
```

Esse mesmo clienteId agora será exigido também no construtor, juntamente com o cadastro

```csharp
public Pedido(string clienteId, Cadastro cadastro)
{
    ClienteId = clienteId;
    Cadastro = cadastro;
}
```

Mas só modificar o modelo não é suficiente. Para aplicar as alterações no banco, vamos
criar uma nova migração:

```
PM> Add-Migration "Pedido_ClienteId"
```

Em seguida, aplicamos as alterações:

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

Agora vamos modificar nosso repositório de pedidos

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

E como esse clienteId será obtido?

Vamos mexer no PedidoController para criar um método que procura essa informação nos claims do usuário:

(arquivo PedidoController.cs)
```csharp
private string GetUserId()
{
    return @User.FindFirst("sub")?.Value;
}
```

Agora o GetUserId() será acessado pelos outros métodos do controller:

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

Depois de muitas alterações, vamos agora rodar a solução e ver se conseguimos gravar os pedidos com os ids dos usuários

![Pedido Cliente Id](Pedido_ClienteId.png)

![Tabela Cadastro](Tabela_Cadastro.png)

Como vimos, agora o ID do cliente está sendo gravado juntamente com os pedidos!

# Item05 - Autorizando WebAPI

PROBLEMA PRÁTICO : Permitir acesso autorizado a uma web api externa ao MVC
SOLUÇÃO PRÁTICA : Compartilhar com a nova web api as informações do usuário logado
ABSTRAÇÃO DO PROBLEMA PRÁTICO EM TEORIA : Uma nova web api externa não consegue identificar se o usuário está logado na aplicação MVC
ABSTRAÇÃO DA SOLUÇÃO EM TEORIA : criar uma configuração que inclua a web api na autorização do IdentityServer

Vamos começar criando um novo projeto Web API dentro da nossa solução:

O projeto se chamará CasaDoCodigo.Relatorio

![Newwebapi](newwebapi.png)

Agora vamos mudar o endereço do projeto Web API para http://localhost:5002

Vamos definir como projeto inicial e rodá-lo:

![Values](values.png)

Vamos modificar o ValuesController desse novo projeto para ler/gravar dados do relatório

Nosso relatório será muito simples: apenas uma lista de strings estática, em memória:

(arquivo ValuesController.cs)
```csharp
private static readonly List<string> Relatorio = new List<string>();
```

Agora modificamos a action Get() para retornar uma string, em vez de uma lista de strings.

```csharp
public ActionResult<string> Get()
```

A string retornada será construída com a ajuda de um `StringBuilder`

```csharp
StringBuilder sb = new StringBuilder();
foreach (var item in Relatorio)
{
    sb.AppendLine(item);
}
return sb.ToString();
```

Por outro lado, a gravação do relatório só exigirá a inclusão de uma string na lista Relatorio,
na action Post():

```csharp
public void PostAsync([FromBody] string value)
{
    Relatorio.Add(value);
}
```

Já as outras actions (Put, Delete) podem ser excluídas.

Vamos rodar novamente a web api

Para testar o relatório, precisamos rodar o programa Postman, para consumir a action Post:

![Primeiralinha](primeiralinha.png)

![Segundalinha](segundalinha.png)

![Relatorio2](relatorio2.png)

Cada linha do relatório representará os dados de um pedido da aplicação MVC.

Você deve aplicar as seguintes regras:

- Qualquer pessoa pode LER o relatório
- Somente os usuários autenticados poderão GRAVAR linhas no relatório

Para isso, vamos proteger o método `Post` com o atributo `[Authorize]`

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

Claro, porque precisamos configurar a autenticação da nossa web api.

Começamos criando a configuração da url do serviço Identity:

(arquivo appsettings.json)
```json
"IdentityUrl": "http://localhost:5000"
```

Agora precisamos instalar no web api o pacote `IdentityServer4.AccessTokenValidation`


```
PM> Install-Package IdentityServer4.AccessTokenValidation
```

Isso permitirá adicionar o código mais abaixo.

Na classe `Startup`, precisamos configurar a autenticação

Esse código precisa conter:


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

Já na aplicação MVC, vamos criar a configuração com o endereço do serviço de relatório

(arquivo appsettings.json)
```json
"RelatorioUrl": "http://localhost:5002"
```

Esse serviço vai ser acessado aom a ajuda de tokens de acesso, que precisam ser consultados no serviço do IdentityServer.


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

Rodando a aplicação web api, vamos testar novamente com o Postman, para tentar inserir uma linha no relatório.

![Postman401](postman401.png)

Vemos que desta vez o Postman falhou com o erro HTTP 401, indicando acesso não autorizado.

Vamos parar a aplicação e definir os 2 projetos (MVC e Relatorio) como iniciais.



