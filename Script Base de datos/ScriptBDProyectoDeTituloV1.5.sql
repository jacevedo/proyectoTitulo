-- phpMyAdmin SQL Dump
-- version 3.2.4
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 27-09-2013 a las 01:05:18
-- Versión del servidor: 5.1.44
-- Versión de PHP: 5.3.1

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `sfh`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `abono`
--
use sfh;

CREATE TABLE IF NOT EXISTS `abono` (
  `ID_ABONO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_TRATAMIENTO_DENTAL` int(11) DEFAULT NULL,
  `FECHA_DE_ABONO` date DEFAULT NULL,
  `MONTO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_ABONO`),
  KEY `INDEX_ABONO_1` (`ID_TRATAMIENTO_DENTAL`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=16 ;

--
-- Volcar la base de datos para la tabla `abono`
--

INSERT INTO `abono` (`ID_ABONO`, `ID_TRATAMIENTO_DENTAL`, `FECHA_DE_ABONO`, `MONTO`) VALUES
(1, 3, '1991-12-12', 10000),
(2, 2, '2013-06-24', 10000),
(4, 4, '2013-08-19', 9000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ACCESOS`
--

CREATE TABLE IF NOT EXISTS `accesos` (
  `COD_ACCESO` int(11) NOT NULL,
  `DESCRIPCION_ACCESO` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_ACCESO`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `ACCESOS`
--

INSERT INTO `accesos` (`COD_ACCESO`, `DESCRIPCION_ACCESO`) VALUES
(707, 'Usuario administrador: Posee las credenciales nece'),
(706, 'Usuario Doctor: Posee las credenciales necesarias '),
(705, 'Usuario Asistente: Posee las credenciales necesari'),
(704, 'Usuario Paciente: Posee las credenciales necesaria');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `AREAINSUMO`
--

CREATE TABLE IF NOT EXISTS `areainsumo` (
  `ID_AREA_INSUMO` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE_AREA` varchar(50) DEFAULT NULL,
  `DESCRIPCION_AREA` text,
  PRIMARY KEY (`ID_AREA_INSUMO`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Volcar la base de datos para la tabla `AREAINSUMO`
--

INSERT INTO `areainsumo` (`ID_AREA_INSUMO`, `NOMBRE_AREA`, `DESCRIPCION_AREA`) VALUES
(1, 'Oficina', 'Insumos de Oficina'),
(2, 'Esterilizacion', 'Insumos de Esterilizacion'),
(3, 'Jeringas', 'Jeringas para usar datos'),
(4, 'Medicamentes', 'Medicamentos de los pacientes');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cita`
--

CREATE TABLE IF NOT EXISTS `cita` (
  `ID_CITA` int(11) NOT NULL AUTO_INCREMENT,
  `ID_ODONTOLOGO` int(11) DEFAULT NULL,
  `ID_PACIENTE` int(11) DEFAULT NULL,
  `HORA_DE_INICIO` datetime DEFAULT NULL,
  `HORA_DE_TERMINO` datetime DEFAULT NULL,
  `FECHA` date DEFAULT NULL,
  PRIMARY KEY (`ID_CITA`),
  KEY `INDEX_CITA_1` (`ID_ODONTOLOGO`),
  KEY `INDEX_CITA_2` (`ID_PACIENTE`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=7 ;

--
-- Volcar la base de datos para la tabla `cita`
--

INSERT INTO `cita` (`ID_CITA`, `ID_ODONTOLOGO`, `ID_PACIENTE`, `HORA_DE_INICIO`, `HORA_DE_TERMINO`, `FECHA`) VALUES
(1, 1, 3, '2012-00-00 00:00:00', '2013-00-00 00:00:00', '2013-08-25'),
(2, 2, 2, '2013-00-00 00:00:00', '2014-00-00 00:00:00', '2013-08-25'),
(3, 1, 3, '2013-00-00 00:00:00', '2014-00-00 00:00:00', '2013-08-25'),
(4, 3, 4, '2013-00-00 00:00:00', '2014-00-00 00:00:00', '2013-08-25'),
(5, 2, 1, '2014-00-00 00:00:00', '2015-00-00 00:00:00', '2013-08-25'),
(6, 3, 2, '2014-00-00 00:00:00', '2015-00-00 00:00:00', '2013-08-25');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `comuna`
--

CREATE TABLE IF NOT EXISTS `comuna` (
  `ID_COMUNA` int(11) NOT NULL,
  `ID_REGION` int(11) DEFAULT NULL,
  `NOM_COMUNA` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID_COMUNA`),
  KEY `INDEX_COMUNA_1` (`ID_REGION`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `comuna`
--

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

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `datosdecontacto`
--

CREATE TABLE IF NOT EXISTS `datosdecontacto` (
  `ID_PERSONA` int(11) NOT NULL,
  `ID_COMUNA` int(11) DEFAULT NULL,
  `FONO_FIJO` varchar(10) DEFAULT NULL,
  `FONO_CELULAR` varchar(10) DEFAULT NULL,
  `DIRECCION` varchar(50) DEFAULT NULL,
  `MAIL` varchar(50) DEFAULT NULL,
  `F_INGRESO` date DEFAULT NULL,
  PRIMARY KEY (`ID_PERSONA`),
  KEY `INDEX_DATOSDECONTACTO_1` (`ID_COMUNA`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `datosdecontacto`
--

INSERT INTO `datosdecontacto` (`ID_PERSONA`, `ID_COMUNA`, `FONO_FIJO`, `FONO_CELULAR`, `DIRECCION`, `MAIL`, `F_INGRESO`) VALUES
(1, 2, '+567685932', '+343849482', 'antonio varas 666', 'varas@varas.cl', '2013-08-02'),
(2, 4, '+568798754', '+458374838', 'San Martin 33', 'martin@martin.cl', '2013-08-23'),
(3, 10, '+454323212', '+432343987', 'san paolo 33', 'paolo@paolo.cl', '2013-08-16'),
(4, 21, '+432939321', '+569837283', 'sebastian cerrano 332', 'sebastian@sebastian.cl', '2013-08-15');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `fichadental`
--

CREATE TABLE IF NOT EXISTS `fichadental` (
  `ID_FICHA` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PACIENTE` int(11) DEFAULT NULL,
  `ID_ODONTOLOGO` int(11) DEFAULT NULL,
  `FECH_INGRESO` date DEFAULT NULL,
  `ANAMNESIS` varchar(100) DEFAULT NULL,
  `HABILITADO_FICHA` int(11) NOT NULL,
  PRIMARY KEY (`ID_FICHA`),
  KEY `INDEX_FICHADENTAL_1` (`ID_PACIENTE`),
  KEY `INDEX_FICHADENTAL_3` (`ID_ODONTOLOGO`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=8 ;

--
-- Volcar la base de datos para la tabla `fichadental`
--

INSERT INTO `fichadental` (`ID_FICHA`, `ID_PACIENTE`, `ID_ODONTOLOGO`, `FECH_INGRESO`, `ANAMNESIS`, `HABILITADO_FICHA`) VALUES
(1, 1, 1, '1991-12-12', 'Penisilina', 0),
(2, 1, 1, '1991-12-12', 'Penisilina', 0),
(3, 1, 1, '2013-09-04', 'asd', 1),
(4, 4, 4, '2013-08-12', 'Diabetes', 0),
(5, 1, 1, '1991-12-12', 'Penisilina', 0),
(6, 1, 1, '1991-12-12', 'Penisilina', 0),
(7, 1, 1, '1991-12-12', 'Penisilina', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `funcionario`
--

CREATE TABLE IF NOT EXISTS `funcionario` (
  `ID_FUNCIONARIO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PERSONA` int(11) DEFAULT NULL,
  `PUESTO_DE_TRABAJO` varchar(50) DEFAULT NULL,
  `FUNCIONARIO_HABILITADO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_FUNCIONARIO`),
  KEY `INDEX_FUNCIONARIO_1` (`ID_PERSONA`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

--
-- Volcar la base de datos para la tabla `funcionario`
--

INSERT INTO `funcionario` (`ID_FUNCIONARIO`, `ID_PERSONA`, `PUESTO_DE_TRABAJO`, `FUNCIONARIO_HABILITADO`) VALUES
(1, 2, 'Dentista', NULL),
(2, 3, 'Asistente Dental', NULL),
(3, 5, 'Dentista', NULL),
(4, 6, 'Asistente Dental', NULL),
(5, 1, 'Administrador', 1),
(6, 1, 'Administrador', 1),
(7, 1, 'Administrador', 1),
(8, 1, 'Administrador', 1),
(9, 1, 'Administrador', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `gastos`
--

CREATE TABLE IF NOT EXISTS `gastos` (
  `ID_GASTOS` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PERSONA` int(11) DEFAULT NULL,
  `CONCEPTO_GASTO` varchar(1000) NOT NULL,
  `MONTO_GASTOS` int(11) DEFAULT NULL,
  `DESCUENTO_GASTOS` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_GASTOS`),
  KEY `INDEX_GASTOS_1` (`ID_PERSONA`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=5 ;

--
-- Volcar la base de datos para la tabla `gastos`
--

INSERT INTO `gastos` (`ID_GASTOS`, `ID_PERSONA`, `CONCEPTO_GASTO`, `MONTO_GASTOS`, `DESCUENTO_GASTOS`) VALUES
(1, 1, '', 40000, 30000),
(2, 1, '', 30000, 40000),
(3, 1, '', 40000, 30000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `INIDICADORESECONOMICOS`
--

CREATE TABLE IF NOT EXISTS `inidicadoreseconomicos` (
  `ID_INIDICADOR` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE_INDICADOR` varchar(100) DEFAULT NULL,
  `VALOR_EN_PESOS` int(11) DEFAULT NULL,
  `UNIDAD_DE_MEDIDA` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID_INIDICADOR`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Volcar la base de datos para la tabla `INIDICADORESECONOMICOS`
--

INSERT INTO `inidicadoreseconomicos` (`ID_INIDICADOR`, `NOMBRE_INDICADOR`, `VALOR_EN_PESOS`, `UNIDAD_DE_MEDIDA`) VALUES
(1, 'UF', 23, 'Pesos Chilenos'),
(2, 'DOLAR OBSERVADO($)', 510, 'Pesos Chilenos'),
(3, 'UTM', 40, 'Pesos Chilenos'),
(4, 'YEN JAPONES', 5, 'Pesos Chilenos'),
(5, 'EURO', 613, 'Pesos Chilenos');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `insumos`
--

CREATE TABLE IF NOT EXISTS `insumos` (
  `ID_INSUMO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_AREA_INSUMO` int(11) DEFAULT NULL,
  `ID_GASTOS` int(11) DEFAULT NULL,
  `NOMBRE_INSUMO` varchar(50) DEFAULT NULL,
  `CANTIDAD` float DEFAULT NULL,
  `DESCRIPCION_INSUMO` text,
  `UNIDAD_DE_MEDIDA_INSUMO` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID_INSUMO`),
  KEY `INDEX_INSUMOS_1` (`ID_AREA_INSUMO`),
  KEY `INDEX_INSUMOS_2` (`ID_GASTOS`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=4 ;

--
-- Volcar la base de datos para la tabla `insumos`
--

INSERT INTO `insumos` (`ID_INSUMO`, `ID_AREA_INSUMO`, `ID_GASTOS`, `NOMBRE_INSUMO`, `CANTIDAD`, `DESCRIPCION_INSUMO`, `UNIDAD_DE_MEDIDA_INSUMO`) VALUES
(1, 3, 1, 'Jeringas', 3, 'Compra de Jeringas', 'Unidad'),
(2, 4, 2, 'Antibioticos', 100, 'Compra Antibioticos', 'Caja'),
(3, 1, 3, 'Hojas impresion', 20, 'Comrpa hojas de impresion', 'Resma');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `LISTAPRECIOS`
--

CREATE TABLE IF NOT EXISTS `listaprecios` (
  `ID_PRECIOS` int(11) NOT NULL AUTO_INCREMENT,
  `COMENTARIO` text,
  `VALOR_NETO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_PRECIOS`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=31 ;

--
-- Volcar la base de datos para la tabla `LISTAPRECIOS`
--

INSERT INTO `listaprecios` (`ID_PRECIOS`, `COMENTARIO`, `VALOR_NETO`) VALUES
(4, 'Urgencia. Tratamiento Inicial 1 Sesion', 14500),
(5, 'asd', 130),
(6, 'Urgencia En Hospital Id. Anterior', 29000),
(7, 'Estudio Preliminar Clinico, Rx Y Modelos', 29000),
(8, 'Informes Periciales 1 Hora Profesional', 43500),
(9, 'Consultorias Y Estudio Profesional: 1 Hora', 43500),
(10, 'Higiene O Profilaxis En Adultos', 29000),
(11, 'Higiene O Profilaxis En Niños', 14500),
(12, 'Instrucción Y Control Higiene Oral Adultos', 14500),
(13, 'Instrucción Y Control Higiene Oral Niños', 14500),
(14, 'Aplicación De Fluor En Colutorios (trat)', 14500),
(15, 'Aplicación Fluor Gel Total Niños Y Adultos', 14500),
(16, 'Aplicación Fluor Total Silano  ID', 72500),
(17, 'Aplicación Sellante Pieza Temp. Fotocurado', 14500),
(18, 'Aplicación Sellante Pieza Def. Fotocurado', 21700),
(19, 'Mantenedor Espacio Fijo', 58000),
(20, 'Mantenedor De Espacio Removible', 58000),
(21, 'Consulta Y Examen Maxilofacial', 29000),
(22, 'Interconsulta E Informe', 43500),
(23, 'Controles De La Especialidad', 29000),
(24, 'Interconsulta (junta De Especialistas)', 58000),
(25, 'Recargo Por Tratamiento Fuera Del Lugar Habitual', 58000),
(26, 'Exodoncia Simple', 43500),
(27, 'Exodoncia A Colgajo', 58000),
(28, 'Exodoncia De Incluidos', 116000),
(29, 'Exodoncia De 4 Terceros Molares Incluidos', 290000),
(30, 'Procedimiento', 12000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `odontologo`
--

CREATE TABLE IF NOT EXISTS `odontologo` (
  `ID_ODONTOLOGO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PERSONA` int(11) DEFAULT NULL,
  `ESPECIALIDAD` varchar(50) DEFAULT NULL,
  `ODONTOLOGO_HABILITADO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_ODONTOLOGO`),
  KEY `INDEX_ODONTOLOGO_1` (`ID_PERSONA`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=11 ;

--
-- Volcar la base de datos para la tabla `odontologo`
--

INSERT INTO `odontologo` (`ID_ODONTOLOGO`, `ID_PERSONA`, `ESPECIALIDAD`, `ODONTOLOGO_HABILITADO`) VALUES
(1, 2, 'Endodoncia', 1),
(2, 1, 'Cirugia', NULL),
(3, 10, 'Prostodoncia', NULL),
(4, 11, 'Ortodoncia', NULL),
(5, 1, 'Cirugia', NULL),
(6, 1, 'Cirugia', NULL),
(7, 1, 'Cirugia', 1),
(8, 1, 'Cirugia', 1),
(9, 1, 'Cirugia', 1),
(10, 1, 'Cirugia', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ORDENDELABORATORIO`
--

CREATE TABLE IF NOT EXISTS `ordendelaboratorio` (
  `ID_ORDEN_LABORATORIO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_ODONTOLOGO` int(11) NOT NULL,
  `ID_PACIENTE` int(11) NOT NULL,
  `N_FICHA_LABORATORIO` int(11) NOT NULL,
  `CLINICA` varchar(80) DEFAULT NULL,
  `BD` varchar(50) DEFAULT NULL,
  `BI` varchar(50) DEFAULT NULL,
  `PD` varchar(50) DEFAULT NULL,
  `PI` varchar(50) DEFAULT NULL,
  `FECHA_CREACION` date NOT NULL,
  `FECHA_ENTREGA` date DEFAULT NULL,
  `HORA_ENTREGA` time DEFAULT NULL,
  `COLOR` varchar(60) DEFAULT NULL,
  `ESTADO` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`ID_ORDEN_LABORATORIO`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=11 ;

--
-- Volcar la base de datos para la tabla `ORDENDELABORATORIO`
--

INSERT INTO `ordendelaboratorio` (`ID_ORDEN_LABORATORIO`, `ID_ODONTOLOGO`, `ID_PACIENTE`, `N_FICHA_LABORATORIO`, `CLINICA`, `BD`, `BI`, `PD`, `PI`, `FECHA_CREACION`, `FECHA_ENTREGA`, `HORA_ENTREGA`, `COLOR`, `ESTADO`) VALUES
(1, 1, 2, 123123, 'Santa Ana', '10', '11', '20', '21', '2013-09-06', '2013-10-26', '10:00:00', 'Blanco', 'Rechazada'),
(2, 3, 2, 123123, 'Santa-Ana', '10', '11', '20', '21', '2013-09-14', '2013-09-26', '16:00:00', 'Blanco', 'Recibida'),
(3, 1, 2, 123123, 'San Clemente', '12', '12', '12', '21', '2013-09-21', '2013-09-07', '10:00:00', 'Blanco', 'Rechazada'),
(4, 1, 3, 123123, 'qweqwe', 'qweasd1', 'qweasd1', 'qweasd1', 'qweasd1', '2013-09-06', '2013-09-11', '10:00:00', 'asd', 'asd'),
(5, 3, 2, 1, 'Santa', '10', '11', '20', '21', '2013-08-26', '2013-09-26', '16:00:00', 'Blanco', 'Recibida'),
(6, 1, 1, 123123, 'Santa Ana', '10', '11', '20', '21', '2013-09-26', '2013-09-26', '16:00:00', 'Blanco', 'Recibida'),
(7, 1, 1, 123123, 'Santa Ana', '10', '11', '20', '21', '2013-09-26', '2013-09-26', '16:00:00', 'Blanco', 'Recibida'),
(8, 1, 1, 123123, 'San Ramon', '12', '43', '32', '23', '2013-09-22', '2013-09-22', '10:00:00', 'blanco', 'ENVIADA'),
(9, 1, 1, 4343, 'ads', 'asd', 'io', 'ji', 'jo', '2013-09-22', '2013-09-22', '10:00:00', 'asd', 'ENVIADA'),
(10, 1, 1, 123123, 'san Ramon', '19', '32', '92', '32', '2013-09-22', '2013-09-22', '10:00:00', 'blanco', 'ENVIADA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `paciente`
--

CREATE TABLE IF NOT EXISTS `paciente` (
  `ID_PACIENTE` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PERSONA` int(11) DEFAULT NULL,
  `FECHA_INGRESO` date DEFAULT NULL,
  `HABILITADO_PACIENTE` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_PACIENTE`),
  KEY `INDEX_PACIENTE_1` (`ID_PERSONA`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=10 ;

--
-- Volcar la base de datos para la tabla `paciente`
--

INSERT INTO `paciente` (`ID_PACIENTE`, `ID_PERSONA`, `FECHA_INGRESO`, `HABILITADO_PACIENTE`) VALUES
(1, 1, '2013-04-12', 1),
(2, 7, '2013-05-16', NULL),
(3, 8, '2013-07-01', NULL),
(4, 9, '2013-08-11', NULL),
(5, 0, '0000-00-00', NULL),
(6, 1, '2013-04-12', NULL),
(7, 1, '2013-04-12', NULL),
(8, 1, '2013-04-12', NULL),
(9, 1, '2013-04-12', NULL);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `PASS`
--

CREATE TABLE IF NOT EXISTS `pass` (
  `ID_PERSONA` int(11) NOT NULL,
  `PASS` text,
  `FECHA_CADUCIDAD` date DEFAULT NULL,
  PRIMARY KEY (`ID_PERSONA`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `PASS`
--

INSERT INTO `pass` (`ID_PERSONA`, `PASS`, `FECHA_CADUCIDAD`) VALUES
(1, 'Tatus.2013', '2014-08-01'),
(2, 'Peres.2013', '2014-08-01'),
(3, 'Palma.2013', '2014-08-01'),
(4, 'Muñoz.2013', '2014-08-01'),
(5, 'Garrido.2013', '2013-08-01'),
(6, 'Madrid.2013', '2014-08-01'),
(7, 'Salcedo.2013', '2013-08-01'),
(8, 'Sanchez.2013', '2014-08-01'),
(9, 'Paredes.2013', '2013-08-01'),
(10, 'Carrizo.2013', '2013-08-01'),
(11, 'Lopez.2013', '2013-08-01');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `PERFIL`
--

CREATE TABLE IF NOT EXISTS `perfil` (
  `ID_PERFIL` int(11) NOT NULL,
  `NOM_PERFIL` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`ID_PERFIL`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `PERFIL`
--

INSERT INTO `perfil` (`ID_PERFIL`, `NOM_PERFIL`) VALUES
(1, 'Administrador'),
(2, 'Doctor'),
(3, 'Asistente'),
(4, 'Paciente');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `permisos`
--

CREATE TABLE IF NOT EXISTS `permisos` (
  `ID_PERFIL` int(11) NOT NULL,
  `COD_ACCESO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_PERFIL`),
  KEY `INDEX_PERMISOS_1` (`COD_ACCESO`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `permisos`
--

INSERT INTO `permisos` (`ID_PERFIL`, `COD_ACCESO`) VALUES
(1, 707),
(2, 706),
(3, 705),
(4, 704);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `persona`
--

CREATE TABLE IF NOT EXISTS `persona` (
  `ID_PERSONA` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PERFIL` int(11) DEFAULT NULL,
  `RUT` varchar(11) DEFAULT NULL,
  `DV` varchar(1) DEFAULT NULL,
  `NOMBRE` varchar(50) DEFAULT NULL,
  `APELLIDO_PATERNO` varchar(50) DEFAULT NULL,
  `APELLIDO_MATERNO` varchar(50) DEFAULT NULL,
  `FECHA_NAC` date DEFAULT NULL,
  PRIMARY KEY (`ID_PERSONA`),
  KEY `INDEX_PERSONA_1` (`ID_PERFIL`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=18 ;

--
-- Volcar la base de datos para la tabla `persona`
--

INSERT INTO `persona` (`ID_PERSONA`, `ID_PERFIL`, `RUT`, `DV`, `NOMBRE`, `APELLIDO_PATERNO`, `APELLIDO_MATERNO`, `FECHA_NAC`) VALUES
(1, 1, '17231233', '2', 'Ada', 'Tatus', 'Boren', '1991-08-06'),
(15, 1, '17897359', '2', 'ada', 'wonk', 'asturias', '1991-12-12'),
(3, 3, '9878987', '4', 'Nicolas', 'Palma', 'Silva', '1987-05-27'),
(4, 4, '3272373', '2', 'Jose', 'Muñoz', 'Lopez', '1989-02-03'),
(5, 2, '17901230', '2', 'Viviana', 'Garrido', 'Sanchez', '1988-02-08'),
(6, 3, '17899006', '3', 'Lilia', 'Madrid', 'Sepulveda', '1988-01-09'),
(7, 4, '16009332', '8', 'Lissete', 'Salcedo', 'Taiba', '1987-12-08'),
(8, 4, '6336666', 'k', 'Patricia', 'Sanchez', 'Pavez', '1959-09-08'),
(9, 4, '18992457', 'k', 'Daniela', 'Paredes', 'Chamorro', '1988-04-29'),
(10, 2, '15725009', '0', 'Camila', 'Carrizo', 'Pacheco', '1983-05-19'),
(11, 2, '19746228', '7', 'Pedro', 'Lopez', 'Moya', '1993-12-04'),
(13, 1, '17897359', '2', 'ada', 'wonk', 'asturias', '1991-12-12'),
(14, 1, '17897359', '2', 'ada', 'wonk', 'asturias', '1991-12-12'),
(16, NULL, '17897359', '2', NULL, NULL, NULL, NULL),
(17, 1, '17897359', '2', 'ada', 'wonk', 'asturias', '1991-12-12'),
(2, 1, '178972492', '2', 'asdasd', 'asdasd', 'asdasd', '2013-09-21');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `piezadental`
--

CREATE TABLE IF NOT EXISTS `piezadental` (
  `ID_PIEZA` int(11) NOT NULL,
  `ID_TRATAMIENTO_DENTAL` int(11) DEFAULT NULL,
  `ID_ORDEN_LABORATORIO` int(11) DEFAULT NULL,
  `ID_TIPO_PIEZA` int(11) DEFAULT NULL,
  `NOMBRE_PIEZA` varchar(50) DEFAULT NULL,
  `DESCRIPCION_PIEZA` text,
  `PERIODO_PIEZA` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_PIEZA`),
  KEY `INDEX_PIEZADENTAL_1` (`ID_TRATAMIENTO_DENTAL`),
  KEY `INDEX_PIEZADENTAL_2` (`ID_ORDEN_LABORATORIO`),
  KEY `INDEX_PIEZADENTAL_3` (`ID_TIPO_PIEZA`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `piezadental`
--

INSERT INTO `piezadental` (`ID_PIEZA`, `ID_TRATAMIENTO_DENTAL`, `ID_ORDEN_LABORATORIO`, `ID_TIPO_PIEZA`, `NOMBRE_PIEZA`, `DESCRIPCION_PIEZA`, `PERIODO_PIEZA`) VALUES
(1, 4, 1, 14, 'Primer Molar Superior Izquierdo', 'Primer Molar Superior Izquierdo', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `presupuesto`
--

CREATE TABLE IF NOT EXISTS `presupuesto` (
  `ID_PRESUPUESTO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_FICHA` int(11) DEFAULT NULL,
  `VALORTOTAL` int(11) DEFAULT NULL,
  `FECHA_PRESUPUESTO` date NOT NULL,
  PRIMARY KEY (`ID_PRESUPUESTO`),
  KEY `INDEX_PRESUPUESTO_1` (`ID_FICHA`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- Volcar la base de datos para la tabla `presupuesto`
--

INSERT INTO `presupuesto` (`ID_PRESUPUESTO`, `ID_FICHA`, `VALORTOTAL`, `FECHA_PRESUPUESTO`) VALUES
(1, 3, 10000, '1991-12-12'),
(2, 3, 30000, '1991-12-12'),
(3, 3, 15000, '2013-09-04'),
(4, 4, 32000, '2013-09-12'),
(5, 3, 30000, '2013-09-21'),
(7, 3, 10000, '2013-09-21'),
(8, 3, 10000, '1991-12-12'),
(9, 3, 10000, '1991-12-12'),
(10, 3, 10000, '1991-12-12'),
(11, 4, 12000, '2013-09-22');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `REGION`
--

CREATE TABLE IF NOT EXISTS `region` (
  `ID_REGION` int(11) NOT NULL,
  `NOM_REGION` varchar(50) DEFAULT NULL,
  `NUM_REGION_ROMANO` varchar(4) DEFAULT NULL,
  PRIMARY KEY (`ID_REGION`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `REGION`
--

INSERT INTO `region` (`ID_REGION`, `NOM_REGION`, `NUM_REGION_ROMANO`) VALUES
(15, 'REGIÓN DE ARICA Y PARINACOTA', 'XV'),
(1, 'REGIÓN DE TARAPACÁ', 'I'),
(2, 'REGIÓN DE ANTOFAGASTA', 'II'),
(3, 'REGIÓN DE ATACAMA', 'III'),
(4, 'REGIÓN DE COQUIMBO', 'IV'),
(5, 'REGIÓN DE VALPARAISO', 'V'),
(13, 'REGIÓN METROPOLITANA', 'XIII'),
(6, 'REGIÓN DEL LIBERTADOR GENERAL BERNARDO O HIGGINS', 'VI'),
(7, 'REGIÓN DEL MAULE', 'VII'),
(8, 'REGIÓN DEL BÍO - BÍO', 'VIII'),
(9, 'REGIÓN DE LA ARAUCANÍA', 'IX'),
(14, 'REGION DE LOS RÍOS', 'XIV'),
(10, 'REGIÓN DE LOS LAGOS', 'X'),
(11, 'REGIÓN AYSÉN DEL GENERAL CARLOS IBÁÑEZ DEL CAMPO', 'XI'),
(12, 'REGIÓN DE MAGALLANES Y LA ANTÁRTICA CHILENA ', 'XII');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `reporte`
--

CREATE TABLE IF NOT EXISTS `reporte` (
  `ID_REPORTE` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PERSONA` int(11) DEFAULT NULL,
  `F_CREACION` date DEFAULT NULL,
  `TIPO_REPORTE` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ID_REPORTE`),
  KEY `INDEX_REPORTE_1` (`ID_PERSONA`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 AUTO_INCREMENT=1 ;

--
-- Volcar la base de datos para la tabla `reporte`
--


-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `TIPODEPIEZA`
--

CREATE TABLE IF NOT EXISTS `tipodepieza` (
  `ID_TIPO_PIEZA` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE_CIENTIFICO_PIEZA` varchar(100) DEFAULT NULL,
  `DESCRIPCION` text,
  PRIMARY KEY (`ID_TIPO_PIEZA`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=33 ;

--
-- Volcar la base de datos para la tabla `TIPODEPIEZA`
--

INSERT INTO `tipodepieza` (`ID_TIPO_PIEZA`, `NOMBRE_CIENTIFICO_PIEZA`, `DESCRIPCION`) VALUES
(1, 'Tercer Molar Superior Derecho', 'Tercer Molar Superior Derecho'),
(2, 'Segundo Molar Superior Derecho', 'Segundo Molar Superior Derecho'),
(3, 'Primer Molar Superior Derecho', 'Primer Molar Superior Derecho'),
(4, 'Segundo Premolar Superior Derecho', 'Segundo Premolar Superior Derecho'),
(5, 'Primer Premolar Superior Derecho', 'Primer Premolar Superior Derecho'),
(6, 'Canino Superior Derecho', 'Canino Superior Derecho'),
(7, 'Incisivo Lateral Superior Derecho', 'Incisivo Lateral Superior Derecho'),
(8, 'Incisivo Central Superior Derecho', 'Incisivo Central Superior Derecho'),
(9, 'Incisivo Central Superior Izquierdo', 'Incisivo Central Superior Izquierdo'),
(10, 'Incisivo Lateral Superior Izquierdo', 'Incisivo Lateral Superior Izquierdo'),
(11, 'Canino Superior Izquierdo', 'Canino Superior Izquierdo'),
(12, 'Primer Premolar Superior Izquierdo', 'Primer Premolar Superior Izquierdo'),
(13, 'Segundo Premolar Superior Izquierdo', 'Segundo Premolar Superior Izquierdo'),
(14, 'Primer Molar Superior Izquierdo', 'Primer Molar Superior Izquierdo'),
(15, 'Segundo Molar Superior Izquierdo', 'Segundo Molar Superior Izquierdo'),
(16, 'Tercer Molar Superior Izquierdo', 'Tercer Molar Superior Izquierdo'),
(17, 'Tercer Molar Inferior Derecho', 'Tercer Molar Inferior Derecho'),
(18, 'Segundo Molar Inferior Derecho', 'Segundo Molar Inferior Derecho'),
(19, 'Primer Molar Inferior Derecho', 'Primer Molar Inferior Derecho'),
(20, 'Segundo Premolar Inferior Derecho', 'Segundo Premolar Inferior Derecho'),
(21, 'Primer Premolar Inferior Derecho', 'Primer Premolar Inferior Derecho'),
(22, 'Canino Inferior Derecho', 'Canino Inferior Derecho'),
(23, 'Incisivo Lateral Inferior Derecho', 'Incisivo Lateral Inferior Derecho'),
(24, 'Incisivo Central Inferior Derecho', 'Incisivo Central Inferior Derecho'),
(25, 'Incisivo Central Inferior Izquierdo', 'Incisivo Central Inferior Izquierdo'),
(26, 'Incisivo Lateral Inferior Izquierdo', 'Incisivo Lateral Inferior Izquierdo'),
(27, 'Canino Inferior Izquierdo', 'Canino Inferior Izquierdo'),
(28, 'Primer Premolar Inferior Izquierdo', 'Primer Premolar Inferior Izquierdo'),
(29, 'Segundo Premolar Inferior Izquierdo', 'Segundo Premolar Inferior Izquierdo'),
(30, 'Primer Molar Inferior Izquierdo', 'Primer Molar Inferior Izquierdo'),
(31, 'Segundo Molar Inferior Izquierdo', 'Segundo Molar Inferior Izquierdo'),
(32, 'Tercer Molar Inferior Izquierdo', 'Tercer Molar Inferior Izquierdo');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tratamientodental`
--

CREATE TABLE IF NOT EXISTS `tratamientodental` (
  `ID_TRATAMIENTO_DENTAL` int(11) NOT NULL AUTO_INCREMENT,
  `ID_FICHA` int(11) DEFAULT NULL,
  `FECH_CREACION` date DEFAULT NULL,
  `TRATAMIENTO` text,
  `FECHA_SEGUIMIENTO` date DEFAULT NULL,
  `VALOR_TOTAL` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_TRATAMIENTO_DENTAL`),
  KEY `INDEX_TRATAMIENODENTAL_1` (`ID_FICHA`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=12 ;

--
-- Volcar la base de datos para la tabla `tratamientodental`
--

INSERT INTO `tratamientodental` (`ID_TRATAMIENTO_DENTAL`, `ID_FICHA`, `FECH_CREACION`, `TRATAMIENTO`, `FECHA_SEGUIMIENTO`, `VALOR_TOTAL`) VALUES
(1, 1, '1991-12-12', 'extraccion', '1991-12-12', 100000),
(2, 1, '1991-12-12', 'extraccion', '1991-12-12', 100000),
(3, 3, '2013-07-23', 'Tratamiento Dental De Hoy', '2013-08-12', 5000),
(4, 4, '2013-08-12', 'Caries', '2013-08-19', 14000),
(5, 1, '1991-12-12', 'extraccion', '1991-12-12', 100000),
(6, 1, '1991-12-12', 'extraccion', '1991-12-12', 100000),
(7, 1, '1991-12-12', 'extraccion', '1991-12-12', 100000),
(8, 1, '1991-12-12', 'extraccion', '1991-12-12', 100000),
(9, 3, '2013-09-21', 'extraccion Muela Juicio', '2013-09-21', 15000),
(10, 1, '1991-12-12', 'extraccion', '1991-12-12', 100000),
(11, 1, '1991-12-12', 'extraccion', '1991-12-12', 100000);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `VERSION`
--

CREATE TABLE IF NOT EXISTS `version` (
  `ID_VERSION` int(11) NOT NULL,
  `NOM_VERSION` varchar(50) DEFAULT NULL,
  `COMENTARIO_VERSION` text,
  PRIMARY KEY (`ID_VERSION`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `VERSION`
--

INSERT INTO `version` (`ID_VERSION`, `NOM_VERSION`, `COMENTARIO_VERSION`) VALUES
(1, 'SFH - Sistema de toma de horas y fichas medicas v ', '\r\nSFH - Primera versión de desarrollo.');
