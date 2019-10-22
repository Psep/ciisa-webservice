-- crear base de datos
create database evaluacion3;

--usar base de datos
use evaluacion3;

-- crear tabla de atencion
create table Atencion(
	idAtencion int identity(1,1) Primary Key,
	nombreDoctor varchar(50),
	boxOcupado int,
	fechaAtencion Date,
	pacientesAtendidos int
);

-- insertar datos
insert into dbo.Atencion values ('Edmundo Garcia', 4, '22-10-2019', 19);

-- crear procedimiento de listar por fechas de inicio y término
create procedure sp_findAllAtencion
	@fechaInicio as Date,
	@fechaTermino as Date

	as
		begin
			select a.nombreDoctor, a.boxOcupado, a.fechaAtencion, a.pacientesAtendidos 
			from dbo.Atencion a where a.fechaAtencion between @fechaInicio and @fechaTermino;
end

-- probar sp
exec sp_findAllAtencion '22-10-2019','22-10-2019'