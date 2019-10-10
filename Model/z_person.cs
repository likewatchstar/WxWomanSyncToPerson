using System;
namespace WxWomanSyncToZPerson.Model
{
	/// <summary>
	/// z_person:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class z_person
	{
		public z_person()
		{}
		#region Model
		private string _person_id;
		private string _fno;
		private string _name;
		private string _sex;
		private DateTime? _birthday;
		private string _zjlx;
		private string _idcard;
		private string _gj;
		private string _nationid;
		private string _eduid;
		private string _censusid;
		private string _marryid;
		private DateTime? _imarrdate;
		private string _censuscode;
		private string _censusaddr;
		private string _census_dno;
		private string _addrcode;
		private string _address;
		private string _addrdoorno;
		private string _czcode;
		private string _czdz;
		private string _czmph;
		private string _tel;
		private string _relation;
		private string _pt_id;
		private string _sczk;
		private string _zxyy;
		private byte[] _zp;
		private DateTime? _addtime;
		private string _addby;
		private DateTime? _updatetime;
		private string _updateby;
		private string _managementareacode;
		/// <summary>
		/// 主键(newid())
		/// </summary>
		public string Person_id
		{
			set{ _person_id=value;}
			get{return _person_id;}
		}
		/// <summary>
		/// 户编号(z_family.id)
		/// </summary>
		public string Fno
		{
			set{ _fno=value;}
			get{return _fno;}
		}
		/// <summary>
		/// 姓名
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 性别
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// 证件类型
		/// </summary>
		public string Zjlx
		{
			set{ _zjlx=value;}
			get{return _zjlx;}
		}
		/// <summary>
		/// 身份证
		/// </summary>
		public string Idcard
		{
			set{ _idcard=value;}
			get{return _idcard;}
		}
		/// <summary>
		/// 国籍
		/// </summary>
		public string Gj
		{
			set{ _gj=value;}
			get{return _gj;}
		}
		/// <summary>
		/// 民族
		/// </summary>
		public string NationId
		{
			set{ _nationid=value;}
			get{return _nationid;}
		}
		/// <summary>
		/// 文化程度
		/// </summary>
		public string eduId
		{
			set{ _eduid=value;}
			get{return _eduid;}
		}
		/// <summary>
		/// 户口性质
		/// </summary>
		public string censusId
		{
			set{ _censusid=value;}
			get{return _censusid;}
		}
		/// <summary>
		/// 婚姻状况
		/// </summary>
		public string marryId
		{
			set{ _marryid=value;}
			get{return _marryid;}
		}
		/// <summary>
		/// 婚姻登记日期
		/// </summary>
		public DateTime? IMarrDate
		{
			set{ _imarrdate=value;}
			get{return _imarrdate;}
		}
		/// <summary>
		/// 户籍地编码
		/// </summary>
		public string censusCode
		{
			set{ _censuscode=value;}
			get{return _censuscode;}
		}
		/// <summary>
		/// 户籍地址
		/// </summary>
		public string censusAddr
		{
			set{ _censusaddr=value;}
			get{return _censusaddr;}
		}
		/// <summary>
		/// 户籍地门牌号
		/// </summary>
		public string census_DNo
		{
			set{ _census_dno=value;}
			get{return _census_dno;}
		}
		/// <summary>
		/// 现居住地编码
		/// </summary>
		public string addrcode
		{
			set{ _addrcode=value;}
			get{return _addrcode;}
		}
		/// <summary>
		/// 现居住地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 现居住地址门牌号
		/// </summary>
		public string addrDoorNo
		{
			set{ _addrdoorno=value;}
			get{return _addrdoorno;}
		}
		/// <summary>
		/// 常住地编码
		/// </summary>
		public string czcode
		{
			set{ _czcode=value;}
			get{return _czcode;}
		}
		/// <summary>
		/// 常住地址
		/// </summary>
		public string czdz
		{
			set{ _czdz=value;}
			get{return _czdz;}
		}
		/// <summary>
		/// 常住地址门牌号
		/// </summary>
		public string czmph
		{
			set{ _czmph=value;}
			get{return _czmph;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// 与户主关系
		/// </summary>
		public string Relation
		{
			set{ _relation=value;}
			get{return _relation;}
		}
		/// <summary>
		/// 人员类型
		/// </summary>
		public string pt_Id
		{
			set{ _pt_id=value;}
			get{return _pt_id;}
		}
		/// <summary>
		/// 生存状况(1生存,0死亡)
		/// </summary>
		public string Sczk
		{
			set{ _sczk=value;}
			get{return _sczk;}
		}
		/// <summary>
		/// 注销原因(1迁出2死亡)
		/// </summary>
		public string Zxyy
		{
			set{ _zxyy=value;}
			get{return _zxyy;}
		}
		/// <summary>
		/// 照片
		/// </summary>
		public byte[] Zp
		{
			set{ _zp=value;}
			get{return _zp;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? Addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 添加人
		/// </summary>
		public string AddBy
		{
			set{ _addby=value;}
			get{return _addby;}
		}
		/// <summary>
		/// 修改时间
		/// </summary>
		public DateTime? Updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 修改人
		/// </summary>
		public string UpdateBy
		{
			set{ _updateby=value;}
			get{return _updateby;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ManagementAreaCode
		{
			set{ _managementareacode=value;}
			get{return _managementareacode;}
		}
		#endregion Model

	}
}

