SimpleTaskSystem.Application��Ӧ�÷����:
Ӧ����ӿڼ̳�IApplicationService��ABP�Զ�Ϊ������ṩһЩ��������:����ע�룬������Ч��֤
����Ӧ�������ʵ�ֶ�ӦӦ�������ӿ�
DTO


һ:����Ӧ�������xxxxAppService:
(1)xxxxxAppService �̳л�����Service:AsyncCrudAppService<T>,�̳�Ӧ�÷���ӿ�IxxxxxAppService
(2)IxxxxxAppService �̳� IAsyncCrudAppService<T>ʹ���������ע�롢������Ч��֤�����ԡ�
(3) xxxxxAppService ��һ��������£�
    
	//�ִ��ӿڣ��������������ݿ⽻��
	IxxxRepository  _xxxRepository //��Ӧʵ��Ĳִ��ӿ�
	IOtherRepository|IRepository<Other>  _otherRepository //����ʵ��Ĳִ��ӿ�

	public xxxxxAppService(IxxxxRepository xxxRepository,IRepository<Other> otherRepository){
			_xxxRepository = xxxRepository;
			_otherRepository = otherRepository;
	}
	//����Ӧ��ҵ�񷽷�����

���磺
 IUserAppService:IAsyncCrudAppService<T>  
 UserAppService:AsyncCrudAppService<T>,IUserAppService 


 ��.DTO:
ÿ��Service���ж�Ӧ��һ��DTO��
��1����ʽ���ṹ������ʾ��ʹ��
��2��������Ч�飬�̳�IValidatableObjectʵ���Զ���Ч��
	IEnumerable<ValidationResult> Validate(ValidationContext validationContext);//�Զ���Ч��
	        [Required]
        [StringLength(User.MaxNameLength)]	 
		public string Name { get; set; } //Ĭ��Ч��

DTO����:���ݴ���������ݿ�������ݵİ��˹�,��1�����а��˹������壨2��ת������Ŀ��ص㲻���ݵ����ݽṹ��3������Ӧ�������ݿ�֮��ֱ�ӷ���