using Consul;
using Microsoft.Extensions.Configuration;
using System;

namespace ServerTest.Utility
{
    public static class ConsulHelper
    {
        public static void ConsulRegist(this IConfiguration configuration)
        {
            try
            {
                string ip = configuration["ip"];
                string port = configuration["port"];
                string weight = configuration["weight"];
                string name = configuration["name"];
                string consulAddress = configuration["ConsulAddress"];
                string consulCenter = configuration["ConsulCenter"];

                ConsulClient client = new ConsulClient(c =>
                {
                    c.Address = new Uri(consulAddress);
                    c.Datacenter = consulCenter;
                });

                client.Agent.ServiceRegister(new AgentServiceRegistration()
                {
                    ID = "service " + ip + ":" + port,//Ray--唯一的
                    Name = name,//服务名称
                    Address = ip,
                    Port = int.Parse(port),
                    Check = new AgentServiceCheck()
                    {
                        Interval = TimeSpan.FromSeconds(5),
                        HTTP = $"http://{ip}:{port}/Health/Index",
                        Timeout = TimeSpan.FromSeconds(5),
                        DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(10)
                    }//配置心跳
                }).Wait();

                Console.WriteLine($"{ip}:{port}--weight:{weight}"); //命令行参数获取
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Consul注册：{ex.Message}");
            }
        }
    }
}
