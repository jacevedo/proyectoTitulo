drop database if exists sfh;
create database sfh character set utf8 collate utf8_general_ci;
use sfh;

/*==============================================================*/
/* Table: ABONO                                                 */
/*==============================================================*/
create table abono
(
   ID_ABONO             int not null,
   ID_TRATAMIENTO_DENTAL int,
   FECHA_DE_ABONO       date,
   MONTO                int,
   primary key (ID_ABONO)
);

/*==============================================================*/
/* Table: ACCESOS                                               */
/*==============================================================*/
create table accesos
(
   COD_ACCESO           int not null,
   DESCRIPCION_ACCESO   varchar(50),
   primary key (COD_ACCESO)
);

/*==============================================================*/
/* Table: AREAINSUMO                                            */
/*==============================================================*/
create table areainsumo
(
   ID_AREA_INSUMO       int not null auto_increment,
   NOMBRE_AREA          varchar(50),
   DESCRIPCION_AREA     text,
   primary key (ID_AREA_INSUMO)
);

/*==============================================================*/
/* Table: CITA                                                  */
/*==============================================================*/
create table cita
(
   ID_CITA              int not null,
   ID_ODONTOLOGO        int,
   ID_PACIENTE          int,
   HORA_DE_INICIO       datetime,
   HORA_DE_TERMINO      datetime,
   FECHA                date,
   primary key (ID_CITA)
);

/*==============================================================*/
/* Table: COMUNA                                                */
/*==============================================================*/
create table comuna
(
   ID_COMUNA            int not null,
   ID_REGION            int,
   NOM_COMUNA           varchar(50),
   primary key (ID_COMUNA)
);

/*==============================================================*/
/* Table: DATOSDECONTACTO                                       */
/*==============================================================*/
create table datosdecontacto
(
   ID_PERSONA           int not null,
   ID_COMUNA            int,
   FONO_FIJO            varchar(15),
   FONO_CELULAR         varchar(15),
   DIRECCION            varchar(50),
   MAIL                 varchar(50),
   F_INGRESO            date,
   primary key (ID_PERSONA)
);

/*==============================================================*/
/* Table: FICHADENTAL                                           */
/*==============================================================*/
create table fichadental
(
   ID_FICHA             int not null,
   ID_PACIENTE          int,
   ID_PRESUPUESTO       int,
   ID_ODONTOLOGO        int,
   FECH_INGRESO         date,
   ANAMNESIS            varchar(100),
   primary key (ID_FICHA)
);

/*==============================================================*/
/* Table: FUNCIONARIO                                           */
/*==============================================================*/
create table funcionario
(
   ID_FUNCIONARIO       int not null,
   ID_PERSONA           int,
   PUESTO_DE_TRABAJO    varchar(50),
   primary key (ID_FUNCIONARIO)
);

/*==============================================================*/
/* Table: GASTOS                                                */
/*==============================================================*/
create table gastos
(
   ID_GASTOS            int not null,
   ID_PERSONA           int,
   MONTO_GASTOS         int,
   DESCUENTO_GASTOS     int,
   primary key (ID_GASTOS)
);

/*==============================================================*/
/* Table: INIDICADORES_ECONOMICOS                               */
/*==============================================================*/
create table  inidicadoreseconomicos
(
   ID_INIDICADOR        int not null,
   NOMBRE_INDICADOR     varchar(100),
   VALOR_EN_PESOS       int,
   UNIDAD_DE_MEDIDA     varchar(20),
   primary key (ID_INIDICADOR)
);

/*==============================================================*/
/* Table: INSUMOS                                               */
/*==============================================================*/
create table  insumos
(
   ID_INSUMO            int not null,
   ID_AREA_INSUMO       int,
   ID_GASTOS            int,
   NOMBRE_INSUMO        varchar(50),
   CANTIDAD             float,
   DESCRIPCION_INSUMO   text,
   UNIDAD_DE_MEDIDA     varchar(20),
   primary key (ID_INSUMO)
);

/*==============================================================*/
/* Table: LISTA_PRECIOS                                         */
/*==============================================================*/
create table listaprecios
(
   ID_PRECIOS           int not null auto_increment,
   COMENTARIO           text,
   VALOR_NETO           int,
   primary key (ID_PRECIOS)
);

/*==============================================================*/
/* Table: ODONTOLOGO                                            */
/*==============================================================*/
create table odontologo
(
   ID_ODONTOLOGO        int not null auto_increment,
   ID_PERSONA           int not null,
   ESPECIALIDAD         varchar(50),
   primary key (ID_ODONTOLOGO)
);

/*==============================================================*/
/* Table: ORDEN_DE_LABORATORIO                                  */
/*==============================================================*/
create table ordendelaboratorio
(
   ID_ORDEN_LABORATORIO int not null auto_increment,
   CLINICA              varchar(80),
   BD                   varchar(50),
   BI                   varchar(50),
   PD                   varchar(50),
   PI                   varchar(50),
   FECHA_ENTREGA        date,
   HORA_ENTREGA         time,
   COLOR                varchar(60),
   primary key (ID_ORDEN_LABORATORIO)
);

/*==============================================================*/
/* Table: PACIENTE                                              */
/*==============================================================*/
create table paciente
(
   ID_PACIENTE          int not null,
   ID_PERSONA           int,
   FECHA_INGRESO        date,
   primary key (ID_PACIENTE)
);

/*==============================================================*/
/* Table: PASS                                                  */
/*==============================================================*/
create table pass
(
   ID_PERSONA           int not null,
   PASS                 text,
   FECHA_CADUCIDAD      date,
   primary key (ID_PERSONA)
);

/*==============================================================*/
/* Table: PERFIL                                                */
/*==============================================================*/
create table perfil
(
   ID_PERFIL            int not null,
   NOM_PERFIL           varchar(40),
   primary key (ID_PERFIL)
);

/*==============================================================*/
/* Table: PERMISOS                                              */
/*==============================================================*/
create table permisos
(
   ID_PERFIL            int not null,
   COD_ACCESO           int,
   primary key (ID_PERFIL)
);

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table persona
(
   ID_PERSONA           int  auto_increment,
   ID_PERFIL            int not null,
   RUT                  varchar(11),
   DV                   varchar(1),
   NOMBRE               varchar(50),
   APELLIDO_PATERNO     varchar(50),
   APELLIDO_MATERNO     varchar(50),
   FECHA_NAC            date,
   primary key (ID_PERSONA)
);

/*==============================================================*/
/* Table: PIEZADENTAL                                           */
/*==============================================================*/
create table piezadental
(
   ID_PIEZA             int not null,
   ID_TRATAMIENTO_DENTAL int,
   ID_ORDEN_LABORATORIO int,
   ID_TIPO_PIEZA        int,
   NOMBRE_PIEZA         varchar(50),
   DESCRIPCION_PIEZA    text,
   PERIODO_PIEZA        int,
   primary key (ID_PIEZA)
);

/*==============================================================*/
/* Table: PRESUPUESTO                                           */
/*==============================================================*/
create table presupuesto
(
   ID_PRESUPUESTO       int not null,
   VALORTOTAL           int,
   primary key (ID_PRESUPUESTO)
);

/*==============================================================*/
/* Table: REGION                                                */
/*==============================================================*/
create table region
(
   ID_REGION            int not null,
   NOM_REGION           varchar(50),
   NUM_REGION_ROMANO    varchar(4),
   primary key (ID_REGION)
);

/*==============================================================*/
/* Table: REPORTE                                               */
/*==============================================================*/
create table reporte
(
   ID_REPORTE           int not null,
   ID_PERSONA           int,
   F_CREACION           date,
   TIPO_REPORTE         varchar(50),
   primary key (ID_REPORTE)
);

/*==============================================================*/
/* Table: TIPODEPIEZA                                           */
/*==============================================================*/
create table tipodepieza
(
   ID_TIPO_PIEZA        int not null,
   NOMBRE_CIENTIFICO_PIEZA varchar(100),
   DESCRIPCION          text,
   primary key (ID_TIPO_PIEZA)
);

/*==============================================================*/
/* Table: TRATAMIENTODENTAL                                     */
/*==============================================================*/
create table tratamientodental
(
   ID_TRATAMIENTO_DENTAL int not null,
   ID_FICHA             int,
   FECH_CREACION        date,
   TRATAMIENTO          text,
   FECHA_SEGUIMIENTO    date,
   VALOR_TOTAL          int,
   primary key (ID_TRATAMIENTO_DENTAL)
);

/*==============================================================*/
/* Table: VERSION                                               */
/*==============================================================*/
create table version
(
   ID_VERSION           int not null,
   NOM_VERSION          varchar(50),
   COMENTARIO           text,
   primary key (ID_VERSION)
);

alter table abono add constraint FK_ABONO_TRATAMIENTO foreign key (ID_TRATAMIENTO_DENTAL)
      references tratamientodental (ID_TRATAMIENTO_DENTAL) on delete restrict on update restrict;

alter table cita add constraint FK_CITA_ODONTOLOGO foreign key (ID_ODONTOLOGO)
      references odontologo (ID_ODONTOLOGO) on delete restrict on update restrict;

alter table cita add constraint FK_CITA_PACIENTE foreign key (ID_PACIENTE)
      references paciente (ID_PACIENTE) on delete restrict on update restrict;

alter table comuna add constraint FK_COMUNA_REGION foreign key (ID_REGION)
      references region (ID_REGION) on delete restrict on update restrict;

alter table datosdecontacto add constraint FK_CONTACTO_COMUNA foreign key (ID_COMUNA)
      references comuna (ID_COMUNA) on delete restrict on update restrict;

alter table datosdecontacto add constraint FK_CONTACTO_PERSONA foreign key (ID_PERSONA)
      references persona (ID_PERSONA) on delete restrict on update restrict;

alter table fichadental add constraint FK_FICHA_ODONTOLOGO foreign key (ID_ODONTOLOGO)
      references odontologo (ID_ODONTOLOGO) on delete restrict on update restrict;

alter table fichadental add constraint FK_FICHA_PACIENTE foreign key (ID_PACIENTE)
      references paciente (ID_PACIENTE) on delete restrict on update restrict;

alter table fichadental add constraint FK_FICHA_PRESUPUESTO foreign key (ID_PRESUPUESTO)
      references presupuesto (ID_PRESUPUESTO) on delete restrict on update restrict;

alter table funcionario add constraint FK_FUNCIONARIO_PERSONA foreign key (ID_PERSONA)
      references persona (ID_PERSONA) on delete restrict on update restrict;

alter table gastos add constraint FK_GASTOS_PERSONA foreign key (ID_PERSONA)
      references persona (ID_PERSONA) on delete restrict on update restrict;

alter table insumos add constraint FK_INSUMOS_AREAINSUMO foreign key (ID_AREA_INSUMO)
      references areainsumo (ID_AREA_INSUMO) on delete restrict on update restrict;

alter table insumos add constraint FK_INSUMOS_GASTOS foreign key (ID_GASTOS)
      references gastos (ID_GASTOS) on delete restrict on update restrict;

alter table odontologo add constraint FK_MEDICO_PERSONA foreign key (ID_PERSONA)
      references persona (ID_PERSONA) on delete restrict on update restrict;

alter table paciente add constraint FK_PACIENTE_PERSONA foreign key (ID_PERSONA)
      references persona (ID_PERSONA) on delete restrict on update restrict;

alter table pass add constraint FK_PASS_PERSONA foreign key (ID_PERSONA)
      references persona (ID_PERSONA) on delete restrict on update restrict;

alter table permisos add constraint FK_PERMISOS_ACCESOS foreign key (COD_ACCESO)
      references accesos (COD_ACCESO) on delete restrict on update restrict;

alter table permisos add constraint FK_PERMISOS_PERFIL foreign key (ID_PERFIL)
      references perfil (ID_PERFIL) on delete restrict on update restrict;

alter table persona add constraint FK_PERSONA_PERFIL foreign key (ID_PERFIL)
      references perfil (ID_PERFIL) on delete restrict on update restrict;

alter table piezadental add constraint FK_PIEZA_DENTAL foreign key (ID_TRATAMIENTO_DENTAL)
      references tratamientodental (ID_TRATAMIENTO_DENTAL) on delete restrict on update restrict;

alter table piezadental add constraint FK_PIEZA_ORDEN foreign key (ID_ORDEN_LABORATORIO)
      references ordendelaboratorio (ID_ORDEN_LABORATORIO) on delete restrict on update restrict;

alter table piezadental add constraint FK_PIEZA_TIPOPIEZA foreign key (ID_TIPO_PIEZA)
      references tipodepieza (ID_TIPO_PIEZA) on delete restrict on update restrict;

alter table reporte add constraint FK_REPORTE_PERSONA foreign key (ID_PERSONA)
      references persona (ID_PERSONA) on delete restrict on update restrict;

alter table tratamientodental add constraint FK_TRATAMIENTO_FICHA foreign key (ID_FICHA)
      references fichadental (ID_FICHA) on delete restrict on update restrict;
	  
	  
/*==============================================================*/
/* Index: INDEX_ABONO_1                                         */
/*==============================================================*/
create index INDEX_ABONO_1 on abono
(
   ID_TRATAMIENTO_DENTAL
);

/*==============================================================*/
/* Index: INDEX_CITA_1                                          */
/*==============================================================*/
create index INDEX_CITA_1 on cita
(
   ID_ODONTOLOGO
);

/*==============================================================*/
/* Index: INDEX_CITA_2                                          */
/*==============================================================*/
create index INDEX_CITA_2 on cita
(
   ID_PACIENTE
);

/*==============================================================*/
/* Index: INDEX_COMUNA_1                                        */
/*==============================================================*/
create index INDEX_COMUNA_1 on comuna
(
   ID_REGION
);

/*==============================================================*/
/* Index: INDEX_DATOSDECONTACTO_1                               */
/*==============================================================*/
create index INDEX_DATOSDECONTACTO_1 on datosdecontacto
(
   ID_COMUNA
);

/*==============================================================*/
/* Index: INDEX_FICHADENTAL_1                                   */
/*==============================================================*/
create index INDEX_FICHADENTAL_1 on fichadental
(
   ID_PACIENTE
);

/*==============================================================*/
/* Index: INDEX_FICHADENTAL_2                                   */
/*==============================================================*/
create index INDEX_FICHADENTAL_2 on fichadental
(
   ID_PRESUPUESTO
);

/*==============================================================*/
/* Index: INDEX_FICHADENTAL_3                                   */
/*==============================================================*/
create index INDEX_FICHADENTAL_3 on fichadental
(
   ID_ODONTOLOGO
);

/*==============================================================*/
/* Index: INDEX_FUNCIONARIO_1                                   */
/*==============================================================*/
create index INDEX_FUNCIONARIO_1 on funcionario
(
   ID_PERSONA
);

/*==============================================================*/
/* Index: INDEX_GASTOS_1                                        */
/*==============================================================*/
create index INDEX_GASTOS_1 on gastos
(
   ID_PERSONA
);

/*==============================================================*/
/* Index: INDEX_INSUMOS_1                                       */
/*==============================================================*/
create index INDEX_INSUMOS_1 on insumos
(
   ID_AREA_INSUMO
);

/*==============================================================*/
/* Index: INDEX_INSUMOS_2                                       */
/*==============================================================*/
create index INDEX_INSUMOS_2 on insumos
(
   ID_GASTOS
);

/*==============================================================*/
/* Index: INDEX_ODONTOLOGO_1                                    */
/*==============================================================*/
create index INDEX_ODONTOLOGO_1 on odontologo
(
   ID_PERSONA
);

/*==============================================================*/
/* Index: INDEX_PACIENTE_1                                      */
/*==============================================================*/
create index INDEX_PACIENTE_1 on paciente
(
   ID_PERSONA
);

/*==============================================================*/
/* Index: INDEX_PERMISOS_1                                      */
/*==============================================================*/
create index INDEX_PERMISOS_1 on permisos
(
   COD_ACCESO
);

/*==============================================================*/
/* Index: INDEX_PERSONA_1                                       */
/*==============================================================*/
create index INDEX_PERSONA_1 on persona
(
   ID_PERFIL
);

/*==============================================================*/
/* Index: INDEX_PIEZADENTAL_1                                   */
/*==============================================================*/
create index INDEX_PIEZADENTAL_1 on piezadental
(
   ID_TRATAMIENTO_DENTAL
);

/*==============================================================*/
/* Index: INDEX_PIEZADENTAL_2                                   */
/*==============================================================*/
create index INDEX_PIEZADENTAL_2 on piezadental
(
   ID_ORDEN_LABORATORIO
);

/*==============================================================*/
/* Index: INDEX_PIEZADENTAL_3                                   */
/*==============================================================*/
create index INDEX_PIEZADENTAL_3 on piezadental
(
   ID_TIPO_PIEZA
);

/*==============================================================*/
/* Index: INDEX_REPORTE_1                                       */
/*==============================================================*/
create index INDEX_REPORTE_1 on reporte
(
   ID_PERSONA
);

/*==============================================================*/
/* Index: INDEX_TRATAMIENODENTAL_1                              */
/*==============================================================*/
create index INDEX_TRATAMIENODENTAL_1 on tratamientodental
(
   ID_FICHA
);


/*==============================================================*/
/* POBLAMIENTO DE DATOS SFH VERSION                             */
/*==============================================================*/


INSERT INTO `version`(`ID_VERSION`, `NOM_VERSION`, `COMENTARIO`) VALUES (1,'SFH - Sistema de toma de horas y fichas medicas v 1.0 Alfa','
SFH - Primera versión de desarrollo.');

INSERT INTO `inidicadoreseconomicos`(`ID_INIDICADOR`, `NOMBRE_INDICADOR`, `VALOR_EN_PESOS`, `UNIDAD_DE_MEDIDA`) VALUES (1,'UF',23.007,'Pesos Chilenos');
INSERT INTO `inidicadoreseconomicos`(`ID_INIDICADOR`, `NOMBRE_INDICADOR`, `VALOR_EN_PESOS`, `UNIDAD_DE_MEDIDA`) VALUES (2,'DOLAR OBSERVADO($)',510,'Pesos Chilenos');
INSERT INTO `inidicadoreseconomicos`(`ID_INIDICADOR`, `NOMBRE_INDICADOR`, `VALOR_EN_PESOS`, `UNIDAD_DE_MEDIDA`) VALUES (3,'UTM',40.326,'Pesos Chilenos');
INSERT INTO `inidicadoreseconomicos`(`ID_INIDICADOR`, `NOMBRE_INDICADOR`, `VALOR_EN_PESOS`, `UNIDAD_DE_MEDIDA`) VALUES (4,'YEN JAPONES',5,'Pesos Chilenos');
INSERT INTO `inidicadoreseconomicos`(`ID_INIDICADOR`, `NOMBRE_INDICADOR`, `VALOR_EN_PESOS`, `UNIDAD_DE_MEDIDA`) VALUES (5,'EURO',613,'Pesos Chilenos');

INSERT INTO `accesos`(`COD_ACCESO`, `DESCRIPCION_ACCESO`) VALUES (707,'Usuario administrador: Posee las credenciales necesarias 
para manejar cada uno de los módulos que posee SFH. 
Advertencia: Solo el encargado de este sistema debe poseer este perfil.');
INSERT INTO `accesos`(`COD_ACCESO`, `DESCRIPCION_ACCESO`) VALUES (706,'Usuario Doctor: Posee las credenciales necesarias para 
manejar cada uno de los módulos asociados a la clínica y pacientes.');
INSERT INTO `accesos`(`COD_ACCESO`, `DESCRIPCION_ACCESO`) VALUES (705,'Usuario Asistente: Posee las credenciales necesarias 
para manejar los módulos asociados a la administración de pacientes.');
INSERT INTO `accesos`(`COD_ACCESO`, `DESCRIPCION_ACCESO`) VALUES (704,'Usuario Paciente: Posee las credenciales necesarias 
para acceder al modulo para pacientes de la clínica.');

INSERT INTO  `perfil` (`ID_PERFIL` ,`NOM_PERFIL`) VALUES (1,'Administrador');
INSERT INTO  `perfil` (`ID_PERFIL` ,`NOM_PERFIL`) VALUES (2,'Doctor');
INSERT INTO  `perfil` (`ID_PERFIL` ,`NOM_PERFIL`) VALUES (3,'Asistente');
INSERT INTO  `perfil` (`ID_PERFIL` ,`NOM_PERFIL`) VALUES (4,'Paciente');

INSERT INTO `permisos`(`ID_PERFIL`, `COD_ACCESO`) VALUES (1,707);
INSERT INTO `permisos`(`ID_PERFIL`, `COD_ACCESO`) VALUES (2,706);
INSERT INTO `permisos`(`ID_PERFIL`, `COD_ACCESO`) VALUES (3,705);
INSERT INTO `permisos`(`ID_PERFIL`, `COD_ACCESO`) VALUES (4,704);

INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '1', '17231233', '2', 'Ada', 'Tatus', 'Boren', '1991-08-06');
INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '2', '12323123', '3', 'Juan', 'Peres', 'Peres', '1992-08-11');
INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '3', '9878987', '4', 'Nicolas', 'Palma', 'Silva', '1987-05-27');
INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '4', '3272373', '2', 'Jose', 'Muñoz', 'Lopez', '1989-02-03');
INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '2', '17901230', '2', 'Viviana', 'Garrido', 'Sanchez', '1988-02-08');
INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '3', '17899006', '3', 'Lilia', 'Madrid', 'Sepulveda', '1988-01-09');
INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '4', '16009332', '8', 'Lissete', 'Salcedo', 'Taiba', '1987-12-08');
INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '4', '6336666', 'k', 'Patricia', 'Sanchez', 'Pavez', '1959-09-08');
INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '4', '18992457', 'k', 'Daniela', 'Paredes', 'Chamorro', '1988-04-29');
INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '2', '15725009', '0', 'Camila', 'Carrizo', 'Pacheco', '1983-05-19');
INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES (NULL, '2', '19746228', '7', 'Pedro', 'Lopez', 'Moya', '1993-12-04');

INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (15,'REGIÓN DE ARICA Y PARINACOTA','XV');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (1,'REGIÓN DE TARAPACÁ','I');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (2,'REGIÓN DE ANTOFAGASTA','II');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (3,'REGIÓN DE ATACAMA','III');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (4,'REGIÓN DE COQUIMBO','IV');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (5,'REGIÓN DE VALPARAISO','V');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (13,'REGIÓN METROPOLITANA','XIII');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (6,'REGIÓN DEL LIBERTADOR GENERAL BERNARDO O HIGGINS','VI');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (7,'REGIÓN DEL MAULE','VII');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (8,'REGIÓN DEL BÍO - BÍO','VIII');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (9,'REGIÓN DE LA ARAUCANÍA','IX');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (14,'REGION DE LOS RÍOS','XIV');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (10,'REGIÓN DE LOS LAGOS','X');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (11,'REGIÓN AYSÉN DEL GENERAL CARLOS IBÁÑEZ DEL CAMPO','XI');
INSERT INTO `region` (`ID_REGION`,`NOM_REGION`,`NUM_REGION_ROMANO`) VALUES (12,'REGIÓN DE MAGALLANES Y LA ANTÁRTICA CHILENA ','XII');

INSERT INTO `comuna` (`ID_COMUNA`, `ID_REGION`, `NOM_COMUNA`) VALUES
(1, 15, 'Arica'),
(2, 15, 'Camarones'),
(3, 15, 'Putre'),
(4, 15, 'General Lagos'),
(5, 1, 'Iquique'),
(6, 1, 'Alto Hospicio'),
(7, 1, 'Pozo Almonte'),
(8, 1, 'Camiña'),
(9, 1, 'Colchane'),
(10, 1, 'Huara'),
(11, 1, 'Pica'),
(12, 2, 'Antofagasta'),
(13, 2, 'Mejillones'),
(14, 2, 'Sierra Gorda'),
(15, 2, 'Taltal'),
(16, 2, 'Calama'),
(17, 2, 'Ollagüe'),
(18, 2, 'San Pedro de Atacama'),
(19, 2, 'Tocopilla'),
(20, 2, 'María Elena'),
(21, 3, 'Copiapó'),
(22, 3, 'Caldera'),
(23, 3, 'Tierra Amarilla'),
(24, 3, 'Chañaral'),
(25, 3, 'Diego de Almagro'),
(26, 3, 'Vallenar'),
(27, 3, 'Alto del Carmen'),
(28, 3, 'Freirina'),
(29, 3, 'Huasco'),
(30, 4, 'La Serena'),
(31, 4, 'Coquimbo'),
(32, 4, 'Andacollo'),
(33, 4, 'La Higuera'),
(34, 4, 'Paiguano'),
(35, 4, 'Vicuña'),
(36, 4, 'Illapel'),
(37, 4, 'Canela'),
(38, 4, 'Los Vilos'),
(39, 4, 'Salamanca'),
(40, 4, 'Ovalle'),
(41, 4, 'Combarbalá'),
(42, 4, 'Monte Patria'),
(43, 4, 'Punitaqui'),
(44, 4, 'Río Hurtado'),
(45, 5, 'Valparaíso'),
(46, 5, 'Casablanca'),
(47, 5, 'Concón'),
(48, 5, 'Juan Fernández'),
(49, 5, 'Puchuncaví'),
(50, 5, 'Quilpué'),
(51, 5, 'Quintero'),
(52, 5, 'Villa Alemana'),
(53, 5, 'Viña del Mar'),
(54, 5, 'Isla de Pascua'),
(55, 5, 'Los Andes'),
(56, 5, 'Calle Larga'),
(57, 5, 'Rinconada'),
(58, 5, 'San Esteban'),
(59, 5, 'La Ligua'),
(60, 5, 'Cabildo'),
(61, 5, 'Papudo'),
(62, 5, 'Petorca'),
(63, 5, 'Zapallar'),
(64, 5, 'Quillota'),
(65, 5, 'La Calera'),
(66, 5, 'Hijuelas'),
(67, 5, 'La Cruz'),
(68, 5, 'Limache'),
(69, 5, 'Nogales'),
(70, 5, 'Olmué'),
(71, 5, 'San Antonio'),
(72, 5, 'Algarrobo'),
(73, 5, 'Cartagena'),
(74, 5, 'El Quisco'),
(75, 5, 'El Tabo'),
(76, 5, 'Santo Domingo'),
(77, 5, 'San Felipe'),
(78, 5, 'Catemu'),
(79, 5, 'Llaillay'),
(80, 5, 'Panquehue'),
(81, 5, 'Putaendo'),
(82, 5, 'Santa María'),
(83, 6, 'Rancagua'),
(84, 6, 'Codegua'),
(85, 6, 'Coinco'),
(86, 6, 'Coltauco'),
(87, 6, 'Doñihue'),
(88, 6, 'Graneros'),
(89, 6, 'Las Cabras'),
(90, 6, 'Machalí'),
(91, 6, 'Malloa'),
(92, 6, 'Mostazal'),
(93, 6, 'Olivar'),
(94, 6, 'Peumo'),
(95, 6, 'Pichidegua'),
(96, 6, 'Quinta de Tilcoco'),
(97, 6, 'Rengo'),
(98, 6, 'Requínoa'),
(99, 6, 'San Vicente'),
(100, 6, 'Pichilemu'),
(101, 6, 'La Estrella'),
(102, 6, 'Litueche'),
(103, 6, 'Marchihue'),
(104, 6, 'Navidad'),
(105, 6, 'Paredones'),
(106, 6, 'San Fernando'),
(107, 6, 'Chépica'),
(108, 6, 'Chimbarongo'),
(109, 6, 'Lolol'),
(110, 6, 'Nancagua'),
(111, 6, 'Palmilla'),
(112, 6, 'Peralillo'),
(113, 6, 'Placilla'),
(114, 6, 'Pumanque'),
(115, 6, 'Santa Cruz'),
(116, 7, 'Talca'),
(117, 7, 'Constitución'),
(118, 7, 'Curepto'),
(119, 7, 'Empedrado'),
(120, 7, 'Maule'),
(121, 7, 'Pelarco'),
(122, 7, 'Pencahue'),
(123, 7, 'Río Claro'),
(124, 7, 'San Clemente'),
(125, 7, 'San Rafael'),
(126, 7, 'Cauquenes'),
(127, 7, 'Chanco'),
(128, 7, 'Pelluhue'),
(129, 7, 'Curicó'),
(130, 7, 'Hualañé'),
(131, 7, 'Licantén'),
(132, 7, 'Molina'),
(133, 7, 'Rauco'),
(134, 7, 'Romeral'),
(135, 7, 'Sagrada Familia'),
(136, 7, 'Teno'),
(137, 7, 'Vichuquén'),
(138, 7, 'Linares'),
(139, 7, 'Colbún'),
(140, 7, 'Longaví'),
(141, 7, 'Parral'),
(142, 7, 'Retiro'),
(143, 7, 'San Javier'),
(144, 7, 'Villa Alegre'),
(145, 7, 'Yerbas Buenas'),
(146, 8, 'Concepción'),
(147, 8, 'Coronel'),
(148, 8, 'Chiguayante'),
(149, 8, 'Florida'),
(150, 8, 'Hualqui'),
(151, 8, 'Lota'),
(152, 8, 'Penco'),
(153, 8, 'San Pedro de la Paz'),
(154, 8, 'Santa Juana'),
(155, 8, 'Talcahuano'),
(156, 8, 'Tomé'),
(157, 8, 'Hualpén'),
(158, 8, 'Lebu'),
(159, 8, 'Arauco'),
(160, 8, 'Cañete'),
(161, 8, 'Contulmo'),
(162, 8, 'Curanilahue'),
(163, 8, 'Los Alamos'),
(164, 8, 'Tirúa'),
(165, 8, 'Los Angeles'),
(166, 8, 'Antuco'),
(167, 8, 'Cabrero'),
(168, 8, 'Laja'),
(169, 8, 'Mulchén'),
(170, 8, 'Nacimiento'),
(171, 8, 'Negrete'),
(172, 8, 'Quilaco'),
(173, 8, 'Quilleco'),
(174, 8, 'San Rosendo'),
(175, 8, 'Santa Bárbara'),
(176, 8, 'Tucapel'),
(177, 8, 'Yumbel'),
(178, 8, 'Alto Biobío'),
(179, 8, 'Chillán'),
(180, 8, 'Bulnes'),
(181, 8, 'Cobquecura'),
(182, 8, 'Coelemu'),
(183, 8, 'Coihueco'),
(184, 8, 'Chillán Viejo'),
(185, 8, 'El Carmen'),
(186, 8, 'Ninhue'),
(187, 8, 'Ñiquén'),
(188, 8, 'Pemuco'),
(189, 8, 'Pinto'),
(190, 8, 'Portezuelo'),
(191, 8, 'Quillón'),
(192, 8, 'Quirihue'),
(193, 8, 'Ránquil'),
(194, 8, 'San Carlos'),
(195, 8, 'San Fabián'),
(196, 8, 'San Ignacio'),
(197, 8, 'San Nicolás'),
(198, 8, 'Treguaco'),
(199, 8, 'Yungay'),
(200, 9, 'Temuco'),
(201, 9, 'Carahue'),
(202, 9, 'Cunco'),
(203, 9, 'Curarrehue'),
(204, 9, 'Freire'),
(205, 9, 'Galvarino'),
(206, 9, 'Gorbea'),
(207, 9, 'Lautaro'),
(208, 9, 'Loncoche'),
(209, 9, 'Melipeuco'),
(210, 9, 'Nueva Imperial'),
(211, 9, 'Padre Las Casas'),
(212, 9, 'Perquenco'),
(213, 9, 'Pitrufquén'),
(214, 9, 'Pucón'),
(215, 9, 'Saavedra'),
(216, 9, 'Teodoro Schmidt'),
(217, 9, 'Toltén'),
(218, 9, 'Vilcún'),
(219, 9, 'Villarrica'),
(220, 9, 'Cholchol'),
(221, 9, 'Angol'),
(222, 9, 'Collipulli'),
(223, 9, 'Curacautín'),
(224, 9, 'Ercilla'),
(225, 9, 'Lonquimay'),
(226, 9, 'Los Sauces'),
(227, 9, 'Lumaco'),
(228, 9, 'Purén'),
(229, 9, 'Renaico'),
(230, 9, 'Traiguén'),
(231, 9, 'Victoria'),
(232, 14, 'Valdivia'),
(233, 14, 'Corral'),
(234, 14, 'Lanco'),
(235, 14, 'Los Lagos'),
(236, 14, 'Máfil'),
(237, 14, 'Mariquina'),
(238, 14, 'Paillaco'),
(239, 14, 'Panguipulli'),
(240, 14, 'La Unión'),
(241, 14, 'Futrono'),
(242, 14, 'Lago Ranco'),
(243, 14, 'Río Bueno'),
(244, 10, 'Puerto Montt'),
(245, 10, 'Calbuco'),
(246, 10, 'Cochamó'),
(247, 10, 'Fresia'),
(248, 10, 'Frutillar'),
(249, 10, 'Los Muermos'),
(250, 10, 'Llanquihue'),
(251, 10, 'Maullín'),
(252, 10, 'Puerto Varas'),
(253, 10, 'Castro'),
(254, 10, 'Ancud'),
(255, 10, 'Chonchi'),
(256, 10, 'Curaco de Vélez'),
(257, 10, 'Dalcahue'),
(258, 10, 'Puqueldón'),
(259, 10, 'Queilén'),
(260, 10, 'Quellón'),
(261, 10, 'Quemchi'),
(262, 10, 'Quinchao'),
(263, 10, 'Osorno'),
(264, 10, 'Puerto Octay'),
(265, 10, 'Purranque'),
(266, 10, 'Puyehue'),
(267, 10, 'Río Negro'),
(268, 10, 'San Juan de la Costa'),
(269, 10, 'San Pablo'),
(270, 10, 'Chaitén'),
(271, 10, 'Futaleufú'),
(272, 10, 'Hualaihué'),
(273, 10, 'Palena'),
(274, 11, 'Coihaique'),
(275, 11, 'Lago Verde'),
(276, 11, 'Aisén'),
(277, 11, 'Cisnes'),
(278, 11, 'Guaitecas'),
(279, 11, 'Cochrane'),
(280, 11, 'OHiggins'),
(281, 11, 'Tortel'),
(282, 11, 'Chile Chico'),
(283, 11, 'Río Ibáñez'),
(284, 12, 'Punta Arenas'),
(285, 12, 'Laguna Blanca'),
(286, 12, 'Río Verde'),
(287, 12, 'San Gregorio'),
(288, 12, 'Cabo de Hornos (Ex-Navarino)'),
(289, 12, 'Antártica'),
(290, 12, 'Porvenir'),
(291, 12, 'Primavera'),
(292, 12, 'Timaukel'),
(293, 12, 'Puerto Natales'),
(294, 12, 'Torres del Paine'),
(295, 13, 'Santiago'),
(296, 13, 'Cerrillos'),
(297, 13, 'Cerro Navia'),
(298, 13, 'Conchalí'),
(299, 13, 'El Bosque'),
(300, 13, 'Estación Central'),
(301, 13, 'Huechuraba'),
(302, 13, 'Independencia'),
(303, 13, 'La Cisterna'),
(304, 13, 'La Florida'),
(305, 13, 'La Granja'),
(306, 13, 'La Pintana'),
(307, 13, 'La Reina'),
(308, 13, 'Las Condes'),
(309, 13, 'Lo Barnechea'),
(310, 13, 'Lo Espejo'),
(311, 13, 'Lo Prado'),
(312, 13, 'Macul'),
(313, 13, 'Maipú'),
(314, 13, 'Ñuñoa'),
(315, 13, 'Pedro Aguirre Cerda'),
(316, 13, 'Peñalolén'),
(317, 13, 'Providencia'),
(318, 13, 'Pudahuel'),
(319, 13, 'Quilicura'),
(320, 13, 'Quinta Normal'),
(321, 13, 'Recoleta'),
(322, 13, 'Renca'),
(323, 13, 'San Joaquín'),
(324, 13, 'San Miguel'),
(325, 13, 'San Ramón'),
(326, 13, 'Vitacura'),
(327, 13, 'Puente Alto'),
(328, 13, 'Pirque'),
(329, 13, 'San José de Maipú'),
(330, 13, 'Colina'),
(331, 13, 'Lampa'),
(332, 13, 'Tiltil'),
(333, 13, 'San Bernardo'),
(334, 13, 'Buin'),
(335, 13, 'Calera de Tango'),
(336, 13, 'Paine'),
(337, 13, 'Melipilla'),
(338, 13, 'Alhué'),
(339, 13, 'Curacaví'),
(340, 13, 'María Pinto'),
(341, 13, 'San Pedro'),
(342, 13, 'Talagante'),
(343, 13, 'El Monte'),
(344, 13, 'Isla de Maipo'),
(345, 13, 'Padre Hurtado'),
(346, 13, 'Peñaflor');


INSERT INTO  `gastos` (`ID_GASTOS` ,`ID_PERSONA` ,`MONTO_GASTOS` ,`DESCUENTO_GASTOS`) VALUES ('1', '1', '40000', '30000');
INSERT INTO  `gastos` (`ID_GASTOS` ,`ID_PERSONA` ,`MONTO_GASTOS` ,`DESCUENTO_GASTOS`) VALUES ('2', '1', '30000', '40000');
INSERT INTO  `gastos` (`ID_GASTOS` ,`ID_PERSONA` ,`MONTO_GASTOS` ,`DESCUENTO_GASTOS`) VALUES ('3', '1', '40000', '30000');

insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null, "Examen Inicial,Plan De Tratamiento Y Presupuesto",21750);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Control Y Examen Periodico De Rigor",14500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Interconsulta Con Informe Escrito 1 Sesion",29000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Urgencia. Tratamiento Inicial 1 Sesion",14500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Urgencia A Domicilio Id. Anterior",29000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Urgencia En Hospital Id. Anterior",29000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Estudio Preliminar Clinico, Rx Y Modelos",29000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Informes Periciales 1 Hora Profesional",43500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Consultorias Y Estudio Profesional: 1 Hora",43500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Higiene O Profilaxis En Adultos",29000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Higiene O Profilaxis En Niños",14500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Instrucción Y Control Higiene Oral Adultos",14500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Instrucción Y Control Higiene Oral Niños",14500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Aplicación De Fluor En Colutorios (trat)",14500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Aplicación Fluor Gel Total Niños Y Adultos",14500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Aplicación Fluor Total Silano  ID",72500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Aplicación Sellante Pieza Temp. Fotocurado",14500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Aplicación Sellante Pieza Def. Fotocurado",21700);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Mantenedor Espacio Fijo",58000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Mantenedor De Espacio Removible",58000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Consulta Y Examen Maxilofacial",29000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Interconsulta E Informe",43500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Controles De La Especialidad",29000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Interconsulta (junta De Especialistas)",58000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Recargo Por Tratamiento Fuera Del Lugar Habitual",58000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Exodoncia Simple",43500);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Exodoncia A Colgajo",58000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Exodoncia De Incluidos",116000);
insert into `listaprecios` (`ID_PRECIOS`,`COMENTARIO`,`VALOR_NETO`) values(null,"Exodoncia De 4 Terceros Molares Incluidos",290000);

INSERT INTO  `ordendelaboratorio` (`ID_ORDEN_LABORATORIO` ,`CLINICA` ,`BD` ,`BI` ,`PD` ,`PI` ,`FECHA_ENTREGA` ,`HORA_ENTREGA` ,`COLOR`) VALUES (NULL ,  'San Clemente',  'BD',  'BI',  'PD',  'PI',  '2013-08-26',  '13:00',  'BLANCO');


INSERT INTO `funcionario` (`ID_FUNCIONARIO` ,`ID_PERSONA` ,`PUESTO_DE_TRABAJO`) VALUES ('1', '2', 'Dentista');
INSERT INTO `funcionario` (`ID_FUNCIONARIO` ,`ID_PERSONA` ,`PUESTO_DE_TRABAJO`) VALUES ('2', '3', 'Asistente Dental');
INSERT INTO `funcionario` (`ID_FUNCIONARIO`, `ID_PERSONA`, `PUESTO_DE_TRABAJO`) VALUES ('3', '5', 'Dentista');
INSERT INTO `funcionario` (`ID_FUNCIONARIO`, `ID_PERSONA`, `PUESTO_DE_TRABAJO`) VALUES ('4', '6', 'Asistente Dental');

INSERT INTO `paciente` (`ID_PACIENTE`, `ID_PERSONA`, `FECHA_INGRESO`) VALUES ('1', '4', '2013-04-01');
INSERT INTO `paciente` (`ID_PACIENTE`, `ID_PERSONA`, `FECHA_INGRESO`) VALUES ('2', '7', '2013-05-16');
INSERT INTO `paciente` (`ID_PACIENTE`, `ID_PERSONA`, `FECHA_INGRESO`) VALUES ('3', '8', '2013-07-01');
INSERT INTO `paciente` (`ID_PACIENTE`, `ID_PERSONA`, `FECHA_INGRESO`) VALUES ('4', '9', '2013-08-11');

INSERT INTO `odontologo` (`ID_ODONTOLOGO`, `ID_PERSONA`, `ESPECIALIDAD`) VALUES ('1', '2', 'Endodoncia');
INSERT INTO `odontologo` (`ID_ODONTOLOGO`, `ID_PERSONA`, `ESPECIALIDAD`) VALUES ('2', '5', 'Ortodoncia');
INSERT INTO `odontologo` (`ID_ODONTOLOGO`, `ID_PERSONA`, `ESPECIALIDAD`) VALUES ('3', '10', 'Prostodoncia');
INSERT INTO `odontologo` (`ID_ODONTOLOGO`, `ID_PERSONA`, `ESPECIALIDAD`) VALUES ('4', '11', 'Ortodoncia');


INSERT INTO `presupuesto` (`ID_PRESUPUESTO`, `VALORTOTAL`) VALUES ('1', '25000');
INSERT INTO `presupuesto` (`ID_PRESUPUESTO`, `VALORTOTAL`) VALUES ('2', '50000');
INSERT INTO `presupuesto` (`ID_PRESUPUESTO`, `VALORTOTAL`) VALUES ('3', '15000');
INSERT INTO `presupuesto` (`ID_PRESUPUESTO`, `VALORTOTAL`) VALUES ('4', '32000');

INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('1', 'Tercer Molar Superior Derecho', 'Tercer Molar Superior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('2', 'Segundo Molar Superior Derecho', 'Segundo Molar Superior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('3', 'Primer Molar Superior Derecho', 'Primer Molar Superior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('4', 'Segundo Premolar Superior Derecho', 'Segundo Premolar Superior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('5', 'Primer Premolar Superior Derecho', 'Primer Premolar Superior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('6', 'Canino Superior Derecho', 'Canino Superior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('7', 'Incisivo Lateral Superior Derecho', 'Incisivo Lateral Superior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('8', 'Incisivo Central Superior Derecho', 'Incisivo Central Superior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('9', 'Incisivo Central Superior Izquierdo', 'Incisivo Central Superior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('10', 'Incisivo Lateral Superior Izquierdo', 'Incisivo Lateral Superior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('11', 'Canino Superior Izquierdo', 'Canino Superior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('12', 'Primer Premolar Superior Izquierdo', 'Primer Premolar Superior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('13', 'Segundo Premolar Superior Izquierdo', 'Segundo Premolar Superior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('14', 'Primer Molar Superior Izquierdo', 'Primer Molar Superior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('15', 'Segundo Molar Superior Izquierdo', 'Segundo Molar Superior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('16', 'Tercer Molar Superior Izquierdo', 'Tercer Molar Superior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('17', 'Tercer Molar Inferior Derecho', 'Tercer Molar Inferior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('18', 'Segundo Molar Inferior Derecho', 'Segundo Molar Inferior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('19', 'Primer Molar Inferior Derecho', 'Primer Molar Inferior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('20', 'Segundo Premolar Inferior Derecho', 'Segundo Premolar Inferior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('21', 'Primer Premolar Inferior Derecho', 'Primer Premolar Inferior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('22', 'Canino Inferior Derecho', 'Canino Inferior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('23', 'Incisivo Lateral Inferior Derecho', 'Incisivo Lateral Inferior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('24', 'Incisivo Central Inferior Derecho', 'Incisivo Central Inferior Derecho');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('25', 'Incisivo Central Inferior Izquierdo', 'Incisivo Central Inferior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('26', 'Incisivo Lateral Inferior Izquierdo', 'Incisivo Lateral Inferior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('27', 'Canino Inferior Izquierdo', 'Canino Inferior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('28', 'Primer Premolar Inferior Izquierdo', 'Primer Premolar Inferior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('29', 'Segundo Premolar Inferior Izquierdo', 'Segundo Premolar Inferior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('30', 'Primer Molar Inferior Izquierdo', 'Primer Molar Inferior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('31', 'Segundo Molar Inferior Izquierdo', 'Segundo Molar Inferior Izquierdo');
INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES ('32', 'Tercer Molar Inferior Izquierdo', 'Tercer Molar Inferior Izquierdo');

INSERT INTO `fichadental` (`ID_FICHA`, `ID_PACIENTE`, `ID_PRESUPUESTO`, `ID_ODONTOLOGO`, `FECH_INGRESO`, `ANAMNESIS`) VALUES ('1', '1', '1', '1', '2013-05-06', 'Hipertension');
INSERT INTO `fichadental` (`ID_FICHA`, `ID_PACIENTE`, `ID_PRESUPUESTO`, `ID_ODONTOLOGO`, `FECH_INGRESO`, `ANAMNESIS`) VALUES ('2', '2', '2', '2', '2013-06-17', 'Diabetes');
INSERT INTO `fichadental` (`ID_FICHA`, `ID_PACIENTE`, `ID_PRESUPUESTO`, `ID_ODONTOLOGO`, `FECH_INGRESO`, `ANAMNESIS`) VALUES ('3', '3', '3', '3', '2013-07-02', 'Presión baja');
INSERT INTO `fichadental` (`ID_FICHA`, `ID_PACIENTE`, `ID_PRESUPUESTO`, `ID_ODONTOLOGO`, `FECH_INGRESO`, `ANAMNESIS`) VALUES ('4', '4', '4', '4', '2013-08-12', 'Diabetes');

INSERT INTO `tratamientodental` (`ID_TRATAMIENTO_DENTAL`, `ID_FICHA`, `FECH_CREACION`, `TRATAMIENTO`, `FECHA_SEGUIMIENTO`, `VALOR_TOTAL`) VALUES ('1', '1', '2013-06-05', 'Extraccion de muela', '2013-06-12', '15000');
INSERT INTO `tratamientodental` (`ID_TRATAMIENTO_DENTAL`, `ID_FICHA`, `FECH_CREACION`, `TRATAMIENTO`, `FECHA_SEGUIMIENTO`, `VALOR_TOTAL`) VALUES ('2', '2', '2013-06-17', 'Caries', '2013-06-24', '20000');
INSERT INTO `tratamientodental` (`ID_TRATAMIENTO_DENTAL`, `ID_FICHA`, `FECH_CREACION`, `TRATAMIENTO`, `FECHA_SEGUIMIENTO`, `VALOR_TOTAL`) VALUES ('3', '3', '2013-07-02', 'Tratamiento Conducto', '2013-07-05', '50000');
INSERT INTO `tratamientodental` (`ID_TRATAMIENTO_DENTAL`, `ID_FICHA`, `FECH_CREACION`, `TRATAMIENTO`, `FECHA_SEGUIMIENTO`, `VALOR_TOTAL`) VALUES ('4', '4', '2013-08-12', 'Caries', '2013-08-19', '14000');

INSERT INTO `abono` (`ID_ABONO`, `ID_TRATAMIENTO_DENTAL`, `FECHA_DE_ABONO`, `MONTO`) VALUES ('1', '1', '2013-06-10', '5000');
INSERT INTO `abono` (`ID_ABONO`, `ID_TRATAMIENTO_DENTAL`, `FECHA_DE_ABONO`, `MONTO`) VALUES ('2', '2', '2013-06-24', '10000');
INSERT INTO `abono` (`ID_ABONO`, `ID_TRATAMIENTO_DENTAL`, `FECHA_DE_ABONO`, `MONTO`) VALUES ('3', '3', '2013-07-08', '10000');
INSERT INTO `abono` (`ID_ABONO`, `ID_TRATAMIENTO_DENTAL`, `FECHA_DE_ABONO`, `MONTO`) VALUES ('4', '4', '2013-08-19', '9000');

INSERT INTO  `areainsumo` (`ID_AREA_INSUMO` ,`NOMBRE_AREA` ,`DESCRIPCION_AREA`) VALUES (NULL ,  'Oficina',  'Insumos de Oficina');
INSERT INTO  `areainsumo` (`ID_AREA_INSUMO` ,`NOMBRE_AREA` ,`DESCRIPCION_AREA`) VALUES (NULL ,  'esterilizacion',  'Insumos de esterilizacion');
INSERT INTO  `areainsumo` (`ID_AREA_INSUMO` ,`NOMBRE_AREA` ,`DESCRIPCION_AREA`) VALUES (NULL ,  'Jeringas',  'Jeringas para usar datos');
INSERT INTO  `areainsumo` (`ID_AREA_INSUMO` ,`NOMBRE_AREA` ,`DESCRIPCION_AREA`) VALUES (NULL ,  'Medicamentes',  'Medicamentos de los pacientes');



INSERT INTO  `datosdecontacto` (`ID_PERSONA` ,`ID_COMUNA` ,`FONO_FIJO` ,`FONO_CELULAR` ,`DIRECCION` ,`MAIL` ,`F_INGRESO`) VALUES ('1',  '2',  '+567685932',  '+343849482',  'antonio varas 666',  'varas@varas.cl',  '2013-08-02');
INSERT INTO  `datosdecontacto` (`ID_PERSONA` ,`ID_COMUNA` ,`FONO_FIJO` ,`FONO_CELULAR` ,`DIRECCION` ,`MAIL` ,`F_INGRESO`) VALUES ('2',  '4',  '+568798754',  '+458374838',  'San Martin 33',  'martin@martin.cl',  '2013-08-23'); 
INSERT INTO  `datosdecontacto` (`ID_PERSONA` ,`ID_COMUNA` ,`FONO_FIJO` ,`FONO_CELULAR` ,`DIRECCION` ,`MAIL` ,`F_INGRESO`) VALUES ('3',  '10',  '+45432321232',  '+43234398743',  'san paolo 33',  'paolo@paolo.cl',  '2013-08-16');
INSERT INTO  `datosdecontacto` (`ID_PERSONA` ,`ID_COMUNA` ,`FONO_FIJO` ,`FONO_CELULAR` ,`DIRECCION` ,`MAIL` ,`F_INGRESO`) VALUES ('4',  '21',  '+432939321',  '+56983728393',  'sebastian cerrano 332',  'sebastian@sebastian.cl',  '2013-08-15');


