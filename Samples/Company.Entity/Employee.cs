﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Entity
{
    [DisplayName("员工")]
    [DisplayColumn("Name")]
    [Parent(typeof(EmployeeGroup), "Group")]
    [EntityAuthentication(AllowAnonymous = false, ViewRolesRequired = new string[] { "Admin" })]
    public class Employee : UserBase
    {
        [Display(Name = "员工姓名", Order = 0)]
        [Required]
        public virtual string Name { get; set; }

        [Display(Name = "员工组", Order = 10)]
        [Required]
        public virtual EmployeeGroup Group { get; set; }

        [Display(Name = "性别", Order = 20)]
        [CustomDataType(CustomDataType.Sex)]
        [Required]
        public virtual bool Sex { get; set; }

        [Display(Name = "创建日期", Order = 20)]
        [Hide(IsHiddenOnView = false)]
        public override DateTime CreateDate { get { return base.CreateDate; } set { base.CreateDate = value; } }

        public override bool IsInRole(string role)
        {
            return Group.Power.ToString() == role;
        }
    }
}
