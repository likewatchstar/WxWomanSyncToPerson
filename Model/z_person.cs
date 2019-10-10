using System;
namespace WxWomanSyncToZPerson.Model
{
	/// <summary>
	/// z_person:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
		/// ����(newid())
		/// </summary>
		public string Person_id
		{
			set{ _person_id=value;}
			get{return _person_id;}
		}
		/// <summary>
		/// �����(z_family.id)
		/// </summary>
		public string Fno
		{
			set{ _fno=value;}
			get{return _fno;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// �Ա�
		/// </summary>
		public string Sex
		{
			set{ _sex=value;}
			get{return _sex;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public DateTime? Birthday
		{
			set{ _birthday=value;}
			get{return _birthday;}
		}
		/// <summary>
		/// ֤������
		/// </summary>
		public string Zjlx
		{
			set{ _zjlx=value;}
			get{return _zjlx;}
		}
		/// <summary>
		/// ���֤
		/// </summary>
		public string Idcard
		{
			set{ _idcard=value;}
			get{return _idcard;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string Gj
		{
			set{ _gj=value;}
			get{return _gj;}
		}
		/// <summary>
		/// ����
		/// </summary>
		public string NationId
		{
			set{ _nationid=value;}
			get{return _nationid;}
		}
		/// <summary>
		/// �Ļ��̶�
		/// </summary>
		public string eduId
		{
			set{ _eduid=value;}
			get{return _eduid;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string censusId
		{
			set{ _censusid=value;}
			get{return _censusid;}
		}
		/// <summary>
		/// ����״��
		/// </summary>
		public string marryId
		{
			set{ _marryid=value;}
			get{return _marryid;}
		}
		/// <summary>
		/// �����Ǽ�����
		/// </summary>
		public DateTime? IMarrDate
		{
			set{ _imarrdate=value;}
			get{return _imarrdate;}
		}
		/// <summary>
		/// �����ر���
		/// </summary>
		public string censusCode
		{
			set{ _censuscode=value;}
			get{return _censuscode;}
		}
		/// <summary>
		/// ������ַ
		/// </summary>
		public string censusAddr
		{
			set{ _censusaddr=value;}
			get{return _censusaddr;}
		}
		/// <summary>
		/// ���������ƺ�
		/// </summary>
		public string census_DNo
		{
			set{ _census_dno=value;}
			get{return _census_dno;}
		}
		/// <summary>
		/// �־�ס�ر���
		/// </summary>
		public string addrcode
		{
			set{ _addrcode=value;}
			get{return _addrcode;}
		}
		/// <summary>
		/// �־�ס��ַ
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// �־�ס��ַ���ƺ�
		/// </summary>
		public string addrDoorNo
		{
			set{ _addrdoorno=value;}
			get{return _addrdoorno;}
		}
		/// <summary>
		/// ��ס�ر���
		/// </summary>
		public string czcode
		{
			set{ _czcode=value;}
			get{return _czcode;}
		}
		/// <summary>
		/// ��ס��ַ
		/// </summary>
		public string czdz
		{
			set{ _czdz=value;}
			get{return _czdz;}
		}
		/// <summary>
		/// ��ס��ַ���ƺ�
		/// </summary>
		public string czmph
		{
			set{ _czmph=value;}
			get{return _czmph;}
		}
		/// <summary>
		/// ��ϵ�绰
		/// </summary>
		public string tel
		{
			set{ _tel=value;}
			get{return _tel;}
		}
		/// <summary>
		/// �뻧����ϵ
		/// </summary>
		public string Relation
		{
			set{ _relation=value;}
			get{return _relation;}
		}
		/// <summary>
		/// ��Ա����
		/// </summary>
		public string pt_Id
		{
			set{ _pt_id=value;}
			get{return _pt_id;}
		}
		/// <summary>
		/// ����״��(1����,0����)
		/// </summary>
		public string Sczk
		{
			set{ _sczk=value;}
			get{return _sczk;}
		}
		/// <summary>
		/// ע��ԭ��(1Ǩ��2����)
		/// </summary>
		public string Zxyy
		{
			set{ _zxyy=value;}
			get{return _zxyy;}
		}
		/// <summary>
		/// ��Ƭ
		/// </summary>
		public byte[] Zp
		{
			set{ _zp=value;}
			get{return _zp;}
		}
		/// <summary>
		/// ���ʱ��
		/// </summary>
		public DateTime? Addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public string AddBy
		{
			set{ _addby=value;}
			get{return _addby;}
		}
		/// <summary>
		/// �޸�ʱ��
		/// </summary>
		public DateTime? Updatetime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// �޸���
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

