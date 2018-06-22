Simple task system - Application (service) layer.
-----------------------------------------

This layer contains application services and DTOs. Application layer is used by presentation layer and uses domain (core) layer to perform application specific operations.



SimpleTaskSystem.Application：应用服务层:
应用类接口继承IApplicationService，ABP自动为这个类提供一些功能特性:依赖注入，参数有效验证
定义应用类服务，实现对应应用类服务接口
DTO


一:定义应用类服务xxxxAppService:
(1)xxxxxAppService 继承基础的Service:AsyncCrudAppService<T>,继承应用服务接口IxxxxxAppService
(2)IxxxxxAppService 继承 IAsyncCrudAppService<T>使其具有依赖注入、参数有效验证等特性。
(3) xxxxxAppService 中一般包含以下：
    
	//仓储接口：用于数据与数据库交互
	IxxxRepository  _xxxRepository //对应实体的仓储接口
	IOtherRepository|IRepository<Other>  _otherRepository //关联实体的仓储接口

	public xxxxxAppService(IxxxxRepository xxxRepository,IRepository<Other> otherRepository){
			_xxxRepository = xxxRepository;
			_otherRepository = otherRepository;
	}
	//其他应用业务方法创建
使用仓储进行数据库操作，它通往构造函数注入仓储对象的引用

例如：
 IUserAppService:IAsyncCrudAppService<T>  
 UserAppService:AsyncCrudAppService<T>,IUserAppService 


 二.DTO:
每个Service都有对应的一个DTO：
（1）格式化结构方便显示层使用
（2）对数据效验，继承IValidatableObject实现自定义效验
	IEnumerable<ValidationResult> Validate(ValidationContext validationContext);//自定义效验
	        [Required]
        [StringLength(User.MaxNameLength)]	 
		public string Name { get; set; } //默认效验

DTO功能:数据传输对象，数据库出来数据的搬运工,（1）具有搬运功能载体（2）转换处理到目标地点不兼容的数据结构（3）隔离应用于数据库之间直接访问


三.GetXXXXInput和GetTasksOutput
两个包含DT的对象，用于UI和服务直接交互。
