//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComputerClub
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeSchedule
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int IdEmployee { get; set; }
        public System.TimeSpan TimeStart { get; set; }
        public System.TimeSpan TimeEnd { get; set; }
    
        public virtual Employees Employees { get; set; }
    }
}
