-- phpMyAdmin SQL Dump
-- version 3.3.7deb7
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 01-11-2013 a las 18:56:13
-- Versión del servidor: 5.1.66
-- Versión de PHP: 5.3.3-7+squeeze17

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
-- Estructura de tabla para la tabla `accesos`
--

CREATE TABLE IF NOT EXISTS `accesos` (
  `COD_ACCESO` int(11) NOT NULL,
  `DESCRIPCION_ACCESO` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`COD_ACCESO`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `accesos`
--

INSERT INTO `accesos` (`COD_ACCESO`, `DESCRIPCION_ACCESO`) VALUES
(707, 'Usuario administrador: Posee las credenciales nece'),
(706, 'Usuario Doctor: Posee las credenciales necesarias '),
(705, 'Usuario Asistente: Posee las credenciales necesari'),
(704, 'Usuario Paciente: Posee las credenciales necesaria');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `areainsumo`
--

CREATE TABLE IF NOT EXISTS `areainsumo` (
  `ID_AREA_INSUMO` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE_AREA` varchar(50) DEFAULT NULL,
  `DESCRIPCION_AREA` text,
  PRIMARY KEY (`ID_AREA_INSUMO`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=9 ;

--
-- Volcar la base de datos para la tabla `areainsumo`
--

INSERT INTO `areainsumo` (`ID_AREA_INSUMO`, `NOMBRE_AREA`, `DESCRIPCION_AREA`) VALUES
(1, 'Oficina', 'Insumos de Oficina'),
(2, 'Esterilizacion', 'Insumos de Esterilizacion'),
(4, 'Requerimiento', 'Requerimientos'),
(3, 'Casa', 'Articulos Hogar'),
(6, 'Oficina', 'asd'),
(7, 'Oficina', 'asd'),
(8, 'Oficina', 'asd'),
(5, 'Cuestonario', 'El cliente contesta todo como un cuestonario');

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
  `ESTADO` int(11) NOT NULL,
  PRIMARY KEY (`ID_CITA`),
  KEY `INDEX_CITA_1` (`ID_ODONTOLOGO`),
  KEY `INDEX_CITA_2` (`ID_PACIENTE`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=25 ;

--
-- Volcar la base de datos para la tabla `cita`
--

INSERT INTO `cita` (`ID_CITA`, `ID_ODONTOLOGO`, `ID_PACIENTE`, `HORA_DE_INICIO`, `HORA_DE_TERMINO`, `FECHA`, `ESTADO`) VALUES
(2, 3, 2, '2013-11-23 12:00:00', '2013-11-23 13:00:00', '2013-11-23', 1),
(4, 3, 4, '2013-11-23 13:00:00', '2013-11-23 14:00:00', '2013-11-23', 1),
(5, 2, 1, '2014-00-00 00:00:00', '2015-00-00 00:00:00', '2013-08-25', 0),
(6, 3, 2, '2014-00-00 00:00:00', '2015-00-00 00:00:00', '2013-08-25', 0),
(24, 4, 3, '2013-11-07 15:00:00', '2013-11-07 15:00:00', '2013-11-07', 0),
(23, 7, 3, '2013-11-07 15:30:00', '2013-11-07 15:30:00', '2013-11-07', 0),
(22, 4, 3, '2013-10-03 12:30:00', '2013-10-03 12:30:00', '2013-10-03', 0),
(21, 7, 3, '2013-10-03 12:00:00', '2013-10-03 12:00:00', '2013-10-03', 0);

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
(1, 2, '0227780184', ' 569760872', 'antonio Varas 666', 'asd@asd.com', '2013-02-02'),
(8, 2, '0227780184', ' 569760872', 'antonio Varas 666', 'asd@asd.com', '2013-02-02'),
(3, 10, '+454323212', '+432343987', 'san paolo 33', 'paolo@paolo.cl', '2013-08-16'),
(4, 21, '+432939321', '+569837283', 'sebastian cerrano 332', 'sebastian@sebastian.cl', '2013-08-15'),
(29, 2, '0227780184', ' 569760872', NULL, 'asd@asd.com', '2013-02-02'),
(30, 2, '0227780184', ' 569760872', NULL, 'asd@asd.com', '2013-02-02'),
(31, 1, '+569760872', '+569760872', NULL, 'jaim.acevedoc@gmai.com', '0000-00-00'),
(32, 1, '+569760872', '+569760872', NULL, 'jaim.acevedoc@gmai.com', '0000-00-00'),
(11, 295, '+562778018', '+569760872', 'Tadeo Vargas 447', 'correo@prueba.cl', '0000-00-00');

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
(2, 2, 1, '1991-12-12', 'Penisilina', 0),
(3, 3, 1, '2013-09-04', 'asd', 1),
(4, 4, 4, '2013-08-12', 'Diabetes', 0),
(5, 7, 1, '1991-12-12', 'Penisilina', 0),
(6, 5, 1, '1991-12-12', 'Penisilina', 0),
(7, 6, 1, '1991-12-12', 'Penisilina', 1);

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
(2, 3, 'Asistente Dental', 1),
(3, 5, 'Dentista', 1),
(4, 6, 'Asistente Dental', 1),
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
  `FECHA_GASTO` date NOT NULL,
  PRIMARY KEY (`ID_GASTOS`),
  KEY `INDEX_GASTOS_1` (`ID_PERSONA`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Volcar la base de datos para la tabla `gastos`
--

INSERT INTO `gastos` (`ID_GASTOS`, `ID_PERSONA`, `CONCEPTO_GASTO`, `MONTO_GASTOS`, `DESCUENTO_GASTOS`, `FECHA_GASTO`) VALUES
(1, 1, 'Jeringas', 40000, 30000, '0000-00-00'),
(2, 1, 'Colacion casa', 2000, 0, '0000-00-00'),
(3, 1, 'Taxi', 40000, 30000, '0000-00-00'),
(5, 1, 'Colacion', 2000, 0, '2013-11-23');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `horario`
--

CREATE TABLE IF NOT EXISTS `horario` (
  `ID_HORARIO` int(11) NOT NULL AUTO_INCREMENT,
  `ID_ODONTOLOGO` int(11) NOT NULL,
  `DIA` varchar(30) NOT NULL,
  `HORA_INICIO` time NOT NULL,
  `HORA_TERMINO` time NOT NULL,
  `DURACION_MODULO` time NOT NULL,
  PRIMARY KEY (`ID_HORARIO`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

--
-- Volcar la base de datos para la tabla `horario`
--

INSERT INTO `horario` (`ID_HORARIO`, `ID_ODONTOLOGO`, `DIA`, `HORA_INICIO`, `HORA_TERMINO`, `DURACION_MODULO`) VALUES
(1, 7, 'jueves', '12:00:00', '16:00:00', '00:30:00'),
(2, 3, 'jueves', '14:00:00', '20:00:00', '00:15:00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `inidicadoreseconomicos`
--

CREATE TABLE IF NOT EXISTS `inidicadoreseconomicos` (
  `ID_INIDICADOR` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE_INDICADOR` varchar(100) DEFAULT NULL,
  `VALOR_EN_PESOS` int(11) DEFAULT NULL,
  `UNIDAD_DE_MEDIDA` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ID_INIDICADOR`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Volcar la base de datos para la tabla `inidicadoreseconomicos`
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
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Volcar la base de datos para la tabla `insumos`
--

INSERT INTO `insumos` (`ID_INSUMO`, `ID_AREA_INSUMO`, `ID_GASTOS`, `NOMBRE_INSUMO`, `CANTIDAD`, `DESCRIPCION_INSUMO`, `UNIDAD_DE_MEDIDA_INSUMO`) VALUES
(1, 3, 1, 'Jeringas', 3, 'Compra de Jeringas', 'Unidad'),
(2, 3, 1, 'Jeringas 15 ML', 10, 'Compra al por mayor', '10'),
(3, 1, 3, 'Hojas impresion', 20, 'Comrpa hojas de impresion', 'Resma'),
(4, 3, 3, 'Jeringas 10 ML', 10, 'Compra al por mayor', '10'),
(5, 3, 1, 'Jeringas 10 ML', 10, 'Compra al por mayor', '10');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `listaprecios`
--

CREATE TABLE IF NOT EXISTS `listaprecios` (
  `ID_PRECIOS` int(11) NOT NULL AUTO_INCREMENT,
  `COMENTARIO` text,
  `VALOR_NETO` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID_PRECIOS`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=35 ;

--
-- Volcar la base de datos para la tabla `listaprecios`
--

INSERT INTO `listaprecios` (`ID_PRECIOS`, `COMENTARIO`, `VALOR_NETO`) VALUES
(4, 'asdas', 100),
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
(30, 'Procedimiento', 12000),
(31, '123', 123),
(32, 'Procedimiento', 12000),
(33, '123', 123),
(34, '123', 123);

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
(2, 1, 'Cirugia', 1),
(3, 10, 'Prostodoncia', 1),
(4, 11, 'Ortodoncia', 1),
(5, 1, 'Cirugia', 1),
(6, 1, 'Cirugia', 1),
(7, 1, 'Cirugia', 1),
(8, 1, 'Cirugia', 1),
(9, 1, 'Cirugia', 1),
(10, 1, 'Cirugia', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `ordendelaboratorio`
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
-- Volcar la base de datos para la tabla `ordendelaboratorio`
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
(2, 7, '2013-05-16', 1),
(3, 8, '2013-07-01', 1),
(4, 9, '2013-08-11', 1),
(5, 0, '0000-00-00', 1),
(6, 1, '2013-04-12', 1),
(7, 1, '2013-04-12', 1),
(8, 1, '2013-04-12', 0),
(9, 1, '2013-04-12', 1);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `pass`
--

CREATE TABLE IF NOT EXISTS `pass` (
  `ID_PERSONA` int(11) NOT NULL,
  `PASS` text,
  `FECHA_CADUCIDAD` date DEFAULT NULL,
  PRIMARY KEY (`ID_PERSONA`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `pass`
--

INSERT INTO `pass` (`ID_PERSONA`, `PASS`, `FECHA_CADUCIDAD`) VALUES
(1, '$2a$08$sFKDgfoHn8DTh9CGQiBd6e13fXlymaiC/ZRz6MjSlyI8jBcKdyLji', '2014-08-01'),
(2, '$2a$08$sFKDgfoHn8DTh9CGQiBd6e13fXlymaiC/ZRz6MjSlyI8jBcKdyLji', '2014-08-01'),
(3, '$2a$08$sFKDgfoHn8DTh9CGQiBd6e13fXlymaiC/ZRz6MjSlyI8jBcKdyLji', '2014-08-01'),
(4, '$2a$08$sFKDgfoHn8DTh9CGQiBd6e13fXlymaiC/ZRz6MjSlyI8jBcKdyLji', '2014-08-01'),
(5, '$2a$08$sFKDgfoHn8DTh9CGQiBd6e13fXlymaiC/ZRz6MjSlyI8jBcKdyLji', '2013-08-01'),
(6, '$2a$08$sFKDgfoHn8DTh9CGQiBd6e13fXlymaiC/ZRz6MjSlyI8jBcKdyLji', '2014-08-01'),
(7, '$2a$08$sFKDgfoHn8DTh9CGQiBd6e13fXlymaiC/ZRz6MjSlyI8jBcKdyLji', '2013-08-01'),
(8, '$2a$08$1fywBvOH3BWzA.D3OuhMieqJ1AMJtUXEbb1uvofn8ckeNdaheUGeu', '2013-08-09'),
(9, '$2a$08$sFKDgfoHn8DTh9CGQiBd6e13fXlymaiC/ZRz6MjSlyI8jBcKdyLji', '2013-08-01'),
(10, '$2a$08$sFKDgfoHn8DTh9CGQiBd6e13fXlymaiC/ZRz6MjSlyI8jBcKdyLji', '2013-08-01'),
(11, '$2a$08$sFKDgfoHn8DTh9CGQiBd6e13fXlymaiC/ZRz6MjSlyI8jBcKdyLji', '2013-08-01'),
(32, '$2a$08$47GbgGRxjGrcT6NaoeiYFuvdRdcjIW/T.d.ki8jNj7Ugr8W6c8Va6', '2014-01-01'),
(31, '$2a$08$NpetfEplkVPPro0Tmu9khOELfk.sTdS.4K7mzn7JfTo2Z6cafLHcS', '2014-01-01'),
(30, '$2a$08$ZLpVl9F5f8tah.12yIxKxOB/OVx//WhzhEOpRiOU5jWuu7.GpB2SK', '2014-01-01'),
(29, '$2a$08$etA2CNi8MIMvEl5I37P6Be3TTRk4F8Dq35pyfagh7SXnlDW7Al4PG', '2014-01-01');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `perfil`
--

CREATE TABLE IF NOT EXISTS `perfil` (
  `ID_PERFIL` int(11) NOT NULL,
  `NOM_PERFIL` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`ID_PERFIL`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `perfil`
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
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=33 ;

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
(8, 4, '6336666', 'k', 'Vivi', 'Sanchez', 'Pavez', '1959-09-08'),
(9, 4, '18992457', 'k', 'Daniela', 'Paredes', 'Chamorro', '1988-04-29'),
(10, 2, '15725009', '0', 'Camila', 'Carrizo', 'Pacheco', '1983-05-19'),
(11, 2, '19746228', '7', 'Pedro', 'Lopez', 'Moya', '1993-12-04'),
(13, 1, '17897359', '2', 'ada', 'wonk', 'asturias', '1991-12-12'),
(14, 1, '17897359', '2', 'ada', 'wonk', 'asturias', '1991-12-12'),
(17, 1, '17897359', '2', 'ada', 'wonk', 'asturias', '1991-12-12'),
(2, 1, '11111111', '2', 'ada', 'wonk', 'asturias', '1991-12-12'),
(32, 4, '17897359', '2', 'jaime', 'acevedo', 'cerna', '1991-04-06'),
(31, 4, '17897359', '2', 'jaime', 'acevedo', 'cerna', '1991-04-06'),
(30, 4, '17897359', '2', 'ada', 'wonk', 'asturias', '1991-12-12'),
(29, 4, '17897359', '2', 'ada', 'wonk', 'asturias', '1991-12-12');

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
-- Estructura de tabla para la tabla `region`
--

CREATE TABLE IF NOT EXISTS `region` (
  `ID_REGION` int(11) NOT NULL,
  `NOM_REGION` varchar(50) DEFAULT NULL,
  `NUM_REGION_ROMANO` varchar(4) DEFAULT NULL,
  PRIMARY KEY (`ID_REGION`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `region`
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
-- Estructura de tabla para la tabla `session`
--

CREATE TABLE IF NOT EXISTS `session` (
  `ID_SESSION` int(11) NOT NULL AUTO_INCREMENT,
  `ID_PERSONA` int(11) NOT NULL,
  `KEY_SESSION` text NOT NULL,
  `FECHA_HORA_INGRESO` datetime DEFAULT NULL,
  `FECHA_HORA_CADUCIDAD` datetime DEFAULT NULL,
  PRIMARY KEY (`ID_SESSION`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=202 ;

--
-- Volcar la base de datos para la tabla `session`
--

INSERT INTO `session` (`ID_SESSION`, `ID_PERSONA`, `KEY_SESSION`, `FECHA_HORA_INGRESO`, `FECHA_HORA_CADUCIDAD`) VALUES
(52, 4, '$2a$08$/h3dm2I/Tx.sZU7LgZOKOeHRENtSboOQ/RvWZj2aFAgDfnn7VNJdy', '2013-10-19 15:39:39', '2013-10-19 15:39:39'),
(51, 1, '$2a$08$WYqOGqa4LSD4KD0ZDBoVRuBA69Txb2eDZKVVqIF./vhUhkBB6EBQu', '2013-10-19 15:38:01', '2013-10-19 15:38:01'),
(50, 1, '$2a$08$RQaqihSBxbUvXsObTNXGceuspdsX2obZbpspqdV95drn.ZMiZ8b3i', '2013-10-19 15:36:49', '2013-10-19 15:36:49'),
(49, 1, '$2a$08$0weHKWAAgVVC9pmLk9WhKOKLyl4rjM5dntwwxRpphcw.9xtnn7H8.', '2013-10-19 15:05:39', '2013-10-19 15:05:39'),
(48, 1, '$2a$08$Zsn9Dr2tnR7VL1R8WcZ2n.AY70sntYcg8UQb7EMuIif1UFzPtrJWi', '2013-10-19 15:05:38', '2013-10-19 15:05:38'),
(47, 1, '$2a$08$HNZz1UHFkn7rJrCqbClEp.Vgmjh5vJy8MG0mk6uraH9sb/HVDFQ16', '2013-10-19 15:05:38', '2013-10-19 15:05:38'),
(46, 1, '$2a$08$VraXlzCmqB8mO5Q89J7cCORFygNWwe.b8gBYZbFFj4ADPFnI9AAVa', '2013-10-19 15:05:37', '2013-10-19 15:05:37'),
(45, 1, '$2a$08$JWy.2XCyVMi8lNE0M4Yu4e5iVb/pvPYJ.jmICcgsVhYIf022y7WMa', '2013-10-19 15:05:36', '2013-10-19 15:05:36'),
(44, 1, '$2a$08$o8776Juwef3ksYfvZZo.4O2l1gAOZuUkQGbyzuFQgodbp41SlacdG', '2013-10-19 15:05:36', '2013-10-19 15:05:36'),
(43, 1, '$2a$08$7ch2gL.NhbySxHcudnLNQ.fg3r0OZQl9bdLV./8GCPleVrmuKN1de', '2013-10-19 15:05:35', '2013-10-19 15:05:35'),
(42, 1, '$2a$08$dVrAk0GJKo5hEWNQbD3jaubsN1Yygn4mOSMC7jnDzGsZxy3mVd4ue', '2013-10-19 15:05:33', '2013-10-19 15:05:33'),
(41, 1, '$2a$08$eC9G2KrLOr2KYTbTaJ7lYenBEK8by9YPJn2f2T3Fl59cqkaJ6SHtG', '2013-10-19 15:04:03', '2013-10-19 15:04:03'),
(40, 1, '$2a$08$xaVXlxQT8OcDSEs34mcvB.yif67aaDymFfuVVfspKLh7jxxMiKdmq', '2013-10-10 17:45:29', '2013-10-10 17:45:29'),
(39, 1, '$2a$08$jZjY2KdTOSPwGBbhdx9lHuQ6TeAN2.4C4uOnsFduSoc0usOr8Favi', '2013-10-10 17:40:00', '2013-10-10 17:40:00'),
(53, 1, '$2a$08$DbEdKirEahvnmdKPU5uFju34QJAWeVKYXINfulGZfpyfBN5bqTx6y', '2013-10-30 21:21:14', '2013-10-30 21:21:14'),
(54, 1, '$2a$08$2mNT4HscepqiPnLsFmJcTeSjKUuhQ..WXmjOqf.A2/.dMSCYl2Obi', '2013-10-30 21:23:09', '2013-10-30 21:23:09'),
(55, 1, '$2a$08$CK1l6z.DUKnoztdwwBufteJRuVk0xLlnr/II.bHV3Fk2VvsS0exYq', '2013-10-30 21:23:25', '2013-10-30 21:23:25'),
(56, 1, '$2a$08$Wb3u6ltJqeuwHuN9ew//veqrRb9VLR8DRUF.WwOYSAwa/KDPP2LCa', '2013-10-30 21:25:14', '2013-10-30 21:25:14'),
(57, 1, '$2a$08$anWda8AF526dht.o9ZCFu.DkBGLtASg6EhWmE4iPsIxcR3wSFBV.a', '2013-10-30 21:25:17', '2013-10-30 21:25:17'),
(58, 1, '$2a$08$rWKaH73d0ZSVfvJDyZJSz.8QXr.FHlIUqARIhrdkwQtoynM8DJKla', '2013-10-30 21:27:01', '2013-10-30 21:27:01'),
(59, 1, '$2a$08$EjbU1NTHiONJLvQaOdzlEeukGjUW17rPTyLNwhXMTfoELWQdNAbVW', '2013-10-30 21:27:28', '2013-10-30 21:27:28'),
(60, 9, '$2a$08$A6qBR/ifvZiJ9DJG/.Z13.4E5KD3454wy137nqkbP0DMypzQiQHCe', '2013-10-30 21:28:18', '2013-10-30 21:28:18'),
(61, 8, '$2a$08$IEItTIO3IDr2sNNdrrRwLOdtkxoaYV09IAmf9RPWRSSIXj5CLKc/C', '2013-10-30 23:12:00', '2013-10-30 23:12:00'),
(62, 1, '$2a$08$AChJqvAb6vM3acbmgDI1e.DmtJTPp1y8Zj9gzJ1/aJTsP95hVX4vu', '2013-10-30 23:13:03', '2013-10-30 23:13:03'),
(63, 8, '$2a$08$9b7/kIrn9AWpAA9ONpWRd.azGhOOy.0onwzDsHxAoHvKMhlZaONiy', '2013-10-30 23:23:21', '2013-10-30 23:23:21'),
(64, 8, '$2a$08$/Ei2arXXPpYFhEQogMgmgOPURxfuz10LRNbb7tWn1rjlFEJQDxTcm', '2013-10-30 23:23:26', '2013-10-30 23:23:26'),
(65, 8, '$2a$08$X8o6Xu8QnZcP2Qwcq8yIG.CT2t5avxx2s8L/4plJtjAwkR0FDngRe', '2013-10-30 23:23:28', '2013-10-30 23:23:28'),
(66, 8, '$2a$08$32rYEINoLIRY4KUFjQZjnuk54hfmVoGi7vHoehY9pOiWRW1EcPwly', '2013-10-30 23:33:54', '2013-10-30 23:33:54'),
(67, 8, '$2a$08$zeWWEVg7fJat/fHKi/MekuAyBpsOMfb.bm3KB4iZvxmW5fmaCkiZa', '2013-10-31 00:48:03', '2013-10-31 00:48:03'),
(68, 8, '$2a$08$QSiAjkNf3I5I/EjHxnpQUe4wXv1LdfzbghbXT/n2k.abf/JA/ZKHO', '2013-10-31 01:24:50', '2013-10-31 01:24:50'),
(69, 8, '$2a$08$QiE8N.EAhFkixxDFlm0jyeK4eoJtAIQ7t37dq8kUMkOjlDBYB3nCO', '2013-10-31 01:27:09', '2013-10-31 01:27:09'),
(70, 8, '$2a$08$WzkE2yaKOJBMGX7gLVJ0Je/W0nDtCXjfdqWvSxU6yt43Q2ctOp9/W', '2013-10-31 01:29:20', '2013-10-31 01:29:20'),
(71, 1, '$2a$08$wQ6LWZHbTpF0UQ/e.SJLX.NeO9gS13zx2H.BnGJf3WpHpdfE6FHly', '2013-10-31 02:38:35', '2013-10-31 02:38:35'),
(72, 1, '$2a$08$/AXdqdcmGekgAQDwvyFQRO/eDWF7yd.XcRhR8LdkXfMb/hpuEJmfO', '2013-10-31 02:39:08', '2013-10-31 02:39:08'),
(73, 8, '$2a$08$THrv704AnMdAyt/7etFgYOsb9.cy9yqc8pah859kCAJxxXmSxTg0G', '2013-10-31 02:39:19', '2013-10-31 02:39:19'),
(74, 8, '$2a$08$GsGICf1K2dq78u8dnKRQweoHIvMlwFuMGABMhFB5o4yLpzCf3GEP.', '2013-10-31 02:39:22', '2013-10-31 02:39:22'),
(75, 8, '$2a$08$WoX5Wyp26qISPmH/pY1MquorT2yKu3YiOog7uYOizc5kv5y0dXqam', '2013-10-31 02:40:29', '2013-10-31 02:40:29'),
(76, 1, '$2a$08$j5kl4bo/kf8/h8tB59Eatu4UOAs3S.IrapgwQXEho4c/GV7xhNDb.', '2013-10-31 02:41:03', '2013-10-31 02:41:03'),
(77, 1, '$2a$08$UxX7b0OEQkMa91ABqgK6Q.wonlMfdAeb29UYTKOv2HlAU2y7cUMkW', '2013-10-31 02:48:12', '2013-10-31 02:48:12'),
(78, 1, '$2a$08$iheyMFpIwUfFMBwn3Cu0CO/cqnE9GsPV6bWP4hhn9fJgZAIBKC//6', '2013-10-31 02:48:20', '2013-10-31 02:48:20'),
(79, 2, '$2a$08$quFVwbD6CtK65rNgBwFHNO9H.FKSG0rLtaFzo5v970LOUIptw2EfK', '2013-10-31 02:52:16', '2013-10-31 02:52:16'),
(80, 2, '$2a$08$waGMKG/2UNgQKZUNK8SYQ.D3LNXjKtyi/akSVjGm7RnW0GmhamESC', '2013-10-31 02:53:33', '2013-10-31 02:53:33'),
(81, 8, '$2a$08$VOpWfLQbpf4H4ECRcNbdZeq3AY5/mK4Dp0ms1Wk6ZgQq8pYvN.jUu', '2013-10-31 02:55:12', '2013-10-31 02:55:12'),
(82, 8, '$2a$08$SmeLWs/qJJmYpJKfr436FeI1yFhLr2boOQRT7kggZAmEobZtc7eam', '2013-10-31 02:55:22', '2013-10-31 02:55:22'),
(83, 8, '$2a$08$uSd8nU4FueMFIU/l7HW4yuni0550JqSTu6S9XZWZN9hQTakePduEa', '2013-10-31 02:56:53', '2013-10-31 02:56:53'),
(84, 8, '$2a$08$B9dYajQwcE3WSVtIWMYbwOqFFkzpL1ADZEmd8nB391dDTtMUY9ETq', '2013-10-31 02:57:36', '2013-10-31 02:57:36'),
(85, 8, '$2a$08$rSHFacVU89mVC98qhYQDIOt9xpdvq4.g9/fnIscKpNLsl/tqVDmAK', '2013-10-31 03:26:41', '2013-10-31 03:26:41'),
(86, 8, '$2a$08$2LVYQ.TnH5.RlL2a73iBbezuR9RpUvGp8gN/KgIxCxjR/MGkUHgIu', '2013-10-31 03:49:10', '2013-10-31 03:49:10'),
(87, 8, '$2a$08$o8NFNe880N2d1qrOWcA86etQDOVKY0KVAp52nZGx9MQdXVhgKva0W', '2013-10-31 04:35:33', '2013-10-31 04:35:33'),
(88, 8, '$2a$08$5YxEVFlmSOX6TsQ3TwVuKew0fE2GI.rZ3hECHg.sDQYrB3NCYGsXC', '2013-10-31 04:37:00', '2013-10-31 04:37:00'),
(89, 8, '$2a$08$KJ8c9ZtMB8oy98.CX3243ul.2F9X/8FC5IqWttTDpdqiJxorKPUQq', '2013-10-31 04:39:12', '2013-10-31 04:39:12'),
(90, 8, '$2a$08$oihL57ct7bQ2Mj7LNsXlx.uoRJ.BZwM2CaAWseHDS9wsGxaG5.bXK', '2013-10-31 04:41:21', '2013-10-31 04:41:21'),
(91, 8, '$2a$08$cbXEgyFvUrJed.RPuNfwc.IPCL2T1t/utqjWNBiPplL3NA5O4rNaO', '2013-10-31 04:43:02', '2013-10-31 04:43:02'),
(92, 8, '$2a$08$cu/FALk1PYMsgfQpn3pt6.nJ0BfbbsDm2CeEVgGS3Zel3URThJsUG', '2013-10-31 04:45:22', '2013-10-31 04:45:22'),
(93, 8, '$2a$08$dIaK6W5LKRS1.zlmQ..Qku.kApw0tUd6Cl1fLYwomNMtAiGVY7u0y', '2013-10-31 04:45:56', '2013-10-31 04:45:56'),
(94, 8, '$2a$08$12FI5Omm2S0MJAbGvNz2/enwlC3hikW0O0FsSrH/UREu5eqnoMy5K', '2013-10-31 04:47:42', '2013-10-31 04:47:42'),
(95, 8, '$2a$08$YvXLYEBJKyvAZIb1DUhvzOHpVUEcfSG9jFeDNRmOOSz.fhYiXSuTu', '2013-10-31 04:48:28', '2013-10-31 04:48:28'),
(96, 8, '$2a$08$eewNfIzqmBhNo9NhgNQ7K.qhaaNaSJQQJCrX6Z5A/5s1jecDYmRSC', '2013-10-31 04:49:01', '2013-10-31 04:49:01'),
(97, 8, '$2a$08$5KP.kVmrGTmm0.fQqbqaG.0ILhEc52ON9Ejzwfuf2tjGGh.hFZyua', '2013-10-31 04:49:57', '2013-10-31 04:49:57'),
(98, 8, '$2a$08$Za1Zu4ytw9bUhQhv3eCDW.in0bDt22uk0Nk6XhwDbefZp9Oyen2Hm', '2013-10-31 05:30:07', '2013-10-31 05:30:07'),
(99, 8, '$2a$08$fMlqalI4xt3oN1XDBZ9Fmez9lcv2ambuFqSJkC2bKpJ/QoJqryGXi', '2013-10-31 05:31:32', '2013-10-31 05:31:32'),
(100, 8, '$2a$08$4UFwPYec7FkSwuQtouXJZujF8dFq9tc22oS100bkcOp.c/zIdjXxW', '2013-10-31 05:36:38', '2013-10-31 05:36:38'),
(101, 8, '$2a$08$xEpyYK6y9S3C3wJUQoeSRuxH0KmkVrDfA//LRlaPPM32zqqE6F6n6', '2013-10-31 05:37:37', '2013-10-31 05:37:37'),
(102, 8, '$2a$08$0lyrD90cnfzKGExjisj/COviVXY3rlKeYbbwlnc0gxzrCKDwFQBom', '2013-10-31 05:40:28', '2013-10-31 05:40:28'),
(103, 8, '$2a$08$7OJHzgEXLhNOA760/qyjNuVfUKIHZbBSNE96cACvaythSarV82CJK', '2013-10-31 05:45:38', '2013-10-31 05:45:38'),
(104, 8, '$2a$08$zI8vqmGbc9CkCO61KyqQl.w3IAOWStAjq27ysVzX6BXszMSgtCL02', '2013-10-31 05:47:45', '2013-10-31 05:47:45'),
(105, 8, '$2a$08$sijGvlNe0AQsrRLxRjj1YOJAKset3uAcclELhYi3Rf7odj0YX1oM.', '2013-10-31 06:15:43', '2013-10-31 06:15:43'),
(106, 8, '$2a$08$cAYlzOF9gi5FM/cPTMoPyuSNrzqYEpPFfslZHnEeZPI43Qn7fqcfK', '2013-10-31 06:16:52', '2013-10-31 06:16:52'),
(107, 8, '$2a$08$yzYW1quG9RtWLWpbhLx37ONSjvRVWbFV7OVyhcV6qZ8Wj919uMGPC', '2013-10-31 06:17:58', '2013-10-31 06:17:58'),
(108, 8, '$2a$08$.g9iE7vR4Laj6B5V/66MiOOLhlvojZYNMjfskCEFGNCixV.He.GDO', '2013-10-31 06:19:13', '2013-10-31 06:19:13'),
(109, 8, '$2a$08$Fm1yrApOXAzQgnAkCAnDEe/63tMXta7VJWgQrn0D99LXrx73UHt/.', '2013-10-31 06:20:06', '2013-10-31 06:20:06'),
(110, 8, '$2a$08$BS1ofiIeex6MRUURd02/fegNr1s/1u4VTy9sldFnhVnJe98rPrOHm', '2013-10-31 06:22:08', '2013-10-31 06:22:08'),
(111, 8, '$2a$08$gSlzi1DurMC6nmjO5239w.14FxnmA0QAY9qHO84/kPNl5wy9IHfLq', '2013-10-31 06:23:38', '2013-10-31 06:23:38'),
(112, 8, '$2a$08$Zvno5uP2Hr89VO5HUXhaIetI7I3Y1a7wr2lMCig/8jfuyz/Dx.G6W', '2013-10-31 06:25:33', '2013-10-31 06:25:33'),
(113, 8, '$2a$08$PfmcearJ7uWZ0eaW7S86fOT2ojJ7PwwPL2QvqcV5WRX6jAyTPu.XK', '2013-10-31 06:27:32', '2013-10-31 06:27:32'),
(114, 8, '$2a$08$Qu1KqiPjjK6lc5a76O/mN.Xa4jlO1XAR5uZmCO4mvmxJEC6OFQlFu', '2013-10-31 06:29:31', '2013-10-31 06:29:31'),
(115, 8, '$2a$08$UozW9mjseAATf2VntBZUkeklTcPOHX4WGlDIzNESN6lTIdRL67nAq', '2013-10-31 06:30:27', '2013-10-31 06:30:27'),
(116, 8, '$2a$08$qaGm7SCKJScMBrCrzUTD3.QDgSS4Emv.1gigP2WCYAK2YA2eMeVZS', '2013-10-31 06:39:16', '2013-10-31 06:39:16'),
(117, 8, '$2a$08$942ud6p1RCbxoOZ9ov8h/.jlKR78vYVJoNVw1OKUSowA0bLdNw4lO', '2013-10-31 06:51:48', '2013-10-31 06:51:48'),
(118, 8, '$2a$08$1fFCcRTedPQfuAlcGDGqCOmMu0SEWH.hNOHGAqKLhINT3M84cIcV6', '2013-10-31 06:52:50', '2013-10-31 06:52:50'),
(119, 8, '$2a$08$YITc0dfLbenvD7UXG4smluLpVuzX8nxS3DWwT5AKHNUFq3o9peqOW', '2013-10-31 06:54:21', '2013-10-31 06:54:21'),
(120, 8, '$2a$08$XjzY.usnay.rYTVioW32QeVHTtZVenkzavi0crCj6qCJc.JL/41UW', '2013-10-31 06:57:10', '2013-10-31 06:57:10'),
(121, 8, '$2a$08$T6/5EA5uYT.pdxVLUxmzv.u4y1IvECdw90578l/BNjSiaV88.aM4W', '2013-10-31 06:58:18', '2013-10-31 06:58:18'),
(122, 8, '$2a$08$yDxt1fBQ3vTt6LaZDgW5jeCuHRC5YN0HtSsBWFTdCnCXiLo4fXwRe', '2013-10-31 07:00:01', '2013-10-31 07:00:01'),
(123, 8, '$2a$08$gpox2GiVFAvLFafTLXTACuBVicT.uH8q7N65OADvToM8F8658wKla', '2013-10-31 07:01:15', '2013-10-31 07:01:15'),
(124, 8, '$2a$08$s5ipu2PSFq.FZn6Tn0vSZ.oqdE9hhiQaWLADh3YxvECm1DIqizDhG', '2013-10-31 07:02:17', '2013-10-31 07:02:17'),
(125, 8, '$2a$08$HlaVUBEz2D17jVFX1bKce.k/A0rGa8N3nZTjOL7YvTCVkCmQ/EDHi', '2013-10-31 07:03:06', '2013-10-31 07:03:06'),
(126, 8, '$2a$08$EW3/QwowwZOhszxsQ7wg7.Uc9X3XpS4QUBF5IQqcqZRxaSabQdQ8i', '2013-10-31 07:03:43', '2013-10-31 07:03:43'),
(127, 8, '$2a$08$r5HIpME99ZaQJyIqg5fssuPyQGIJ1LyTu54nSW23eshytSroFOSB6', '2013-10-31 07:05:37', '2013-10-31 07:05:37'),
(128, 8, '$2a$08$FtQe/aCEEFgCdfjBkzCnAuO6uhDKiVLTMlOlo53TGF7oBGvaTQzdK', '2013-10-31 07:06:22', '2013-10-31 07:06:22'),
(129, 8, '$2a$08$vMhTsxkmhdbKkXFtlTpctuNHARVnPwCFnjkr9a.aa0/7nxGlPM/QS', '2013-10-31 07:42:15', '2013-10-31 07:42:15'),
(130, 8, '$2a$08$5JaR3kLL8JuR/uSRnig1hO4LqkzYofvDY/W6M4uz30PiGzKVtGnLi', '2013-10-31 07:44:34', '2013-10-31 07:44:34'),
(131, 8, '$2a$08$IynNMJWou7sN66FBw3x5S.lhK4FbsAmSCH3TbZOoPH5dPly69xkou', '2013-10-31 08:00:26', '2013-10-31 08:00:26'),
(132, 8, '$2a$08$ByJ2WK73VxHS5Wucm7JNzOswnr3096Rxzl/5mSEOeqS2wXhQwETeu', '2013-10-31 08:11:39', '2013-10-31 08:11:39'),
(133, 8, '$2a$08$amdB6vDFWYxOjb4wumSvZOo.7rBwsutlOEpcpjeA/4PNzyQiWX5oy', '2013-10-31 08:13:09', '2013-10-31 08:13:09'),
(134, 8, '$2a$08$.71RwhSKIr2gzEJ.xPGoCutuZ.toPCtANx6KjryWn88l8Ja8VUsli', '2013-10-31 08:19:28', '2013-10-31 08:19:28'),
(135, 8, '$2a$08$oFtQ7G4o/y0bC0ZJyaeLtONuckz6Y528EXLV.0CJ2xiEzqszWchsS', '2013-10-31 08:49:39', '2013-10-31 08:49:39'),
(136, 8, '$2a$08$Isfb1qMGOUhjUg/6PYTCz.CzkrwEsNiTGD8mlKzTBfzzruXdKJR5O', '2013-10-31 08:51:42', '2013-10-31 08:51:42'),
(137, 8, '$2a$08$roGh2B.GDh4GbkOQIeLvse1WMDyN7jY5hF0Y/IrlAJy3OsSmw9eWG', '2013-10-31 09:20:30', '2013-10-31 09:20:30'),
(138, 8, '$2a$08$ETQW6RtlCRQjpDKOata9.ueyrohwbxIwfdKDIcyrG7j6KROXJXqwq', '2013-10-31 09:23:07', '2013-10-31 09:23:07'),
(139, 8, '$2a$08$TrlXZnpBXExWq6EjL3rofeJkXx.NWKsb7T0SPN/jhNXWIx/6I6Bgi', '2013-10-31 09:43:57', '2013-10-31 09:43:57'),
(140, 8, '$2a$08$urSwCTh.cXuJyRxAns6RCuwvX.GrZ/wLYthXTgIPNx9et/.0Nl04C', '2013-10-31 09:47:46', '2013-10-31 09:47:46'),
(141, 8, '$2a$08$3dF85r/KizWx9WKH6RV/pu/2zp3oXNR8GXNNw/jde2DfIau4OXzLi', '2013-10-31 09:49:26', '2013-10-31 09:49:26'),
(142, 8, '$2a$08$uo64//kVbI.kshM5vJB4i.RUkTP7kTuQ1r6bi6JGpoDSMExtce5PG', '2013-10-31 09:52:29', '2013-10-31 09:52:29'),
(143, 8, '$2a$08$8emskA7Xfz9NA7G0CT0hneQ5BVnamKdsDqNIKp4AgAyoMYeyP2PDK', '2013-10-31 09:56:50', '2013-10-31 09:56:50'),
(144, 8, '$2a$08$vWRJCj0QUlNL4V8NfImpZeSLiSJX0jIaeMb0Pj10KnEhUxyFV5VpW', '2013-10-31 09:59:51', '2013-10-31 09:59:51'),
(145, 8, '$2a$08$pFhZmf9.S.90kAqoSRQhM.zH2ynpHDLRSB/mHvz3hFd8GtHOafR1q', '2013-10-31 10:01:48', '2013-10-31 10:01:48'),
(146, 8, '$2a$08$9pvD1LvpbnREgSPvpNcCA.1gjrA13kx8LmclQ8FeGf65zSUqTiOUy', '2013-10-31 10:02:36', '2013-10-31 10:02:36'),
(147, 8, '$2a$08$eFvlnrqmYQJ0kvxINJSVQe88sH7RV.TPrP19iguAPjXiRyV0P6.vS', '2013-10-31 10:02:49', '2013-10-31 10:02:49'),
(148, 8, '$2a$08$3dOYFAdxb4OMffRp5irIme6c/VYxCL7ZD48kVUEy4IXuOwXqNCAi2', '2013-10-31 10:02:51', '2013-10-31 10:02:51'),
(149, 8, '$2a$08$7zcYFfmfdiGbCBEuXAflieRNH4BSJZHwES7YREuc.RbWJEHxkNVFC', '2013-10-31 10:03:33', '2013-10-31 10:03:33'),
(150, 8, '$2a$08$8Wqg8ZdgcSnhMDlDg.LolOW6r3iYXHZtYndfUXvzPodu/9GJ0xWsa', '2013-10-31 10:04:15', '2013-10-31 10:04:15'),
(151, 8, '$2a$08$lXUc2dlg6hqOBHV/Rc89iODvgm31CKRGJQ.xdR2dc32sv7QBw9KH.', '2013-10-31 10:05:48', '2013-10-31 10:05:48'),
(152, 8, '$2a$08$pKm.v5pJVVzqs3.xrw08ouENfgwMLZow.rhQg8lbiRuHZgvQmFTHK', '2013-10-31 10:05:50', '2013-10-31 10:05:50'),
(153, 8, '$2a$08$/rWWpl9KX14dhDX3cE1cMuNyDAmYYJm9ugg2RmsL4yRgKHYgGy7y6', '2013-10-31 10:05:53', '2013-10-31 10:05:53'),
(154, 8, '$2a$08$cTWIg65//26ki9WyK1JXYurUSt173t3b2Ci5C1KhShENN71mJXAJW', '2013-10-31 10:08:45', '2013-10-31 10:08:45'),
(155, 8, '$2a$08$l2G4G37ERJBP2411lKxZRuSanhJ2AIF3oJ1vytKofRxyMzvooEYQK', '2013-10-31 10:28:01', '2013-10-31 10:28:01'),
(156, 8, '$2a$08$hnsWgLXefxh5vpTc5k1nduMzs0CwA8uaBudDcT7yef37sveG607F.', '2013-10-31 11:39:44', '2013-10-31 11:39:44'),
(157, 8, '$2a$08$lHOE0Qr92uFW9jtKlM.dD.HPFuS3Cpd8UpN8pmT9M4PRXmVMjmO4C', '2013-10-31 12:01:42', '2013-10-31 12:01:42'),
(158, 2, '$2a$08$9.2j7TSS.VjjbSpQpLmwju.N2moEiQNnG4M5OXayegaeJiyy/WCFW', '2013-10-31 12:08:52', '2013-10-31 12:08:52'),
(159, 11, '$2a$08$bZHtX6g5J1hR/Tj5GG/i4u0zuw62q3thlhjkbD8zo7ahmjaAeD/EC', '2013-10-31 12:11:02', '2013-10-31 12:11:02'),
(160, 11, '$2a$08$gLvR9ub/1Vc9JVoK42xGS.EJWwWD1aGFwaLKpPlzA9dPq8.NaUcJy', '2013-10-31 12:39:50', '2013-10-31 12:39:50'),
(161, 11, '$2a$08$k5KKUlnL0NyA9O4naR796eZt2KBrriQu5ONnSstr7iMBI9qlSxXgy', '2013-10-31 12:41:29', '2013-10-31 12:41:29'),
(162, 11, '$2a$08$LWnW1VMM8.SOJAtphSNO5uqijqCK2qpVZZBoPWbuab8ngtPy7pNzS', '2013-10-31 12:41:33', '2013-10-31 12:41:33'),
(163, 11, '$2a$08$pRe/M.vab6qUfJZSNOhYEef3UFM8VGzfJrYtgC0X0VLEYsc4l4U4e', '2013-10-31 12:41:44', '2013-10-31 12:41:44'),
(164, 11, '$2a$08$7clPwVV8C/D31Ziu9pd6N.ushfoUYOkI0dqsjzdnA46cSTakHz4mS', '2013-10-31 12:42:27', '2013-10-31 12:42:27'),
(165, 11, '$2a$08$CrVJIrZmtAJ6jHH609BOiOUCr6LQXMhklVT7SssVlLov.BH9asePi', '2013-10-31 12:42:58', '2013-10-31 12:42:58'),
(166, 11, '$2a$08$hZoOpKU83guRXJ3qpK.MqO0luBpJm/.3kKovcnlN4hlo1oNJdUy.S', '2013-10-31 12:45:49', '2013-10-31 12:45:49'),
(167, 11, '$2a$08$to5BbwQV/buc.zyYTSHctOsJn56PxCdeMVF5jVQj9HYg8iL9FPHmi', '2013-10-31 12:54:52', '2013-10-31 12:54:52'),
(168, 11, '$2a$08$qbrFV7iC6ukQwxWqP06VHOg/j/8EYfI93RimKIb3Oe7ogEZKziqH.', '2013-10-31 13:02:22', '2013-10-31 13:02:22'),
(169, 11, '$2a$08$bBOzIHgazHKb1cPii.ABMO2J6yftbOzaOVcPh630oCswAlOHkrSOG', '2013-10-31 13:04:39', '2013-10-31 13:04:39'),
(170, 11, '$2a$08$HW/LTXAnWQalWmBew9Ba.OKDRZjyU0UhTlwwhb2HO3FPkrmhxFMxy', '2013-10-31 13:21:37', '2013-10-31 13:21:37'),
(171, 8, '$2a$08$CCfpPguMri7Ls5AIEh1IgucYFu7RouNBE.aSbtPWEpF0yzTWarK5O', '2013-10-31 13:26:39', '2013-10-31 13:26:39'),
(172, 8, '$2a$08$mRAYr7kWF4AoNd.KCUckcOUM8KD8lgmoeQmzPYkb/YC72w/XqWX92', '2013-10-31 22:43:30', '2013-10-31 22:43:30'),
(173, 8, '$2a$08$Q9XMTDWhmdIWYmu8dVlJlOnkU0vUNZWCCbH10yhsGpddz/4sb..bW', '2013-11-01 00:32:52', '2013-11-01 00:32:52'),
(174, 8, '$2a$08$zbvSw8wXHCNVKrD6JvtpZOej85HaEgcRZ9bkn/cnLXmxwIBbh9tE6', '2013-11-01 02:01:13', '2013-11-01 02:01:13'),
(175, 8, '$2a$08$/UZ32T3x6SXlbbQwXspVUOhBW0k5UfXKJo7ZQyn9aUPrvZjbKelR2', '2013-11-01 02:02:16', '2013-11-01 02:02:16'),
(176, 8, '$2a$08$EnUQHiXr2wOeYJuuWM0wRecHioiaYMammfLXDeyXJxq3ek.0iLmQa', '2013-11-01 02:03:19', '2013-11-01 02:03:19'),
(177, 8, '$2a$08$UpIWvTxK3Plk2fYMq/NDPuldW/slSFKwYziimBGZS.r6v4I26iVVW', '2013-11-01 02:05:20', '2013-11-01 02:05:20'),
(178, 8, '$2a$08$fc5aPeZYWzXXq9j7WPvLMuea/.0OGK2zNbn6o0FA6k0i.0s3kA2Fy', '2013-11-01 02:06:51', '2013-11-01 02:06:51'),
(179, 8, '$2a$08$.OBc0w75IUOpnidT0yr24O3oq7XuSMiIrP4QS8OjhH8Uf35kSUd0u', '2013-11-01 02:09:25', '2013-11-01 02:09:25'),
(180, 8, '$2a$08$BCCbjlD5fkGIOsf6itBMBeZijM.AYVCO1ruN1LIf5J3mdeBcC756W', '2013-11-01 02:10:33', '2013-11-01 02:10:33'),
(181, 8, '$2a$08$zCCdbOvhehyRgtRte1bbUezbI4XnW12keFfvwu6w/E5bss67mxjD2', '2013-11-01 02:14:36', '2013-11-01 02:14:36'),
(182, 8, '$2a$08$5wKPJQ.9Sc5Fp72DYdhzM.AHBKDeeY9fjIUnjYdtrDOBBgQnc1fXe', '2013-11-01 02:42:56', '2013-11-01 02:42:56'),
(183, 8, '$2a$08$nErCTjcJneM9BMdewmmP2.ubLIO9S7P0qCdq4ZvBGh0t8LDH0pTMK', '2013-11-01 03:00:17', '2013-11-01 03:00:17'),
(184, 8, '$2a$08$Tng7EBNI/lUE/rpB5pvFwe0WgJaroyZKu7HoDYoeir18bkndHWt96', '2013-11-01 04:53:22', '2013-11-01 04:53:22'),
(185, 11, '$2a$08$unHz076WVSyuGCBVQL7FTOX8cDYtb1IUbzA8jSXvKHnTuxediUtGa', '2013-11-01 05:19:05', '2013-11-01 05:19:05'),
(186, 11, '$2a$08$x57ftWICe.qX9rA9r/QDyeMitMtZWANzCl/VURBLGs/FNql/2.snq', '2013-11-01 05:24:58', '2013-11-01 05:24:58'),
(187, 11, '$2a$08$7.cCmG1.7UesKsHYnizkd.F8doTMGSipSY5/vMjrvgXAynxQvX6TS', '2013-11-01 05:30:39', '2013-11-01 05:30:39'),
(188, 8, '$2a$08$MbpDq0ZfyQgSb73DicJq1ue9Vl748LsqC3lWwO7MatiH8MEm83KdC', '2013-11-01 07:07:36', '2013-11-01 07:07:36'),
(189, 10, '$2a$08$rci9qY4/zd6WSGVOTGSKUeOnY8EAZOMDRhAOnA34xF6eT5S3GNGjO', '2013-11-01 08:09:49', '2013-11-01 08:09:49'),
(190, 10, '$2a$08$paN6AAV.hKIfTqYG9wmyB.KmyKJkEfHwwM0v4UWfdBmf7wpcwZ/UC', '2013-11-01 08:10:40', '2013-11-01 08:10:40'),
(191, 10, '$2a$08$HxRZqjA1MnAIPT3tgSaQGeDi0ktNRTNhOKfjHR2WFLRp7062ccptK', '2013-11-01 08:26:30', '2013-11-01 08:26:30'),
(192, 10, '$2a$08$VmFqQD8lwBRCmZ9jUiipcekUXUxY/hArAXjL8RxvGfUayiwK3.zam', '2013-11-01 08:29:36', '2013-11-01 08:29:36'),
(193, 10, '$2a$08$G41A5LLfx6xGzMYMxW2KJ.ekaoUFWXaTTzDCOs97s0O/P4qaYcso6', '2013-11-01 08:30:31', '2013-11-01 08:30:31'),
(194, 10, '$2a$08$x8RQs12e6b0oZrnAULE22erHLw.VVej7HD590pM2.SwowY6T0HC0i', '2013-11-01 11:43:09', '2013-11-01 11:43:09'),
(195, 10, '$2a$08$FsTwOa94//RrgKaA5JXCNe1pvkcqqYjSQnw1D32Zj7m/Fm7lZwedy', '2013-11-01 11:48:49', '2013-11-01 11:48:49'),
(196, 10, '$2a$08$jReKxXpNHnk5K7p/i.0Wc.MHsYsljhjljm6cNxf8GQZ1QDvqW8WqK', '2013-11-01 11:50:25', '2013-11-01 11:50:25'),
(197, 6, '$2a$08$2v5WAHe/976oy.pU3VHkfeks96FmwAm1IW/vSIRo4RCuVEH1chTRm', '2013-11-01 12:58:50', '2013-11-01 12:58:50'),
(198, 6, '$2a$08$5IfnQ29uE5xI5HloMfgNQ.GLMwBBMZwID3x9LFwB.Sy3cb39uAlBW', '2013-11-01 12:59:01', '2013-11-01 12:59:01'),
(199, 6, '$2a$08$oJ08QS.XoIEBHT.bKgomA.6KFHg0rax4UbgK.9wHsu1YHw4Rcsxsy', '2013-11-01 13:01:15', '2013-11-01 13:01:15'),
(200, 6, '$2a$08$Gd6UF/Zp6yz6ASpSvsIOu.kjK9k/5Ax4lnGn/q.dTtdY1dT9gAvsS', '2013-11-01 13:01:43', '2013-11-01 13:01:43'),
(201, 6, '$2a$08$xsOb6W48B2Bt.7CB4b0izuVLCnQ76.20Rtgw0EUYCb5wUjRGnDAhe', '2013-11-01 13:02:23', '2013-11-01 13:02:23');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipodepieza`
--

CREATE TABLE IF NOT EXISTS `tipodepieza` (
  `ID_TIPO_PIEZA` int(11) NOT NULL AUTO_INCREMENT,
  `NOMBRE_CIENTIFICO_PIEZA` varchar(100) DEFAULT NULL,
  `DESCRIPCION` text,
  PRIMARY KEY (`ID_TIPO_PIEZA`)
) ENGINE=MyISAM  DEFAULT CHARSET=utf8 AUTO_INCREMENT=33 ;

--
-- Volcar la base de datos para la tabla `tipodepieza`
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
(2, 2, '1991-12-12', 'extraccion', '1991-12-12', 100000),
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
-- Estructura de tabla para la tabla `version`
--

CREATE TABLE IF NOT EXISTS `version` (
  `ID_VERSION` int(11) NOT NULL,
  `NOM_VERSION` varchar(50) DEFAULT NULL,
  `COMENTARIO_VERSION` text,
  PRIMARY KEY (`ID_VERSION`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Volcar la base de datos para la tabla `version`
--

INSERT INTO `version` (`ID_VERSION`, `NOM_VERSION`, `COMENTARIO_VERSION`) VALUES
(1, 'SFH - Sistema de toma de horas y fichas medicas v ', '\r\nSFH - Primera versión de desarrollo.');
