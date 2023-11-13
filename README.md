## Blazor Application Jobs

### Esta é uma aplicação Web desenvolvida com Blazor Web Assembly e ASP.NET Core 7 para fins de fixação de estudos.

- A aplicação Blazor é compilada em WebAssembly, permitindo que o código C# seja executado diretamente no navegador do usuário. Isso significa que toda a aplicação é carregada de uma vez, e as interações subsequentes são gerenciadas localmente no navegador, sem a necessidade de comunicação constante com o servidor.

- O projeto oferece uma solução onde é possível cadastrar, visualizar e aplicar para vagas de emprego.

- Foi implementada a autenticação utilizando o  ASP.NET Core Identity.

- Optou-se por utilizar um banco de dados em memória para simplificar o processo de desenvolvimento e teste. Isso significa que todas as informações relacionadas a vagas de emprego e aplicações são armazenadas temporariamente durante a execução da aplicação, facilitando a inicialização e depuração do sistema.

### Funcionalidades Principais


- Cadastro de Vagas de Emprego: Os recrutadores podem cadastrar novas vagas, fornecendo informações detalhando o titúlo da vaga, descrição, empresa, localidade e salário.

![image](https://github.com/RafaelaRomin/BlazorApplicationJobs/assets/124751861/88c4a185-7aa0-48ac-9d2f-ba8ab89212d1)

Visualização de Vagas: O usuário podem consultar as vagas cadastradas na aba "Home".

![image](https://github.com/RafaelaRomin/BlazorApplicationJobs/assets/124751861/156a701f-94bf-4c12-81e7-089fb6fba71d)


Aplicação para Vagas: Os candidatos podem se candidatar a vagas diretamente pela plataforma, enviando suas informações e currículos para consideração.

![image](https://github.com/RafaelaRomin/BlazorApplicationJobs/assets/124751861/f25ae006-24c8-4031-b84c-ad028ac4b531)

Acompanhamento de Aplicações: Candidatos podem acompanhar as vagas que já aplicou na aba "Aplicações realizadas". 

![image](https://github.com/RafaelaRomin/BlazorApplicationJobs/assets/124751861/00fdd31f-297c-43c6-b4e4-09ce8a238a76)


