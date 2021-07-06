Delete from ReforId
Delete from pedidos
DBCC CHECKIDENT ('[Pedidos]', RESEED, 0);
GO