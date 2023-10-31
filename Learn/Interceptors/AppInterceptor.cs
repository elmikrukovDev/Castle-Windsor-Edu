using Castle.DynamicProxy;
using NLog;
using System;

namespace Application.Interceptors;

public class AppInterceptor : IInterceptor {
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    public void Intercept(IInvocation invocation) {
        try {
            switch(invocation.Method.Name) {
                case "OnStartup":
                    logger.Info($"| {invocation.TargetType.FullName} | {invocation.Method.Name}: starting application with user: " +
                        $"\"{Environment.UserName}\" in machine: \"{Environment.MachineName}\"");
                    logger.Info($"| {invocation.TargetType.FullName} | {invocation.Method.Name}: prepare on the application start");
                    invocation.Proceed();
                    logger.Info($"| {invocation.TargetType.FullName} | {invocation.Method.Name}: app status: \"started\"");
                    break;
                case "OnExit":
                    logger.Info($"| {invocation.TargetType.FullName} | {invocation.Method.Name}: exiting the application... User: " +
                        $"\"{Environment.UserName}\" in machine: \"{Environment.MachineName}\"");
                    invocation.Proceed();
                    logger.Info($"| {invocation.TargetType.FullName} | {invocation.Method.Name}: app status: \"stopped\"");
                    break;
                case null:
                    throw new NullReferenceException("INTERCEPT ERROR: Method name is null");
                default:
                    logger.Info($"| {invocation.TargetType.FullName} | {invocation.Method.Name}: call");
                    invocation.Proceed();
                    break;
            }
        } catch(Exception e) {
            logger.Error(e);
            throw;
        }
    }
}