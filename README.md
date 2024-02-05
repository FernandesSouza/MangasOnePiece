# MangasOnePiece

Backend de um site de leitura de mangás de One Piece


Os usuários podem acessar e ler qualquer mangá já lançado sem a necessidade de login.
Eles também podem se registrar para interagir com outros leitores e participar de debates.

O site possui um acesso de administrador para realizar operações CRUD completas nos mangás, facilitando a postagem de novos conteúdos e modificações.

[Atualização] --> Testes Unitários com xUnit

Autenticação JWT


Biblioteca de validação -> Fluent Validation


Biblioteca para auxílio do mapeamento das entidades -> AutoMapper

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Executando a Aplicação OnePiece com Docker

Este guia irá ajudá-lo a executar a aplicação OnePiece usando o Docker e o Dockerfile fornecido. Certifique-se de ter o Docker instalado em sua máquina antes de prosseguir.

Pré-requisitos

Docker instalado em sua máquina.

Passos
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 Clonar o Repositório
 
git clone <repository_url>

cd <cloned_repository_directory>

---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 Construir a Imagem Docker
   
Abra um terminal e navegue até o diretório que contém o Dockerfile.
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
docker build -t onepiece-app .

Este comando constrói uma imagem Docker chamada onepiece-app.
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
docker run -p 8080:80 -d onepiece-app

Este comando executa um contêiner Docker chamado onepiece-app em modo destacado, mapeando a porta 8080 em sua máquina local para a porta 80 dentro do contêiner.
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 Acessar a Aplicação
 
Abra seu navegador da web e acesse http://localhost:8080/swagger/index.html.

Você deverá ver a aplicação OnePiece em execução.
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Parando o Contêiner

Se precisar interromper o contêiner em execução, use o seguinte comando:

docker stop nome-container
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Removendo o Contêiner

Para remover o contêiner após interrompê-lo, use o seguinte comando:
docker rm onepiece-app
---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Removendo a Imagem


docker rmi onepiece-app
