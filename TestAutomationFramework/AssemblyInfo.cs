using NUnit.Framework;
[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]
[assembly: FixtureLifeCycle(LifeCycle.InstancePerTestCase)]