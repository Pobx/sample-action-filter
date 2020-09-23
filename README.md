# ตัวอย่างการใช้งาน Action Fileter in ASP.NET Core 3.1.x

#### Release: 23/09/2020
<ul>
<li>ลบไฟล์ ValidationFilterAttribute.cs</li>
<li>แก้ไขไฟล์ ResponseModelAttribute.cs ให้ support condition ModelState กรณี Invalide</li>
<li>ใช้ local variable ใน if statement(context.Result is OkObjectResult okResult) แทนการใช้  var result = context.Result as ObjectResult</li>
<li>กรณี Exception ระบบจะเรียกใช้ HandleExceptionAttribute เพื่อ Response กลับไปที่ Client ด้วย HttpStatusCode 500</li>
</ul>