-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 23, 2018 at 03:14 AM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eddie_harris`
--
CREATE DATABASE IF NOT EXISTS `eddie_harris` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `eddie_harris`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `name`) VALUES
(95, 'Jane Johnson'),
(96, 'Katie Jones'),
(97, 'Alice  Smith'),
(98, 'Krystal Lin'),
(99, 'Dwayne Johnson'),
(100, 'The Rock'),
(101, 'Welcome'),
(102, 'Welcome'),
(103, 'Shaun Alexander'),
(104, 'Cat'),
(128, 'Welcome'),
(129, 'Welcome'),
(130, 'Hello'),
(131, 'Welcome'),
(132, 'test Name'),
(133, 'Mr. Test name'),
(135, 'test Name'),
(136, 'ss'),
(137, 'Welcome'),
(138, 'Steve Smith'),
(139, 'Welcome'),
(140, 'Welcome'),
(141, 'Welcome'),
(143, 'Jimmy Stevens'),
(144, 'Welcome'),
(145, 'Jane Johnson'),
(146, 'The Rock'),
(147, 'Mr. X');

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `specialty` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `specialty`) VALUES
(2, 'Buzz Cut'),
(3, 'Women Long'),
(4, 'Women Short'),
(5, 'Men Long'),
(6, 'Men Short'),
(9, 'Color');

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`) VALUES
(2, 'Jimmy John'),
(46, 'Mr. Cutter'),
(47, 'Ed Scissorhands'),
(48, 'Mr. Cutter Jr.'),
(55, 'Eddie Harris');

-- --------------------------------------------------------

--
-- Table structure for table `stylists_clients`
--

CREATE TABLE `stylists_clients` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `client_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists_clients`
--

INSERT INTO `stylists_clients` (`id`, `stylist_id`, `client_id`) VALUES
(2, 2, 96),
(4, 2, 98),
(5, 2, 99),
(7, 46, 101),
(8, 47, 102),
(9, 46, 103),
(10, 2, 104),
(29, 2, 132),
(30, 46, 133),
(34, 48, 138),
(36, 48, 143),
(37, 55, 145),
(38, 55, 146),
(39, 55, 147);

-- --------------------------------------------------------

--
-- Table structure for table `stylists_specialties`
--

CREATE TABLE `stylists_specialties` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists_specialties`
--

INSERT INTO `stylists_specialties` (`id`, `stylist_id`, `specialty_id`) VALUES
(1, 1, 2),
(4, 2, 3),
(5, 2, 4),
(7, 46, 3),
(8, 46, 4),
(11, 47, 3),
(22, 50, 6),
(25, 51, 3),
(26, 51, 2),
(27, 48, 5),
(28, 48, 3),
(29, 55, 9),
(30, 55, 2),
(31, 55, 3),
(32, 55, 4),
(33, 55, 5),
(34, 55, 6),
(35, 47, 5);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists_clients`
--
ALTER TABLE `stylists_clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=148;

--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=56;

--
-- AUTO_INCREMENT for table `stylists_clients`
--
ALTER TABLE `stylists_clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=40;

--
-- AUTO_INCREMENT for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
