using System;
namespace WxWomanSyncToZPerson.Model
{
	/// <summary>
	/// 人员扩展信息
	/// </summary>
	[Serializable]
	public partial class z_person_extend
	{
		public z_person_extend()
		{}
		#region Model
		private string _pkid;
		private string _person_id;
		private string _p_fqid;
		private string _p_fqxm;
		private string _p_fqzjlx;
		private string _p_fqsfz;
		private string _p_mqid;
		private string _p_mqxm;
		private string _p_mqzjlx;
		private string _p_mqsfz;
		private string _p_poid;
		private string _p_poxm;
		private string _p_pozjlx;
		private string _p_posfz;
		private string _p_gzdwxz;
		private string _p_gzdwmc;
		private string _p_gzdwdz;
		private string _p_gzdwdh;
		private string _p_zylx;
		private DateTime? _addtime;
		private string _addby;
		private DateTime? _updatetime;
		private string _updateby;
		/// <summary>
		/// 主键(newid())
		/// </summary>
		public string PKID
		{
			set{ _pkid=value;}
			get{return _pkid;}
		}
		/// <summary>
		/// z_person.id
		/// </summary>
		public string Person_ID
		{
			set{ _person_id=value;}
			get{return _person_id;}
		}
		/// <summary>
		/// 父亲id,z_person.id
		/// </summary>
		public string p_fqID
		{
			set{ _p_fqid=value;}
			get{return _p_fqid;}
		}
		/// <summary>
		/// 父亲姓名
		/// </summary>
		public string P_fqxm
		{
			set{ _p_fqxm=value;}
			get{return _p_fqxm;}
		}
		/// <summary>
		/// 父亲证件类型
		/// </summary>
		public string P_fqzjlx
		{
			set{ _p_fqzjlx=value;}
			get{return _p_fqzjlx;}
		}
		/// <summary>
		/// 父亲身份证
		/// </summary>
		public string P_fqsfz
		{
			set{ _p_fqsfz=value;}
			get{return _p_fqsfz;}
		}
		/// <summary>
		/// 母亲id,z_person.id
		/// </summary>
		public string p_mqID
		{
			set{ _p_mqid=value;}
			get{return _p_mqid;}
		}
		/// <summary>
		/// 母亲姓名
		/// </summary>
		public string P_mqxm
		{
			set{ _p_mqxm=value;}
			get{return _p_mqxm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string P_mqzjlx
		{
			set{ _p_mqzjlx=value;}
			get{return _p_mqzjlx;}
		}
		/// <summary>
		/// 母亲身份证
		/// </summary>
		public string P_mqsfz
		{
			set{ _p_mqsfz=value;}
			get{return _p_mqsfz;}
		}
		/// <summary>
		/// 配偶id,z_person.id
		/// </summary>
		public string p_poID
		{
			set{ _p_poid=value;}
			get{return _p_poid;}
		}
		/// <summary>
		/// 配偶姓名
		/// </summary>
		public string P_poxm
		{
			set{ _p_poxm=value;}
			get{return _p_poxm;}
		}
		/// <summary>
		/// 配偶证件类型
		/// </summary>
		public string p_pozjlx
		{
			set{ _p_pozjlx=value;}
			get{return _p_pozjlx;}
		}
		/// <summary>
		/// 配偶身份证
		/// </summary>
		public string P_posfz
		{
			set{ _p_posfz=value;}
			get{return _p_posfz;}
		}
		/// <summary>
		/// 工作单位性质
		/// </summary>
		public string P_gzdwxz
		{
			set{ _p_gzdwxz=value;}
			get{return _p_gzdwxz;}
		}
		/// <summary>
		/// 工作单位名称
		/// </summary>
		public string P_gzdwmc
		{
			set{ _p_gzdwmc=value;}
			get{return _p_gzdwmc;}
		}
		/// <summary>
		/// 工作单位地址
		/// </summary>
		public string P_gzdwdz
		{
			set{ _p_gzdwdz=value;}
			get{return _p_gzdwdz;}
		}
		/// <summary>
		/// 工作单位电话
		/// </summary>
		public string P_gzdwdh
		{
			set{ _p_gzdwdh=value;}
			get{return _p_gzdwdh;}
		}
		/// <summary>
		/// 职业类型
		/// </summary>
		public string P_zylx
		{
			set{ _p_zylx=value;}
			get{return _p_zylx;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? AddTime
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
		public DateTime? UpdateTime
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
		#endregion Model

	}
}

