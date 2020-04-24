using System;
using System.Collections.Generic;
using System.Text;

namespace TanulmanyiRendszer.Domain
{
    public abstract class EntityBase
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
    }
}