using System;
using System.Collections.Generic;

namespace RAS.Bootcamo.Catalog.Mvc.Net.Datas.Entities
{
    public partial class Pembely
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Alamat { get; set; } = null!;
        public string NoHp { get; set; } = null!;

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
