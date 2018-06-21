Simple task system - EntityFramework infrastructure module
-----------------------------------------

This layer is used to create classes to work with EntityFramework. It implements repositories and database migrations.

NHibernate specific codes are placed in this seperated class library. Thus, our domain and application are isolated from EntityFramework.




系统仓储层：
     Code First EF 数据迁移生成数据库表
	 实现仓储接口的仓储基类，及基类扩展
	 仓储类通过DBContext与数据库建立联系



一.实现仓储接口的仓储基类，及基类扩展
	xxxRepository:SimpleTaskSystemRepositoryBase<T>,IxxxRepository  //继承仓储类基类，继承仓储接口

二.仓储类通过DBContext与数据库建立联系
数据库操作实体框架工作单元和存储库模式的组合，创建实体操作接口IDbSet


   // 通过数据迁移配置文件 Code first 生成数据库文件 
    /**
	*  工具--NuGet包管理器--程序包管理器控制台下：
    *在VS2013底部的“程序包管理器控制台”窗口中，选择默认项目“SimpleTaskSystem.EntityFramework”并执行命令“Add-Migration InitialCreate” 
    * 会在Migrations文件夹下生成一个xxxx-InitialCreate.cs文件
    * 
    * 
    * 在“程序包管理器控制台”执行“Update-Database”，会自动在数据库创建相应的数据表
    * 
    * 更新重复上面的操作
    * **/


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