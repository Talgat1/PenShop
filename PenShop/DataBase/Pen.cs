//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PenShop.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pen
    {
        public Pen()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int Id { get; set; }
        public int IdCompany { get; set; }
        public int IdType { get; set; }
        public string Color { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual TypePen TypePen { get; set; }
    }
}