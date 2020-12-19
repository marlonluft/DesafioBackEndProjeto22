# DesafioBackEndProjeto22
Teste técnico back-end para a empresa Projeto22

# Descrição:
Para o teste técnico, deve-se criar uma API (Web App) com as seguintes premissas:

- Um agendamento interno deve acessar a API do OpenWeather
( https://openweathermap.org/api ) a cada 15 minutos;
- As informações a serem recuperadas da API do OpenWeather são os valores
das temperaturas das seguintes capitais: São Paulo, Rio de Janeiro e
Florianópolis;
- Uma vez que os dados forem lidos, estes devem ser armazenados (em
memória ou no disco);
- Dentro do Web App, uma API em REST deve ser disponibilizada para a
consulta dos dados de temperatura armazenados;
- A API deve permitir a consulta passando os seguintes parâmetros
obrigatórios: Nome da(s) cidade(s), Data de Início e Data de Fim;

# Plataforma
A API deve estar pronta para rodar em qualquer plataforma e em uma máquina com
somente dotnet instalado, com o comando `dotnet run` e nada mais.
Pontos extras se entregar o projeto dentro de algum container!!

# Requisitos
- Seu código deve estar pronto para rodar
- O código deve usar C# em um projeto ASP NET ou ASP NET Core
- Você deve incluir testes de unidade
- Tome cuidado com segurança, resiliência e velocidade
- Tente não incluir artefatos de seu build local (se utilizar build), como por
exemplo, as bin, debug ou similar.

# Critérios de avaliação
A qualidade da solução é fundamental, assim será levado em consideração na hora
de avaliar as provas:
- Qualidade dos testes, praticamos TDD, portanto consideramos esse item
fundamental para a aprovação do candidato
- Arquitetura da solução: isolamento das camadas, injeção de dependências,
etc..

# Pontos Extras
- Disponibilize uma documentação da API com Swagger;
- Documente o que você achar necessário;
- Disponibilize o projeto dentro de um container;
