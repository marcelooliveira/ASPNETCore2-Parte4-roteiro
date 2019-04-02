## Exercícios

### Item01 - Criando o Projeto IdentityServer4

##### Exercício 1)
   
Quais afirmações abaixo são corretas sobre o ASP.NET Core Identity?

- (x) a. pode ser gerado facilmente por um novo "scaffolding" do projeto
- (x) b. é efetivo quando você só precisa de um sistema de login simples
- ( ) c. funciona como uma autoridade externa para validar identidades
- ( ) d. permite que múltiplos clientes possam fazer login
- ( ) e. é gerado a partir de um novo projeto exclusivo para serviço de usuários
- ( ) f. permite envolver e acessar várias APIs do seu sistema, de forma segura
- ( ) g. Autenticação como serviço
- ( ) h. Single Sign-on / Sign-out
- ( ) i. Controle de acesso para APIs

##### Exercício 2)
   
Quais afirmações abaixo são corretas sobre o IdentityServer?

- ( ) a. pode ser gerado facilmente por um novo "scaffolding" do projeto
- ( ) b. é efetivo quando você só precisa de um sistema de login simples
- (x) c. funciona como uma autoridade externa para validar identidades
- (x) d. permite que múltiplos clientes possam fazer login
- (x) e. é gerado a partir de um novo projeto exclusivo para serviço de usuários
- (x) f. permite envolver e acessar várias APIs do seu sistema, de forma segura
- (x) g. Autenticação como serviço
- (x) h. Single Sign-on / Sign-out
- (x) i. Controle de acesso para APIs

##### Exercício 3)
   
Como adicionar funcionalidades do ASP.NET Core Identity num projeto preexistente?

- (x) a. Clicar sobre o projeto > Add New Scaffolded Item > Identity > Identity
- (x) b. Selecionar a página de layout, views de Identity, classe de contexto, tipo de banco de dados e classe de usuário
- (x) c. Incluir uma partial view para o login do usuário
- (x) d. Add-Migration Usuarios -context CasaDoCodigoContext
- (x) e. rodar o comando: Update-Database -context CasaDoCodigoContext
- (x) f. app.UseAuthentication();

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

b. 
Adicionar esta opção na configuração do servidor IdentityServer:
```csharp
options.GetClaimsFromUserInfoEndpoint = true;
```

c. 
Adicionar esta opção na configuração do cliente MVC:
```csharp
options.SaveTokens = true;
```

d. 
Adicionar esta opção na configuração do servidor IdentityServer:
```csharp
options.SaveTokens = true;
```

##### Exercício 2)
   
Por que as claims (declarações) do usuário logado não aparecem na aplicação MVC?

##### Exercício 3)
   
O que acontece quando o usuário conectado faz logout na tela de carrinho?
 
### Item04 - Pedidos de Clientes

##### Exercício 1)
   
Como obter o id do usuário autenticado?

##### Exercício 2)
   
O que é JWT?

- (x) a. Os JSON Web Tokens são um padrão aberto da indústria para representar declarações do usuário (claims) com segurança entre duas partes.
- ( ) b. Os JSON Web Tokens são um padrão proprietário criado pela Microsoft para representar declarações do usuário (claims) com segurança entre duas partes.
- ( ) c. Os JSON Web Tokens são um padrão aberto da indústria para realizar chamadas AJAX com segurança entre duas partes.
- ( ) d. Os JSON Web Tokens são um padrão proprietário criado pela Microsoft para realizar chamadas AJAX com segurança entre duas partes.

##### Exercício 3)
   
Selecione abaixo quais são exemplos de claims existentes em um JWT (Jason Web Token):

- (x) a. Nome do cliente
- (x) b. CPF do cliente
- (x) c. Data de nascimento do cliente
- ( ) d. Cookies
- ( ) e. Jason Web Tokens
- ( ) f. Endereço do servidor IdentityServer

##### Exercício 4)
   
Você está usando uma aplicação ASP.NET Core em conjunto com autenticação via IdentityServer.
Você verifica que o usuário está devidamente autenticado, porém a claim "sub" não está aparecendo na lista de claims do usuário na aplicação cliente MVC.
O que fazer?

- (x) a. Eliminar o mapeamento de claims na aplicação MVC, com a linha de código: `JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();`
- ( ) b. Criar uma nova claim "sub" na aplicação IdentityServer, com a linha de código: `var Sub = System.Guid.NewGuid();`
- ( ) c. Criar uma nova claim "sub" na aplicação cliente MVC, com a linha de código: `var Sub = System.Guid.NewGuid();`
- ( ) d. Eliminar o mapeamento de claims na aplicação IdentityServer, com a linha de código: `JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();`

### Item05 - Autorizando WebAPI

##### Exercício 1)
   
Como envolver um novo projeto Web API no processo de autorização?

- (x) a. Proteger uma ou mais actions do novo projeto Web API com o atributo `[Authorize]`
- (x) b. Instalar no projeto Web API o pacote `IdentityServer4.AccessTokenValidation`
- (x) c. Configurar autenticação na classe Startup do projeto Web API 
- (x) d. Configurar o novo projeto Web API como ApiResource e escopo no projeto IdentityServer
- ( ) e. Proteger uma ou mais actions do novo projeto Web API com o atributo `[Authenticate]`
- ( ) f. Instalar no projeto MVC o pacote `IdentityServer4.AccessTokenValidation`
- ( ) g. Configurar autenticação na classe Startup do projeto IdentityServer
- ( ) h. Configurar o novo projeto Web API como Client no projeto IdentityServer


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

##### Exercício 3)
   
Como fazer chamadas autorizadas HTTP Post ao serviço Web API a partir da aplicação cliente MVC?

- (x) a.
1. Criar uma nova instância de `HttpClient` com o `HttpClientFactory`
2. Solicitar o access token à aplicação IdentityServer
3. Definir o header de autorização do `HttpClient` com o access token
4. Fazer uma requisição POST usando o `HttpClient`

- ( ) b.
1. Criar uma nova instância de `HttpClient` com o `HttpClientFactory`
2. Enviar o login e senha do usuário à aplicação IdentityServer
3. Definir o header de autorização do `HttpClient` com o login e senha do usuário
4. Fazer uma requisição POST usando o `HttpClient`

- ( ) c.
1. Criar uma nova instância de `HttpClient` com o `HttpClientFactory`
2. Enviar o login e senha do usuário à aplicação IdentityServer e receber de volta um access token
3. Definir o header de autorização do `HttpClient` com o access token
4. Fazer uma requisição POST usando o `HttpClient`

- ( ) d.
1. Criar uma nova instância de `HttpClient` com o `HttpClientFactory`
2. Enviar o access token à aplicação IdentityServer e receber de volta o login e a senha do usuário
3. Definir o header de autorização do `HttpClient` com o login e senha do usuário
4. Fazer uma requisição POST usando o `HttpClient`


