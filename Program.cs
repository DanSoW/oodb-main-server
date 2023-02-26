/*
 * ����� ����� � ������ oodb-main-server
 * **/

using Db4objects.Db4o;
using oodb_project.controllers.db4o;
using oodb_project.controllers.mongo;
using oodb_project.controllers.perst;
using oodb_project.data;

// �������� ���������� ������ WebApplicationBuilder ��� ���������������� ���-����������
var builder = WebApplication.CreateBuilder(args);

// ������ ���-����������
var app = builder.Build();

// ���������������� ����������� ����� � ������
app.UseDefaultFiles();
app.UseStaticFiles();

// ��� ������� ��������� ���� �� ���� ��, � ���� ���� - ������� ���
if (File.Exists("db4o.yap"))
{
    File.Delete("db4o.yap");
}

// ���������������� ���� (db4o)
IObjectContainer dbDb4o = Db4oEmbedded.OpenFile(Db4oEmbedded.NewConfiguration(), "db4o.yap");

// ���������� ���� ��������� �������
var mockData = new MockData(dbDb4o);
mockData.generateData();

// ������������� ��������� ��� ������ � ���� db4o
var initDb4oController = new InitDb4oController(app, dbDb4o);
initDb4oController.InitRoutes();

// ������������� ��������� ��� ������ � ���� perst
var initPerstController = new InitPerstController(app);
initPerstController.InitRoutes();

// ������������� ��������� ��� ������ � MongoDB
var initMongoController = new InitMongoController(app);
initMongoController.InitRoutes();

// ������ ���������� ����������
app.Run();

// �������� ���������� � ����� ������
dbDb4o.Close();
