--Listar Historial de reportes por defecto:--

SELECT per.RUT,per.DV,per.NOMBRE,per.APELLIDO_PATERNO,per.APELLIDO_MATERNO,
re.ID_REPORTE,re.F_CREACION, re.TIPO_REPORTE FROM persona per,reporte re WHERE 
per.ID_PERSONA = re.ID_PERSONA;

--Listar con filtro de fecha mostrar los datos desde 2013-09-10 hasta 2013-10-24:--

SELECT per.RUT,per.DV,per.NOMBRE,per.APELLIDO_PATERNO,per.APELLIDO_MATERNO,
re.ID_REPORTE,re.F_CREACION, re.TIPO_REPORTE FROM persona per,reporte re WHERE 
 re.F_CREACION >= '2013-09-10' AND re.F_CREACION <= '2013-10-24' AND per.ID_PERSONA = re.ID_PERSONA;

--Listar fechas en la tabla abono desde la mas antigua a la mas nueva ejemplo: primera 2013-06-12, ultima 2013-10-24--

SELECT `ID_REPORTE`,`F_CREACION` FROM `reporte` ORDER BY `F_CREACION`;

--Listar fechas en la tabla abono desde la mas nueva a la mas antigua ejemplo: primera 2013-10-24, ultima 2013-06-12--

SELECT `ID_REPORTE`,`F_CREACION` FROM `reporte` ORDER BY `F_CREACION` DESC;