use Uricao
go
INSERT INTO Direccion VALUES('Venezuela','Pais', NULL);

INSERT INTO Direccion VALUES('Amazonas','Estado',1);
INSERT INTO Direccion VALUES('Anzoategui','Estado',1);
INSERT INTO Direccion VALUES('Apure','Estado',1);
INSERT INTO Direccion VALUES('Aragua','Estado',1);
INSERT INTO Direccion VALUES('Barinas','Estado',1);
INSERT INTO Direccion VALUES('Bolivar','Estado',1);
INSERT INTO Direccion VALUES('Carabobo','Estado',1);
INSERT INTO Direccion VALUES('Cojedes','Estado',1);
INSERT INTO Direccion VALUES('Delta Amacuro','Estado',1);
INSERT INTO Direccion VALUES('Falcon','Estado',1);
INSERT INTO Direccion VALUES('Guarico','Estado',1);
INSERT INTO Direccion VALUES('Lara','Estado',1);
INSERT INTO Direccion VALUES('Merida','Estado',1);
INSERT INTO Direccion VALUES('Miranda','Estado',1);
INSERT INTO Direccion VALUES('Monagas','Estado',1);
INSERT INTO Direccion VALUES('Nueva Esparta','Estado',1);
INSERT INTO Direccion VALUES('Portuguesa','Estado',1);
INSERT INTO Direccion VALUES('Sucre','Estado',1);
INSERT INTO Direccion VALUES('Tachira','Estado',1);
INSERT INTO Direccion VALUES('Trujillo','Estado',1);
INSERT INTO Direccion VALUES('Vargas','Estado',1);
INSERT INTO Direccion VALUES('Yaracuy','Estado',1);
INSERT INTO Direccion VALUES('Zulia','Estado',1);
INSERT INTO Direccion VALUES('Distrito Capital','Estado',1);

INSERT INTO Direccion VALUES('Puerto Ayacucho','Ciudad',2);
INSERT INTO Direccion VALUES('Barcelona','Ciudad',3);
INSERT INTO Direccion VALUES('San Fernando de Apure','Ciudad',4);
INSERT INTO Direccion VALUES('Maracay','Ciudad',5);
INSERT INTO Direccion VALUES('Barinas','Ciudad',6);
INSERT INTO Direccion VALUES('Ciudad Bolivar','Ciudad',7);
INSERT INTO Direccion VALUES('Valencia','Ciudad',8);
INSERT INTO Direccion VALUES('San Carlos','Ciudad',9);
INSERT INTO Direccion VALUES('Tucupita','Ciudad',10);
INSERT INTO Direccion VALUES('Coro','Ciudad',11);
INSERT INTO Direccion VALUES('San Juan de los Morros','Ciudad',12);
INSERT INTO Direccion VALUES('Barquisimeto','Ciudad',13);
INSERT INTO Direccion VALUES('Merida','Ciudad',14);
INSERT INTO Direccion VALUES('Los Teques','Ciudad',15);
INSERT INTO Direccion VALUES('Maturin','Ciudad',16);
INSERT INTO Direccion VALUES('La Asuncion','Ciudad',17);
INSERT INTO Direccion VALUES('Guanare','Ciudad',18);
INSERT INTO Direccion VALUES('Cumana','Ciudad',19);
INSERT INTO Direccion VALUES('San Cristobal','Ciudad',20);
INSERT INTO Direccion VALUES('Trujillo','Ciudad',21);
INSERT INTO Direccion VALUES('Felipe','Ciudad',22);
INSERT INTO Direccion VALUES('San Felipe','Ciudad',23);
INSERT INTO Direccion VALUES('Maracaibo','Ciudad',24);
INSERT INTO Direccion VALUES('Caracas','Ciudad',25);
use Uricao
go
INSERT INTO Direccion VALUES('Qta. El Portal Avenida Río de Janeiro','Detalle',49);
INSERT INTO Direccion VALUES('Av. Francisco De Miranda, Edificio Centro La Paz, Piso 7, Apto. O71, Urbanización La California Norte','Detalle',49);
INSERT INTO Direccion VALUES('Av. Bermúdez, Edificio Solin, Sector Centro, Piso 2, Apto. 31','Detalle',49);
INSERT INTO Direccion VALUES('Av. Libertador, Edificio Multicentro B, Piso 3, Apto. B-31, Urbanización Chacao','Detalle',49);
INSERT INTO Direccion VALUES('Calle El Manguito, Qta. N° 2, Urbanización El Hatillo','Detalle',49);
INSERT INTO Direccion VALUES('Calle Santa Ana, Casa Nro. 18 Coberlamina, Urbanización Boleíta','Detalle',39);
INSERT INTO Direccion VALUES('Esq. Veroes, a Esq. Jesuita, Edificio Imanta, Piso 2, Apto. 3, Urbanización Altagracia','Detalle',39);
INSERT INTO Direccion VALUES('Av. Francisco De Miranda, Edificio Mariscal Sucre, Piso 9, Apto. 4, Urbanización Chacao','Detalle',39);
INSERT INTO Direccion VALUES('Calle 3b, Qta. Maribel, Piso PB, Urbanización La Urbina','Detalle',38);
INSERT INTO Direccion VALUES('Av. Principal, Edificio Maploca II, Piso 7, Apt. 7B, Urbanización Los Cortijos de Lourdes','Detalle',38);
INSERT INTO Direccion VALUES('Av. República Dominicana, Edificio Alpha, Piso 2, Apto. 2-F, Urbanización Boleíta','Detalle',39);

go
INSERT INTO [Uricao].[dbo].[Usuario]
           ([loginUser]
           ,[passwordUser]
           ,[tipoidUser]
           ,[cedulaUser]
           ,[nombreUser1]
           ,[nombreUser2]
           ,[apellidoUser1]
           ,[apellidoUser2]
           ,[nacimientoUser]
           ,[fechIngresoUser]
           ,[generoUser]
           ,[correoUser]
           ,[ocupacionUser]
           ,[fkidDireccion]
           ,[fotoUser]
           ,[estado]
           ,[ingresoUser])
     VALUES
           ('carlos'
           ,'1234'
           ,'V'
           ,'19560012'
           ,'Carlos'
           ,'Israel'
           ,'Cedeno'
           ,'Balbas'
           ,'1988-07-29'
           ,'2012-10-01'
           ,'masculino'
           ,'derfettemann@gmail.com'
           ,'profesional'
           ,50
           ,null
           ,'Activo'          
           ,5000)
GO

INSERT INTO [Uricao].[dbo].[Usuario]
           ([loginUser]
           ,[passwordUser]
           ,[tipoidUser]
           ,[cedulaUser]
           ,[nombreUser1]
           ,[nombreUser2]
           ,[apellidoUser1]
           ,[apellidoUser2]
           ,[nacimientoUser]
           ,[fechIngresoUser]
           ,[generoUser]
           ,[correoUser]
           ,[ocupacionUser]
           ,[fkidDireccion]
           ,[fotoUser]
           ,[estado]
           ,[ingresoUser])
     VALUES
           ('yeimy'
           ,'1234'
           ,'V'
           ,'18555202'
           ,'Yeimy'
           ,null
           ,'Martinez'
           ,null
           ,'1985-01-07'
           ,'2012-10-01'
           ,'femenino'
           ,'yeimymartinez@gmail.com'
           ,'profesional'
           ,51
           ,null
           ,'Activo'
           ,5000)
GO

INSERT INTO [Uricao].[dbo].[Usuario]
           ([loginUser]
           ,[passwordUser]
           ,[tipoidUser]
           ,[cedulaUser]
           ,[nombreUser1]
           ,[nombreUser2]
           ,[apellidoUser1]
           ,[apellidoUser2]
           ,[nacimientoUser]
           ,[fechIngresoUser]
           ,[generoUser]
           ,[correoUser]
           ,[ocupacionUser]
           ,[fkidDireccion]
           ,[fotoUser]
           ,[estado]
           ,[ingresoUser])
     VALUES
           ('salvi'
           ,'1234'
           ,'V'
           ,'19154639'
           ,'Salvador'
           ,'Hilario'
           ,'Delgado'
           ,'Khassale'
           ,'1988-05-16'
           ,'2012-10-01'
           ,'masculino'
           ,'salvi1605@gmail.com'
           ,'profesional'
           ,52
           ,null
           ,'Activo'
           ,5000)
GO

INSERT INTO [Uricao].[dbo].[Usuario]
           ([loginUser]
           ,[passwordUser]
           ,[tipoidUser]
           ,[cedulaUser]
           ,[nombreUser1]
           ,[nombreUser2]
           ,[apellidoUser1]
           ,[apellidoUser2]
           ,[nacimientoUser]
           ,[fechIngresoUser]
           ,[generoUser]
           ,[correoUser]
           ,[ocupacionUser]
           ,[fkidDireccion]
           ,[fotoUser]
           ,[estado]
           ,[ingresoUser])
     VALUES
           ('arles'
           ,'1234'
           ,'V'
           ,'19720330'
           ,'Arleska'
           ,null
           ,'Perez'
           ,'Velasquez'
           ,'1989-06-19'
           ,'2012-10-01'
           ,'femenino'
           ,'arleskaperez89@gmail.com'
           ,'profesional'
           ,53
           ,null
           ,'Activo'
           ,5000)
GO



INSERT INTO [Uricao].[dbo].[Usuario]
           ([loginUser]
           ,[passwordUser]
           ,[tipoidUser]
           ,[cedulaUser]
           ,[nombreUser1]
           ,[nombreUser2]
           ,[apellidoUser1]
           ,[apellidoUser2]
           ,[nacimientoUser]
           ,[fechIngresoUser]
           ,[generoUser]
           ,[correoUser]
           ,[ocupacionUser]
           ,[fkidDireccion]
           ,[fotoUser]
           ,[estado]
           ,[ingresoUser])
     VALUES
           ('kike'
           ,'1234'
           ,'V'
           ,'17643617'
           ,'Jesus'
           ,null
           ,'Simanca'
           ,'Gonzales'
           ,'1986-04-23'
           ,'2012-10-01'
           ,'masculino'
           ,'jsimancas@gmail.com'
           ,'estudiante'
           ,54
           ,null
           ,'Activo'
           ,5000)
GO

INSERT INTO [Uricao].[dbo].[Usuario]
           ([loginUser]
           ,[passwordUser]
           ,[tipoidUser]
           ,[cedulaUser]
           ,[nombreUser1]
           ,[nombreUser2]
           ,[apellidoUser1]
           ,[apellidoUser2]
           ,[nacimientoUser]
           ,[fechIngresoUser]
           ,[generoUser]
           ,[correoUser]
           ,[ocupacionUser]
           ,[fkidDireccion]
           ,[fotoUser]
           ,[estado]
           ,[ingresoUser])
     VALUES
           ('jpuma'
           ,'1234'
           ,'V'
           ,'19464123'
           ,'Jose'
           ,'Paolo'
           ,'Puma'
           ,'Ferrante'
           ,'1989-10-03'
           ,'2012-10-01'
           ,'masculino'
           ,'jpuma23@gmail.com'
           ,'Estudiante'
           ,25
           ,'estudiante'
           ,'Activo'
           ,5000)
GO

INSERT INTO Usuario VALUES('Gustavo01','123abc','V','17693645','Gustavo',NULL,'Hernandez', NULL,'1960/01/01','2010/07/30','Masculino','gustavohernandez@gmail.com',null,25,'gushernandez.jpg','Activo',2000);
INSERT INTO Usuario VALUES('Nube02','123bcd','V','17560657','Nubielis',NULL,'Pereira',NULL,'1986/03/30','2010/01/26','Femenino','nubipereira@gmail.com',null,55,'nubipereira.jpg','Activo',2000);
INSERT INTO Usuario VALUES('Karla03','123cde','E','14123456','Karla',NULL,'Rodriguez',NULL,'1982/07/13','2011/05/14','Femenino','karlarodriguez@gmail.com',null,56,'karlarodriguez.jpg','Activo',2000);
INSERT INTO Usuario VALUES('Paty04','123def','V','15123456','Patricia',NULL,'Pietro',NULL,'1984/01/26','2011/03/09','Femenino','patipietro@gmail.com',null,18,'patipietro.jpg','Activo',2000);
INSERT INTO Usuario VALUES('Elis05','123efg','V','16123456','Elis',NULL,'Iglesias',NULL,'1978/08/05','2011/09/30','Masculino','elisiglesias@gmail.com',null,57,'elisiglesias.jpg','Activo',2000);
INSERT INTO Usuario VALUES('caro06','123fgh','E','11123456','Carolina',NULL,'Pereira',NULL,'1979/05/09','2012/02/19','Femenino','caropereira@gmail.com',null,13,'caropereira.jpg','Inactivo',2000);
INSERT INTO Usuario VALUES('Andres07','123ghi','V','17452369','Andres',NULL,'Hernandez',NULL,'1986/04/19','2011/04/23','Masculino','andreshernandez@gmail.com',null,58,'andreshernandez.jpg','Activo',2000);
INSERT INTO Usuario VALUES('Gaby08','123hij','V','12654852','Gabriela',NULL,'Perez',NULL,'1948/12/12','2011/06/27','Femenino','gabrielaperez@gmail.com',null,8,'gabrielaperez.jpg','Activo',2000);
INSERT INTO Usuario VALUES('Mariana09','123ijk','E','19654231','Mariana',NULL,'Sosa',NULL,'1989/12/13','2012/08/05','Femenino','marianasosa@gmail.com',null,59,'marianasosa.jpg','Activo',2000);
INSERT INTO Usuario VALUES('Luis10','123jkl','V','17800645','Luis',NULL,'Capriles',NULL,'1960/01/01','2011/10/03','Masculino','luiscapriles@gmail.com',null,60,'luiscapriles.jpg','Activo',2000);
INSERT INTO Usuario VALUES('maguca','123jkl','V','13124567','Carlo',NULL,'Magurno',NULL,'1960/01/01','2011/10/03','Masculino','maguca@gmail.com',null,23,'maguca.jpg','Activo',20000);



INSERT INTO [Uricao].[dbo].[Rol]
           ([nombreRol]
           ,[descripcionRol],[estado])
     VALUES
           ('Cliente'
           ,'Es el actor principal de la empresa, es decir, es aquel que va a la empresa y 
           es atendido por el personal, él se registra en el sistema y maneja sus citas 
           odontológicas, puede ver sus presupuestos y ver la información bancaria de la empresa.','Activo')
GO
INSERT INTO [Uricao].[dbo].[Rol]
           ([nombreRol]
           ,[descripcionRol],[estado])
     VALUES
           ('Administrador del Sistema'
           ,'Encargado de manejar los recursos de la empresa, personal, cuentas y suministros, 
           dirigiendo así los departamentos de cuentas por cobrar, historia de pacientes, 
           presupuestos, productos, suministros y tratamientos de los clientes.','Activo')
GO

INSERT INTO [Uricao].[dbo].[Rol]
           ([nombreRol]
           ,[descripcionRol],[estado])
     VALUES
           ('Personal Odontologico'
           ,'Trata directamente al cliente, examinando y aplicando tratamientos a los clientes. 
           Éste personal maneja el sistema controlando las citas, tratamientos, productos e 
           inventario.','Activo')
GO

INSERT INTO [Uricao].[dbo].[Rol]
           ([nombreRol]
           ,[descripcionRol],[estado])
     VALUES
           ('Administrador de Empresa'
           ,'Encargado de gestionar todo el sistema, apoyando íntegramente todas las áreas y 
           partes de la empresa donde se encentra el sistema, teniendo la posibilidad de 
           manejar cada parte que lo amerite.','Activo')
GO

INSERT INTO [Uricao].[dbo].[Rol]
           ([nombreRol]
           ,[descripcionRol],[estado])
     VALUES
           ('Secretaria'
           ,'Encargada de apoyar las operaciones de lo empleados de la empresa, 
           con la gestión del departamento o módulo que se encuentre, como tratamientos, 
           citas, facturas, presupuestos, cuentas por cobrar, consultar personal.','Activo')
GO

INSERT INTO [Uricao].[dbo].[Usuario_Rol] ([fkidUsuario],[fkidRol]) Values(1,1) 
GO
INSERT INTO [Uricao].[dbo].[Usuario_Rol] ([fkidUsuario],[fkidRol]) values(2,1) 
GO
INSERT INTO [Uricao].[dbo].[Usuario_Rol] ([fkidUsuario],[fkidRol]) values(3,1) 
GO
INSERT INTO [Uricao].[dbo].[Usuario_Rol] ([fkidUsuario],[fkidRol]) values(4,1) 
GO
INSERT INTO [Uricao].[dbo].[Usuario_Rol] ([fkidUsuario],[fkidRol]) values(5,1) 
GO
INSERT INTO [Uricao].[dbo].[Usuario_Rol] ([fkidUsuario],[fkidRol]) values(1,2) 
GO
INSERT INTO [Uricao].[dbo].[Usuario_Rol] ([fkidUsuario],[fkidRol]) values(2,3) 
GO
INSERT INTO [Uricao].[dbo].[Usuario_Rol] ([fkidUsuario],[fkidRol]) values(3,3) 
GO
INSERT INTO [Uricao].[dbo].[Usuario_Rol] ([fkidUsuario],[fkidRol]) values(4,5) 
GO
INSERT INTO [Uricao].[dbo].[Usuario_Rol] ([fkidUsuario],[fkidRol]) values(5,5) 
GO


insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar cita','Activo');
GO	
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Modificar cita','Activo');
GO	
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Cancelar cita','Activo');
GO	
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar agenda','Activo');
GO	
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar horario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar cliente','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Confirmar cita','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar Agenda general','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Gestionar Historia de Paciente','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar Historia Clínica','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar Historia Base','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar Secuencia de Tratamiento','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar Historia Clínica','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Detalle de la Historia Clínica','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Modificar Historia Clínica','Activo');
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Activar/Desactivar Historia Clínica','Activo');
GO

insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar empleado','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Modificar Empleado','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar Empleado','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Activar-Desactivar Empleado','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Generar presupuesto','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar presupuesto','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Generar factura','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar factura','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Activar/desactivar factura','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Crear la cuenta por cobrar','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar un Abono a la cuenta por cobrar','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Modificar la cuenta por cobrar','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar la cuenta por cobrar','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Cambiar estado de la cuenta por cobrar','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar cuenta por pagar','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Modificar Cuenta por Pagar','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar Cuenta por Pagar','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Activar Desactivar Cuenta por Psagar','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Abonar Cuenta por pagar','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar Productos a inventario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Editar Productos en inventario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Desactivar/Activar Productos en inventario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Registrar consumo de productos en inventario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar Inventario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar Producto','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Editar Producto','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Desactivar/Acivar producto ','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar Producto','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar Proveedor','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Editar Proveedor','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Desactivar/Activar Proveedor','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar Proveedores','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Gestionar Productos','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Gestionar Inventario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Gestionar Proveedores','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar Banco','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar Banco','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Modificar Banco','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Activar Desactivar Banco','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar rol','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Modificar rol','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Habilita/Deshabilitar rol','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar rol','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar rol','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar privilegios','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Modificar privilegios','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Habilita/Deshabilitar privilegios','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar privilegios','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar Usuario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Modificar Usuario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Habilita/Deshabilitar Usuario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar Usuario','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Ingresar en el sistema','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Recuperar contraseña','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar cuenta','Activo');
GO
insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Cambiar contraseña','Activo');
GO

insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Agregar tratamiento','Activo');
GO

insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Modificar Tratamiento','Activo');
GO

insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Consultar Tratamiento','Activo');
GO

insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Activar Desactivar Tratamiento','Activo');
GO

insert into [Uricao].[dbo].[Privilegio]
(
[nombrePrivilegio],[estado])
     VALUES 
	('Cambiar contraseña','Activo');
GO

INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (1,
     1)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (1,
     2)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (1,
     3)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (1,
     4)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (1,
     5)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     4)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     6)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     1)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     2)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     7)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     8)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     9)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     10)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     11)
     GO
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     12)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     13)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     14)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     15)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     16)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     9)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     10)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     11)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     13)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     14)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     19)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     19)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     18)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     18)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     21)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     22)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     23)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
    24)
    GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     21)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     22)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     23)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     24)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     25)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (1,
     22)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (1,
     24)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     26)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     26)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     27)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     27)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     28)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     28)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     29)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     29)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     30)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     30)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     31)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     32)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     33)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
    34 )
    GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     35)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     35)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     36)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     37)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     38)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     39)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     40)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     41)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     42)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     43)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     44)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     45)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     46)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     47)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     48)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     49)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     50)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (4,
     51)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     39)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     44)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     49)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     50)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (1,
     54)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
    74)
    GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     75)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (3,
     76)
     GO
     
     INSERT INTO [Uricao].[dbo].[Privilegio_Rol]
           ([fkIdRol],
			[fkIdPrivilegio])
     VALUES
     (5,
     76) 
     GO
     
     INSERT INTO [Uricao].[dbo].[Banco]([nombreBanco],[rifBanco],[estado])VALUES('Mercantil','J-00002961-0','Activo');
GO
INSERT INTO [Uricao].[dbo].[Banco]([nombreBanco],[rifBanco],[estado])VALUES('Banesco','J-00002961-0','Activo');
GO
INSERT INTO [Uricao].[dbo].[Banco]([nombreBanco],[rifBanco],[estado])VALUES('Venezuela','J-00002961-0','Activo');
GO
INSERT INTO [Uricao].[dbo].[Banco]([nombreBanco],[rifBanco],[estado])VALUES('BBVA','J-00002961-0','Activo');
GO
INSERT INTO [Uricao].[dbo].[Banco]([nombreBanco],[rifBanco],[estado])VALUES('Caroni','J-00002961-0','Activo');
GO
INSERT INTO [Uricao].[dbo].[Banco]([nombreBanco],[rifBanco],[estado])VALUES('Caribe','J-00002961-0','Activo');
GO
INSERT INTO [Uricao].[dbo].[Banco]([nombreBanco],[rifBanco],[estado])VALUES('Banfoandes','J-00002961-0','Activo');
GO
INSERT INTO [Uricao].[dbo].[Banco]([nombreBanco],[rifBanco],[estado])VALUES('Plaza','J-00002961-0','Activo');
GO
INSERT INTO [Uricao].[dbo].[Banco]([nombreBanco],[rifBanco],[estado])VALUES('Bicentenario','J-00002961-0','Activo');
GO
INSERT INTO [Uricao].[dbo].[Banco]([nombreBanco],[rifBanco],[estado])VALUES('Corpbanca','J-00002961-0','Activo');
GO




INSERT INTO [Uricao].[dbo].[Tratamiento]
          
          ([nombreTratamiento]
          ,[duracionTratamiento]
          ,[descripccionTratamiento]
          ,[costoTratamiento]
          ,[imagenTratamiento]
          ,[explicacionTratamiento]
          ,[estadoTratamiento])
    VALUES
          ('Primera cita'
          ,1
          ,'Evaluacion del Odontologo para el nuevo paciente'
          ,200
          ,NULL
          ,'El odontologo se encargar? de evaluar al paciente de manera general'
          ,'Activo')
GO

INSERT INTO [Uricao].[dbo].[Tratamiento]
          ([nombreTratamiento]
          ,[duracionTratamiento]
          ,[descripccionTratamiento]
          ,[costoTratamiento]
          ,[imagenTratamiento]
          ,[explicacionTratamiento]
          ,[estadoTratamiento])
    VALUES
          ('Tartrectomia'
          ,2
          ,'Procedimiento mediante el cual se retiran el c?lculo dental (sarro), dep?sitos blandos (placa) y manchas de los dientes' 
          ,480.50
          ,NULL
          ,'Suele realizarse mediante aparatos que producen una vibraci?n a nivel de una punta activa, y es esta vibraci?n la que hace que se desprenda el c?lculo. Son aparatos ultrasonidos, s?nicos o ultras?nicos, dependiendo de la frecuencia de la vibraci?n que se consiga. Despu?s de utilizar los ultrasonidos se suelen pulir las superficies de los dientes utilizando una pasta especial, y gomas o cepillos en un instrumento rotatorio.'
          ,'Activo')
GO

INSERT INTO [Uricao].[dbo].[Tratamiento]
          ([nombreTratamiento]
          ,[duracionTratamiento]
          ,[descripccionTratamiento]
          ,[costoTratamiento]
          ,[imagenTratamiento]
          ,[explicacionTratamiento]
          ,[estadoTratamiento])
    VALUES
          ('Endodoncia'
          ,3
          ,'Consiste en la extirpaci?n parcial o la extirpaci?n total de la pulpa dental'
          ,850
          ,NULL
          ,'Se aplica en piezas dentales fracturadas, con caries profundas o lesionadas en su tejido pulpar'
          ,'Inactivo')
GO
INSERT INTO [Uricao].[dbo].[Tratamiento]
          ([nombreTratamiento]
          ,[duracionTratamiento]
          ,[descripccionTratamiento]
          ,[costoTratamiento]
          ,[imagenTratamiento]
          ,[explicacionTratamiento]
          ,[estadoTratamiento])
    VALUES
          ('Exodoncia'
          ,4
          ,'Extracci?n de diente o muela o porci?n del mismo'
          ,1300
          ,NULL
          ,'Las extracciones requieren solamente de tres elementos: sindesmotomos, f?rceps y elevadores.'
          ,'Activo')
GO

INSERT INTO [Uricao].[dbo].[Tratamiento]
          ([nombreTratamiento]
          ,[duracionTratamiento]
          ,[descripccionTratamiento]
          ,[costoTratamiento]
          ,[imagenTratamiento]
          ,[explicacionTratamiento]
          ,[estadoTratamiento])
    VALUES
          ('Tratamiento de Caries'
          ,1
          ,'Extracci?n de carie en diente o muela'
          ,152.20
          ,NULL
          ,'Limpiar la cavidad resultante de una caries para luego rellenarla con resina o amalgama'
          ,'Activo')
GO

INSERT INTO [Uricao].[dbo].[Tratamiento]
          
          ([nombreTratamiento]
          ,[duracionTratamiento]
          ,[descripccionTratamiento]
          ,[costoTratamiento]
          ,[imagenTratamiento]
          ,[explicacionTratamiento]
          ,[estadoTratamiento])
    VALUES
          ('Blanqueamiento Dental'
          ,1
          ,'Procedimiento de blaqueo de dientes'
          ,250
          ,NULL
          ,'Este proceso incluye el uso cuidadosamente controlado de un gel de per?xido de relativamente alta concentraci?n, que es aplicado a los dientes por el dentista o t?cnico entrenado despu?s de que las enc?as se hayan protegido con un protector de goma.'
          ,'Activo')
GO

/*INSERTS DE LA TABLA TRATAMIENTO_ASOCIADO*/
 INSERT INTO [Uricao].[dbo].[Tratamiento_Asociado]
          ([fkidTratamiento1]
          ,[fkidTratamiento2])
    VALUES
          (5
          ,6)
GO		

INSERT INTO [Uricao].[dbo].[Tratamiento_Asociado]
          ([fkidTratamiento1]
          ,[fkidTratamiento2])
    VALUES
          (5
          ,3)
GO

INSERT INTO [Uricao].[dbo].[Tratamiento_Asociado]
          ([fkidTratamiento1]
          ,[fkidTratamiento2])
    VALUES
          (5
          ,4)
GO


INSERT INTO [Uricao].[dbo].[Tratamiento_Asociado]
          ([fkidTratamiento1]
          ,[fkidTratamiento2])
    VALUES
          (5
          ,2)
GO


INSERT INTO [Uricao].[dbo].[Tratamiento_Asociado]
          ([fkidTratamiento1]
          ,[fkidTratamiento2])
    VALUES
          (3
          ,2)
GO


INSERT INTO [Uricao].[dbo].[Tratamiento_Asociado]
          ([fkidTratamiento1]
          ,[fkidTratamiento2])
    VALUES
          (2
          ,3)
GO


INSERT INTO [Uricao].[dbo].[Tratamiento_Asociado]
          ([fkidTratamiento1]
          ,[fkidTratamiento2])
    VALUES
          (4
          ,3)
GO


INSERT INTO [Uricao].[dbo].[Tratamiento_Asociado]
          ([fkidTratamiento1]
          ,[fkidTratamiento2])
    VALUES
          (4
          ,2)
GO


Insert into Proveedor (rifProveedor, nombreProveedor, fkIdDireccion, estado) values ('J-18028551-0','HiperDental',23,'activo');
Insert into Proveedor (rifProveedor, nombreProveedor, fkIdDireccion, estado) values ('K-21388445-0','Dento Salud Co.',25, 'activo');
Insert into Proveedor (rifProveedor, nombreProveedor, fkIdDireccion, estado) values ('R-15468462-0','Colgate',25, 'activo');


Insert into Contacto (nombreContacto, apellidoContacto, correoContacto, fkidProveedor) values ('Oscar ','Mederos Mesa','omederos@hiperdental.com',1);
Insert into Contacto (nombreContacto, apellidoContacto, correoContacto, fkidProveedor) values ('Maria Eugenia ','Garcia  ','mgarcia331@gmail.com',2);
Insert into Contacto (nombreContacto, apellidoContacto, correoContacto, fkidProveedor) values ('Antonio ','Vega Perz','vegaperz@dentos.com',2);
Insert into Contacto (nombreContacto, apellidoContacto, correoContacto, fkidProveedor) values ('Alfredo ','Villanueva','alfredo@hotmail.com',3);
Insert into Contacto (nombreContacto, apellidoContacto, correoContacto, fkidProveedor) values ('Carlos ','Hernandez','chcarlos@hotmail.com',3);
Insert into Contacto (nombreContacto, apellidoContacto, correoContacto, fkidProveedor) values ('Pedro ','Perez','pperez@outlock.com',3);


Insert into Marca (nombreMarca, fkidProveedor) values ('DentMart',1);
Insert into Marca (nombreMarca, fkidProveedor) values ('VivaDent',2);
Insert into Marca (nombreMarca, fkidProveedor) values ('Gnatus',2);
Insert into Marca (nombreMarca, fkidProveedor) values ('GUM',2);


Insert into Categoria (nombreCategoria) values ('Resinas');
Insert into Categoria (nombreCategoria) values ('Amalgamas');
Insert into Categoria (nombreCategoria) values ('Anestesias');
Insert into Categoria (nombreCategoria) values ('Guantes');
Insert into Categoria (nombreCategoria) values ('Instrumental de examen');


Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Resina restaurador fluido','Producto Medico',10,1);
Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Resina restaurador de posteriores','Producto Medico',5,1);
Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Resina restaurador universal','Producto Medico',2,1);
Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Amalgamas en capsulas','Producto Medico',10,2);
Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Amalgamas en polvo','Producto Medico',10,2);
Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Anestesia tipica','Producto Medico',4,3);
Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Anestesia inyectable','Producto Medico',4,3);
Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Guantes latex','Equipo Medico',20,4);
Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Guantes quirurgicos','Equipo Medico',5,4);
Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Jeringa carpule','Equipo Medico',10,5);
Insert into Producto (nombreProducto, tipoProducto, cantidadMinInventario, fkCategoria) values ('Jeringa yutil','Equipo Medico',3,5);


Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('113421',25,'Alta',1,1);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('334353',20,'Alta',3,2);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('445444',15,'Media',1,3);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('555676',32,'Alta',2,1);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('123153',13,'Baja',4,2);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('778989',43,'Alta',4,4);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('909099',34,'Media',1,4);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('123221',43,'Alta',4,5);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('909022',12,'Alta',4,6);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('213122',14,'Alta',4,7);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('555565',14,'Alta',1,7);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('976334',6,'Alta',3,8);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('353679',5,'Alta',2,8);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('345249',6,'Alta',3,9);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('111111',12,'Alta',1,10);
Insert into Detalle_Producto (codigoProducto, precioProducto, calidadProducto, fkMarca, fkProducto) values ('444444',15,'Alta',1,11);


Insert into Lote (fechaIngresoLote,fechaVencimientoLote, cantidadLote, ubicacionLote, fkidDet_Pro) values ('2012-11-10','2014-12-25',20,'CU-12',1);
Insert into Lote (fechaIngresoLote,fechaVencimientoLote, cantidadLote, ubicacionLote, fkidDet_Pro) values ('2012-11-10','2014-12-30',50,'CU-11',3);
Insert into Lote (fechaIngresoLote,fechaVencimientoLote, cantidadLote, ubicacionLote, fkidDet_Pro) values ('2012-10-12','2020-10-15',30,'U1-3',2);
Insert into Lote (fechaIngresoLote,fechaVencimientoLote, cantidadLote, ubicacionLote, fkidDet_Pro) values ('2012-09-02','2013-11-11',40,'CU-12',1);
Insert into Lote (fechaIngresoLote,fechaVencimientoLote, cantidadLote, ubicacionLote, fkidDet_Pro) values ('2012-10-02','2015-12-11',100,'A-1-2',6);
Insert into Lote (fechaIngresoLote,fechaVencimientoLote, cantidadLote, ubicacionLote, fkidDet_Pro) values ('2012-11-21','2023-01-10',50,'A-1-5',9);
Insert into Lote (fechaIngresoLote,fechaVencimientoLote, cantidadLote, ubicacionLote, fkidDet_Pro) values ('2012-11-21','2023-01-10',30,'A-1-6',10);
Insert into Lote (fechaIngresoLote,fechaVencimientoLote, cantidadLote, ubicacionLote, fkidDet_Pro) values ('2012-11-10','2020-03-03',50,'Repisa 1',12);
Insert into Lote (fechaIngresoLote,fechaVencimientoLote, cantidadLote, ubicacionLote, fkidDet_Pro) values ('2012-11-10','2020-04-03',50,'Repisa 1',13);
Insert into Lote (fechaIngresoLote,fechaVencimientoLote, cantidadLote, ubicacionLote, fkidDet_Pro) values ('2012-11-10','2017-06-05',20,'B-33',14);


Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-10',4);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-10',2);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-10',1);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-10',4);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-11',5);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-11',1);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-11',1);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-13',3);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-14',2);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-17',2);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-18',3);
Insert into Consumo (fkidLote, fechaConsumo, cantidadConsumo) values (4,'2012-11-18',3);


 INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (8
          ,2
          ,1
          ,1)
GO

 INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (6
          ,2
          ,1
          ,1)
GO

 INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (8
          ,3
          ,1
          ,1)
GO

INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (7
          ,3
          ,1
          ,1)
GO

INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (10
          ,3
          ,1
          ,1)
GO

INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (8
          ,4
          ,1
          ,1)
GO
INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (7
          ,4
          ,1
          ,1)
GO

INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (10
          ,4
          ,1
          ,1)
GO

INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (1
          ,4
          ,1
          ,1)
GO

INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (8
          ,5
          ,1
          ,1)
GO


INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (7
          ,5
          ,1
          ,1)
GO


INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (10
          ,5
          ,1
          ,1)
GO


INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (4
          ,5
          ,1
          ,1)
GO


INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (9
          ,6
          ,1
          ,1)
GO


INSERT INTO [Uricao].[dbo].[Tratamiento_Producto]
          ([fkProducto]
          ,[fkTratamiento]
          ,[prioridad_trat_prod]
          ,[cantidad_trat_prod])
    VALUES
          (6
          ,6
          ,2
          ,1)
GO
INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0105-1111-2222-3333-4444'
           ,null
           ,1
           ,'corriente'
           ,'empresa'
           ,null,'activo')
GO

INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0134-1111-2222-3333-4444'
           ,null
           ,2
           ,'maxima'
           ,'empresa'
           ,null,'activo')
GO

INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0102-1111-2222-3333-4444'
           ,null
           ,3
           ,'corriente'
           ,'empresa'
           ,null,'activo')
GO

INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0108-1111-2222-3333-4444'
           ,null
           ,4
           ,'corriente'
           ,'empresa'
           ,null,'activo')
GO

INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0128-1111-2222-3333-4444'
           ,null
           ,5
           ,'maxima'
           ,'empresa'
           ,null,'activo')
GO

INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0114-1111-2222-3333-4444'
           ,null
           ,6
           ,'maxima'
           ,'empresa'
           ,null,'activo')
GO

INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0007-1111-2222-3333-4444'
           ,null
           ,7
           ,'corriente'
           ,'empresa'
           ,null,'activo')
GO

INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0138-1111-2222-3333-4444'
           ,null
           ,8
           ,'maxima'
           ,'empresa'
           ,null,'activo')
GO

INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0175-1111-2222-3333-4444'
           ,null
           ,9
           ,'corriente'
           ,'empresa'
           ,null,'activo')
GO

INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0121-1111-2222-3333-4444'
           ,null
           ,10
           ,'maxima'
           ,'empresa'
           ,null,'activo')
GO

INSERT INTO [Uricao].[dbo].[Cuenta_Bancaria]
           ([numeroCuenta]
           ,[fkIdProveedor]
           ,[fkIdBanco]
           ,[tipoCuenta]
           ,[tipoUso]
           ,[fkIdUsuario],[estado])
     VALUES
           ('0133-1111-2222-3333-4444'
           ,null
           ,10
           ,'corriente'
           ,'empresa'
           ,null,'activo')
GO



insert Cuenta_Bancaria values('201290109',1,1,'corriente','consulta',null,'activo');
insert Cuenta_Bancaria values('029829811',2,1,'corriente','consulta',null,'activo');
insert Cuenta_Bancaria values('020919282',2,2,'ahorro','consulta',null,'activo');
insert Cuenta_Bancaria values('847384001',1,2,'corriente','consulta',null,'activo');
insert Cuenta_Bancaria values('838293929',2,1,'corriente','consulta',null,'activo');
insert Cuenta_Bancaria values('857203983',1,4,'ahorro','consulta',null,'activo');

insert Cuenta_Por_Pagar values('2012/03/12','2012/04/12','credito','activo','proveedor',null,700,12);
insert Cuenta_Por_Pagar values('2012/03/15','2012/05/12','credito','activo','proveedor',null,800,13);
insert Cuenta_Por_Pagar values('2012/03/20','2012/05/12','credito','activo','proveedor',null,900,14);
insert Cuenta_Por_Pagar values('2012/04/05','2012/06/12','credito','activo','proveedor',null,900,15);
insert Cuenta_Por_Pagar values('2012/05/12','2012/07/18','credito','activo','proveedor',null,900,16);
insert Cuenta_Por_Pagar values('2012/05/17','2012/06/17','credito','activo','proveedor',null,900,17);

--CuentaPorCobrar (idCuentaPC , estadoCuentaPC , fkidUsuario)
insert CuentaPorCobrar values('Por Pagar',1);
insert CuentaPorCobrar values('Por Pagar',2);
insert CuentaPorCobrar values('Por Pagar',3);
insert CuentaPorCobrar values('Por Pagar',4);
insert CuentaPorCobrar values('Por Pagar',5);
insert CuentaPorCobrar values('Activa',6);
insert CuentaPorCobrar values('Activa',7);
insert CuentaPorCobrar values('Activa',8);
insert CuentaPorCobrar values('Por Pagar',9);
insert CuentaPorCobrar values('Activa',10);
insert CuentaPorCobrar values('Activa',11);
insert CuentaPorCobrar values('Por Pagar',12);



--Factura (id_Factura , CI_Cliente , nombre_razonsocial, tipo_identificacion, tipoidUser, cedula_rif, fecha, hora, total, fkidDireccion,pagado)

insert Factura values(4,'Arleska Perez','Cedula','V','19720330','2012/10/01','17:25',400,15,0);
insert Factura values(4,'Arleska Perez','Cedula','V','19720330','2012/11/12','17:25',600,15,0);
insert Factura values(4,'Arleska Perez','Cedula','V','19720330','2012/12/12','17:25',800,15,0);
insert Factura values(1,'Carlos Cedeno','Cedula','V','19560012','2012/11/02','7:59',550,15,0);
insert Factura values(1,'Carlos Cedeno','Cedula','V','19560012','2012/11/02','7:59',1000,15,0);
insert Factura values(2,'Yeimy Martinez','Cedula','V','18555202','2012/11/23','11:14',1700,15,0);
insert Factura values(3,'Salvador Delgado','Cedula','V','19154639','2012/11/24','14:31',2600,16,0);
insert Factura values(3,'Salvador Delgado','Cedula','V','19154639','2012/12/10','14:31',600,16,0);
insert Factura values(5,'Jesus Simanca','Cedula','V','17643617','2012/12/09','12:08',230,14,0);
insert Factura values(9,'Karla Rodriguez','Cedula','E','14123456','2012/12/08','12:08',560,14,0);
insert Factura values(12,'Carolina Pereira','Cedula','E','11123456','2012/12/12','12:08',360,14,0);
insert Factura values(15,'Mariana Sosa','Cedula','E','19654231','2012/12/15','12:08',890,14,0);

----Estos Usuarios no se encuentran en la base de datos  
--insert Factura values(6,'Beatriz Rodrguez','RIF',NULL,'J12935761S','16/10/2012','14:39',500,15,1);
--insert Factura values(7,'Carlos Figueredo','RIF',NULL,'J36381929S','17/10/2012','15:31',400,16,1);
--insert Factura values(8,'Julieta Venegas','RIF',NULL,'J63723987S','18/10/2012','17:28',961,15,1);
--insert Factura values(9,'Jesus Perez','RIF',NULL,'J54921376S','19/10/2012','16:50',1700,17,0);
--insert Factura values(10,'Francisco Viterbo','RIF',NULL,'J71926321S','20/10/2012','17:12',2600,16,0);



--/*Abono de cuenta por PAGAR****/

insert Abono values('2012/03/17',200,500,null,1,null);
insert Abono values('2012/04/05',300,200,null,1,null);
insert Abono values('2012/03/30',400,400,null,2,null);
insert Abono values('2012/05/10',300,100,null,2,null);
insert Abono values('2012/03/27',350,550,null,3,null);
insert Abono values('2012/05/08',350,200,null,3,null);
insert Abono values('2012/04/08',100,800,null,4,null);
insert Abono values('2012/06/03',100,700,null,4,null);
insert Abono values('2012/05/15',200,700,null,5,null);
insert Abono values('2012/07/17',200,500,null,5,null);
insert Abono values('2012/05/28',300,600,null,6,null);
insert Abono values('2012/06/09',300,300,null,6,null);

--/*Abono de cuenta por COBRAR(fechaAbono, montoAbono, deuda, fkIdFactura, fkIdCuentaPP, fkIdCuentaPC)*/

insert Abono values('2012/10/27',100,300,1,NULL,4);
insert Abono values('2012/11/30',200,100.5,1,NULL,4);
insert Abono values('2012/12/02',50,50,1,NULL,4);

insert Abono values('2012/09/08',200,400,2,NULL,4);
insert Abono values('2012/09/23',120,280,2,NULL,4);
insert Abono values('2012/08/11',190,90,2,NULL,4);

insert Abono values('2012/07/05',320,480,3,NULL,4);

insert Abono values('2012/09/12',300,250,4,NULL,1);
insert Abono values('2012/08/06',100,150,4,NULL,1);

insert Abono values('2012/06/29',500,500,5,NULL,1);

insert Abono values('2012/10/11',650,1050,6,NULL,2);
insert Abono values('2012/11/03',400,650,6,NULL,2);

insert Abono values('2012/07/15',1300,1300,7,NULL,3);

insert Abono values('2012/09/02',120,480,8,NULL,3);
insert Abono values('2012/10/24',200,280,8,NULL,3);
insert Abono values('2012/11/11',100,180,8,NULL,3);

insert Abono values('2012/10/27',100,130,9,NULL,5);

insert Abono values('2012/08/18',200,360,10,NULL,9);
insert Abono values('2012/05/19',125,235,10,NULL,9);

insert Abono values('2012/09/19',200,160,11,NULL,12);
insert Abono values('2012/12/14',100,60,11,NULL,12);


INSERT INTO Telefono VALUES('0212','1234567','TRABAJO',1,1,1);
INSERT INTO Telefono VALUES('0416','2345678','CELULAR',2,2,2);
INSERT INTO Telefono VALUES('0412','3456789','CELULAR',3,1,3);
INSERT INTO Telefono VALUES('0414','4567890','CELULAR',4,2,1);
INSERT INTO Telefono VALUES('0426','5678901','CELULAR',5,1,2);
INSERT INTO Telefono VALUES('0424','6789012','CELULAR',6,2,3);
INSERT INTO Telefono VALUES('0424','6789012','CELULAR',7,1,1);
INSERT INTO Telefono VALUES('0424','6789012','CELULAR',8,2,2);
INSERT INTO Telefono VALUES('0424','6789012','CELULAR',9,1,3);
INSERT INTO Telefono VALUES('0424','6789012','CELULAR',10,2,1);


INSERT INTO Horario VALUES ('Lunes', 8, 12);
INSERT INTO Horario VALUES ('Lunes', 14, 18);
INSERT INTO Horario VALUES ('Martes', 8, 12);
INSERT INTO Horario VALUES ('Martes', 14, 18);
INSERT INTO Horario VALUES ('Miercoles', 8, 12);
INSERT INTO Horario VALUES ('Miercoles', 14, 18);
INSERT INTO Horario VALUES ('Jueves', 8, 12);
INSERT INTO Horario VALUES ('Jueves', 14, 18);
INSERT INTO Horario VALUES ('Viernes', 8, 12);
INSERT INTO Horario VALUES ('Viernes', 14, 18);


INSERT INTO Usuario_Rol VALUES(7,1);
INSERT INTO Usuario_Rol VALUES(8,2);--este rol es el de auxiliar ya q esta en la tabla usuario como estudiante
INSERT INTO Usuario_Rol VALUES(9,3); 
INSERT INTO Usuario_Rol VALUES(10,4);
INSERT INTO Usuario_Rol VALUES(11,5);
INSERT INTO Usuario_Rol VALUES(12,1);
INSERT INTO Usuario_Rol VALUES(13,2);
INSERT INTO Usuario_Rol VALUES(14,4);
INSERT INTO Usuario_Rol VALUES(15,5);
INSERT INTO Usuario_Rol VALUES(16,3); --este rol es el de auxiliar ya q esta en la tabla usuario como estudiante


INSERT INTO Per_Hor VALUES(7,1);
INSERT INTO Per_Hor VALUES(7,5);
INSERT INTO Per_Hor VALUES(8,2);
INSERT INTO Per_Hor VALUES(8,6);
INSERT INTO Per_Hor VALUES(9,3);
INSERT INTO Per_Hor VALUES(9,7);
INSERT INTO Per_Hor VALUES(10,4);
INSERT INTO Per_Hor VALUES(10,8);
INSERT INTO Per_Hor VALUES(11,1);
INSERT INTO Per_Hor VALUES(11,10);
INSERT INTO Per_Hor VALUES(12,2);
INSERT INTO Per_Hor VALUES(12,9);
INSERT INTO Per_Hor VALUES(13,3);
INSERT INTO Per_Hor VALUES(13,8);
INSERT INTO Per_Hor VALUES(14,4);
INSERT INTO Per_Hor VALUES(14,7);
INSERT INTO Per_Hor VALUES(15,5);
INSERT INTO Per_Hor VALUES(15,6);
INSERT INTO Per_Hor VALUES(16,5);
INSERT INTO Per_Hor VALUES(16,2);
INSERT INTO Per_Hor VALUES(2,1);
INSERT INTO Per_Hor VALUES(2,5);
INSERT INTO Per_Hor VALUES(3,2);
INSERT INTO Per_Hor VALUES(3,6);
INSERT INTO Per_Hor VALUES(17,4);
INSERT INTO Per_Hor VALUES(17,10);


--Presupuesto 

insert Presupuesto values(1,'2012/10/27',2550,'observacion 1');
insert Presupuesto values(2,'2012/10/22',2550,'observacion 2');
insert Presupuesto values(3,'2012/10/27',2550,'observacion 3');
insert Presupuesto values(4,'2012/10/24',2550,'observacion 4');
insert Presupuesto values(5,'2012/10/27',2550,'observacion 5');
insert Presupuesto values(6,'2012/10/27',2550,'observacion 6');
insert Presupuesto values(7,'2012/10/26',2550,'observacion 7');
insert Presupuesto values(8,'2012/10/27',2550,'observacion 8');
insert Presupuesto values(9,'2012/10/12',2550,'observacion 9');
insert Presupuesto values(10,'2012/10/27',2550,'observacion 10');




--Detalle 
/*
insert Detalle values(6,5,250,1,null,null);
insert Detalle values(6,1,250,2,null,null);
insert Detalle values(1,2,200,3,null,null);
insert Detalle values(1,1,200,4,null,null);
insert Detalle values(2,2,480.5,5,null,null);
insert Detalle values(2,3,480.5,6,null,null);
insert Detalle values(3,4,850,7,null,null);
insert Detalle values(3,5,850,8,null,null);
insert Detalle values(4,4,1300,9,null,null);
insert Detalle values(4,8,1300,10,null,null);

insert Detalle values(1,1,200,null,null,1);
insert Detalle values(1,3,200,null,null,2);
insert Detalle values(2,4,480.5,null,null,3);
insert Detalle values(2,2,480.5,null,null,4);
insert Detalle values(3,3,850,null,null,5);
insert Detalle values(3,1,850,null,null,6);
insert Detalle values(4,8,1300,null,null,1);
insert Detalle values(4,2,1300,null,null,2);
insert Detalle values(5,3,152.2,null,null,3);
insert Detalle values(5,4,152.2,null,null,4);

insert Detalle values(4,2,1300,null,null,2);
insert Detalle values(4,3,152.2,null,null,3);
insert Detalle values(4,4,152.2,null,null,4);
*/

insert Detalle values(4,1,200,1,1,1);
insert Detalle values(4,1,250,1,1,6);
insert Detalle values(4,1,1300,1,1,4);

/*------                              INSERTS HISTORIA CLINICA          ---------*/

/***** Inserts HistoriaClinica****/
insert HistoriaClinica values('2012/02/22',1,'El paciente busca mejor sonrisa','activo');
insert HistoriaClinica values('2012/05/04',2,'Se busca alinear dientes','inactivo');
insert HistoriaClinica values('2012/10/12',3,'Paciente no presenta ','inactivo');

/***** Inserts  Atecedente****/
insert Antecedente values('Si',1);
insert Antecedente values('Si',1);
insert Antecedente values('No',1);
insert Antecedente values('No',1);
insert Antecedente values('No',1);
insert Antecedente values('Si',1);
insert Antecedente values('No',1);
insert Antecedente values('Si',1);
insert Antecedente values('Si',1);
insert Antecedente values('No',1);
insert Antecedente values('Si',1);
insert Antecedente values('Si',1);
insert Antecedente values('No',1);
insert Antecedente values('Si',1);
insert Antecedente values('Si',1);
insert Antecedente values('Ninguna',1);
insert Antecedente values('Ninguna',1);
insert Antecedente values('Ninguna',1);
insert Antecedente values('Si',2);
insert Antecedente values('Si',2);
insert Antecedente values('No',2);
insert Antecedente values('Si',2);
insert Antecedente values('Si',2);
insert Antecedente values('No',2);
insert Antecedente values('No',2);
insert Antecedente values('Si',2);
insert Antecedente values('No',2);
insert Antecedente values('No',2);
insert Antecedente values('Si',2);
insert Antecedente values('Si',2);
insert Antecedente values('No',2);
insert Antecedente values('No',2);
insert Antecedente values('Si',2);
insert Antecedente values('Ninguna',2);
insert Antecedente values('Ninguna',2);
insert Antecedente values('Ninguna',2);

/***** Inserts   Odontograma****/
insert Secuencia values('Debe volver en un mes',2,1,'2012/02/22',1,'18','Amalgama','activo');
insert Secuencia values('Debe volver en quince dias',3,1,'2012/05/04',2,'61','Tramo','activo');
insert Secuencia values('Termino su tratamiento',4,1,'2012/10/12',3,'4','Obturacion','activo');
insert Secuencia values('Debe volver en un mes',2,1,'2012/03/22',1,'17','Amalgama','inactivo');
insert Secuencia values('Termino su tratamiento',3,1,'2012/06/04',1,'12','Corona','activo');
insert Secuencia values('Termino su tratamiento',4,1,'2012/11/22',3,'28','Ninguno','inactivo');


/*------------------------- FIN INSERTS HISTORIA CLINICA     ------------------------*/


/***** Inserts    Diagnostico_Historia ****/

insert CITA values ('2012/12/10',8,10,2,1,21,'No Confirmada','Activa');

insert CITA values ('2012/12/12',8,10,2,1,22,'No Confirmada','Activa');

insert CITA values ('2012/12/12',10,12,2,13,22,'No Confirmada','Activa');

insert CITA values ('2012/12/17',14,16,2,1,23,'No Confirmada','Activa');

insert CITA values ('2012/12/17',16,18,2,12,23,'No Confirmada','Activa');

insert CITA values ('2012/12/19',14,16,2,1,24,'No Confirmada','Activa');


insert CITA values ('2013/01/07',8,10,2,1,21,'No Confirmada','Activa');

insert CITA values ('2013/01/07',10,12,2,8,21,'No Confirmada','Activa');

insert CITA values ('2013/01/09',8,10,2,9,22,'No Confirmada','Activa');

insert CITA values ('2013/01/09',10,12,2,11,22,'No Confirmada','Activa');



insert CITA values ('2013/01/08',14,15,5,7,25,'No Confirmada','Activa');

insert CITA values ('2013/01/08',15,16,5,10,25,'No Confirmada','Activa');


insert CITA values ('2013/01/11',14,15,5,15,26,'No Confirmada','Activa');

insert CITA values ('2013/01/11',16,17,5,13,26,'No Confirmada','Activa');



insert CITA values ('2013/01/15',15,16,5,14,25,'No Confirmada','Activa');

insert CITA values ('2013/01/18',16,17,5,4,26,'NoConfirmada','Activa');