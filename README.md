<h1 align="center">StoneChallenge</h1>

### English
Technical challenge developed for .NET developer position.

Technologies used: .NET 6, Cloud Firestore 3.0.0, xUnit 2.4.2, Moq 4.18.2 and Swagger 6.4.0.

Challenge Description:
A company closed the year of operation with a profit and wants to share it among its employees, with the aim of being fair, it created a rule for the distribution of this amount by: area, company time, and salary range (employees who earn less would have their increased participation). For this, the technology team was asked to develop a REST API that receives a maximum amount to distribute and distributes the amount to employees already registered with the data below. Such distribution follows certain rules described below.

**General rules**

-> A weight per area of activity was established:
* Weight 1: Board of Directors;
* Weight 2: Accounting, Finance, Technology;
* Weight 3: General Services;
* Weight 5: Customer Relationship.

-> A weight per salary range and an exception for interns was established:
* Weight 5: Above 8 minimum wages;
* Weight 3: Above 5 minimum wages and less than 8 minimum wages;
* Weight 2: Above 3 minimum wages and less than 5 minimum wages;
* Weight 1: All interns and employees earning up to 3 minimum wages.

-> A weight per admission time was established:
* Weight 1: Up to 1 year of home;
* Weight 2: More than 1 year and less than 3 years;
* Weight 3: Over 3 years and under 8 years;
* Weight 5: More than 8 years.

By the established rules, the formula to arrive at the bonus of each employee is:

![image](https://user-images.githubusercontent.com/43019285/178532414-dbbfd626-a716-4f7f-8749-9c635ddb6d3d.png)

**Subtitle**
* **SB:** Gross Salary
* **PTA:** Weight per admission time
* **PAA:** Weight per operating area
* **PFS:** Weight by salary range

**Data input (JSON format)**

[input.txt](https://github.com/CarolFantini/StoneChallenge/files/9094904/input.txt)

**Example of expected return (JSON format)**

![image](https://user-images.githubusercontent.com/43019285/178534133-adc3bb2c-66cd-4179-b709-e52f27447189.png)

**Return Details**
| **Field**     | **Description** |
| ------------- | ------------- |
| total_distribuido           | Sum of what was paid in PL to all employees |
| total_disponibilizado       | The value the company wanted to distribute  |
| saldo_total_disponibilizado | Total available minus the total distributed |

**Prerequisites**
* The application must contain everything necessary for its operation, it must not be necessary to install
any kind of new external resource, with the exception of frameworks and packages (nuguets);
* .NET Core
* WebApi;
* xUnit for testing;
* Free choice persistence. As a suggestion Firebase, Redis Cloud, or any cloud service, to avoid the need for installation.

### Português
Desafio técnico desenvolvido para vaga de desenvolvedor .NET.

Tecnologias usadas: .NET 6, Cloud Firestore 3.0.0, xUnit 2.4.5 e Swagger 6.4.0.

Descrição do Desafio:
Uma empresa fechou o ano de operação com lucro e deseja reparti-lo entre seus funcionários, com o objetivo de ser justa criou uma regra para a distribuição deste montante por: área, tempo de empresa, e faixa salarial (os funcionários que ganham menos teriam sua participação incrementada). Para isso foi solicitado ao time de tecnologia que desenvolva uma API REST que receba um valor máximo para distribuir e distribua o montante para os funcionários já cadastrados com os dados abaixo. Tal distribuição segue determinadas regras descritas a seguir.

**Regras Gerais**

-> Foi estabelecido um peso por área de atuação:
* Peso 1: Diretoria;
* Peso 2: Contabilidade, Financeiro, Tecnologia;
* Peso 3: Serviços Gerais;
* Peso 5: Relacionamento com o Cliente.

-> Foi estabelecido um peso por faixa salarial e uma exceção para estagiários:
* Peso 5: Acima de 8 salários mínimos;
* Peso 3: Acima de 5 salários mínimos e menor que 8 salários mínimos;
* Peso 2: Acima de 3 salários mínimos e menor que 5 salários mínimos;
* Peso 1: Todos os estagiários e funcionários que ganham até 3 salários mínimos.

-> Foi estabelecido um peso por tempo de admissão:
* Peso 1: Até 1 ano de casa;
* Peso 2: Mais de 1 ano e menos de 3 anos;
* Peso 3: Acima de 3 anos e menos de 8 anos;
* Peso 5: Mais de 8 ano.

Pelas regras estabelecias, a fórmula para se chegar ao bônus de cada funcionário é:

![image](https://user-images.githubusercontent.com/43019285/178532414-dbbfd626-a716-4f7f-8749-9c635ddb6d3d.png)

**Legenda**
* **SB:** Salário Bruto
* **PTA:** Peso por tempo de admissão
* **PAA:** Peso por aréa de atuação
* **PFS:** Peso por faixa salarial

**Input de dados (formato JSON)**

[input.txt](https://github.com/CarolFantini/StoneChallenge/files/9094904/input.txt)

**Exemplo de retorno esperado (formato JSON)**

![image](https://user-images.githubusercontent.com/43019285/178534133-adc3bb2c-66cd-4179-b709-e52f27447189.png)

**Detalhes do retorno**
| **Campo**     | **Descrição** |
| ------------- | ------------- |
| total_distribuido           | Soma do que foi pago em PL a todos os funcionários |
| total_disponibilizado       | O valor que a empresa desejava distribuir          |
| saldo_total_disponibilizado | Total disponibilizado menos o total distribuído    |

**Pré requisitos**
* A aplicação deve conter todo o necessário para seu funcionamento, não deve ser necessário instalar
qualquer tipo de novo recurso externo, com exceção dos frameworks e pacotes (nuguets);
* .NET Core
* WebApi;
* xUnit para testes;
* Persistência de livre escolha. Como sugestão Firebase, Redis Cloud, ou qualquer serviço de nuvem, para
evitar necessidades de instalação.

## License
<a href="https://github.com/CarolFantini/BCChallenge/blob/main/LICENSE">
<img alt="License" src="https://img.shields.io/github/license/CarolFantini/BCChallenge?color=green">
</a>
  
## Author
<a href="https://linkedin.com/in/carolfantini"><img alt="LinkedIn" title="LinkedIn" src="https://img.shields.io/badge/-LinkedIn-1DA1F2?style=for-the-badge&logo=linkedin&logoColor=white"/></a>
  <a href="https://twitter.com/carol_fantini"><img alt="Twitter" title="Twitter" src="https://img.shields.io/badge/-Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white"/></a>
