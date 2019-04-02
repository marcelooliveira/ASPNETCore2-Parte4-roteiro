## Exercícios

### Item01 - Criando o Projeto IdentityServer4

##### Exercício 1)
   
Quais afirmações abaixo são corretas sobre o ASP.NET Core Identity?

- (x) a. pode ser gerado facilmente por um novo "scaffolding" do projeto
Correto. O ASP.NET Core 2.1 e posterior permite realizar um "scaffolding", que fornece ASP.NET Core Identity como um biblioteca de classes Razor.
- (x) b. é efetivo quando você só precisa de um sistema de login simples
Correto. Se você só precisa de um controle de autenticação/autorização de usuários para uma aplicação, usar ASP.NET Core Identity é o mais adequado.
- ( ) c. funciona como uma autoridade externa para validar identidades
Incorreto. ASP.NET Core Identity não funciona como um projeto externo.
- ( ) d. permite que múltiplos clientes possam fazer login
Incorreto. O uso do ASP.NET Core Identity se limita à aplicação que a utiliza.
- ( ) e. é gerado a partir de um novo projeto exclusivo para serviço de usuários
Incorreto. Você utilizará o ASP.NET Core Identity no próprio projeto MVC.
- ( ) f. permite envolver e acessar várias Web APIs do seu sistema, de forma segura
Incorreto. As  Web APIs não terão como reconhecer o usuário autenticado.
- ( ) g. Autenticação como serviço
Incorreto. Com ASP.NET Core Identity, você não terá autenticação como serviço.
- ( ) h. Single Sign-on / Sign-out
Incorreto. ASP.NET Core Identity não permite autenticação centralizada de vários serviços, necessária para realizar Single Sign-on


##### Exercício 2)
   
Quais afirmações abaixo são corretas sobre o IdentityServer?

- ( ) a. pode ser gerado facilmente por um novo "scaffolding" de projeto cliente MVC
Incorreto. IdentityServer precisa ser gerado como um projeto separado do seu projeto cliente MVC.
- ( ) b. é efetivo quando você só precisa de um sistema de login simples
Incorreto. A configuração do IdentityServer é mais complexa, e precisa de modificações tanto no projeto IdentityServer, cliente MVC como também nas Web APIs envolvidas.
- (x) c. funciona como uma autoridade externa para validar identidades
Correto. IdentityServer dá suporte para provedores de identidade externos, como o Azure Active Directory, o Google, o Facebook, etc. Isso protege seus aplicativos dos detalhes de como conectar-se a esses provedores externos.
- (x) d. permite que múltiplos clientes possam fazer login
Correto. IdentityServer permite que vários clientes possam utilizar o serviço do IdentityServer para se autenticarem e compartilharem credenciais do usuário conectado.
- (x) e. é gerado a partir de um novo projeto exclusivo para serviço de usuários
Correto. Você introduz o IdentityServer na sua solução criando um novo projeto com template IdentityServer.
- (x) f. permite envolver e acessar várias APIs do seu sistema, de forma segura
Correto. O IdentityServer emite tokens de acesso para APIs para vários tipos de clientes, por exemplo servidor para servidor, aplicativos da Web, SPAs e aplicativos nativos / móveis.
- (x) g. Autenticação como serviço
Correto. IdentityServer fornece lógica de login e fluxo de trabalho centralizados para todos os seus aplicativos (web, nativo, móvel, serviços). O IdentityServer é uma implementação oficialmente certificada do OpenID Connect.
- (x) h. Single Sign-on / Sign-out
Correto. IdentityServer fornece um ponto central para que um usuário possa usar diversas aplicações e fazer login e logout apenas uma vez.

##### Exercício 3)
   
Como adicionar funcionalidades do ASP.NET Core Identity num projeto preexistente?

1. Clicar sobre o projeto e selecionar `Add New Scaffolded Item > Identity > Identity`
2. Selecionar a página de layout, views de Identity, classe de contexto, tipo de banco de dados e classe de usuário
3. Incluir uma partial view para o login do usuário
4. `Add-Migration Usuarios -context CasaDoCodigoContext`
5. rodar o comando: `Update-Database -context CasaDoCodigoContext`
6. `app.UseAuthentication();`

##### Exercício 4)
   
Como criar um projeto STS com IdentityServer?

- (x) a. Abrir Developer Command Prompt for VS 2017
- (x) b. No diretório da solução, criar um novo diretório para o projeto Iden
- (x) c. Instalar templates IdentityServer4 `dotnet new -i identityserver4.templates`
- (x) d. Criar novo projeto ASP.NET Identity for user management: `dotnet new is4aspid`
- (x) e. Fazer o "seeding" (alimentar) o banco de dados de usuário
- (x) f. Adicionar o novo projeto IdentityServer à solução
- (x) g. Definir os 2 projetos como iniciais (Startup Projects)

### Item02 - Autorizando o Cliente MVC

##### Exercício 1)
   
Você está desenvolvendo uma aplicação que já utiliza autenticação/autorização. O que acontece quando um usuário desconectado tenta acessar uma view através de uma action protegida num controller da sua aplicação?

- (x) a. O usuário é redirecionado para a página de login
- ( ) b. O usuário é redirecionado para a página de logout
- ( ) c. O usuário consegue acessar a action normalmente
- ( ) d. Ocorre uma exceção de AuthenticationException

##### Exercício 2)
   
Como as declarações do usuário (claims) são trocadas entre o IdentityServer e a aplicação MVC?

- (x) a. A aplicação MVC faz um redirecionamento para a uma view de login da aplicação IdentityServer, onde o usuário realiza o login. Após a autenticação, o usuário é redirecionado de volta para a aplicação MVC com os cookies contendo o token JWT com as declarações do usuário (claims).
- ( ) b. A aplicação MVC faz uma chamada HTTP via AJAX (JavaScript), enviando login e senha para a aplicação IdentityServer, onde o usuário é autenticado. A chamada AJAX retorna o token JWT com as declarações do usuário (claims). 
- ( ) c. A aplicação MVC faz uma chamada POST usando um objeto HttpClient, passando login e senha para uma action da aplicação IdentityServer, onde o usuário é autenticado. A chamada assíncrona retorna o token JWT com as declarações do usuário (claims).
- ( ) d. A aplicação MVC faz uma chamada GET usando um objeto HttpClient, passando login e senha para uma action da aplicação IdentityServer, onde o usuário é autenticado. A chamada assíncrona retorna o token JWT com as declarações do usuário (claims). 

##### Exercício 3)
   
Quais actions devem ser protegidas?

Você está desenvolvendo uma aplicação de comércio eletrônico.

Você quer permitir que usuários possam pesquisar produtos do site livremente, sem obrigá-los a fazer autenticação com login com a senha.
Porém, a manipulação de pedidos deve ser feita somente por usuários devidamente autorizados.

Quais actions de controller da aplicação devem ser protegidos pelo atributo `[Authorize]`?

- (x) a. Carrinho
- (x) b. Cadastro
- (x) c. Resumo
- (x) d. UpdateQuantidade
- ( ) e. Carrossel
- ( ) f. BuscaProdutos
 
### Item03 - Fluxo de Logout

##### Exercício 1)
   
Você está tentando exibir o nome do usuário conectado nas views da aplicação cliente MVC.
Para isso, você adiciona as seguintes linhas ao arquivo `_layout.cshtml`:

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

Entretanto, ao consultar as declarações do usuário (claims), você nota que está faltando a declaração (claim) com o nome do usuário:

```csharp
Context.User.Claims.ToList()
Count = 4
    [0]: {sid: a7a7a086af6a1ae87c682638a80824c1}
    [1]: {http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier: 5f1aaf2e-3f22-467b-bd96-60a5cd4ec095}
    [2]: {http://schemas.microsoft.com/identity/claims/identityprovider: local}
    [3]: {http://schemas.microsoft.com/claims/authnmethodsreferences: pwd}
```

O que você precisa fazer para que a claim com o nome do usuário esteja presente nessa lista?

a. 
Adicionar esta opção na configuração do cliente MVC:
```csharp
options.GetClaimsFromUserInfoEndpoint = true;
```
Correto. A propriedade `GetClaimsFromUserInfoEndpoint` define se o manipulador 
deve ir até o endpoint de informações do usuário para recuperar declarações 
adicionais ou não após criar uma identidade a partir do id_token recebido do 
endpoint do token. O padrão é falso'.

b. 
Adicionar esta opção na configuração do servidor IdentityServer:
```csharp
options.GetClaimsFromUserInfoEndpoint = true;
```
Incorreto. Essa configuração não deve ser feita no servidor IdentityServer.

c. 
Adicionar esta opção na configuração do cliente MVC:
```csharp
options.SaveTokens = true;
```
Incorreto. `SaveTokens` apenas define se os tokens de acesso devem ser armazenados nas propriedades de autenticação após uma autorização bem-sucedida.

d. 
Adicionar esta opção na configuração do servidor IdentityServer:
```csharp
options.SaveTokens = true;
```
Incorreto. `SaveTokens` apenas define se os tokens de acesso devem ser armazenados nas propriedades de autenticação após uma autorização bem-sucedida.

##### Exercício 2)
   
Você precisa programar uma action em um controller para desconectar o usuário logado numa aplicação cliente que trabalha com IdentityServer.

Escolha o código adequado para implementar essa action:

a. 
```csharp
[Authorize]
public async Task Logout()
{
    await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
}
```
Correto. O método `HttpContext.SignOutAsync` nessas duas linhas exclui os cookies usadosna autenticação.  Isso efetivamente desconecta o usuário, forçando-o a um novo login da próxima vez que ele tentar acessar um recurso protegido.

b. 
```csharp
[Authorize]
public IActionResult Logout()
{
    return View("LoggedOut", vm);
}
```
Incorreto. Esse código apenas irá redirecionar o usuário para uma outra view, sem efetivamente desconectá-lo.

c. 
```csharp
[Authorize]
public async Task Logout()
{
    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme);
}
```
Incorreto. Precisamos fazer um sign-out, não um sign-in.


### Item04 - Pedidos de Clientes

##### Exercício 1)
  
O que é JWT?

- (x) a. Os JSON Web Tokens são um padrão aberto da indústria para representar declarações do usuário (claims) com segurança entre duas partes.
Correto. Usamos esse padrão nos projetos ASP.NET Core para transmitir claims entre aplicações MVC, IdentityServer e Web API.
- ( ) b. Os JSON Web Tokens são um padrão proprietário criado pela Microsoft para representar declarações do usuário (claims) com segurança entre duas partes.
Incorreto. JWTs não são padrão proprietário.
- ( ) c. Os JSON Web Tokens são um padrão aberto da indústria para realizar chamadas AJAX com segurança entre duas partes.
Incorreto. É possível utilizar tokens JWT com AJAX, mas eles não limitados a requisições AJAX.
- ( ) d. Os JSON Web Tokens são um padrão proprietário criado pela Microsoft para realizar chamadas AJAX com segurança entre duas partes.
Incorreto. JWTs não são padrão proprietário, e além disso é possível utilizar tokens JWT com AJAX, mas eles não limitados a requisições AJAX.

##### Exercício 2)
   
Selecione abaixo quais são exemplos de claims existentes em um JWT (Jason Web Token):

- (x) a. Nome do cliente
Correto. O nome do cliente é um atributo do cliente que poderia ser transmitido através de um token JWT.
- (x) b. CPF do cliente
Correto. O CPF do cliente é um atributo do cliente que poderia ser transmitido através de um token JWT.
- (x) c. Data de nascimento do cliente
Correto. A data de nascimento do cliente é um atributo do cliente que poderia ser transmitido através de um token JWT.
- ( ) d. Cookies
Incorreto. Cookies não são claims (declarações do usuário). Eles são arquivos transmitidos junto com requisições web e nas respostas a essas requisições.
- ( ) e. Jason Web Tokens
Incorreto. Jason Web Tokens não são claims (declarações do usuário), mas sim um padrão de transmissão de claims.
- ( ) f. Endereço do servidor IdentityServer
Incorreto. O endereço do servidor IdentityServer não é uma informação do usuário.

##### Exercício 3)
   
Você está usando uma aplicação ASP.NET Core em conjunto com autenticação via IdentityServer.
Você verifica que o usuário está devidamente autenticado, porém a claim "sub" não está aparecendo na lista de claims do usuário na aplicação cliente MVC.
O que fazer?

- (x) a. Eliminar o mapeamento de claims na aplicação MVC, com a linha de código: `JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();`
Correto. O ASP.NET Core converte por padrão a claim "sub" para outro nome: "nameidentifier". É necessário eliminar esse mapeamento para se obter o claim "sub".
- ( ) b. Criar uma nova claim "sub" na aplicação IdentityServer, com a linha de código: `var Sub = System.Guid.NewGuid();`
Incorreto. Não se deve criar uma nova claim "sub" na aplicação IdentityServer, pois ela já está criada.
- ( ) c. Criar uma nova claim "sub" na aplicação cliente MVC, com a linha de código: `var Sub = System.Guid.NewGuid();`
Incorreto. Não se deve criar uma nova claim "sub" na aplicação IdentityServer, pois ela já está criada.

### Item05 - Autorizando WebAPI

##### Exercício 1)
   
Como envolver um novo projeto Web API no processo de autorização?

- (x) a. Proteger uma ou mais actions do novo projeto Web API com o atributo `[Authorize]`
Correto. O atributo `[Authorize]` especifica que o acesso a um controlador ou método de ação é restrito a usuários que atendem ao requisito de autorização.
- (x) b. Instalar no projeto Web API o pacote `IdentityServer4.AccessTokenValidation`
Correto. Esse pacote permite adicionar autenticação com o método de extensão `AddIdentityServerAuthentication`.
- (x) c. Configurar autenticação na classe Startup do projeto Web API 
Correto. A autenticação da Web API precisa ser configurada, passando código da API, segredo e url da autoridade (servidor IdentityServer).
- (x) d. Configurar o novo projeto Web API como ApiResource e escopo no projeto IdentityServer
Correto. O projeto IdentityServer deve ser configurado para que ele reconheça e permita acesso à Web API.
- ( ) e. Proteger uma ou mais actions do novo projeto Web API com o atributo `[Authenticate]`
Incorreto. Não existe um atributo `AuthenticateAttribute` para permitir ou restringir acesso a métodos da aplicaçãpo.
- ( ) f. Instalar no projeto MVC o pacote `IdentityServer4.AccessTokenValidation`
Incorreto. Esse pacote não deve ser instalado na aplicação cliente MVC.
- ( ) g. Configurar autenticação na classe Startup do projeto IdentityServer
Incorreto. Não se deve modificar a autenticação no projeto Startup apenas para acomodar uma nova Web API.
- ( ) h. Configurar o novo projeto Web API como Client no projeto IdentityServer
Incorreto. Um Web API não deve ser configurado como cliente.

##### Exercício 2)
   
Qual configuração de autenticação da Web API é correta?

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
Correto. Você precisa configurar a autenticação usando IdentityServer, passando como dados o id e nome da Web API, e também a Url do servidor IdentityServer, que é a autoridade da autenticação.

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
Incorreto. Você não pode configurar dados do cliente, pois está configurando uma Web API.

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
Incorreto. Essa configuração é criada pelo template do projeto IdentityServer, e não deve ser usada na sua Web API.

##### Exercício 3)
   
Como fazer chamadas autorizadas HTTP Post ao serviço Web API a partir da aplicação cliente MVC?

- (x) a.
1. Criar uma nova instância de `HttpClient` com o `HttpClientFactory`
2. Solicitar o access token à aplicação IdentityServer
3. Definir o header de autorização do `HttpClient` com o access token
4. Fazer uma requisição POST usando o `HttpClient`
Correto. É necessário requisitar o access token ao serviço IdentityServer e passá-lo no cabeçalho da requisição feita ao serviço Web API.

- ( ) b.
1. Criar uma nova instância de `HttpClient` com o `HttpClientFactory`
2. Enviar o login e senha do usuário à aplicação IdentityServer
3. Definir o header de autorização do `HttpClient` com o login e senha do usuário
4. Fazer uma requisição POST usando o `HttpClient`
Incorreto. Com IdentityServer você não envia login e senha da aplicação cliente para o IdentityServer, nem envia login e senha para o serviço Web API.

- ( ) c.
1. Criar uma nova instância de `HttpClient` com o `HttpClientFactory`
2. Enviar o login e senha do usuário à aplicação IdentityServer e receber de volta um access token
3. Definir o header de autorização do `HttpClient` com o access token
4. Fazer uma requisição POST usando o `HttpClient`
Incorreto. Com IdentityServer você não envia usuário e senha da aplicação cliente para o IdentityServer.

- ( ) d.
1. Criar uma nova instância de `HttpClient` com o `HttpClientFactory`
2. Enviar o access token à aplicação IdentityServer e receber de volta o login e a senha do usuário
3. Definir o header de autorização do `HttpClient` com o login e senha do usuário
4. Fazer uma requisição POST usando o `HttpClient`
Incorreto. Com IdentityServer você não envia login e senha para o serviço Web API.




