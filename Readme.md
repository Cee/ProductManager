# Readme

## ���н�ͼ

![ScreenShot](./ScreenShot.png)

![Database](./Database.jpg)

## ���л���
- װ��.NET Framework 4.0�������Լ�MySQL�ĵ���
- �����64λWindowsϵͳ
- ��������Windows 8.1 + VS2013 + .NET Framework 4.5������ͨ��

## ʵ�ֹ���
- ������һ�ε���ҵ������`GridView`��`ObjectDataSource`�󶨵ķ�ʽ��ʵ�����ݵĳ��֡�ͨ���趨�м���`ObjectDataSource`��`GridView`���ĸ�����`SelectMethod`��`UpdateMethod`��`InsertMethod`��`DeleteMethod`��ɶԷ������ݵĴ���`DetailView`����������ݡ���Ĭ����ʾ��һ�е����ݣ�
- SQL����ʹ��MySQL�ṩ��`MySQLConnector`��ɡ���Ҫ�����Ϊ����������

		String sqlSearch = "select * from product";
		String sqlInsert = "insert into product values (" + id + ", " + name + ", " + price + ")";
		String sqlDelete = "delete from product where id='" + id + "'";
		String sqlUpdate = "update product set name='" + name + "' , price='" + price + "' where id='" + id + "'";

## ��������
- ��Ϊ����`GridView`��`DetailView`������`ObjectDataSource`��������û���ݵ�ʱ��᲻��ʾ�κε���Ϣ�����ݣ�����`DetailView`���޷�������ݡ�
- ���ǵ����е�id��������������ϣ�����̲�Ҫ����ظ���id�ͱ༭����id�����ݡ�

## ������
- ����: [Cee��s Home](https://chu2byo.me)
- Github: [Cee's Github](https://github.com/cirnocee)