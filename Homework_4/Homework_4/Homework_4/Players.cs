//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Homework_4
{
    using System;
    using System.Collections.Generic;
    
    public partial class Players
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdClubs { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }
        public int IdCountries { get; set; }
    
        public virtual Clubs Clubs { get; set; }
        public virtual Countries Countries { get; set; }
    }
}
