/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[nome]
      ,[nascimento]
      ,[telefone1]
      ,[telefone2]
      ,[endereco1]
      ,[endereco2]
      ,[rede]
      ,[cpf]
      ,[rg]
  FROM [cliente].[dbo].[cad_cliente]