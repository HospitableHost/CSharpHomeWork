1. 编写面向对象程序实现长方形、正方形、三角形等形状的类。每个形状类都能计算面积、判断形状是否合法。 请尝试合理使用接口/抽象类、属性来实现。
2. 随机创建10个形状对象，计算这些对象的面积之和。 尝试使用简单工厂设计模式来创建对象。


由于只是控制台应用，故只上传了启动类的.cs文件

解释：
①任务2中的工厂类有一个静态函数，它返回值是抽象基类Shape类型，这样直接使用Shape.GetArea();来实现动态多态，直接计算相应形状的面积
②使用随机产生一个正整数+随机产生的0-1之间的浮点数可以使得边一定是非负的浮点数
