// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SandO.Bll;
using SandO.Bll.BllClasses;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("SandO Sistem Kurulumuna Hoşgeldiniz!");
Console.WriteLine("Lütfen aşağıdaki adımları takip ediniz.");
Console.WriteLine("1. Veritabanı bağlantı bilgilerini giriniz.");
Console.WriteLine("2. Veritabanı tablolarını oluşturunuz.");
Console.WriteLine("3. Veritabanı tablolarını doldurunuz.");
Console.WriteLine("4. Veritabanı tablolarını kontrol ediniz.");
Console.WriteLine("5. Kurulumu tamamlayınız.");

Console.WriteLine("1. Adım: Veritabanı bağlantı bilgilerini giriniz.");
// Integrated Security olup olmamına bağlı olarak connection string oluşturulur.
string connectionString = string.Empty;
Console.WriteLine("Integrated Security kullanılacak mı? (E/H)");
string integratedSecurity = Console.ReadLine();

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.Encrypt = false;
string databaseName;
if (integratedSecurity.ToUpper() == "E")
{
    Console.WriteLine("Server adını giriniz:");
    string server = Console.ReadLine();
    Console.WriteLine("Database adını giriniz:");
    databaseName = Console.ReadLine();
    sqlConnectionStringBuilder.DataSource = server;
    sqlConnectionStringBuilder.IntegratedSecurity = true;
}
else
{
    Console.WriteLine("Server adını giriniz:");
    string server = Console.ReadLine();
    Console.WriteLine("Database adını giriniz:");
    databaseName = Console.ReadLine();
    Console.WriteLine("Kullanıcı adını giriniz:");
    string user = Console.ReadLine();
    Console.WriteLine("Şifreyi giriniz:");
    string password = Console.ReadLine();
    sqlConnectionStringBuilder.DataSource = server;
    sqlConnectionStringBuilder.UserID = user;
    sqlConnectionStringBuilder.Password = password;
    sqlConnectionStringBuilder.IntegratedSecurity = false;
}

connectionString = sqlConnectionStringBuilder.ConnectionString;

// connection string ile veritabanı bağlantısını test et. Açılmazsa hata mesajı ver.
using (SqlConnection connection = new SqlConnection(connectionString))
{
    try
    {
        connection.Open();
        Console.WriteLine("Veritabanı bağlantısı başarılı.");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Veritabanı bağlantısı başarısız. Hata: " + ex.Message);
    }
}

sqlConnectionStringBuilder.InitialCatalog = databaseName;
connectionString = sqlConnectionStringBuilder.ConnectionString;

DbContextOptionsBuilder<SandOContext> dbContextOptionsBuilder = new DbContextOptionsBuilder<SandOContext>();
dbContextOptionsBuilder.UseSqlServer(connectionString);

SandOContext context = new SandOContext(dbContextOptionsBuilder.Options);
try
{
    context.Database.Migrate();
    Console.WriteLine("Veritabanı tabloları oluşturuldu.");
}
catch (Exception e)
{
    Console.WriteLine(e);
}

Console.ReadLine();
