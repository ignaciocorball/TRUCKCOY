-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 29, 2021 at 12:25 PM
-- Server version: 10.4.20-MariaDB
-- PHP Version: 7.3.29

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `truckcoy`
--

-- --------------------------------------------------------

--
-- Table structure for table `drivers`
--

CREATE TABLE `drivers` (
  `id` int(255) NOT NULL,
  `name` varchar(125) NOT NULL,
  `phone` int(15) NOT NULL,
  `imei` varchar(255) NOT NULL,
  `patente` varchar(10) NOT NULL,
  `status` varchar(20) NOT NULL,
  `company` varchar(255) NOT NULL,
  `regdate` datetime NOT NULL,
  `lastaccess` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `lat_src` double NOT NULL,
  `lng_src` double NOT NULL,
  `alt_src` int(5) NOT NULL,
  `degrees_src` float NOT NULL,
  `city` varchar(255) NOT NULL,
  `img` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `drivers`
--

INSERT INTO `drivers` (`id`, `name`, `phone`, `imei`, `patente`, `status`, `company`, `regdate`, `lastaccess`, `lat_src`, `lng_src`, `alt_src`, `degrees_src`, `city`, `img`) VALUES
(1, 'Marcus Dantus', 985993550, '447704378330136', '41 AX 17', 'Offline', 'TRUCKCOY', '2021-11-11 12:21:15', '2021-11-28 00:34:39', -45.585821, -72.040001, 0, 333, 'Coyhaique', '1.jpg'),
(2, 'Andrea Gallardo', 980194472, '538875575823139', '41 AX 16', 'Eliminado', 'TRUCKCOY', '2021-11-11 12:22:22', '2021-11-15 09:33:36', 0, 0, 0, 0, 'Coyhaique', 'default-profile.jpg'),
(3, 'Roque Mansilla', 990720081, '504824396950937', '41 AX 15', 'Offline', 'TRUCKCOY', '2021-11-11 12:23:35', '2021-11-27 21:47:22', -45.581623, -72.037061, 0, 222, 'Coyhaique', 'default-profile.jpg'),
(4, 'Eliseo Castillo', 950707063, '334923033491242', '41 AX 14', 'Online', 'TRUCKCOY', '2021-11-11 12:24:46', '2021-11-27 21:46:59', -45.583152, -72.042169, 0, 130, 'Coyhaique', 'default-profile.jpg'),
(5, 'Celeste Valotta', 937868039, '524727556237688', '41 AX 13', 'Online', 'TRUCKCOY', '2021-11-11 12:25:44', '2021-11-27 21:46:59', -45.574468, -72.067079, 0, 270, 'Coyhaique', 'default-profile.jpg'),
(6, 'Victoria Ignacia', 979831844, '862206546339128', '41 AX 12', 'Online', 'TRUCKCOY', '2021-11-11 12:26:12', '2021-11-27 21:46:59', -45.578592, -72.061241, 0, 265, 'Coyhaique', '6.jpg'),
(7, 'Ana Victoria', 908738306, '454652323602382', '41 AX 11', 'Online', 'TRUCKCOY', '2021-11-11 12:27:16', '2021-11-27 21:46:59', -45.580344, -72.067476, 0, 356, 'Coyhaique', '7.jpg'),
(8, 'René Lopez', 914748364, '493139079057170', '41 AX 10', 'Online', 'TRUCKCOY', '2021-11-11 12:28:32', '2021-11-28 04:13:41', -45.5835996, -72.0663091, 0, 210, 'Coyhaique', 'default-profile.jpg'),
(9, 'Carlos Bremer', 955392560, '534669703662319', '41 AX 09', 'Online', 'TRUCKCOY', '2021-11-11 12:29:10', '2021-11-27 21:46:59', -45.5803836, -72.0739052, 0, 16, 'Coyhaique', '9.jpg'),
(10, 'Arturo Ayub', 949556784, '304531146636656', '41 AX 08', 'Online', 'TRUCKCOY', '2021-11-11 12:30:12', '2021-11-27 21:46:59', -45.5711389, -72.0760579, 0, 274, 'Coyhaique', '10.jpg'),
(11, 'Rodrigo Herrera', 944899250, '441110622812273', '41 AX 07', 'Online', 'TRUCKCOY', '2021-11-11 12:31:22', '2021-11-28 00:34:03', -45.572869, -72.064439, 0, 222, 'Coyhaique', '11.jpg'),
(12, 'Elon Musk', 985993550, '447704378330136', '41 AX 06', 'Online', 'TRUCKCOY', '2021-11-11 12:35:41', '2021-11-28 00:31:26', -45.584106, -72.046761, 0, 170, 'Coyhaique', '1.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `routes`
--

CREATE TABLE `routes` (
  `id` int(11) NOT NULL,
  `name` varchar(40) NOT NULL,
  `destination_address` varchar(500) NOT NULL,
  `source_address` varchar(500) NOT NULL,
  `city` varchar(255) NOT NULL,
  `patente` varchar(8) NOT NULL,
  `phone` int(9) NOT NULL,
  `lat_src` double NOT NULL,
  `lng_src` double NOT NULL,
  `deg_src` float NOT NULL,
  `lat_dest` double NOT NULL,
  `lng_dest` double NOT NULL,
  `order_income` datetime DEFAULT NULL,
  `order_finished` datetime DEFAULT NULL,
  `company` varchar(20) NOT NULL,
  `status` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `routes`
--

INSERT INTO `routes` (`id`, `name`, `destination_address`, `source_address`, `city`, `patente`, `phone`, `lat_src`, `lng_src`, `deg_src`, `lat_dest`, `lng_dest`, `order_income`, `order_finished`, `company`, `status`) VALUES
(1, 'Marcus Dantus', 'Almte. Barroso 731, Coyhaique, Aysén', 'Almte. Simpson 1988, Coyhaique, Aysén', 'Coyhaique', '41 AX 06', 981924433, -45.584106, -72.046761, 333, -45.574967, -72.057336, '2021-09-13 20:31:43', '2021-09-13 20:31:43', 'TRUCKCOY', 'Exitoso'),
(2, 'Rodrigo Herrera', 'Pdte. Errázuriz 1270-1244, Coyhaique, Aysén', 'Almte. Barroso 731, Coyhaique, Aysén', 'Coyhaique', '41 AX 07', 981924433, -45.572869, -72.064439, 144, -45.57805, -72.059106, '2021-09-13 20:29:45', '2021-09-13 20:29:45', 'TRUCKCOY', 'Cancelado'),
(3, 'Arturo Ayub', 'Lautaro 143, Coyhaique, Aysén', 'Las Tepas, Coyhaique, Aysén', 'Coyhaique', '41 AX 08', 981924433, -45.583947, -72.069075, 222, -45.574369, -72.075289, '2021-09-13 20:10:21', '2021-09-13 20:30:21', 'TRUCKCOY', 'Exitoso'),
(4, 'Carlos Bremer', 'Paraguay 1407, Coyhaique, Aysén', 'Alfonso Serrano 855, Coyhaique, Aysén', 'Coyhaique', '41 AX 09', 981924433, -45.582453, -72.058539, 130, -45.572711, -72.050483, '2021-09-13 20:31:06', '2021-09-13 20:31:06', 'TRUCKCOY', 'Exitoso'),
(5, 'Markus Lopez', 'Cerro Mackay 1498-1444, Coyhaique, Aysén', 'Manuel Rodríguez 239, Coyhaique, Aysén', 'Coyhaique', '41 AX 10', 981924433, -45.567369, -72.068142, 270, -45.585708, -72.057572, '2021-09-13 20:29:07', '2021-09-13 20:29:07', 'TRUCKCOY', 'Exitoso'),
(6, 'Ana Victoria', 'Manuel Rojas, Coyhaique, Aysén', 'Lautaro 2290, Coyhaique, Aysén', 'Coyhaique', '41 AX 11', 940497169, -45.582586, -72.048353, 265, -45.588797, -72.051042, '2021-09-16 21:54:21', '2021-09-16 21:54:21', 'TRUCKCOY', 'Exitoso'),
(7, 'Victoria Ignacia', 'Miraflores 14-10, Coyhaique, Aysén', 'Pdte. Carlos Ibáñez 101-211, Coyhaique, Aysén', 'Coyhaique', '41 AX 12', 940497169, -45.580494, -72.076669, 356, -45.567406, -72.071311, '2021-09-16 21:54:21', NULL, 'TRUCKCOY', 'En Tránsito'),
(8, 'Marcus Dantus', 'Abedules, Coyhaique, Aysén', 'Valle Simpson 21, Coyhaique, Aysén', 'Coyhaique', '41 AX 06', 981924433, -45.571333, -72.076006, 210, -45.575008, -72.038161, '2021-09-18 18:31:23', NULL, 'TRUCKCOY', 'En Tránsito'),
(9, 'Rodrigo Herrera', 'Arturo Aldunate 1798-1702, Coyhaique, Aysén', 'Los Nogales 1398-1302, Coyhaique, Aysén', 'Coyhaique', '41 AX 07', 981924433, -45.587403, -72.052322, 16, -45.585361, -72.066108, '2021-09-18 18:33:41', NULL, 'TRUCKCOY', 'En Tránsito'),
(10, 'Arturo Ayub', 'Alfonso Serrano 35, Coyhaique, Aysén', 'La Frontera 3488-3308, Coyhaique, Aysén', 'Coyhaique', '41 AX 08', 981924433, -45.573094, -72.052589, 274, -45.581567, -72.028356, '2021-09-18 18:35:24', NULL, 'TRUCKCOY', 'En Tránsito');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `username` varchar(255) NOT NULL,
  `pass` varchar(255) NOT NULL,
  `company` varchar(25) NOT NULL,
  `description` varchar(555) NOT NULL,
  `regdate` datetime NOT NULL,
  `lastaccess` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `rank` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `username`, `pass`, `company`, `description`, `regdate`, `lastaccess`, `rank`) VALUES
(1, 'Patagonia', '698d51a19d8a121ce581499d7b701668', 'TRUCKCOY', 'The best fleet management tracking system is TRUCKCOY ', '2021-10-31 02:04:30', '2021-11-27 21:29:00', 1);

-- --------------------------------------------------------

--
-- Table structure for table `vehicles`
--

CREATE TABLE `vehicles` (
  `id` int(11) NOT NULL,
  `name` varchar(10) NOT NULL,
  `ignition` tinyint(1) NOT NULL,
  `temp` int(4) NOT NULL,
  `kms_today` int(11) NOT NULL,
  `alerts` int(11) NOT NULL,
  `location` varchar(255) NOT NULL,
  `speed` int(11) NOT NULL,
  `trips` int(11) NOT NULL,
  `kms_total` int(11) NOT NULL,
  `lastupdate` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `company` varchar(20) NOT NULL,
  `driver` varchar(20) NOT NULL,
  `lat` double NOT NULL,
  `lng` double NOT NULL,
  `deg` float NOT NULL,
  `status` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vehicles`
--

INSERT INTO `vehicles` (`id`, `name`, `ignition`, `temp`, `kms_today`, `alerts`, `location`, `speed`, `trips`, `kms_total`, `lastupdate`, `company`, `driver`, `lat`, `lng`, `deg`, `status`) VALUES
(5, 'S52614', 1, 26, 278, 11, 'Las Lengas #1170, Coyhaique.', 75, 155, 11138, '2021-11-21 05:15:16', 'TRUCKCOY', 'Celeste Valotta', -45.574468, -72.067079, 270, 'Online'),
(6, 'S62461', 1, 28, 322, 1, 'Héctor Monreal #599, Coyhaique.', 65, 42, 652, '2021-11-21 05:15:16', 'TRUCKCOY', 'Victoria Ignacia', -45.578592, -72.061241, 265, 'Online'),
(7, 'S71868', 1, 32, 315, 5, 'Los Coigües #321. Compañía de Bomberos Coyhaique, Coyhaique.', 72, 102, 824, '2021-11-21 05:15:16', 'TRUCKCOY', 'Ana Victoria', -45.580344, -72.067476, 356, 'Online'),
(8, 'Z17152', 1, 29, 214, 1, 'Las Lumas #947, Coyhaique.', 32, 109, 6920, '2021-11-28 04:15:38', 'TRUCKCOY', 'René Lopez', -45.5835996, -72.0663091, 210, 'Online'),
(9, 'S92456', 1, 25, 111, 0, 'Avenida Ogana #1002, Coyhaique.', 49, 42, 595, '2021-11-21 05:15:16', 'TRUCKCOY', 'Carlos Bremer', -45.5803836, -72.0739052, 16, 'Online'),
(10, 'A4289', 1, 24, 242, 2, 'Universidad de Aysén - Campus Río Simpson, Coyhaique.', 66, 725, 9738, '2021-11-21 05:15:16', 'TRUCKCOY', 'Arturo Ayub', -45.5711389, -72.0760579, 274, 'Online'),
(11, 'A4280', 1, 25, 152, 0, 'Alejandro Gutiérrez #202, Coyhaique.', 72, 55, 2305, '2021-11-21 05:15:16', 'TRUCKCOY', 'Rodrigo Herrera', -45.575485, -72.05599, 222, 'Online'),
(12, 'A4992', 0, 22, 121, 1, 'Desconocida', 0, 242, 1609, '2021-11-21 07:07:09', 'TRUCKCOY', 'Elon Musk', 0, 0, 170, 'Offline'),
(1, 'S82814', 0, 25, 0, 25, 'Cerro Maca - Altas Cumbres #737, Coyhaique.', 55, 542, 12738, '2021-11-21 05:17:21', 'TRUCKCOY', 'Marcus Dantus', -45.585821, -72.040001, 333, 'Online'),
(2, 'S82243', 1, 28, 122, 12, 'Desconocida', 0, 0, 15738, '2021-11-22 22:18:36', 'TRUCKCOY', 'Andrea Gallardo', 0, 0, 0, 'Offline'),
(3, 'S45812', 1, 31, 256, 2, 'Río Ibáñez #324, Coyhaique.', 72, 462, 10348, '2021-11-21 05:18:44', 'TRUCKCOY', 'Roque Mansilla', -45.581623, -72.037061, 222, 'Online'),
(4, 'Z12244', 1, 22, 222, 12, 'Avenida Presidente Errázuriz #2321, Coyhaique.', 81, 325, 9738, '2021-11-21 05:18:44', 'TRUCKCOY', 'Eliseo Castillo', -45.583152, -72.042169, 130, 'Online');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `drivers`
--
ALTER TABLE `drivers`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `routes`
--
ALTER TABLE `routes`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `drivers`
--
ALTER TABLE `drivers`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `routes`
--
ALTER TABLE `routes`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
