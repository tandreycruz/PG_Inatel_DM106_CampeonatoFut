# Pós-Graduação em Desenvolvimento Mobile e Cloud Computing - Inatel
## DM106 - Desenvolvimento de Web Services com Segurança sob a Plataforma .NET
## Prof. MSc. José Andery Carneiro
### Descrição:
Repositório utilizado para guardar arquivos dos exercícios práticos e Projeto Final, referentes ao projeto CampeonatoFut, produzidos na disciplina Desenvolvimento de Web Services com Segurança sob a Plataforma .NET.<br><br>
### 📂 Exercícios Práticos:


---

- [Exercício 1](https://github.com/tandreycruz/PG_Inatel_DM106_CampeonatoFut/tree/exercicio1)

  Os arquivos referentes ao Exercício 1, parte integrante da avaliação da disciplina DM106 estão na branch 'exercicio1'.

- [Exercício 2](https://github.com/tandreycruz/PG_Inatel_DM106_CampeonatoFut/tree/exercicio2)

  Os arquivos referentes ao Exercício 2, parte integrante da avaliação da disciplina DM106 estão na branch 'exercicio2'.

- [Exercício 3](https://github.com/tandreycruz/PG_Inatel_DM106_CampeonatoFut/tree/exercicio3)

  Os arquivos referentes ao Exercício 3, parte integrante da avaliação da disciplina DM106 estão na branch 'exercicio3'.

- [Exercício 4](https://github.com/tandreycruz/PG_Inatel_DM106_CampeonatoFut/tree/exercicio4)

  Os arquivos referentes ao Exercício 4, parte integrante da avaliação da disciplina DM106 estão na branch 'exercicio4'.<br><br><br>

### 📂 Projeto Final:


---
#### Descrição:
Sistema para gestão de partidas de um campeonato de futebol. Permite cadastrar times de futebol, seus respectivos jogadores (1:N), seus respectivos uniformes (1:N – nova funcionalidade) e relacionar com vários 
estádios (N:N) que os times farão seus jogos.
  
Os arquivos referentes ao Projeto Final, parte integrante da avaliação da disciplina DM106 estão na branch 'master'.
<br><br>

#### Diagrama de Classes:

![Diagrama de Classes](https://github.com/tandreycruz/PG_Inatel_DM106_CampeonatoFut/blob/master/images/DiagramaClassesCampeonatoFut_ProjetoFinal.jpg)


<br><br>
#### Novas Funcionalidades:
- Listar os times por estádios cadastrados 

  Com esta funcionalidade poderemos listar todos os times que estão associados a todos os estádios cadastrados. Ou seja, poderemos ver os jogos que ocorrerão em cada estádio e os times que jogarão neles. Também  poderemos ver os estádios cadastrados que ainda não possuem times associados a eles. 

  Esta funcionalidade foi implementada em um método GET na classe [StadiumExtension.cs](https://github.com/tandreycruz/PG_Inatel_DM106_CampeonatoFut/blob/master/CampeonatoFut_API/EndPoints/StadiumExtension.cs), e poderá ser experimentada via swagger no grupo Stadium, opção GET /Stadium/Teams. 
<br><br>
 

- Criação e implementação da classe Uniform (1:N) 

  A classe Uniform listará todos os possíveis uniformes que cada time poderá ter. O relacionamento estabelecido com a classe Team é de 1:N: um time poderá ter de um a vários uniformes e um uniforme pertence somente a um time. 

  Todos as funcionalidades da classe Uniform foram implementados e testados à semelhança da classe Player, que também possui relacionamento 1:N com a classe Team. 

  As funcionalidades da classe Uniform poderão ser experimentadas via swagger no grupo Uniform, opções GET, POST, PUT, DELETE e GET (uniforme por id).
<br><br>
#### Linguagem:
C#
<br><br>

#### IDE:
Microsoft Visual Studio Community 2022 (Versão 17.13.6)<br><br>



### Autor:
**Taíbe Cruz**

taibe.andrey@pg.inatel.br

tandreycruz@hotmail.com
