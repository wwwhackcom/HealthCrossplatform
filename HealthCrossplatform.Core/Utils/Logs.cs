using MvvmCross;
using MvvmCross.Logging;

namespace HealthCrossplatform.Core.Utils
{
    public static class Logs
    {
        public static IMvxLog Instance { get; } = Mvx.Resolve<IMvxLogProvider>().GetLogFor("HealthCrossplatform");
    }
}
