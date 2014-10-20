# Readme

## 运行截图

![ScreenShot](./ScreenShot.png)

## 运行环境
- 装有.NET Framework 4.0或以上的电脑
- 最好是64位Windows系统
- 本程序在Windows 8.1 + VS2013 + .NET Framework 4.5上运行通过

## 运行向导
1.  考虑到上次作业的坑爹问题，这次提供了Web的发布版本。发布版为`Publish`文件夹中的`Lab3`。
2.  打开IIS新建一个网站，目录选择`Lab3`的路径，默认监听80端口。
3.  配置完成后在浏览器中打开`http://localhost/index.aspx`即可。

## 实现过程
类似上一次的作业，采用`GridView`和`ObjectDataSource`绑定的方式，实现数据的呈现。通过设定中间体`ObjectDataSource`对`GridView`的四个函数`SelectMethod`，`UpdateMethod`，`InsertMethod`和`DeleteMethod`完成对返回数据的处理。`DetailView`用于添加数据。（默认显示第一行的数据）

## 其他问题
- 因为绑定了`GridView`和`DetailView`都绑定了`ObjectDataSource`。所以在没数据的时候会不显示任何的信息和数据，并且`DetailView`中无法添加数据。
- 考虑到所有的id都是主键，所以希望助教不要添加重复的id和编辑更改id的内容。

## 关于我
- 博客: [Cee‘s Home](https://chu2byo.me)
- Github: [Cee's Github](https://github.com/cirnocee)