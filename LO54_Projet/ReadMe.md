## Add / Update an entity into the DB
For each new entity :
```
Enable-migrations -ContextTypeName EntityNameDb -MigrationsDirectory DataContexts\EntityNameMigrations
```

Create or update the entity in the DB :
```
add-migration -ConfigurationTypeName LO54_Projet.Repository.EntityNameMigrations.Configuration "MigrationName"
```

Update the DB :
```
update-database -ConfigurationTypeName LO54_Projet.Repository.EntityNameMigrations.Configuration
```
