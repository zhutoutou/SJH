using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZIT.SJHServer.Model.DataExchangeFunction
{
    /// <summary>
    /// 系统人员数据上报
    /// </summary>
    public class SysUserData
    {
       /// <summary>
       /// 消息名
       /// </summary>
        public string CommandID{get;set;}
        /// <summary>
        /// 系统登录用户名
        /// </summary>
        public string UserName{get;set;}
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string Name{get;set;}
        /// <summary>
        /// 性别（1：男；2：女）
        /// </summary>
        public string Sex{get;set;}
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age{get;set;}
        /// <summary>
        /// 证件类型(1： 身份证；2：军管证；　3：其它）
        /// </summary>
        public string CertificateType { get; set; }
        /// <summary>
        /// 证件号码
        /// </summary>
        public string CertificateNumber{get;set;}
        /// <summary>
        /// 国籍
        /// </summary>
        public string Nationality{get;set;}
        /// <summary>
        /// 所属城市
        /// </summary>
        public string City{get;set;}
        /// <summary>
        /// 所属地区
        /// </summary>
        public string Area{get;set;}
        /// <summary>
        /// 所属单位
        /// </summary>
        public string OwnUnit{get;set;}
        /// <summary>
        /// 所属部门(科室)
        /// </summary>
        public string Department{get;set;}
        /// <summary>
        /// 岗位(如开发、生产、市场等)
        /// </summary>
        public string Position{get;set;}
        /// <summary>
        /// 职务
        /// </summary>
        public string Headship{get;set;}
        /// <summary>
        /// 职能（1：医生；2：护士；3：司机；4：担架工；5：管理；6：后勤；7：其它)
        /// </summary>
        public string Function { get; set; }
        /// <summary>
        /// 技术职称(1：主任医师；2：副主任医师；3：主管医师；4：主治医师；5：医师；6：主管护师；7：医士；8：护师9：护士；10：其它)
        /// </summary>
        public string TechnicalPost { get; set; }
        /// <summary>
        /// 学历(1：小学；2：中学；3：中专；4：大专；5：本科；6：硕士；7：博士；8：其它)
        /// </summary>
        public string Education { get; set; }
        /// <summary>
        /// 血型(1：O型；2：A型；3：B型；4：AB型；5：Rh-型；6：Rh+型；7：其它)
        /// </summary>
        public string BloodType { get; set; }
        /// <summary>
        /// 毕业学校
        /// </summary>
        public string GraduationSchool{get;set;}
        /// <summary>
        /// 专业
        /// </summary>
        public string Profession{get;set;}
        /// <summary>
        /// 用工形式(0:在编；1:非编)
        /// </summary>
        public string WorkForm { get; set; }
        /// <summary>
        /// 是否为专家(1是，0不是)
        /// </summary>
        public string IsExpert{get;set;}
        /// <summary>
        /// 专家特长（心内、急救等）
        /// </summary>
        public string ExpertSpecialty{get;set;}
        /// <summary>
        /// 办公电话
        /// </summary>
        public string OfficeTelephone{get;set;}
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile{get;set;}
        /// <summary>
        /// 家庭电话
        /// </summary>
        public string FamilyTelephone{get;set;}
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email{get;set;}
        /// <summary>
        /// 出生日期, 格式为 ”2006-08-06”
        /// </summary>
        public string BirthDay{get;set;}
        /// <summary>
        /// 毕业时间, 格式为 ”2006-08-06”
        /// </summary>
        public string GraduationDate{get;set;}
        /// <summary>
        /// 参加工作时间, 格式为 ”2006-08-06”
        /// </summary>
        public string JobDate{get;set;}
        /// <summary>
        /// 入职时间, 格式为 ”2006-08-06”
        /// </summary>
        public string EntryPositionDate{get;set;}
        /// <summary>
        /// 注册日期, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string RegisterDate{get;set;}
        /// <summary>
        /// 注销日期, 格式为 ”2006-08-06 12:35:56”
        /// </summary>
        public string WriteoffDate{get;set;}
        /// <summary>
        /// 注销标志(0：未注销，1：注销)
        /// </summary>
        public string Cancel { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get;set; }
        //20151210 修改人:朱星汉 修改内容:添加系统人员密码
        ///<summary>
        ///密码
        ///</summary>
        public string Password { get; set; }

    }
}
