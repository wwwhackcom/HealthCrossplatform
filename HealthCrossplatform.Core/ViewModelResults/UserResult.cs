using System;
namespace HealthCrossplatform.Core.ViewModelResults
{
    public class UserResult<TEntity>
    {
        public TEntity Entity { get; set; }

        public bool Responsed { get; set; }
    }
}
