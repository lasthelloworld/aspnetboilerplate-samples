Database Migrations创建数据库表

通过修改Configuration.cs,添加Code First创建


在NutGet程序包控制台
选择默认项目，执行Add-Migration "InitialCreate"  添加执行Code First。
会在Migrations目录下生成 日期_Initial_Migration.cs 文件,并在数据库中添加数据库表。

若已经存在日期_Initial_Migration.cs，则需先update-database,然后执行Add-Migration "InitialCreate",再执行update-database

运行结果
Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
Applying explicit migrations: [201806150611063_InitialCreate].
Applying explicit migration: 201806150611063_InitialCreate.
Running Seed method.


（以后修改了实体，可以再次执行Add-Migration和Update-Database，就能很轻松的让数据库结构与实体类的同步）