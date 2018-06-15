领域层：
	领域实体
	仓储接口


一.仓储接口:
	把业务代码与实体类与数据库操作更好的分离，可以针对不同的数据库有不同的实现类，而业务代码不需要修改。

	IRepository<T>:
				 定义了常用的增删改查方法
    IxxxRepository : IRepository<T>:
			     扩展xxx上独有方法


二.领域实体
   Entitys类库中

