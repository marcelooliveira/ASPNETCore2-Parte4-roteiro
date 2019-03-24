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

Se você só precisa de uma tabela de usuários com recursos de login de senha e um perfil de usuário, então ASP.NET Identity é perfeito.

Mas sua web app precisa acessar APIs, uma autoridade independente para proteger e validar tokens de identidade e acesso faz sentido.

Por esse motivo, iremos utilizar IdentityServer4 como uma **autoridade externa de login**. Dessa forma, a mesma autenticação e autorização funcionarão tanto para a web app quanto para as web apis.

## O Novo Projeto CasaDoCodigo.Identity

Copiar o projeto "CasaDoCodigo" da pasta **antes** para **Item01**

Abrir Developer Command Prompt for VS 2017

Ir para a pasta Item01:

```
cd **ASPNETCore2-Parte3\Item01**
```

Criar a pasta **CasaDoCodigo.Identity**

```
md CasaDoCodigo.Identity
```

Mudar para a pasta **CasaDoCodigo.Identity**

```
cd CasaDoCodigo.Identity
```

Instalar templates IdentityServer4

```
dotnet new -i identityserver4.templates
```

Criar novo projeto ASP.NET Identity for user management:


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

Adicionar o novo projeto à solução, na pasta Item01

Definir 2 projetos iniciais: \Item01\CasaDoCodigo e \Item01\CasaDoCodigo.Identity.



# Item02 - Autorizando o Cliente MVC

# Item03 - Fluxo de Logout

# Item04 - Pedidos de Clientes

# Item05 - Autorizando WebAPI

