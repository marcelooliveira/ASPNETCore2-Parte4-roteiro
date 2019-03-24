# Da Parte 2 para a Parte 3: diferen�as

Come�amos a parte 3 deste curso com o c�digo que usamos no final �ltimo curso,
**ASP.NET Core parte 2: Um e-Commerce com MVC e EF Core** (https://cursos.alura.com.br/course/aspnet-core-2-validacoes-seguranca)

Por�m, algumas altera��es e atualiza��es foram necess�rias.

**Melhorias**:
1. Todos os m�todos de bancos de dados ou E/S agora s�o ass�ncronos
2. Nova view de busca de produtos
3. O modelo agora tem categorias de Produtos
4. Arquivo `models.cs` foi quebrado em v�rios arquivos, um para cada entidade
5. Reposit�rios foram simplificados: `CategoriaRepository` foi para `ProdutoRepository` e `ItemPedidoRepository` foi para `PedidoRepository`.
6. Fizemos a atualiza��o dos pacotes para ASP.NET Core 2.2

# Item01 - Criando o Projeto IdentityServer4

## Introdu��o

Nesta parte 3 do curso, iremos utilizar um sistema de login e garantir que nossa aplica��o seja acessada apenas por usu�rios autenticados.

Tamb�m vamos utilizar nossa web app em conjunto com um novo projeto web api simples.

Se voc� s� precisa de uma tabela de usu�rios com recursos de login de senha e um perfil de usu�rio, ent�o ASP.NET Identity � perfeito.

A Alura j� possui os cursos abaixo, que utilizam ASP.NET Identity para deixar suas aplica��es seguras:

* **ASP.NET Identity parte 1: Gerencie contas de usu�rios**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt1)

* **ASP.NET Identity parte 2: Autentica��o, seguran�a com lockout**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt2)

* **ASP.NET Identity parte 3: Autoriza��o, autentica��o externa com redes sociais**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt3)

* **ASP.NET Identity parte 4: Autentica��o mais segura com 2 fatores**
(https://www.alura.com.br/curso-online-csharp-aspnet-identity-pt4)

Entretanto, se sua web app precisa acessar web APIs, voc� poder� utilizar uma autoridade independente para proteger e validar tokens de identidade e acesso entre os servi�os.

Por esse motivo, iremos utilizar IdentityServer4 como uma **autoridade externa de login**. Dessa forma, a mesma autentica��o e autoriza��o funcionar�o tanto para a web app quanto para as web apis.

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

- Mudar o endere�o para http://localhost:5000

- Definir 2 projetos iniciais: \Item01\CasaDoCodigo e \Item01\CasaDoCodigo.Identity.

- Executar os 2 projetos

- Fazer login como Alice Smith e Bob Smith

# Item02 - Autorizando o Cliente MVC

```csharp
public static class Config
{
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        return new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
        };
    }

    public static IEnumerable<ApiResource> GetApis()
    {
        return new ApiResource[]
        {
            new ApiResource("api1", "My API #1")
        };
    }

    public static IEnumerable<Client> GetClients()
    {
        return new[]
        {
            // client credentials flow client
            new Client
            {
                ClientId = "client",
                ClientName = "Client Credentials Client",

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("511536EF-F270-4058-80CA-1C89C192F69A".Sha256()) },

                AllowedScopes = { "api1" }
            },

            // MVC client using hybrid flow
            new Client
            {
                ClientId = "mvc",
                ClientName = "MVC Client",

                AllowedGrantTypes = GrantTypes.HybridAndClientCredentials,
                ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                RedirectUris = { "http://localhost:5001/signin-oidc" },
                FrontChannelLogoutUri = "http://localhost:5001/signout-oidc",
                PostLogoutRedirectUris = { "http://localhost:5001/signout-callback-oidc" },

                AllowOfflineAccess = true,
                AllowedScopes = { "openid", "profile", "api1" }
            },

            // SPA client using implicit flow
            new Client
            {
                ClientId = "spa",
                ClientName = "SPA Client",
                ClientUri = "http://identityserver.io",

                AllowedGrantTypes = GrantTypes.Implicit,
                AllowAccessTokensViaBrowser = true,

                RedirectUris =
                {
                    "http://localhost:5002/index.html",
                    "http://localhost:5002/callback.html",
                    "http://localhost:5002/silent.html",
                    "http://localhost:5002/popup.html",
                },

                PostLogoutRedirectUris = { "http://localhost:5002/index.html" },
                AllowedCorsOrigins = { "http://localhost:5002" },

                AllowedScopes = { "openid", "profile", "api1" }
            }
        };
    }
}
```


```csharp
public class Startup
{
    public IConfiguration Configuration { get; }
    public IHostingEnvironment Environment { get; }

    public Startup(IConfiguration configuration, IHostingEnvironment environment)
    {
        Configuration = configuration;
        Environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

        services.Configure<IISOptions>(iis =>
        {
            iis.AuthenticationDisplayName = "Windows";
            iis.AutomaticAuthentication = false;
        });

        var builder = services.AddIdentityServer(options =>
        {
            options.Events.RaiseErrorEvents = true;
            options.Events.RaiseInformationEvents = true;
            options.Events.RaiseFailureEvents = true;
            options.Events.RaiseSuccessEvents = true;
        })
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiResources(Config.GetApis())
            .AddInMemoryClients(Config.GetClients())
            .AddAspNetIdentity<ApplicationUser>();

        if (Environment.IsDevelopment())
        {
            builder.AddDeveloperSigningCredential();
        }
        else
        {
            throw new Exception("need to configure key material");
        }

        services.AddAuthentication()
            .AddGoogle(options =>
            {
                // register your IdentityServer with Google at https://console.developers.google.com
                // enable the Google+ API
                // set the redirect URI to http://localhost:5000/signin-google
                options.ClientId = "copy client ID from Google here";
                options.ClientSecret = "copy client secret from Google here";
            });
    }

    public void Configure(IApplicationBuilder app)
    {
        if (Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
        }

        app.UseStaticFiles();
        app.UseIdentityServer();
        app.UseMvcWithDefaultRoute();
    }
}

```

![Asp Net Users](AspNetUsers.png)

![Asp Net User Claims](AspNetUserClaims.png)



# Item03 - Fluxo de Logout

# Item04 - Pedidos de Clientes

# Item05 - Autorizando WebAPI

