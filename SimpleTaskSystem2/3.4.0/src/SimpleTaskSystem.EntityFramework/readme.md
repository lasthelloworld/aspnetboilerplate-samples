
系统仓储层：
     Code First EF 数据迁移生成数据库表
	 实现仓储接口的仓储基类，及基类扩展
	 仓储类通过DBContext与数据库建立联系



一.实现仓储接口的仓储基类，及基类扩展
	xxxRepository:SimpleTaskSystemRepositoryBase<T>,IxxxRepository  //继承仓储类基类，继承仓储接口

二.仓储类通过DBContext与数据库建立联系
数据库操作实体框架工作单元和存储库模式的组合，创建实体操作接口IDbSet