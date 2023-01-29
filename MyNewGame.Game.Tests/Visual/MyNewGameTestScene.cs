using osu.Framework.Testing;

namespace MyNewGame.Game.Tests.Visual
{
    public partial class MyNewGameTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new MyNewGameTestSceneTestRunner();

        private partial class MyNewGameTestSceneTestRunner : MyNewGameGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}
