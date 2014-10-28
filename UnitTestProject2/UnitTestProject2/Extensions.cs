using NBehave.Narrator.Framework;
using NBehave.Narrator.Framework.EventListeners;
using NBehave.Narrator.Framework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPOPQR.FuntionalTests
{
    static class Extensions
    {
        public static FeatureResults ExecuteTest(this string path)
        {
            return NBehaveConfiguration.New
                .DontIsolateInAppDomain()
                .SetEventListener(new OutputEventListener(new ConsoleWriter()))
                .SetAssemblies(new[] { typeof(CPOPQR.FunctionalTests.Steps.Actions).Assembly.Location })
                .SetScenarioFiles(new[] { path })
                .Build()
                .Run();
        }
        
        public static bool FeatureFaildOrNot(this FeatureResults featureResults)
        {
            return featureResults
                .Where(e=>e.ScenarioResults
                    .Select(s=>s.Result is Failed)
                    .Contains(true))
                    .Count()==0;
        }
    }
}
