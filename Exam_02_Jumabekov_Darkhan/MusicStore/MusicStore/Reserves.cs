//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MusicStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reserves
    {
        public int Id { get; set; }
        public int IdRecord { get; set; }
        public int IdBuyer { get; set; }
        public int Count { get; set; }
    
        public virtual Buyers Buyers { get; set; }
        public virtual Records Records { get; set; }
    }
}