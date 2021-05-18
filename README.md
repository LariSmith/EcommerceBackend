# EcommerceBackend

Passo 1: Ir no SQL Server e pegar o 'Nome do Servidor';

Passo 2: No projeto, ir no 'Ecommerce.service', 'Data', 'Context', abrir o arquivo EcommerceContext.cs e mudar o 'optionBuilder.UseSqlServer()' como o exemplo abaixo: 

optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=ecommerceDB;Data Source=DESKTOP-OG3NMRS\\BWDATOOLSET");

em 'Data Source' botar o nome do seu servidor;

Passo 3: Abrir o 'Package Manager Console', alterar o 'Default project' para Ecommerce.Service e digitar no console: update-database
