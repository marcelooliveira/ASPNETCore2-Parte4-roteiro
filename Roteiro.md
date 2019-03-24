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

Mas sua web app precisa acessar APIs, uma autoridade independente para proteger e validar tokens de identidade e acesso faz sentido.

Por esse motivo, iremos utilizar IdentityServer4 como uma **autoridade externa de login**. Dessa forma, a mesma autentica��o e autoriza��o funcionar�o tanto para a web app quanto para as web apis.

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

Adicionar o novo projeto � solu��o, na pasta Item01

Definir 2 projetos iniciais: \Item01\CasaDoCodigo e \Item01\CasaDoCodigo.Identity.



# Item02 - Autorizando o Cliente MVC

# Item03 - Fluxo de Logout

# Item04 - Pedidos de Clientes

# Item05 - Autorizando WebAPI

