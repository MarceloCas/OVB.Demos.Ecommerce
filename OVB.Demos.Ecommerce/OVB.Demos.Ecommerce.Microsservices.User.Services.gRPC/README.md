# Serviço de comunicação gRPC (Framework)

`gRPC` é um framework open source criado pelo Google para procedimentos de chamada remota, sendo responsável pela nova geração do RPC (Remote Procedure Call). A ideia para o desenvolvimento do projeto é trazer a comunicação entre serviços muito mais performática, por isso foi adotada algumas medidas como:

## Linguagem de Definição de Interfaces (IDL)

Tal linguagem é utilizada por meio do Protocol Buffers (protobuf) e tem como responsabilidade apenas a declaração das propriedades e atributos entre as trocas de informações.

## HTTP 2