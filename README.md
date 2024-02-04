# Aplicação de console com injeção de dependências

Aplicação de console para testar os serviços de injeção de dependência do .Net Core.
São realizadas diferentes injeções de dependências para diferentes escopos de um mesmo serviço.
Cada instância apresenta um Id único para ser identificada nos exemplos.

## Classes

* UnitOfWork: representa uma unidade de trabalho que manipula a conexão com o banco de dados e os repositórios. Recebe uma instância de DbSession e dos repositórios que manipula
* DbSession: representa a conexão com o banco de dados
* Repository<T>: manipula as operações que serão realizadas sobre uma tabela do banco de dados

## Logs

### AddScope

Para cada resolução de injeção de um tipo específico, é criada uma única instância por escopo. Para escopos diferentes, diferentes instâncias.

Como DbSession está configurado para *Scoped*, para cada resolução de injeção é utilizada a única instância criada para o escopo - IDs iguais.

**Escopo 1**

    DI service - AddScoped (all)
    Running ClientController
        UnitOfWorkId: 637e6
        DbSession: b68bb
        ClientRepository: 670e5 | DbSessionId: b68bb
        ProductRepository: f4218 | DbSessionId: b68bb
    finished ClientController

**Escopo 2**

    Running ClientController
        UnitOfWorkId: ce715
        DbSession: 7080e
        ClientRepository: 5d72a | DbSessionId: 7080e
        ProductRepository: 585b9 | DbSessionId: 7080e
    finished ClientController

### AddTransient

Para cada resolução de um tipo é criada uma instância diferente no mesmo escopo. Instâncias diferentes de um tipo específico no mesmo escopo.

Como o DbSession está configurado para *Transient*, para cada resolução de injeção é criada diferentes instâncias para o mesmo escopo - IDs diferentes.

**Escopo 1**

    Running ClientController
        UnitOfWorkId: ac959
        DbSession: 68e4e
        ClientRepository: 23260 | DbSessionId: 0eadb
        ProductRepository: 76f56 | DbSessionId: b4c60
    finished ClientController

**Escopo 2**

    Running ClientController
        UnitOfWorkId: 8d1b7
        DbSession: 72e83
        ClientRepository: b9027 | DbSessionId: 41db2
        ProductRepository: 267e1 | DbSessionId: 7bed0
    Finished ClientController

### AddSingleton

Para cada resolução de um tipo é criada uma única instância durante todo o ciclo de vida da aplicação. Em outras palavras, cria uma única instância que será compartilhada por todos os escopos de serviços da aplicação (escopo global).

Como o DbSession está configurado para *Singleton*, para cada resolução de injeção é utilizada uma única instância criada para todos os escopos da aplicação - Ids iguais.

**Escopo 1**

    Running ClientController
        UnitOfWorkId: 35865
        DbSession: 644ef
        ClientRepository: 8454d | DbSessionId: 644ef
        ProductRepository: b7dff | DbSessionId: 644ef
    Finished ClientController

**Escopo 2**

    Running ClientController
        UnitOfWorkId: 5e295
        DbSession: 644ef
        ClientRepository: 53a0c | DbSessionId: 644ef
        ProductRepository: 4da03 | DbSessionId: 644ef
    Finished ClientController