Simple task system - Core (domain) layer.
-----------------------------------------

This layer includes Entities, Repository interfaces and other domain members.


领域层：
	领域实体
	仓储接口


一.仓储接口:
	把业务代码与实体类与数据库操作更好的分离，可以针对不同的数据库有不同的实现类，而业务代码不需要修改。

	IRepository<T>:
				 定义了常用的增删改查方法
    IxxxRepository : IRepository<T>:
			     扩展xxx上独有方法
	
	仓储接口中操作的方法，数据库连接会自动开启且启动事务。当仓储方法执行结束并且返回以后,所有的实体变化都会被储存, 
	事务被提交并且数据库连接被关闭,一切都由ABP自动化的控制。如果仓储方法抛出任何类型的异常,事务会自动地回滚并且数据连接会被关闭。

二.领域实体
   Entitys类库中