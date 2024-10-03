# Sistema de Biblioteca

Este projeto implementa um sistema de biblioteca em **C#** que permite a gestão de utilizadores e livros, além de possibilitar o empréstimo, reserva e devolução de livros. O sistema também possui a funcionalidade de gestão de penalidades para utilizadores que não devolvem os livros no tempo correto.

## Funcionalidades

### Utilizadores

#### Criar, editar e eliminar utilizadores:
O sistema permite a criação de dois tipos de utilizadores:

- **Utilizador Comum**: Pode emprestar até 3 livros e reservar até 5 livros.
- **Utilizador Especial**: Pode emprestar até 10 livros e tem um número ilimitado de reservas.

Todos os utilizadores têm as seguintes propriedades:

- **Id**
- **Nome**
- **Email**
- **Senha**
- **Lista de livros emprestados**
- **Lista de livros reservados**

#### Listar todos os utilizadores:
- Mostra todos os utilizadores registrados no sistema.

#### Listar a informação de um utilizador por Id:
- Exibe as informações detalhadas de um utilizador específico com base no seu Id.

### Livros

#### Criar, editar e eliminar livros:
O sistema permite a gestão de livros com as seguintes propriedades:

- **Id**
- **Nome**
- **Lista de Autores**
- **Ano**
- **Tempo Máximo de reserva (em dias)**
- **Penalidade em caso de atraso** (Ligeira, Média, Grave)

#### Listar todos os livros:
- Exibe uma lista completa de todos os livros registrados.

#### Listar a informação de um livro por Id:
- Exibe os detalhes de um livro específico com base no seu Id.

### Empréstimo e Reserva

#### Emprestar um livro:
- Um livro só pode ser emprestado se não estiver reservado ou já emprestado para outro utilizador.
- Todos os empréstimos têm um período inicial de 7 dias.

#### Renovar o empréstimo:
- O sistema permite renovar o empréstimo de um livro por mais 7 dias.

#### Devolver um livro:
- Quando um livro é devolvido, ele fica disponível para reserva ou empréstimo por outro utilizador.

#### Reservar um livro:
- Um livro pode ser reservado se não estiver emprestado ou reservado por outro utilizador.

#### Apagar uma reserva:
- O sistema permite que uma reserva seja cancelada.

### Penalidades

#### Punir atrasos:
- Utilizadores que não devolvem os livros a tempo recebem uma penalidade. Existem três níveis de penalidade:
  - **Ligeira** (1)
  - **Média** (2)
  - **Grave** (3)
- Se um utilizador acumular uma penalidade superior a 5, ele não poderá fazer novas reservas até regularizar a situação.
