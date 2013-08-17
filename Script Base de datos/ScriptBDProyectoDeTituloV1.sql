drop table if exists ABONO;

drop table if exists ACCESOS;

drop table if exists AREAINSUMO;

drop table if exists CITA;

drop table if exists COMUNA;

drop table if exists DATOSDECONTACTO;

drop table if exists FICHADENTAL;

drop table if exists FUNCIONARIO;

drop table if exists GASTOS;

drop table if exists INIDICADORES_ECONOMICOS;

drop table if exists INSUMOS;

drop table if exists LISTA_PRECIOS;

drop table if exists ODONTOLOGO;

drop table if exists ORDEN_DE_LABORATORIO;

drop table if exists PACIENTE;

drop table if exists PASS;

drop table if exists PERFIL;

drop table if exists PERMISOS;

drop table if exists PERSONA;

drop table if exists PIEZADENTAL;

drop table if exists PRESUPUESTO;

drop table if exists REGION;

drop table if exists REPORTE;

drop table if exists TIPODEPIEZA;

drop table if exists TRATAMIENTODENTAL;

drop table if exists VERSION;

drop database if exists SFH;

create database SFH character set utf8 collate utf8_general_ci;

use SFH;

/*==============================================================*/
/* Table: ABONO                                                 */
/*==============================================================*/
create table ABONO
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
create table ACCESOS
(
   COD_ACCESO           int not null,
   DESCRIPCION_ACCESO   varchar(50),
   primary key (COD_ACCESO)
);

/*==============================================================*/
/* Table: AREAINSUMO                                            */
/*==============================================================*/
create table AREAINSUMO
(
   ID_AREA_INSUMO       int not null,
   NOMBRE_AREA          varchar(50),
   DESCRIPCION_AREA     text,
   primary key (ID_AREA_INSUMO)
);

/*==============================================================*/
/* Table: CITA                                                  */
/*==============================================================*/
create table CITA
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
create table COMUNA
(
   ID_COMUNA            int not null,
   ID_REGION            int,
   NOM_COMUNA           varchar(50),
   primary key (ID_COMUNA)
);

/*==============================================================*/
/* Table: DATOSDECONTACTO                                       */
/*==============================================================*/
create table DATOSDECONTACTO
(
   ID_PERSONA           int not null,
   ID_COMUNA            int,
   FONO_FIJO            varchar(10),
   FONO_CELULAR         varchar(10),
   DIRECCION            varchar(50),
   MAIL                 varchar(50),
   F_INGRESO            date,
   primary key (ID_PERSONA)
);

/*==============================================================*/
/* Table: FICHADENTAL                                           */
/*==============================================================*/
create table FICHADENTAL
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
create table FUNCIONARIO
(
   ID_FUNCIONARIO       int not null,
   ID_PERSONA           int,
   PUESTO_DE_TRABAJO    varchar(50),
   primary key (ID_FUNCIONARIO)
);

/*==============================================================*/
/* Table: GASTOS                                                */
/*==============================================================*/
create table GASTOS
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
create table INIDICADORES_ECONOMICOS
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
create table INSUMOS
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
create table LISTA_PRECIOS
(
   ID_PRECIOS           int not null,
   COMENTARIO           text,
   VALOR_NETO           int,
   primary key (ID_PRECIOS)
);

/*==============================================================*/
/* Table: ODONTOLOGO                                            */
/*==============================================================*/
create table ODONTOLOGO
(
   ID_ODONTOLOGO        int not null,
   ID_PERSONA           int,
   ESPECIALIDAD         varchar(50),
   primary key (ID_ODONTOLOGO)
);

/*==============================================================*/
/* Table: ORDEN_DE_LABORATORIO                                  */
/*==============================================================*/
create table ORDEN_DE_LABORATORIO
(
   ID_ORDEN_LABORATORIO int not null,
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
create table PACIENTE
(
   ID_PACIENTE          int not null,
   ID_PERSONA           int,
   FECHA_INGRESO        date,
   primary key (ID_PACIENTE)
);

/*==============================================================*/
/* Table: PASS                                                  */
/*==============================================================*/
create table PASS
(
   ID_PERSONA           int not null,
   PASS                 text,
   FECHA_CADUCIDAD      date,
   primary key (ID_PERSONA)
);

/*==============================================================*/
/* Table: PERFIL                                                */
/*==============================================================*/
create table PERFIL
(
   ID_PERFIL            int not null,
   NOM_PERFIL           varchar(40),
   primary key (ID_PERFIL)
);

/*==============================================================*/
/* Table: PERMISOS                                              */
/*==============================================================*/
create table PERMISOS
(
   ID_PERFIL            int not null,
   COD_ACCESO           int,
   primary key (ID_PERFIL)
);

/*==============================================================*/
/* Table: PERSONA                                               */
/*==============================================================*/
create table PERSONA
(
   ID_PERSONA           int not null,
   ID_PERFIL            int,
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
create table PIEZADENTAL
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
create table PRESUPUESTO
(
   ID_PRESUPUESTO       int not null,
   VALORTOTAL           int,
   primary key (ID_PRESUPUESTO)
);

/*==============================================================*/
/* Table: REGION                                                */
/*==============================================================*/
create table REGION
(
   ID_REGION            int not null,
   NOM_REGION           varchar(50),
   NUM_REGION_ROMANO    varchar(4),
   primary key (ID_REGION)
);

/*==============================================================*/
/* Table: REPORTE                                               */
/*==============================================================*/
create table REPORTE
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
create table TIPODEPIEZA
(
   ID_TIPO_PIEZA        int not null,
   NOMBRE_CIENTIFICO_PIEZA varchar(100),
   DESCRIPCION          text,
   primary key (ID_TIPO_PIEZA)
);

/*==============================================================*/
/* Table: TRATAMIENTODENTAL                                     */
/*==============================================================*/
create table TRATAMIENTODENTAL
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
create table VERSION
(
   ID_VERSION           int not null,
   NOM_VERSION          varchar(50),
   COMENTARIO           text,
   primary key (ID_VERSION)
);

alter table ABONO add constraint FK_ABONO_TRATAMIENTO foreign key (ID_TRATAMIENTO_DENTAL)
      references TRATAMIENTODENTAL (ID_TRATAMIENTO_DENTAL) on delete restrict on update restrict;

alter table CITA add constraint FK_CITA_ODONTOLOGO foreign key (ID_ODONTOLOGO)
      references ODONTOLOGO (ID_ODONTOLOGO) on delete restrict on update restrict;

alter table CITA add constraint FK_CITA_PACIENTE foreign key (ID_PACIENTE)
      references PACIENTE (ID_PACIENTE) on delete restrict on update restrict;

alter table COMUNA add constraint FK_COMUNA_REGION foreign key (ID_REGION)
      references REGION (ID_REGION) on delete restrict on update restrict;

alter table DATOSDECONTACTO add constraint FK_CONTACTO_COMUNA foreign key (ID_COMUNA)
      references COMUNA (ID_COMUNA) on delete restrict on update restrict;

alter table DATOSDECONTACTO add constraint FK_CONTACTO_PERSONA foreign key (ID_PERSONA)
      references PERSONA (ID_PERSONA) on delete restrict on update restrict;

alter table FICHADENTAL add constraint FK_FICHA_ODONTOLOGO foreign key (ID_ODONTOLOGO)
      references ODONTOLOGO (ID_ODONTOLOGO) on delete restrict on update restrict;

alter table FICHADENTAL add constraint FK_FICHA_PACIENTE foreign key (ID_PACIENTE)
      references PACIENTE (ID_PACIENTE) on delete restrict on update restrict;

alter table FICHADENTAL add constraint FK_FICHA_PRESUPUESTO foreign key (ID_PRESUPUESTO)
      references PRESUPUESTO (ID_PRESUPUESTO) on delete restrict on update restrict;

alter table FUNCIONARIO add constraint FK_FUNCIONARIO_PERSONA foreign key (ID_PERSONA)
      references PERSONA (ID_PERSONA) on delete restrict on update restrict;

alter table GASTOS add constraint FK_GASTOS_PERSONA foreign key (ID_PERSONA)
      references PERSONA (ID_PERSONA) on delete restrict on update restrict;

alter table INSUMOS add constraint FK_INSUMOS_AREAINSUMO foreign key (ID_AREA_INSUMO)
      references AREAINSUMO (ID_AREA_INSUMO) on delete restrict on update restrict;

alter table INSUMOS add constraint FK_INSUMOS_GASTOS foreign key (ID_GASTOS)
      references GASTOS (ID_GASTOS) on delete restrict on update restrict;

alter table ODONTOLOGO add constraint FK_MEDICO_PERSONA foreign key (ID_PERSONA)
      references PERSONA (ID_PERSONA) on delete restrict on update restrict;

alter table PACIENTE add constraint FK_PACIENTE_PERSONA foreign key (ID_PERSONA)
      references PERSONA (ID_PERSONA) on delete restrict on update restrict;

alter table PASS add constraint FK_PASS_PERSONA foreign key (ID_PERSONA)
      references PERSONA (ID_PERSONA) on delete restrict on update restrict;

alter table PERMISOS add constraint FK_PERMISOS_ACCESOS foreign key (COD_ACCESO)
      references ACCESOS (COD_ACCESO) on delete restrict on update restrict;

alter table PERMISOS add constraint FK_PERMISOS_PERFIL foreign key (ID_PERFIL)
      references PERFIL (ID_PERFIL) on delete restrict on update restrict;

alter table PERSONA add constraint FK_PERSONA_PERFIL foreign key (ID_PERFIL)
      references PERFIL (ID_PERFIL) on delete restrict on update restrict;

alter table PIEZADENTAL add constraint FK_PIEZA_DENTAL foreign key (ID_TRATAMIENTO_DENTAL)
      references TRATAMIENTODENTAL (ID_TRATAMIENTO_DENTAL) on delete restrict on update restrict;

alter table PIEZADENTAL add constraint FK_PIEZA_ORDEN foreign key (ID_ORDEN_LABORATORIO)
      references ORDEN_DE_LABORATORIO (ID_ORDEN_LABORATORIO) on delete restrict on update restrict;

alter table PIEZADENTAL add constraint FK_PIEZA_TIPOPIEZA foreign key (ID_TIPO_PIEZA)
      references TIPODEPIEZA (ID_TIPO_PIEZA) on delete restrict on update restrict;

alter table REPORTE add constraint FK_REPORTE_PERSONA foreign key (ID_PERSONA)
      references PERSONA (ID_PERSONA) on delete restrict on update restrict;

alter table TRATAMIENTODENTAL add constraint FK_TRATAMIENTO_FICHA foreign key (ID_FICHA)
      references FICHADENTAL (ID_FICHA) on delete restrict on update restrict;
