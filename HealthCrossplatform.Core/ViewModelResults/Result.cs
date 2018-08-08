using System;
namespace HealthCrossplatform.Core.ViewModelResults
{
    public class Result<TEntity>
    {
        public TEntity Entity { get; set; }

        public bool Responsed { get; set; }
    }
}
