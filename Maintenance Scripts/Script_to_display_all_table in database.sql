SELECT *
FROM DGMU.INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_SCHEMA = 'xSystem'
ORDER BY TABLE_NAME
