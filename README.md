# Introduce
这是一个JQuery+.net Core(Razor Page)的文件上传模块，基于 [jQuery-File-Upload](https://github.com/blueimp/jQuery-File-Upload).

# Enviroment
.net Core Version : .net Core 3.0

如果部署到Linux上，还需要从Docker上执行以下命令, [详情][1]
```
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
RUN ln -s /lib/x86_64-linux-gnu/libdl.so.2 /lib/x86_64-linux-gnu/libdl.so
RUN apt update
RUN apt install -y libgdiplus
RUN ln -s /usr/lib/libgdiplus.so /lib/x86_64-linux-gnu/libgdiplus.so
```


# Screenshots
![a.png](screenshots/a.png)
 
![b.png](screenshots/b.png)

![c.png](screenshots/c.png)

[1]:https://github.com/JanKallman/EPPlus/issues/83
