//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kurs_Oil
{
    using System;
    using System.Collections.Generic;
    
    public partial class K_DistanceCalculations
    {
        public int DCalculation_Id { get; set; }
        public int FK_User_Id { get; set; }
        public double Consuption { get; set; }
        public double Filled { get; set; }
        public double Results { get; set; }
    
        public virtual K_Users K_Users { get; set; }
    }
}
