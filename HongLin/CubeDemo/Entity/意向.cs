using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace NewLife.School.Entity
{
    /// <summary>意向</summary>
    [Serializable]
    [DataObject]
    [Description("意向")]
    [BindTable("CustomerLink", Description = "意向", ConnName = "School", DbType = DatabaseType.SqlServer)]
    public partial class CustomerLink : ICustomerLink
    {
        #region 属性
        private Int32 _ID;
        /// <summary>编号</summary>
        [DisplayName("编号")]
        [Description("编号")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("ID", "编号", "")]
        public Int32 ID { get { return _ID; } set { if (OnPropertyChanging(__.ID, value)) { _ID = value; OnPropertyChanged(__.ID); } } }

        private String _Name;
        /// <summary>姓名</summary>
        [DisplayName("姓名")]
        [Description("姓名")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Name", "姓名", "", Master = true)]
        public String Name { get { return _Name; } set { if (OnPropertyChanging(__.Name, value)) { _Name = value; OnPropertyChanged(__.Name); } } }

        private String _Mobile;
        /// <summary>电话</summary>
        [DisplayName("电话")]
        [Description("电话")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("Mobile", "电话", "")]
        public String Mobile { get { return _Mobile; } set { if (OnPropertyChanging(__.Mobile, value)) { _Mobile = value; OnPropertyChanged(__.Mobile); } } }

        private DateTime _AccessDate;
        /// <summary>到访日期</summary>
        [DisplayName("到访日期")]
        [Description("到访日期")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("AccessDate", "到访日期", "")]
        public DateTime AccessDate { get { return _AccessDate; } set { if (OnPropertyChanging(__.AccessDate, value)) { _AccessDate = value; OnPropertyChanged(__.AccessDate); } } }

        private Int32 _AccessType;
        /// <summary>到访方式</summary>
        [DisplayName("到访方式")]
        [Description("到访方式")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AccessType", "到访方式", "")]
        public Int32 AccessType { get { return _AccessType; } set { if (OnPropertyChanging(__.AccessType, value)) { _AccessType = value; OnPropertyChanged(__.AccessType); } } }

        private Boolean _IsLink;
        /// <summary>是否联系</summary>
        [DisplayName("是否联系")]
        [Description("是否联系")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IsLink", "是否联系", "")]
        public Boolean IsLink { get { return _IsLink; } set { if (OnPropertyChanging(__.IsLink, value)) { _IsLink = value; OnPropertyChanged(__.IsLink); } } }

        private Int32 _CreateUserID;
        /// <summary>创建者</summary>
        [DisplayName("创建者")]
        [Description("创建者")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("CreateUserID", "创建者", "")]
        public Int32 CreateUserID { get { return _CreateUserID; } set { if (OnPropertyChanging(__.CreateUserID, value)) { _CreateUserID = value; OnPropertyChanged(__.CreateUserID); } } }

        private DateTime _CreateTime;
        /// <summary>创建时间</summary>
        [DisplayName("创建时间")]
        [Description("创建时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("CreateTime", "创建时间", "")]
        public DateTime CreateTime { get { return _CreateTime; } set { if (OnPropertyChanging(__.CreateTime, value)) { _CreateTime = value; OnPropertyChanged(__.CreateTime); } } }

        private String _CreateIP;
        /// <summary>创建地址</summary>
        [DisplayName("创建地址")]
        [Description("创建地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("CreateIP", "创建地址", "")]
        public String CreateIP { get { return _CreateIP; } set { if (OnPropertyChanging(__.CreateIP, value)) { _CreateIP = value; OnPropertyChanged(__.CreateIP); } } }

        private Int32 _UpdateUserID;
        /// <summary>更新者</summary>
        [DisplayName("更新者")]
        [Description("更新者")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UpdateUserID", "更新者", "")]
        public Int32 UpdateUserID { get { return _UpdateUserID; } set { if (OnPropertyChanging(__.UpdateUserID, value)) { _UpdateUserID = value; OnPropertyChanged(__.UpdateUserID); } } }

        private DateTime _UpdateTime;
        /// <summary>更新时间</summary>
        [DisplayName("更新时间")]
        [Description("更新时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UpdateTime", "更新时间", "")]
        public DateTime UpdateTime { get { return _UpdateTime; } set { if (OnPropertyChanging(__.UpdateTime, value)) { _UpdateTime = value; OnPropertyChanged(__.UpdateTime); } } }

        private String _UpdateIP;
        /// <summary>更新地址</summary>
        [DisplayName("更新地址")]
        [Description("更新地址")]
        [DataObjectField(false, false, true, 50)]
        [BindColumn("UpdateIP", "更新地址", "")]
        public String UpdateIP { get { return _UpdateIP; } set { if (OnPropertyChanging(__.UpdateIP, value)) { _UpdateIP = value; OnPropertyChanged(__.UpdateIP); } } }

        private String _Remark;
        /// <summary>备注</summary>
        [DisplayName("备注")]
        [Description("备注")]
        [DataObjectField(false, false, true, 200)]
        [BindColumn("Remark", "备注", "")]
        public String Remark { get { return _Remark; } set { if (OnPropertyChanging(__.Remark, value)) { _Remark = value; OnPropertyChanged(__.Remark); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case __.ID : return _ID;
                    case __.Name : return _Name;
                    case __.Mobile : return _Mobile;
                    case __.AccessDate : return _AccessDate;
                    case __.AccessType : return _AccessType;
                    case __.IsLink : return _IsLink;
                    case __.CreateUserID : return _CreateUserID;
                    case __.CreateTime : return _CreateTime;
                    case __.CreateIP : return _CreateIP;
                    case __.UpdateUserID : return _UpdateUserID;
                    case __.UpdateTime : return _UpdateTime;
                    case __.UpdateIP : return _UpdateIP;
                    case __.Remark : return _Remark;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.ID : _ID = value.ToInt(); break;
                    case __.Name : _Name = Convert.ToString(value); break;
                    case __.Mobile : _Mobile = Convert.ToString(value); break;
                    case __.AccessDate : _AccessDate = value.ToDateTime(); break;
                    case __.AccessType : _AccessType = value.ToInt(); break;
                    case __.IsLink : _IsLink = value.ToBoolean(); break;
                    case __.CreateUserID : _CreateUserID = value.ToInt(); break;
                    case __.CreateTime : _CreateTime = value.ToDateTime(); break;
                    case __.CreateIP : _CreateIP = Convert.ToString(value); break;
                    case __.UpdateUserID : _UpdateUserID = value.ToInt(); break;
                    case __.UpdateTime : _UpdateTime = value.ToDateTime(); break;
                    case __.UpdateIP : _UpdateIP = Convert.ToString(value); break;
                    case __.Remark : _Remark = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得意向字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary>编号</summary>
            public static readonly Field ID = FindByName(__.ID);

            /// <summary>姓名</summary>
            public static readonly Field Name = FindByName(__.Name);

            /// <summary>电话</summary>
            public static readonly Field Mobile = FindByName(__.Mobile);

            /// <summary>到访日期</summary>
            public static readonly Field AccessDate = FindByName(__.AccessDate);

            /// <summary>到访方式</summary>
            public static readonly Field AccessType = FindByName(__.AccessType);

            /// <summary>是否联系</summary>
            public static readonly Field IsLink = FindByName(__.IsLink);

            /// <summary>创建者</summary>
            public static readonly Field CreateUserID = FindByName(__.CreateUserID);

            /// <summary>创建时间</summary>
            public static readonly Field CreateTime = FindByName(__.CreateTime);

            /// <summary>创建地址</summary>
            public static readonly Field CreateIP = FindByName(__.CreateIP);

            /// <summary>更新者</summary>
            public static readonly Field UpdateUserID = FindByName(__.UpdateUserID);

            /// <summary>更新时间</summary>
            public static readonly Field UpdateTime = FindByName(__.UpdateTime);

            /// <summary>更新地址</summary>
            public static readonly Field UpdateIP = FindByName(__.UpdateIP);

            /// <summary>备注</summary>
            public static readonly Field Remark = FindByName(__.Remark);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得意向字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary>编号</summary>
            public const String ID = "ID";

            /// <summary>姓名</summary>
            public const String Name = "Name";

            /// <summary>电话</summary>
            public const String Mobile = "Mobile";

            /// <summary>到访日期</summary>
            public const String AccessDate = "AccessDate";

            /// <summary>到访方式</summary>
            public const String AccessType = "AccessType";

            /// <summary>是否联系</summary>
            public const String IsLink = "IsLink";

            /// <summary>创建者</summary>
            public const String CreateUserID = "CreateUserID";

            /// <summary>创建时间</summary>
            public const String CreateTime = "CreateTime";

            /// <summary>创建地址</summary>
            public const String CreateIP = "CreateIP";

            /// <summary>更新者</summary>
            public const String UpdateUserID = "UpdateUserID";

            /// <summary>更新时间</summary>
            public const String UpdateTime = "UpdateTime";

            /// <summary>更新地址</summary>
            public const String UpdateIP = "UpdateIP";

            /// <summary>备注</summary>
            public const String Remark = "Remark";
        }
        #endregion
    }

    /// <summary>意向接口</summary>
    public partial interface ICustomerLink
    {
        #region 属性
        /// <summary>编号</summary>
        Int32 ID { get; set; }

        /// <summary>姓名</summary>
        String Name { get; set; }

        /// <summary>电话</summary>
        String Mobile { get; set; }

        /// <summary>到访日期</summary>
        DateTime AccessDate { get; set; }

        /// <summary>到访方式</summary>
        Int32 AccessType { get; set; }

        /// <summary>是否联系</summary>
        Boolean IsLink { get; set; }

        /// <summary>创建者</summary>
        Int32 CreateUserID { get; set; }

        /// <summary>创建时间</summary>
        DateTime CreateTime { get; set; }

        /// <summary>创建地址</summary>
        String CreateIP { get; set; }

        /// <summary>更新者</summary>
        Int32 UpdateUserID { get; set; }

        /// <summary>更新时间</summary>
        DateTime UpdateTime { get; set; }

        /// <summary>更新地址</summary>
        String UpdateIP { get; set; }

        /// <summary>备注</summary>
        String Remark { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}