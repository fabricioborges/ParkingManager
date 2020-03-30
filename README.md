# ParkingManager

Aplicativo para gerenciamento de estacionamento, regra de negócio não abrange as questões de pernoites de veículos, ou seja, realiza apenas o cálculo até 24 horas da entrada do veículo para sua saída.

Para a criação do banco de dados necessário utilizar o comando “Update-Database”, pois foi utilizado as Migrations do EntityFramework.
Para inserir a data de saída do veículo é necessário selecionar pela placa qual o veículo deseja, antes de realizar a ação.
Implementado busca pela placa do veículo, podendo ser realizada de for parcial ex.: somente as letras ou somente os números da placa.
