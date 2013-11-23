/*===================Reporte Pacientes Atendidos====================*/

--Lista las citas por rango de fechas desde 2013-02-01 hasta 2013-10-30--

SELECT  `ID_CITA` ,  `ID_ODONTOLOGO` ,  `ID_PACIENTE` ,  `HORA_DE_INICIO` ,  `HORA_DE_TERMINO` ,  `FECHA` ,  `ESTADO` 
FROM  `cita` WHERE  `FECHA` >=  '2013-02-01' AND  `FECHA` <=  '2013-10-30';

--Listar fechas en la tabla citas desde la mas antigua a la mas nueva ejemplo: primera 1990-10-10, ultima 2013-10-11--

SELECT  `ID_CITA` ,  `FECHA` FROM  `cita` ORDER BY  `FECHA`;

--Listar fechas en la tabla citas desde la mas nueva a la mas antigua ejemplo: primera 2013-10-11 , ultima 1990-10-10--

SELECT  `ID_CITA` ,  `FECHA` FROM  `cita` ORDER BY  `FECHA` DESC;

/*===================Reporte Pacientes Monetarios====================*/

--Listar Abonos por Rango de fecha --

SELECT `ID_ABONO`,`ID_TRATAMIENTO_DENTAL`,`FECHA_DE_ABONO`,`MONTO` 

FROM `abono` WHERE `FECHA_DE_ABONO` >=  '2013-02-01' AND  `FECHA_DE_ABONO` <=  '2013-10-30';


--Listar fechas en la tabla abono desde la mas antigua a la mas nueva ejemplo: primera 1990-10-10, ultima 2013-10-11--

SELECT  `ID_ABONO` ,  `FECHA_DE_ABONO` FROM  `abono` ORDER BY  `FECHA_DE_ABONO`; 

--Listar fechas en la tabla abono desde la mas nueva a la mas antigua ejemplo: primera 2013-10-11 , ultima 1990-10-10--

SELECT  `ID_ABONO` ,  `FECHA_DE_ABONO` FROM  `abono` ORDER BY  `FECHA_DE_ABONO` DESC;


--Listar Gastos por Rango de fecha --

SELECT `ID_GASTOS`,`ID_PERSONA`,`CONCEPTO_GASTO`,`MONTO_GASTOS`,`DESCUENTO_GASTOS`,`FECHA_GASTO` 
FROM `gastos` WHERE `FECHA_GASTO` >=  '2013-02-01' AND  `FECHA_GASTO` <=  '2013-12-30;





