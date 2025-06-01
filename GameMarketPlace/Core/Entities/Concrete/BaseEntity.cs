using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Abstract
{
    public abstract class BaseEntity<TKey> : IEntity<TKey>
    {
        public BaseEntity(bool isGeneratedId = false)
        {
            GenerateId(isGeneratedId);
        }

        public TKey Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime EditDate { get; set; }

        public void GenerateId(bool isGeneratedId = true)
        {
            if (isGeneratedId && typeof(TKey) == typeof(Guid))
            {
                object generatedId = Guid.NewGuid();
                Id = (TKey)generatedId;
            }
        }
    }
}
