/****** Script for SelectTopNRows command from SSMS  ******/
SELECT p.Title [Page.Title], 
       b.Name [Block.Name],
       bt.Name [BlockType.Name]
  FROM [Block] [b]
  join [Page] [p] on [p].[Id] = [b].[PageId]
  join [BlockType] [bt] on [bt].[Id] = [b].[BlockTypeId]
  order by p.Name, b.Name