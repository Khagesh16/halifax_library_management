//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dbproject
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class p_publication
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public p_publication()
        {
            this.p_articles = new HashSet<p_articles>();
        }
        [DisplayName("Publication ID")]
        public int publication_id { get; set; }
        [DisplayName("Volume Number")]
        public int volume_number { get; set; }
        [DisplayName("Published Date")]
        public Nullable<System.DateTime> published_date { get; set; }
        [DisplayName("Magazine ID")]
        public Nullable<int> magazine_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p_articles> p_articles { get; set; }
        public virtual p_magazine p_magazine { get; set; }
    }
}