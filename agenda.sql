-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 08-09-2026 a las 04:45:32
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `agenda`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contactos`
--

CREATE TABLE `contactos` (
  `DNI` varchar(20) NOT NULL,
  `Apellido` varchar(100) NOT NULL,
  `Nombres` varchar(100) NOT NULL,
  `Calle` varchar(150) DEFAULT NULL,
  `Depto` varchar(20) DEFAULT NULL,
  `Piso` varchar(20) DEFAULT NULL,
  `Ciudad` varchar(100) DEFAULT NULL,
  `Telefono` varchar(30) DEFAULT NULL,
  `Email` varchar(150) DEFAULT NULL,
  `CUIL_CUIT` varchar(20) DEFAULT NULL,
  `FechaAlta` date DEFAULT NULL,
  `EstadoCivil` varchar(50) DEFAULT NULL,
  `Nacionalidad` varchar(50) DEFAULT NULL,
  `Provincia` varchar(100) DEFAULT NULL,
  `CodigoPostal` varchar(20) DEFAULT NULL,
  `Barrio` varchar(100) DEFAULT NULL,
  `TelefonoAlternativo` varchar(30) DEFAULT NULL,
  `Instagram` varchar(100) DEFAULT NULL,
  `ProfesionOcupacion` varchar(100) DEFAULT NULL,
  `EmpresaLugarTrabajo` varchar(150) DEFAULT NULL,
  `NivelEstudios` varchar(100) DEFAULT NULL,
  `Estado` varchar(20) DEFAULT NULL,
  `MetodoPagoPreferido` varchar(50) DEFAULT NULL,
  `Observaciones` text DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cuentacte`
--

CREATE TABLE `cuentacte` (
  `Id` int(11) NOT NULL,
  `PersonaId` varchar(20) NOT NULL,
  `FechaApertura` date DEFAULT NULL,
  `LimiteCredito` decimal(10,2) DEFAULT NULL,
  `EstadoCredito` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `contactos`
--
ALTER TABLE `contactos`
  ADD PRIMARY KEY (`DNI`);

--
-- Indices de la tabla `cuentacte`
--
ALTER TABLE `cuentacte`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `PersonaId` (`PersonaId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `cuentacte`
--
ALTER TABLE `cuentacte`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cuentacte`
--
ALTER TABLE `cuentacte`
  ADD CONSTRAINT `cuentacte_ibfk_1` FOREIGN KEY (`PersonaId`) REFERENCES `contactos` (`DNI`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
