//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Olimpiad
{
    using System;
    using System.Collections.Generic;
    
    public partial class SportGames
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SportGames()
        {
            this.Results = new HashSet<Results>();
        }
    
        public int Id { get; set; }
        public int IdSportType { get; set; }
        public int IdAthlet { get; set; }
        public int IdOlimpiad { get; set; }
    
        public virtual Athlets Athlets { get; set; }
        public virtual Olimpiads Olimpiads { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Results> Results { get; set; }
        public virtual SportTypes SportTypes { get; set; }
    }
}
