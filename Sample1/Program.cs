var builder = WebApplication.CreateBuilder(args);

//1.独立配置文件(推荐方式)
var hostingConfig = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           // 这里添加配置文件
           .AddJsonFile("hosting.json", true)
           .Build();

builder.WebHost.UseConfiguration(hostingConfig);

var app = builder.Build();

//2.通过代码实现自定义端口
var urls = new string[] { "http://*:81", "https://*:82" };
builder.WebHost.UseUrls(urls);

//3.通过appsettings.json配置实现自定义端口，使用配置文件配置后代码UseUrls配置将实付覆盖（无效）,如：
//"Kestrel": {
//    "Endpoints": {
//        "Http": {
//            "Url": "http://*:96"
//        }
//    }
//}

/// <summary>
/// 输出服务器当前时间
/// </summary>
app.MapGet("/time", () =>
{
    var timeStr = DateTime.Now.ToString();
    Console.WriteLine($"接收到请求:{timeStr}");
    return timeStr;
});

app.Run();