var builder = WebApplication.CreateBuilder(args);

//1.���������ļ�(�Ƽ���ʽ)
var hostingConfig = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           // ������������ļ�
           .AddJsonFile("hosting.json", true)
           .Build();

builder.WebHost.UseConfiguration(hostingConfig);

var app = builder.Build();

//2.ͨ������ʵ���Զ���˿�
var urls = new string[] { "http://*:81", "https://*:82" };
builder.WebHost.UseUrls(urls);

//3.ͨ��appsettings.json����ʵ���Զ���˿ڣ�ʹ�������ļ����ú����UseUrls���ý�ʵ�����ǣ���Ч��,�磺
//"Kestrel": {
//    "Endpoints": {
//        "Http": {
//            "Url": "http://*:96"
//        }
//    }
//}

/// <summary>
/// �����������ǰʱ��
/// </summary>
app.MapGet("/time", () =>
{
    var timeStr = DateTime.Now.ToString();
    Console.WriteLine($"���յ�����:{timeStr}");
    return timeStr;
});

app.Run();