<h1 align="center">StoneChallenge</h1>

### Português
Desafio técnico desenvolvido para vaga de desenvolvedor .NET.

Tecnologias usadas: .NET 6, Cloud Firestore (da Firebase), xUnit 2.4.1 e OpenAPI 3.0.3 (Swagger).

Descrição do Desafio:
Uma empresa fechou o ano de operação com lucro e deseja reparti-lo entre seus funcionários, com o objetivo de ser justa criou uma regra para a distribuição deste montante por: área, tempo de empresa, e faixa salarial (os funcionários que ganham menos teriam sua participação incrementada). Para isso foi solicitado ao time de tecnologia que desenvolva uma API REST que receba um valor máximo para distribuir e distribua o montante para os funcionários já cadastrados com os dados abaixo. Tal distribuição segue determinadas regras descritas a seguir.

**Regras Gerais**

-> Foi estabelecido um peso por área de atuação:
* Peso 1: Diretoria;
* Peso 2: Contabilidade, Financeiro, Tecnologia;
* Peso 3: Serviços Gerais;
* Peso 5: Relacionamento com o Cliente.

* -> Foi estabelecido um peso por faixa salarial e uma exceção para estagiários:
* Peso 5: Acima de 8 salários mínimos;
* Peso 3: Acima de 5 salários mínimos e menor que 8 salários mínimos;
* Peso 2: Acima de 3 salários mínimos e menor que 5 salários mínimos;
* Peso 1: Todos os estagiários e funcionários que ganham até 3 salários mínimos.

* -> Foi estabelecido um peso por tempo de admissão:
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
| saldo_total_disponibilizado | Total disponibilizado menos o total distribuido    |

**Pré requisitos**
* A aplicação deve conter todo o necessário para seu funcionamento, não deve ser necessário instalar
qualquer tipo de novo recurso externo, com exceção dos frameworks e pacotes (nuguets);
* .Net Core
* WebApi;
* xUnit para testes;
* Persistência de livre escolha, como sugestão Firebase, Redis Cloud, ou qualquer serviço de nuvem, para
evitar necessidades de instalação.

## License
<a href="https://github.com/CarolFantini/BCChallenge/blob/main/LICENSE">
<img alt="License" src="https://img.shields.io/github/license/CarolFantini/BCChallenge?color=green">
</a>
  
## Author
<a href="https://linkedin.com/in/carolfantini"><img alt="LinkedIn" title="LinkedIn" src="https://img.shields.io/badge/-LinkedIn-1DA1F2?style=for-the-badge&logo=linkedin&logoColor=white"/></a>
  <a href="https://twitter.com/carol_fantini"><img alt="Twitter" title="Twitter" src="https://img.shields.io/badge/-Twitter-1DA1F2?style=for-the-badge&logo=twitter&logoColor=white"/></a>
