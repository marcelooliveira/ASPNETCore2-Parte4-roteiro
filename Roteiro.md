# Da Parte 2 para a Parte 3: diferenças

Começamos a parte 3 deste curso com o código que usamos no final último curso,
**ASP.NET Core parte 2: Um e-Commerce com MVC e EF Core** (https://cursos.alura.com.br/course/aspnet-core-2-validacoes-seguranca)

Porém, algumas alterações e atualizações foram necessárias.

**Melhorias**:
1. Todos os métodos de bancos de dados ou E/S agora são assíncronos
2. Nova view de busca de produtos
3. O modelo agora tem categorias de Produtos
4. Arquivo `models.cs` foi quebrado em vários arquivos, um para cada entidade
5. Repositórios foram simplificados: `CategoriaRepository` foi para `ProdutoRepository` e `ItemPedidoRepository` foi para `PedidoRepository`.
6. Fizemos a atualização dos pacotes para ASP.NET Core 2.2

# Item01 - Criando o Projeto IdentityServer4

## Introdução

Nesta parte 3 do curso, iremos utilizar um sistema de login e garantir que nossa aplicação seja acessada apenas por usuários autenticados.

Também vamos utilizar nossa web app em conjunto com um novo projeto web api simples.

Se você só precisa de uma tabela de usuários com recursos de login de senha e um perfil de usuário, então **ASP.NET Identity** é a melhor opção para você.

A Alura já possui os cursos abaixo, que utilizam ASP.NET Identity para deixar suas aplicações seguras:

* **ASP.NET Identity parte 1: Gerencie contas de usuários**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt1)

* **ASP.NET Identity parte 2: Autenticação, segurança com lockout**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt2)

* **ASP.NET Identity parte 3: Autorização, autenticação externa com redes sociais**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt3)

* **ASP.NET Identity parte 4: Autenticação mais segura com 2 fatores**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt4)

Entretanto, se você tiver múltiplos clientes, que precisam acessar diferentes web APIs, você poderá utilizar um **servidor de token de segurança (STS)** para proteger e validar tokens de identidade e acesso entre os serviços.

Por esse motivo, iremos utilizar IdentityServer4 como uma **autoridade externa de login**. Dessa forma, a mesma autenticação e autorização funcionarão tanto para a web app quanto para as web apis.

![](https://openid.net/wordpress-content/uploads/2014/09/openid-r-logo-900x360.png)

Algumas características do **IdentityServer4** são:

- **Autenticação como serviço**:
Lógica de login e fluxo de trabalho centralizados para todos os seus aplicativos (web, nativo, móvel, serviços). O IdentityServer é uma implementação oficialmente certificada do OpenID Connect.
- **Single Sign-on / Sign-out**:
Logon e logout único em vários tipos de aplicativos.
- **Controle de acesso para APIs**:
Emitir tokens de acesso para APIs para vários tipos de clientes, por exemplo servidor para servidor, aplicativos da Web, SPAs e aplicativos nativos / móveis.
- **Gateway de Federação**:
Suporte para provedores de identidade externos, como o Azure Active Directory, o Google, o Facebook, etc. Isso protege seus aplicativos dos detalhes de como conectar-se a esses provedores externos.
- **Foco na personalização**:
A parte mais importante - muitos aspectos do IdentityServer podem ser personalizados para atender às suas necessidades. Como o IdentityServer é uma estrutura e não um produto em caixa ou um SaaS, você pode escrever código para adaptar o sistema da maneira que fizer sentido para seus cenários.
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

# Item02 - Autorizando o Cliente MVC

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

> An unhandled exception occurred while processing the request.
InvalidOperationException: No authenticationScheme was specified, and there was no DefaultChallengeScheme found.
Microsoft.AspNetCore.Authentication.AuthenticationService+<ChallengeAsync>d__11.MoveNext()

Por que recebemos esse erro?

Até agora, só dissemos quais actions são autorizadas, porém não definimos o **esquema de autenticação**. 

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


![Asp Net Users](AspNetUsers.png)

![Asp Net User Claims](AspNetUserClaims.png)


# Item03 - Fluxo de Logout

# Item04 - Pedidos de Clientes

# Item05 - Autorizando WebAPI

