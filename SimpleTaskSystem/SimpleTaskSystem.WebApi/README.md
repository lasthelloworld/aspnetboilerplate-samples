Simple task system - Web API (remote façade) layer.
-----------------------------------------

This layer is used to create a Web API layer on top of Application layer.


Application Service的public方法发布成Web Api接口，可以供客户端通过ajax调用。
SimpleTaskSystemApplicationModule这个程序集中所有继承了IApplicationService接口的类，
都会自动创建相应的ApiController，其中的公开方法，就会转换成WebApi接口方法。
如果用SPA单页编程，可以直接在客户端通过ajax调用相应的Application Service的方法了(通过创建了动态Web Api)。