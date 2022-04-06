using System;
namespace OnlineLibrary.PresentationLayer.Quartz.Jobs
{
    public class MyJob
    {
        public MyJob(Type type, string expression)
        {
            Type = type;
            Expression = expression;
        }

        public Type Type { get; }
        public string Expression { get; }
    }
}
