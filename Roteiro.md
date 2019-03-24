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

Definir 2 projetos iniciais: \Item01\CasaDoCodigo e \Item01\CasaDoCodigo.Identity:


